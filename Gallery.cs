using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using HW.Models;

namespace HW
{
    public partial class Gallery : Form
    {
        private GalleryData? galleryData;
        private int currentCategoryIndex = 0;
        private int currentItemIndex = 0;
        private int currentImageIndex = 0;
        private static readonly HttpClient httpClient = new HttpClient();

        public Gallery()
        {
            InitializeComponent();
            InitializeGallery();
        }

        private void InitializeGallery()
        {
            // Configure HttpClient with better headers to avoid blocking
            if (httpClient.DefaultRequestHeaders.UserAgent.Count == 0)
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent",
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
            }
            httpClient.Timeout = TimeSpan.FromSeconds(30);

            // Initialize combo boxes
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            // Set picture box properties
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // Wire up event handlers
            buttonLoad.Click += ButtonLoad_Click;
            buttonView.Click += ButtonView_Click;
            buttonPrev.Click += ButtonPrev_Click;
            buttonNext.Click += ButtonNext_Click;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;

            // Initialize UI state
            UpdateUI();
        }

        private async void ButtonLoad_Click(object sender, EventArgs e)
        {
            string filename = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(filename))
            {
                MessageBox.Show("Please enter a file name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await LoadGalleryAsync(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading gallery: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadGalleryAsync(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException($"File '{filename}' not found.");
            }

            string json = await File.ReadAllTextAsync(filename);
            galleryData = JsonConvert.DeserializeObject<GalleryData>(json);

            if (galleryData?.Gallery == null || !galleryData.Gallery.Any())
            {
                throw new InvalidOperationException("No gallery data found in the file.");
            }

            // Reset indices
            currentCategoryIndex = 0;
            currentItemIndex = 0;
            currentImageIndex = 0;

            // Populate category combo box
            PopulateCategoryComboBox();
            UpdateUI();
        }

        private void PopulateCategoryComboBox()
        {
            comboBox1.Items.Clear();
            if (galleryData?.Gallery != null)
            {
                foreach (var category in galleryData.Gallery)
                {
                    comboBox1.Items.Add(category.Title);
                }
                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
        }

        private void PopulateItemComboBox()
        {
            comboBox2.Items.Clear();
            if (galleryData?.Gallery != null && currentCategoryIndex < galleryData.Gallery.Count)
            {
                var category = galleryData.Gallery[currentCategoryIndex];
                if (category.Data != null)
                {
                    foreach (var item in category.Data)
                    {
                        comboBox2.Items.Add(item.Title);
                    }
                    if (comboBox2.Items.Count > 0)
                    {
                        comboBox2.SelectedIndex = 0;
                    }
                }
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                currentCategoryIndex = comboBox1.SelectedIndex;
                currentItemIndex = 0;
                currentImageIndex = 0;
                PopulateItemComboBox();
                UpdateUI();
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0)
            {
                currentItemIndex = comboBox2.SelectedIndex;
                currentImageIndex = 0;
                UpdateUI();
            }
        }

        private async void ButtonView_Click(object sender, EventArgs e)
        {
            await LoadCurrentImageAsync();
        }

        private void ButtonPrev_Click(object sender, EventArgs e)
        {
            if (GetCurrentUrls()?.Count > 0)
            {
                currentImageIndex = Math.Max(0, currentImageIndex - 1);
                UpdateUI();
                LoadCurrentImageAsync();
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            var urls = GetCurrentUrls();
            if (urls?.Count > 0)
            {
                currentImageIndex = Math.Min(urls.Count - 1, currentImageIndex + 1);
                UpdateUI();
                LoadCurrentImageAsync();
            }
        }

        private List<string>? GetCurrentUrls()
        {
            if (galleryData?.Gallery == null ||
                currentCategoryIndex >= galleryData.Gallery.Count ||
                galleryData.Gallery[currentCategoryIndex].Data == null ||
                currentItemIndex >= galleryData.Gallery[currentCategoryIndex].Data.Count)
            {
                return null;
            }

            return galleryData.Gallery[currentCategoryIndex].Data[currentItemIndex].Url;
        }

        private async Task LoadCurrentImageAsync()
        {
            var urls = GetCurrentUrls();
            if (urls == null || currentImageIndex >= urls.Count)
            {
                pictureBox1.Image = null;
                return;
            }

            string url = urls[currentImageIndex];
            if (string.IsNullOrWhiteSpace(url))
            {
                pictureBox1.Image = null;
                MessageBox.Show("Image URL is empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate URL format
            if (!Uri.TryCreate(url, UriKind.Absolute, out Uri? validUri) ||
                (validUri.Scheme != Uri.UriSchemeHttp && validUri.Scheme != Uri.UriSchemeHttps))
            {
                MessageBox.Show($"Invalid URL format: {url}", "URL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Image = null;
                return;
            }

            // Dispose previous image to free memory
            if (pictureBox1.Image != null)
            {
                var oldImage = pictureBox1.Image;
                pictureBox1.Image = null;
                oldImage.Dispose();
            }

            try
            {
                buttonView.Enabled = false;
                buttonView.Text = "Loading...";
                Application.DoEvents(); // Update UI immediately

                // First, try a HEAD request to check if the resource exists
                bool urlExists = await CheckUrlExistsAsync(url);
                if (!urlExists)
                {
                    MessageBox.Show($"Image not found (404 - Not Found).\n\nThe URL may be invalid or the image may have been removed.\n\nURL: {url}",
                        "Image Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    pictureBox1.Image = null;
                    return;
                }

                using (var response = await httpClient.GetAsync(url))
                {
                    response.EnsureSuccessStatusCode();

                    // Check if the content is actually an image
                    var contentType = response.Content.Headers.ContentType?.MediaType;
                    if (contentType != null && !contentType.StartsWith("image/"))
                    {
                        MessageBox.Show($"The URL does not point to an image.\n\nContent type: {contentType}\n\nURL: {url}",
                            "Invalid Content Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pictureBox1.Image = null;
                        return;
                    }

                    // Read content as byte array first to avoid stream disposal issues
                    byte[] imageData = await response.Content.ReadAsByteArrayAsync();

                    if (imageData.Length == 0)
                    {
                        MessageBox.Show("Downloaded image data is empty.", "Empty Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        pictureBox1.Image = null;
                        return;
                    }

                    using (var memoryStream = new MemoryStream(imageData))
                    {
                        // Create a copy of the image to avoid issues with the stream being disposed
                        var originalImage = Image.FromStream(memoryStream);
                        pictureBox1.Image = new Bitmap(originalImage);
                        originalImage.Dispose();
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                string errorMessage;
                if (httpEx.Message.Contains("404"))
                {
                    errorMessage = "Image not found (404). The URL may be invalid or the image may have been removed.";
                }
                else if (httpEx.Message.Contains("403"))
                {
                    errorMessage = "Access denied (403). The server is blocking access to this image.";
                }
                else if (httpEx.Message.Contains("timeout"))
                {
                    errorMessage = "Request timed out. Please check your internet connection and try again.";
                }
                else if (httpEx.Message.Contains("SSL") || httpEx.Message.Contains("certificate"))
                {
                    errorMessage = "SSL/Certificate error. The server's security certificate has issues.";
                }
                else
                {
                    errorMessage = $"Network error: {httpEx.Message}";
                }

                MessageBox.Show($"Failed to download image:\n{errorMessage}\n\nURL: {url}",
                    "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Image = null;
            }
            catch (TaskCanceledException tcEx) when (tcEx.InnerException is TimeoutException)
            {
                MessageBox.Show("Request timed out. Please check your internet connection and try again.",
                    "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                pictureBox1.Image = null;
            }
            catch (ArgumentException argEx)
            {
                MessageBox.Show($"Invalid image format: {argEx.Message}\n\nThe downloaded content is not a valid image.",
                    "Image Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Image = null;
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("Out of memory. The image may be too large to load.",
                    "Memory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Image = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error loading image: {ex.Message}\n\nURL: {url}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pictureBox1.Image = null;
            }
            finally
            {
                buttonView.Enabled = true;
                buttonView.Text = "View";
            }
        }

        private async Task<bool> CheckUrlExistsAsync(string url)
        {
            try
            {
                using (var request = new HttpRequestMessage(HttpMethod.Head, url))
                {
                    using (var response = await httpClient.SendAsync(request))
                    {
                        return response.IsSuccessStatusCode;
                    }
                }
            }
            catch
            {
                // If HEAD request fails, assume the URL doesn't exist
                return false;
            }
        }

        private void UpdateUI()
        {
            var urls = GetCurrentUrls();
            int totalImages = urls?.Count ?? 0;

            // Update page label
            if (totalImages > 0)
            {
                labelPage.Text = $"{currentImageIndex + 1}/{totalImages}";
            }
            else
            {
                labelPage.Text = "0/0";
            }

            // Update button states
            buttonPrev.Enabled = currentImageIndex > 0;
            buttonNext.Enabled = currentImageIndex < totalImages - 1;
            buttonView.Enabled = galleryData != null && !string.IsNullOrWhiteSpace(urls?.ElementAtOrDefault(currentImageIndex));

            // Update form title
            if (galleryData?.Metadata?.Name != null)
            {
                this.Text = galleryData.Metadata.Name;
            }
        }
    }
}

namespace HW.Models
{
    // Data models for JSON deserialization
    public class GalleryData
    {
        [JsonProperty("metadata")]
        public Metadata? Metadata { get; set; }

        [JsonProperty("gallery")]
        public List<Category>? Gallery { get; set; }
    }

    public class Metadata
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public class Category
    {
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("data")]
        public List<Item>? Data { get; set; }
    }

    public class Item
    {
        [JsonProperty("title")]
        public string Title { get; set; } = string.Empty;

        [JsonProperty("url")]
        public List<string> Url { get; set; } = new List<string>();
    }
}

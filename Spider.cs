using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.Net.Http;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace HW
{

    public partial class Spider : Form
    {
        public Spider()
        {
            InitializeComponent();

            httpClient = new HttpClient();
            // 设置更完整的User-Agent和请求头来避免403错误
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv: 11.0) like Gecko");

            // Initialize WebView2
            InitializeWebView();

            // Configure DataGridView
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.ReadOnly = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.GridColor = Color.LightGray;

            // 添加键盘事件
            this.KeyPreview = true;
            this.KeyDown += Spider_KeyDown;
            textBoxInput.KeyDown += TextBoxInput_KeyDown;

            labelStatus.Text = "状态：就绪";
            posts = new List<PostInfo>();
        }
        public class PostInfo
        {
            public string Title { get; set; } = "";
            public string Url { get; set; } = "";
            public string Author { get; set; } = "";
            public string CreateTime { get; set; } = "";
            public string LastReplyTime { get; set; } = "";
            public string LastReplyUser { get; set; } = "";
            public int ReplyCount { get; set; } = 0;
        };

        private readonly HttpClient httpClient;
        private List<PostInfo> posts;
        private string currentForumUrl = "";
        private bool isWebViewMode = false;
        private CancellationTokenSource? cancellationTokenSource;


        private async void InitializeWebView()
        {
            try
            {
                await webView.EnsureCoreWebView2Async();
                
                // 添加导航完成事件
                webView.CoreWebView2.NavigationCompleted += (sender, e) =>
                {
                    if (e.IsSuccess)
                    {
                        labelStatus.Text = "状态：帖子加载完成";
                    }
                    else
                    {
                        labelStatus.Text = "状态：帖子加载失败";
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"WebView2 初始化失败：{ex.Message}\n请确保已安装 WebView2 Runtime。",
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void ButtonStart_Click(object sender, EventArgs e)
        {
            string forumName = textBoxInput.Text.Trim();
            if (string.IsNullOrEmpty(forumName))
            {
                MessageBox.Show("请输入贴吧名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pages = (int)numericUpDown1.Value;
            
            // 如果正在爬取，则取消
            if (cancellationTokenSource != null && !cancellationTokenSource.Token.IsCancellationRequested)
            {
                cancellationTokenSource.Cancel();
                buttonStart.Text = "开始爬取";
                labelStatus.Text = "状态：已取消";
                return;
            }
            
            cancellationTokenSource = new CancellationTokenSource();
            buttonStart.Text = "取消爬取";
            progressBar1.Value = 0;
            progressBar1.Maximum = pages;
            dataGridView1.Rows.Clear();
            posts.Clear();

            try
            {
                labelStatus.Text = "状态：正在爬取...";
                currentForumUrl = $"https://tieba.baidu.com/f?kw={Uri.EscapeDataString(forumName)}";

                for (int i = 1; i <= pages; i++)
                {
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        labelStatus.Text = "状态：用户取消";
                        break;
                    }
                    
                    string pageUrl = i == 1 ? currentForumUrl : $"{currentForumUrl}&pn={(i - 1) * 50}";
                    await ScrapePage(pageUrl);
                    progressBar1.Value = i;
                    labelStatus.Text = $"状态：第 {i}/{pages} 页完成";
                    Application.DoEvents();
                    
                    await Task.Delay(Random.Shared.Next(1000, 3000), cancellationTokenSource.Token);
                }

                if (!cancellationTokenSource.Token.IsCancellationRequested)
                {
                    labelStatus.Text = $"状态：完成 - 共找到 {posts.Count} 个帖子";
                }
            }
            catch (OperationCanceledException)
            {
                labelStatus.Text = "状态：操作已取消";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelStatus.Text = "状态：发生错误";
            }
            finally
            {
                buttonStart.Text = "开始爬取";
                cancellationTokenSource?.Dispose();
                cancellationTokenSource = null;
            }
        }

        private async Task ScrapePage(string url)
        {
            try
            {
                string html = await httpClient.GetStringAsync(url);

                if (html == null)
                    throw new Exception("无法获取页面内容");

                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                // 查找帖子列表容器
                var threadNodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 'j_thread_list')]");
                
                if (threadNodes != null)
                {
                    foreach (var threadNode in threadNodes)
                    {
                        var postInfo = ExtractPostInfo(threadNode);
                        if (postInfo != null && !string.IsNullOrEmpty(postInfo.Title))
                        {
                            posts.Add(postInfo);
                            AddPostToGrid(postInfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"无法爬取页面 {url}：{ex.Message}");
            }
        }

        private PostInfo ExtractPostInfo(HtmlNode threadNode)
        {
            try
            {
                var postInfo = new PostInfo();

                // 提取标题和链接
                var titleNode = threadNode.SelectSingleNode(".//a[contains(@class, 'j_th_tit')]");
                // 提取作者
                var authorNode = threadNode.SelectSingleNode(".//span[contains(@class, 'tb_icon_author')]");
                // 提取回复数
                var replyNode = threadNode.SelectSingleNode(".//span[contains(@class, 'threadlist_rep_num')]");
                // 提取创建时间
                var createTimeNodes = threadNode.SelectSingleNode(".//span[contains(@class, 'is_show_create_time')]"); 
                // 提取回复时间
                var replyTimeNodes = threadNode.SelectSingleNode(".//span[contains(@class, 'threadlist_reply_date')]");
                // 提取最后回复
                var replyUser = threadNode.SelectSingleNode(".//span[contains(@class, 'tb_icon_author_rely')]");
                
                string title = titleNode.InnerText.Trim();
                string author = authorNode.Attributes["title"]?.Value.Replace("主题作者: ", "");
                string replyCount = replyNode?.InnerText.Trim() ?? "0";
                string href = "https://tieba.baidu.com" + titleNode.Attributes["href"]?.Value;
                string createTime = createTimeNodes?.InnerText.Trim() ?? "unknown";
                string lastReplyTime = replyTimeNodes?.InnerText.Trim() ?? "unknown";
                string lastReplyUser = replyUser?.Attributes["title"]?.Value.Replace("最后回复人: ", "") ?? "unknown";

                postInfo.Author = author ?? "未知";
                postInfo.Title = title;
                postInfo.Url = href;
                postInfo.ReplyCount = int.TryParse(replyCount, out int count) ? count : 0;
                postInfo.CreateTime = createTime;
                postInfo.LastReplyTime = lastReplyTime;
                postInfo.LastReplyUser = lastReplyUser;

                // 解析
                return postInfo;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void AddPostToGrid(PostInfo postInfo)
        {
            if (dataGridView1.InvokeRequired)
            {
                dataGridView1.Invoke(new Action(() => AddPostToGrid(postInfo)));
                return;
            }

            int rowIndex = dataGridView1.Rows.Add();
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            
            row.Cells["ColumnTitle"].Value = postInfo.Title;
            row.Cells["ColumnAuthor"].Value = postInfo.Author;
            row.Cells["ColumnReplyCount"].Value = postInfo.ReplyCount;
            row.Cells["ColumnCreateTime"].Value = postInfo.CreateTime;
            row.Cells["ColumnLastReplyTime"].Value = postInfo.LastReplyTime;
            row.Cells["ColumnView"].Value = "查看";
            
            // 存储URL到Tag中，供点击事件使用
            row.Tag = postInfo.Url;
        }

        private async void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 检查是否点击了"查看"按钮列
            if (e.ColumnIndex == dataGridView1.Columns["ColumnView"].Index && e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                string url = row.Tag?.ToString();
                
                if (!string.IsNullOrEmpty(url))
                {
                    await ShowPostInWebView(url);
                }
            }
        }

        private async Task ShowPostInWebView(string url)
        {
            try
            {
                // 切换到WebView模式
                if (!isWebViewMode)
                {
                    dataGridView1.Visible = false;
                    webView.Visible = true;
                    isWebViewMode = true;
                    
                    // 添加一个返回按钮（简单的实现）
                    this.Text = "百度贴吧爬虫 - 查看帖子 (双击返回列表)";
                }

                labelStatus.Text = "状态：正在加载帖子...";
                
                // 导航到帖子页面
                webView.CoreWebView2.Navigate(url);
                
                labelStatus.Text = "状态：帖子已加载";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"加载帖子时出错：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelStatus.Text = "状态：加载帖子出错";
            }
        }

        private void WebView_DoubleClick(object sender, EventArgs e)
        {
            // 返回到列表视图
            webView.Visible = false;
            dataGridView1.Visible = true;
            isWebViewMode = false;
            this.Text = "百度贴吧爬虫";
            labelStatus.Text = "状态：返回列表";
        }

        private void TextBoxInput_KeyDown(object sender, KeyEventArgs e)
        {
            // 按回车键开始爬取
            if (e.KeyCode == Keys.Enter && buttonStart.Enabled)
            {
                ButtonStart_Click(sender, e);
            }
        }

        private void Spider_KeyDown(object sender, KeyEventArgs e)
        {
            // ESC键返回列表视图
            if (e.KeyCode == Keys.Escape && isWebViewMode)
            {
                WebView_DoubleClick(sender, e);
            }
            // F5刷新当前视图
            else if (e.KeyCode == Keys.F5)
            {
                if (isWebViewMode && webView.CoreWebView2 != null)
                {
                    webView.CoreWebView2.Reload();
                    labelStatus.Text = "状态：正在刷新...";
                }
            }
        }

    }
}

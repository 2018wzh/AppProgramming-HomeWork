using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW
{
    public partial class Selector : Form
    {
        public Selector()
        {
            InitializeComponent();
            listBox.DataSource = items;
        }
        List<string> items = new List<string>
        {
            "Quiz",
            "Gallery",
            "Spider"
        };
        private int currentIndex = 0;
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentIndex = listBox.SelectedIndex;
        }
        private void buttonLaunch_Click(object sender, EventArgs e)
        {

            switch (currentIndex)
            {
                case 0:
                    this.Hide();
                    var quiz = new QuizApp();
                    quiz.ShowDialog();
                    break;
                case 1:
                    this.Hide();
                    var gallery = new Gallery();
                    gallery.ShowDialog();
                    break;
                case 2:
                    this.Hide();
                    var spider = new Spider();
                    spider.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Please select a valid option.");
                    break;
            }
            this.Close();
        }
    }
}

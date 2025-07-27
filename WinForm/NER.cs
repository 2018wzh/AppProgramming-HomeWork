using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using JiebaNet.Segmenter;
using System.Collections.Generic;
using System.Linq;

namespace HW
{
    public partial class NER : Form
    {
        private JiebaSegmenter segmenter = new JiebaSegmenter();

        public NER()
        {
            InitializeComponent();
            InitializeJieba();
            InitializeEventHandlers();
        }

        private void InitializeJieba()
        {
            // 初始化jieba分词器
        }

        private void InitializeEventHandlers()
        {
            buttonClear.Click += ButtonClear_Click!;
        }

        private async void buttonRun_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                MessageBox.Show("请输入要分词的文本！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            buttonRun.Enabled = false;
            textBoxOutput.Text = "正在分词...";
            treeViewResult.Nodes.Clear();

            try
            {
                await Task.Run(() => PerformSegmentation());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"分词过程中发生错误：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonRun.Enabled = true;
            }
        }

        private void PerformSegmentation()
        {
            string inputText = textBoxInput.Text;
            var segments = segmenter.Cut(inputText);

            this.Invoke(new Action(() =>
            {
                DisplayResults(segments);
            }));
        }

        private void DisplayResults(IEnumerable<string> segments)
        {
            // 显示分词结果在输出文本框
            textBoxOutput.Text = "分词结果：\r\n" + string.Join(" / ", segments);
            
            // 对词汇进行分类
            var classifiedWords = ClassifyWords(segments);
            
            // 清空TreeView
            treeViewResult.Nodes.Clear();
            
            // 创建根节点
            TreeNode rootNode = new TreeNode($"分词结果 (共{segments.Count()}个词)");
            treeViewResult.Nodes.Add(rootNode);
            
            // 按类别添加到TreeView
            foreach (var category in classifiedWords)
            {
                TreeNode categoryNode = new TreeNode($"{category.Key} ({category.Value.Count}个)");
                rootNode.Nodes.Add(categoryNode);
                
                int index = 1;
                foreach (var word in category.Value)
                {
                    TreeNode wordNode = new TreeNode($"{index}. {word}");
                    categoryNode.Nodes.Add(wordNode);
                    index++;
                }
            }
            
            // 展开所有节点
            treeViewResult.ExpandAll();
        }

        private Dictionary<string, List<string>> ClassifyWords(IEnumerable<string> segments)
        {
            var classified = new Dictionary<string, List<string>>();
            
            foreach (var word in segments)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;
                
                string category = DetermineWordCategory(word);
                
                if (!classified.ContainsKey(category))
                {
                    classified[category] = new List<string>();
                }
                
                classified[category].Add(word);
            }
            
            return classified;
        }

        private string DetermineWordCategory(string word)
        {
            // 简单的词性分类规则
            if (IsNumber(word))
                return "数词";
            
            if (IsEnglish(word))
                return "英文词汇";
            
            if (IsPunctuation(word))
                return "标点符号";
            
            if (IsPersonName(word))
                return "人名";
            
            if (IsPlaceName(word))
                return "地名";
            
            if (IsOrganization(word))
                return "机构名";
            
            if (IsTimeWord(word))
                return "时间词";
            
            if (IsCommonNoun(word))
                return "常用名词";
            
            if (IsVerb(word))
                return "动词";
            
            if (IsAdjective(word))
                return "形容词";
            
            if (word.Length == 1)
                return "单字词";
            
            return "其他词汇";
        }

        private bool IsNumber(string word)
        {
            return word.Any(char.IsDigit) || 
                   new[] { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "百", "千", "万", "亿" }
                   .Any(num => word.Contains(num));
        }

        private bool IsEnglish(string word)
        {
            return word.Any(c => (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'));
        }

        private bool IsPunctuation(string word)
        {
            return word.All(c => char.IsPunctuation(c) || char.IsSymbol(c)) ||
                   new[] { "，", "。", "！", "？", "；", "：", """, """, "'", "'", "（", "）", "【", "】" }
                   .Contains(word);
        }

        private bool IsPersonName(string word)
        {
            // 常见姓氏
            string[] surnames = { "王", "李", "张", "刘", "陈", "杨", "黄", "赵", "周", "吴", "马", "朱", "胡", "林", "郭", "何", "高", "梁", "郑", "罗" };
            return surnames.Any(surname => word.StartsWith(surname)) && word.Length >= 2 && word.Length <= 4;
        }

        private bool IsPlaceName(string word)
        {
            string[] placeKeywords = { "市", "省", "县", "区", "镇", "村", "路", "街", "巷", "京", "沪", "津", "渝", "港", "澳", "台" };
            return placeKeywords.Any(keyword => word.Contains(keyword)) ||
                   new[] { "北京", "上海", "广州", "深圳", "杭州", "南京", "武汉", "成都", "西安", "重庆", "天津", "青岛", "大连", "厦门", "中国", "美国", "日本", "韩国", "英国", "法国", "德国" }
                   .Any(place => word.Contains(place));
        }

        private bool IsOrganization(string word)
        {
            string[] orgKeywords = { "公司", "集团", "企业", "学校", "大学", "学院", "医院", "银行", "政府", "部门", "局", "委员会", "协会", "组织" };
            return orgKeywords.Any(keyword => word.Contains(keyword));
        }

        private bool IsTimeWord(string word)
        {
            string[] timeKeywords = { "年", "月", "日", "时", "分", "秒", "今天", "明天", "昨天", "现在", "过去", "未来", "早上", "中午", "下午", "晚上", "春", "夏", "秋", "冬" };
            return timeKeywords.Any(keyword => word.Contains(keyword));
        }

        private bool IsCommonNoun(string word)
        {
            string[] commonNouns = { "人", "事", "物", "家", "者", "员", "师", "生", "手", "头", "心", "身", "房", "车", "书", "电脑", "手机", "桌子", "椅子", "门", "窗", "水", "火", "土", "木", "金" };
            return commonNouns.Any(noun => word.Contains(noun));
        }

        private bool IsVerb(string word)
        {
            string[] verbKeywords = { "是", "有", "在", "到", "去", "来", "看", "听", "说", "做", "走", "跑", "吃", "喝", "睡", "起", "坐", "站", "躺", "学", "教", "买", "卖", "给", "拿", "放", "开", "关", "写", "读" };
            return verbKeywords.Any(verb => word.Contains(verb));
        }

        private bool IsAdjective(string word)
        {
            string[] adjKeywords = { "大", "小", "高", "低", "长", "短", "好", "坏", "美", "丑", "新", "旧", "快", "慢", "热", "冷", "多", "少", "重", "轻", "厚", "薄", "宽", "窄", "深", "浅", "亮", "暗", "清", "浊" };
            return adjKeywords.Any(adj => word.Contains(adj)) ||
                   word.EndsWith("的");
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxOutput.Clear();
            treeViewResult.Nodes.Clear();
        }

    }
}

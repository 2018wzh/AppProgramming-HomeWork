using System.Numerics;
using Newtonsoft.Json;

namespace HW
{
    public partial class QuizApp : Form
    {
        public QuizApp()
        {
            // set window size to fixed size
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            // set title
            InitializeComponent();
            try
            {
                init();
                radioButton1.Hide();
                radioButton2.Hide();
                radioButton3.Hide();
                radioButton4.Hide();
                labelQuestion.Hide();
                buttonPrevQ.Hide();
                buttonNextQ.Hide();
                buttonControl.Hide();
                answerBox.Hide();
                progressBar1.Hide();
                labelTimer.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public struct Question
        {
            public string Text;
            public struct Option
            {
                public string Text;
                public bool IsCorrect;
            }
            public List<Option> Options;
        }
        private List<Question> Questions;
        private int currentQuestionIndex = 0;
        private int questionCount = 0;
        private int quizTime = 0;
        private int remainingTime = 0;
        private string quizName = "";
        private HashSet<int> corretAnswers = new HashSet<int>();
        private bool quizStarted = false;
        private bool quizLoaded = false;

        private void initQuestion()
        {
            if (Questions == null || Questions.Count == 0)
            {
                throw new InvalidOperationException("No questions loaded.");
            }
            if (Questions[currentQuestionIndex].Options == null || Questions[currentQuestionIndex].Options.Count != 4)
            {
                throw new InvalidOperationException("No options available for the current question.");
            }
            labelQuestion.Text = Questions[currentQuestionIndex].Text;
            radioButton1.Text = Questions[currentQuestionIndex].Options[0].Text;
            radioButton2.Text = Questions[currentQuestionIndex].Options[1].Text;
            radioButton3.Text = Questions[currentQuestionIndex].Options[2].Text;
            radioButton4.Text = Questions[currentQuestionIndex].Options[3].Text;
        }

        private void updateButtonStates()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            
            if (quizStarted)
            {
                buttonPrevQ.Enabled = currentQuestionIndex > 0;
                buttonNextQ.Enabled = currentQuestionIndex < questionCount - 1;
                buttonControl.Text = "Finish";
                buttonControl.Enabled = true;
            }
            else if (quizLoaded)
            {
                buttonPrevQ.Enabled = false;
                buttonNextQ.Enabled = false;
                buttonControl.Text = "Start";
                buttonControl.Enabled = true;
            }
            else
            {
                buttonPrevQ.Enabled = false;
                buttonNextQ.Enabled = false;
                buttonControl.Enabled = false;
            }
        }

        private void init()
        {
            buttonPrevQ.Enabled = false;
            buttonNextQ.Enabled = false;
            buttonControl.Enabled = false;
            buttonControl.Text = "Start";
            timer1.Interval = 1000; // 1 second
        }

        private void startQuiz()
        {
            if (quizTime > 0)
            {
                remainingTime = quizTime * 60; // Convert minutes to seconds
                progressBar1.Maximum = remainingTime;
                progressBar1.Minimum = 0; // Ensure minimum is set
                progressBar1.Value = remainingTime;
                updateTimerDisplay();
                timer1.Start();
            }
            else
            {
                // For no time limit, just show static display
                labelTimer.Text = "No Time Limit";
                labelTimer.ForeColor = Color.Blue;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 100;
                progressBar1.Value = 0;
            }
            
            labelQuestion.Show();
            radioButton1.Show();
            radioButton2.Show();
            radioButton3.Show();
            radioButton4.Show();
            answerBox.Show();
            progressBar1.Show();
            labelTimer.Show();
            quizStarted = true;
            labelStatus.Text = $"Quiz started! Question {currentQuestionIndex + 1}/{questionCount}";
            labelStatus.ForeColor = Color.Black;
            updateButtonStates();
        }

        private void updateTimerDisplay()
        {
            int hours = remainingTime / 3600;
            int minutes = (remainingTime % 3600) / 60;
            int seconds = remainingTime % 60;
            labelTimer.Text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";

            if (quizTime > 0 && remainingTime >= 0)
            {
                // Ensure the value is within valid range
                progressBar1.Value = Math.Max(0, Math.Min(remainingTime, progressBar1.Maximum));

                // Change color when time is running low
                if (remainingTime <= quizTime * 60 * 0.1) // Last 10%
                {
                    labelTimer.ForeColor = Color.Red;
                }
                else if (remainingTime <= quizTime * 60 * 0.3) // Last 30%
                {
                    labelTimer.ForeColor = Color.Orange;
                }
                else
                {
                    labelTimer.ForeColor = Color.Black;
                }
            }
        }

        private void stopTimer()
        {
            timer1.Stop();
            quizStarted = false;
        }

        private void finishQuiz()
        {
            stopTimer();
            int correctCount = corretAnswers.Count;
            labelStatus.Text = $"Quiz finished! You answered {correctCount} out of {questionCount} questions correctly.";
            labelStatus.ForeColor = Color.Black;
            buttonPrevQ.Enabled = false;
            buttonNextQ.Enabled = false;
            buttonControl.Enabled = false;

            // Disable radio buttons
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            // Hide question and options

        }

        private void checkAnswer(int index)
        {
            if (Questions[currentQuestionIndex].Options[index].IsCorrect)
            {
                labelStatus.Text = "Correct answer!";
                labelStatus.ForeColor = Color.Green;
                if (!corretAnswers.Contains(currentQuestionIndex))
                {
                    corretAnswers.Add(currentQuestionIndex);
                }
            }
            else
            {
                labelStatus.Text = "Incorrect answer.";
                labelStatus.ForeColor = Color.Red;
                if (corretAnswers.Contains(currentQuestionIndex))
                {
                    corretAnswers.Remove(currentQuestionIndex);
                }
            }
        }

        private void OnRadioButtonCheckedChanged(object sender, EventArgs e)
        {
            if (Questions == null || Questions.Count == 0)
            {
                labelStatus.Text = "No questions loaded.";
                return;
            }

            if (!quizStarted)
            {
                return;
            }

            RadioButton rb = sender as RadioButton;
            if (rb == radioButton1)
            {
                checkAnswer(0);
            }
            else if (rb == radioButton2)
            {
                checkAnswer(1);
            }
            else if (rb == radioButton3)
            {
                checkAnswer(2);
            }
            else if (rb == radioButton4)
            {
                checkAnswer(3);
            }
        }

        private void loadFile()
        {
            string filename = textBoxFileName.Text.Trim();
            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentException("File name cannot be empty.");
            }
            string json = File.ReadAllText(filename);

            // 使用匿名类型先解析JSON，然后转换为你的结构体
            var jsonData = JsonConvert.DeserializeAnonymousType(json, new
            {
                metadata = new
                {
                    name = "",
                    time = 0
                },
                questions = new[] {
                    new {
                        question = "",
                        options = new[] {
                            new { option = "", isCorrect = false }
                        }
                    }
                }
            });

            Questions = new List<Question>();
            foreach (var tempQ in jsonData.questions)
            {
                var question = new Question
                {
                    Text = tempQ.question,
                    Options = new List<Question.Option>()
                };

                foreach (var tempOpt in tempQ.options)
                {
                    question.Options.Add(new Question.Option
                    {
                        Text = tempOpt.option,
                        IsCorrect = tempOpt.isCorrect
                    });
                }

                Questions.Add(question);
            }
            quizName = jsonData.metadata.name;
            quizTime = jsonData.metadata.time;
            questionCount = Questions.Count;
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            string filename = textBoxFileName.Text.Trim();
            if (string.IsNullOrEmpty(filename))
            {
                labelStatus.Text = "Please input a file name.";
                return;
            }
            try
            {
                labelStatus.Text = "Loading questions...";
                loadFile();
                // Process questions here
                labelStatus.Text = $"{questionCount} questions loaded successfully. Click 'Start' to begin.";
                currentQuestionIndex = 0;
                quizLoaded = true;
                quizStarted = false;
                corretAnswers.Clear();
                
                initQuestion();
                buttonPrevQ.Show();
                buttonNextQ.Show();
                buttonControl.Show();

                // Always show timer components when quiz is loaded
                progressBar1.Show();
                labelTimer.Show();
                
                if (quizTime > 0)
                {
                    remainingTime = quizTime * 60;
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = remainingTime;
                    updateTimerDisplay();
                }
                else
                {
                    // Show timer as 00:00:00 for no time limit
                    labelTimer.Text = "00:00:00";
                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = 100;
                    progressBar1.Value = 0;
                }

                // Enable all radio buttons
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;

                updateButtonStates();
            }
            catch (FileNotFoundException)
            {
                labelStatus.Text = "File not found. Please check the file name.";
            }
            catch (JsonException ex)
            {
                labelStatus.Text = $"Error parsing JSON:{ex.Message}.";
            }
            catch (Exception ex)
            {
                labelStatus.Text = $"An error occurred: {ex.Message}";
                MessageBox.Show($"Error details: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonControl_Click(object sender, EventArgs e)
        {
            if (!quizStarted && quizLoaded)
            {
                // Start the quiz
                startQuiz();
            }
            else if (quizStarted)
            {
                // Finish the quiz
                finishQuiz();
            }
        }

        private void buttonPrevQ_Click(object sender, EventArgs e)
        {
            if (!quizStarted)
            {
                return;
            }

            currentQuestionIndex--;
            updateButtonStates();
            initQuestion();
            labelStatus.ForeColor = Color.Black;
            labelStatus.Text = $"Question {currentQuestionIndex + 1}/{questionCount}";
        }

        private void buttonNextQ_Click(object sender, EventArgs e)
        {
            if (!quizStarted)
            {
                return;
            }

            currentQuestionIndex++;
            updateButtonStates();
            initQuestion();
            labelStatus.ForeColor = Color.Black;
            labelStatus.Text = $"Question {currentQuestionIndex + 1}/{questionCount}";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTime > 0)
            {
                remainingTime--;
                updateTimerDisplay();
            }
            else
            {
                // Time's up!
                finishQuiz();
                MessageBox.Show("Time's up! The quiz has ended.", "Quiz Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

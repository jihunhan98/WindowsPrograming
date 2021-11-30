using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _201801608_한지훈_랜덤시험문제
{
    public partial class Form1 : Form
    {
        GroupBox[] GB = new GroupBox[3];
        PictureBox[] PB = new PictureBox[4];
        RadioButton[,] Bogi = new RadioButton[3, 4];
        Label[] Quize = new Label[3];
        Label lbScore = new Label();
        Button button = new Button();
        int Score = 0;
        Random random = new Random();
        PictureBox picture = new PictureBox();
        string[] Answer = new string[3];
        public Form1()
        {
            InitializeComponent();
            int[] RandomQ = new int[3] { -1, -1, -1 };
            int[] RandomB = new int[5] { -1, -1, -1, -1, 4 };
            string aa = "[문제";
            string[,] Question = new string[5, 7]
          {
                {"윈도우즈 프로그래밍 교수님의 이름은?","홍윤식","이면섭","김우일","채진석","이면섭","TT"},
                {"다음 중 광역시에 해당하는 도시는?","인천","서울","안산","천안","인천","TT" },
                {"임진왜란이 일어난 년도는?","1491","1492","1591","1592","1592","TT"},
                { "인천대학교의 로고는?","Image/인천대 로고.PNG","Image/성균관대 로고.PNG","Image/건국대 로고.PNG","Image/서울대 로고.PNG","Image/인천대 로고.PNG","TI"},
                { "이 사진은 누구인가? ","김태희","아이유","김고은","송혜교","김고은","IT"},
          };

            int count = 0;
            while (count < 3)
            {
                int num = random.Next(0, 5);
                bool check = true;
                for (int i = 0; i < 3; i++)
                {
                    if (RandomQ[i] == num)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    RandomQ[count] = num;
                    count++;
                }
            }
            count = 0;
            while (count < 4)
            {
                int num = random.Next(0, 4);
                bool check = true;
                for (int i = 0; i < 4; i++)
                {
                    if (RandomB[i] == num)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    RandomB[count] = num;
                    count++;
                }
            }

            #region
            lbScore = new Label();
            this.lbScore.Name = "lbScore";
            this.lbScore.Text = "Score";
            this.lbScore.Size = new Size(110, 40);
            this.lbScore.Location = new System.Drawing.Point(30, 920);
            this.Controls.Add(lbScore);
            #endregion

            #region
            this.button.Name = "btnSubmit";
            this.button.Text = "채점하기";
            this.button.Location = new System.Drawing.Point(200, 920);
            this.button.AutoSize = true;
            this.button.Size = new Size(90, 30);
            this.button.Click += new EventHandler(button_Click);
            this.Controls.Add(button);
            #endregion

            #region
            for (int n = 0; n < GB.Length; n++)
            {
                int k = RandomQ[n];
                GB[n] = new GroupBox();
                this.GB[n].Text = aa + (n + 1) + "] " + Question[k, 0];
                this.GB[n].AutoSize = true;
                this.GB[n].Size = new System.Drawing.Size(500, 120);
                this.GB[n].Location = new System.Drawing.Point(0, 10 + (n * 300));
                this.GB[n].TabIndex = 0;
                this.GB[n].TabStop = false;
                this.Controls.Add(GB[n]);
                if (Question[k, 6] == "TT")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int j = RandomB[i];
                        Bogi[n, i] = new RadioButton();
                        this.Bogi[n, i].Text = Question[k, j + 1];
                        this.Bogi[n, i].Location = new System.Drawing.Point(30, 30 + (i * 20));
                        this.Bogi[n, i].Size = new System.Drawing.Size(100, 20);
                        this.Controls.Add(Bogi[n, i]);
                        this.GB[n].Controls.Add(this.Bogi[n, i]);
                        Answer[n] = Question[k, 5];
                    }
                }
                else if (Question[k, 6] == "TI")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        int j = RandomB[i];
                        Bogi[n, i] = new RadioButton();
                        if (i == 0)
                            this.Bogi[n, i].Location = new System.Drawing.Point(30, 30);
                        else if
                            (i == 1) this.Bogi[n, i].Location = new System.Drawing.Point(290, 30);
                        else if
                            (i == 2) this.Bogi[n, i].Location = new System.Drawing.Point(30, 140);
                        else
                            this.Bogi[n, i].Location = new System.Drawing.Point(290, 140);
                        this.Bogi[n, i].Size = new System.Drawing.Size(100, 20);

                        PB[i] = new PictureBox();
                        this.PB[i].Load(Question[k, j + 1]);
                        Bogi[n, i].Name = Question[k, j + 1];
                        if (Question[k, j + 1] == Question[3, 5])
                            Answer[n] = Question[k, j + 1];
                        if (i == 0)
                            this.PB[i].Location = new System.Drawing.Point(50, 30);
                        else if (i == 1)
                            this.PB[i].Location = new System.Drawing.Point(320, 30);
                        else if (i == 2)
                            this.PB[i].Location = new System.Drawing.Point(50, 150);
                        else if (i == 3)
                            this.PB[i].Location = new System.Drawing.Point(320, 150);
                        this.PB[i].Size = new System.Drawing.Size(100, 100);
                        this.GB[n].Controls.Add(this.PB[i]);
                        this.Controls.Add(Bogi[n, i]);
                        this.GB[n].Controls.Add(this.Bogi[n, i]);


                    }
                }
                else
                {
                    picture = new PictureBox();
                    this.picture.Load("Image/김고은.jpg");
                    picture.Location = new Point(30, 30);
                    picture.Size = new Size(100, 100);
                    this.GB[n].Controls.Add(this.picture);
                    for (int i = 0; i < 4; i++)
                    {
                        int j = RandomB[i];
                        Bogi[n, i] = new RadioButton();
                        this.Bogi[n, i].Location = new System.Drawing.Point(200, 30 + (i * 20));
                        this.Bogi[n, i].Size = new System.Drawing.Size(100, 20);
                        this.Bogi[n, i].Text = Question[k, j + 1];
                        this.Controls.Add(Bogi[n, i]);
                        this.GB[n].Controls.Add(this.Bogi[n, i]);
                        Answer[n] = Question[k, 5];
                    }
                }
            }
            #endregion
        }
        void button_Click(object sender, EventArgs e)
        {
            Score = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Bogi[i, j].Checked)
                    {
                        if (Bogi[i, j].Text == Answer[i])
                        {
                            Score++;
                            break;
                        }
                        else if (Bogi[i, j].Name == Answer[i])
                        {
                            Score++;
                            break;
                        }

                    }
                }
            }
            lbScore.Text = "Score " + Score.ToString();
        }
    }
}

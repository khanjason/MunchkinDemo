using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MunchkinDemo
{
    public partial class Form1 : Form
    {
        Color labelcolor = System.Drawing.ColorTranslator.FromHtml("#ECEFF2");

        private Label Title;
        ListBox presentBox;
        private string version = "V0.1";
        BindingList<string> registeredList = new BindingList<string>();
        ListBox registeredBox;
        BindingList<string> presentList = new BindingList<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetUpUI();
        }

        void SetUpUI()
        {
            Color Titlecolor = System.Drawing.ColorTranslator.FromHtml("#ECEFF2");
            Title = new Label();
            Title.Text = "MUNchkin" + " "+version;
            Title.Font = new Font("Berlin Sans FB", 54f);
            Title.Size = new Size(this.Width,80);
            Title.ForeColor = Titlecolor;
            Color background = System.Drawing.ColorTranslator.FromHtml("#7EA5DF");
            Title.Location = new Point(this.Width, 25);
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            

            this.BackColor = background;
            this.Controls.Add(Title);
            AddRegisterlistbox();
           
        }

        void AddRegisterlistbox()
        {
            

               Color buttonColor = ColorTranslator.FromHtml("#3068BD");

            Label caption1 = new Label();
            caption1.Text = "Available Delegations";
            caption1.Font = new Font("Berlin Sans FB", 22f);
            caption1.Size = new Size(250, 180);
            caption1.ForeColor = labelcolor;
            
            presentBox = new ListBox();
            presentBox.Size = new System.Drawing.Size(200, 100);
            presentBox.Location = new System.Drawing.Point(10, 250);
            caption1.Location = new Point(presentBox.Location.X, presentBox.Location.Y-presentBox.Height);
            presentBox.Items.AddRange(new object[]{"United Kingdom",
        "Saudi Arabia", "USA", "France", "China",
        "Spain"});

            Label caption2 = new Label();
            caption2.Text = "Registered Delegations";
            caption2.Font = new Font("Berlin Sans FB", 22f);
            caption2.Size = new Size(250, 180);
            caption2.ForeColor = labelcolor;

            registeredBox = new ListBox();
            registeredBox.DataSource = registeredList;
            registeredBox.Size = new Size(200, 100);
            registeredBox.Location = new Point(270, 250);
            caption2.Location = new Point(registeredBox.Location.X, registeredBox.Location.Y - registeredBox.Height);

            Button addtoRegisterButton = new Button();
            addtoRegisterButton.Text = ">";
            addtoRegisterButton.ForeColor = labelcolor;
            addtoRegisterButton.BackColor = buttonColor;
            addtoRegisterButton.Location = new Point(presentBox.Location.X, presentBox.Location.Y + presentBox.Height);
            addtoRegisterButton.Click += new System.EventHandler(this.AddToRegister);

            Button checkRegisterButton = new Button();
            checkRegisterButton.Text = "Start";
            checkRegisterButton.ForeColor = labelcolor;
            checkRegisterButton.BackColor = buttonColor;
            checkRegisterButton.Location = new Point(registeredBox.Location.X, registeredBox.Location.Y + registeredBox.Height);
            checkRegisterButton.Click += new System.EventHandler(this.SetCheckOffRegister);
            this.Controls.Add(checkRegisterButton);

            Button deleteFromRegisterButton = new Button();
            deleteFromRegisterButton.Text = "Delete";
            deleteFromRegisterButton.ForeColor = labelcolor;
            deleteFromRegisterButton.BackColor = buttonColor;
            deleteFromRegisterButton.Location = new Point(registeredBox.Location.X+80, registeredBox.Location.Y + registeredBox.Height);
            deleteFromRegisterButton.Click += new System.EventHandler(this.DeleteFromRegister);
            this.Controls.Add(deleteFromRegisterButton);


            this.Controls.Add(addtoRegisterButton);

            this.Controls.Add(presentBox);
            this.Controls.Add(caption1);

            this.Controls.Add(registeredBox);
            this.Controls.Add(caption2);
        }

        void AddToRegister( object sender, EventArgs e)
        {
            string curItem = presentBox.SelectedItem.ToString();
            registeredList.Add(curItem);

        }

        void DeleteFromRegister(object sender, EventArgs e)
        {
            string curItem = registeredBox.SelectedItem.ToString();
            
            registeredList.Remove(curItem);
            registeredBox.Refresh();

        }

        void SetCheckOffRegister(object sender, EventArgs e)
        {
            int labelX = 450;
            int labelY = 250;

            Label[] registerTextList = new Label[registeredList.Count];
            for (int t = 0; t < registeredList.Count; t++)
            {
               registerTextList[t] = new Label();
            }

            int counter = 0;

            while (counter < registeredList.Count)
            {

                registerTextList[counter].Tag = counter + 1;
                registerTextList[counter].Width = 110;
                registerTextList[counter].Height = 40;


                registerTextList[counter].Location = new Point(labelX, labelY);

                

                labelY = labelY + registerTextList[counter].Height;
                
                registerTextList[counter].Text = registeredList[counter];

                this.Controls.Add(registerTextList[counter]);
                counter++;


            }
        

            Label RegisterTitle = new Label();
            RegisterTitle.Text = "Present";
            RegisterTitle.Font = new Font("Berlin Sans FB", 22f);
            RegisterTitle.Size = new Size(120, 80);
            RegisterTitle.Location= new Point(700, registeredBox.Location.Y - registeredBox.Height);
            RegisterTitle.ForeColor = labelcolor;
            this.Controls.Add(RegisterTitle);

            Button[] PresentbtnArr = new Button[registeredList.Count];
            int x = 700;
            int y = 250;

            for (int i = 0; i < registeredList.Count; i++)
            {
                PresentbtnArr[i] = new Button();
            }
            int n = 0;

            while (n < registeredList.Count)
            {
                PresentbtnArr[n].Tag = n + 1; 
                PresentbtnArr[n].Width = 40; 
                PresentbtnArr[n].Height = 40; 
                
                
                PresentbtnArr[n].Left = x;
                PresentbtnArr[n].Top = y;
                
                this.Controls.Add(PresentbtnArr[n]); 

                y = y + PresentbtnArr[n].Height;
                PresentbtnArr[n].BackColor = Color.Gray;
                PresentbtnArr[n].Text = "";

               
                PresentbtnArr[n].Click += new System.EventHandler(MakePresent);
                n++;
            }
           
        }



        void MakePresent(object sender, EventArgs e)
        {
            Button thisbut = sender as Button;
            if (thisbut != null)
            {
                if (thisbut.BackColor == Color.Gray)
                {
                    thisbut.BackColor = Color.LimeGreen;

                    presentList.Add(registeredList[Int16.Parse(thisbut.Tag.ToString()) - 1]);
                    
                }
                else if (thisbut.BackColor == Color.LimeGreen)
                {
                    thisbut.BackColor = Color.Gray;
                    presentList.Remove(registeredList[Int16.Parse(thisbut.Tag.ToString()) - 1]);
                }


            }
        }



    }
}


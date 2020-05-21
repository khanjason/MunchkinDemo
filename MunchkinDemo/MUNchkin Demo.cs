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
        private Label Title;
        ListBox presentBox;
        private string version = "V0.1";
        BindingList<string> registeredList = new BindingList<string>();
        ListBox registeredBox;

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
            Title.Size = new Size(500, this.Width);
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
            

            Color labelcolor = System.Drawing.ColorTranslator.FromHtml("#ECEFF2");
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

        void CheckOffRegister()
        {

        }
    }
}

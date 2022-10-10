using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Maxtrix
{
    internal class Program
    {
        static Form form = new Form();
        static ComboBox comboBox1 = new ComboBox();
        static ComboBox comboBox2 = new ComboBox();
        static Label label = new Label();
        static Button button1 = new Button();
        static FlowLayoutPanel panel1 = new FlowLayoutPanel();
        static FlowLayoutPanel panel2 = new FlowLayoutPanel();
        static FlowLayoutPanel panel3 = new FlowLayoutPanel();
        static TextBox[,] textbox1;
        static TextBox[,] textbox2;
        static TextBox[,] textbox3;
        static int n = 2;
        static string s = "+";
        public static  TextBox[,] createTextBox(int n, Form form, FlowLayoutPanel panel)
        {
            TextBox[,] textbox = new TextBox[n, n];
            for (int i = 0; i < n; i++)
            {

                for (int j = 0; j < n; j++)
                {
                    textbox[i, j] = new TextBox();
                    textbox[i, j].Size = new Size(60, 60);
                }
            }
            panel.Size = new Size(60 * n + 30, 60 * n);
            panel.BackColor = Color.Beige;
            panel.FlowDirection = FlowDirection.LeftToRight;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    form.Controls.Add(textbox[i, j]);
                    panel.Controls.Add(textbox[i, j]);
                }
            }
            form.Controls.Add(panel);
            return textbox;
        }
        static void Main(string[] args)
        {
            // create form
            
            form.Size = new System.Drawing.Size(800, 500);

            // create label 
            label.Text = "Kich thuoc";
            label.Size = new System.Drawing.Size(80, 20);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = Color.Khaki;
            label.Location = new System.Drawing.Point(20, 20);
            form.Controls.Add(label);

            // create comboBox1 
            for (int i = 2; i <= 5; i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.SelectedIndex = 0;
            comboBox1.Size = new System.Drawing.Size(80, 50);
            comboBox1.Location = new Point(120, 20);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            form.Controls.Add(comboBox1);





            //create Textbox1 
            textbox1 = createTextBox(2, form, panel1);
            panel1.Location = new Point(20, 100);

            // create comboBox2
            comboBox2.Items.Add("+");
            comboBox2.Items.Add("x");
            comboBox2.SelectedIndex = 0;
            comboBox2.Size = new Size(80, 50);
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Location = new Point(panel1.Location.X + panel1.Width + 10, panel1.Location.Y);
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            form.Controls.Add(comboBox2);

            // create Textbox2 
            textbox2 = createTextBox(2, form, panel2);
            panel2.Location = new Point(comboBox2.Location.X + comboBox2.Width + 10, 100); 


            // create button equal
            button1.Text = "=";
            button1.Size = new Size(80, 20);
            button1.Location = new Point(panel2.Location.X + panel2.Width + 10, panel2.Location.Y);
            form.Controls.Add(button1);

            // create panel3

            textbox3 = createTextBox(2, form, panel3);
            panel3.Location = new Point(button1.Location.X + button1.Width + 10, button1.Location.Y);


            button1.Click += Button1_Click;


            form.Show();
            Application.Run(form);
        }

        private static void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox; 
            s = comboBox.Text;
        }

        private static void Button1_Click(object sender, EventArgs e)
        {
            if (s == "+")
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int x = Int16.Parse(textbox2[i, j].Text) + Int16.Parse(textbox1[i, j].Text);
                        textbox3[i, j].Text = x.ToString();
                    }
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        int sum = 0;
                        for (int k = 0; k <n; k++)
                        {
                            sum = sum + Int16.Parse(textbox1[i, k].Text) * Int16.Parse(textbox2[k, j].Text);
                        }
                        textbox3[i, j].Text = sum.ToString();
                    }
                }
            }
        }

        private static void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            n = (int)comboBox.SelectedItem;
            foreach (TextBox i in textbox1)
            {
                i.Controls.Remove(i);
                i.Dispose();
            }    
            foreach (TextBox i in textbox2)
            {
                i.Controls.Remove(i);
                i.Dispose();
            }
            foreach (TextBox i in textbox3)
            {
                i.Controls.Remove(i);
                i.Dispose();
            }
            textbox1 = createTextBox(n, form, panel1);
            comboBox2.Location = new Point(panel1.Location.X + panel1.Width + 10, panel1.Location.Y);
            textbox2 = createTextBox(n, form, panel2);
            panel2.Location = new Point(comboBox2.Location.X + comboBox2.Width + 10, 100);
            button1.Location = new Point(panel2.Location.X + panel2.Width + 10, panel2.Location.Y);
            textbox3 = createTextBox(n, form, panel3);
            panel3.Location = new Point(button1.Location.X + button1.Width + 10, button1.Location.Y);
        }
    }
}

// djt me may Cao quai

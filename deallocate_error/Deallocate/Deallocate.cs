using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memory_blocks
{
    public partial class Deallocate : Form
    {
        public Deallocate()
        {
            InitializeComponent();
        }

        private void Deallocate_Load(object sender, EventArgs e)
        {
            string message = "Process 1 failed to allocate, do you want to deallocate another process from the memory?";
            string title = "Allocation Error";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                Dictionary<Nullable<int>, string> comboSource = new Dictionary<Nullable<int>, string>();
                //comboSource.Add(null, "");
                comboSource.Add(1, "Sunday");
                comboSource.Add(2, "Monday");

                comboBox1.DataSource = new BindingSource(comboSource, null);
                comboBox1.DisplayMember = "Value";
                comboBox1.ValueMember = "Key";
                comboBox1.SelectedItem = null; 
            }
            else
            {
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void deallocate_btn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string value = ((KeyValuePair<Nullable<int>, string>)comboBox1.SelectedItem).Value;
                Nullable<int> key = ((KeyValuePair<Nullable<int>, string>)comboBox1.SelectedItem).Key;
                MessageBox.Show(key + "   " + value);
            }
            else
            {
                MessageBox.Show("You have not chosen a process to deallocate");
            }
        }

        private void Deallocate_Paint(object sender, PaintEventArgs e)
        {
            //dimensions of the rectangel
            int width = 200;
            int[] height = { 20, 40, 60, 50, 30 };

            //margins of the rectangle inside the form  
            int blocks_number = 5;
            int x_margin = 400;
            int[] y_margin = new int[blocks_number];

            // Text specifications: pen, font
            Pen black_pen = new Pen(Color.Black, 2);
            Font text_font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            string text;

            // Create a StringFormat object with the each line of text, and the block
            // of text centered on the page.
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            for (int i = 0; i < blocks_number; i++)
            {
                text = "Segment " + i;

                if (i == 0)
                    y_margin[i] = 50;
                else
                    y_margin[i] = y_margin[i - 1] + height[i - 1];


                //draw the addresses beside the rectangle    
                e.Graphics.DrawString("1000", text_font, Brushes.Black, x_margin - 35, y_margin[i] - 8);

                // Create rectangle.
                Rectangle rect = new Rectangle(x_margin, y_margin[i], width, height[i]);
                e.Graphics.DrawString(text, text_font, Brushes.Black, rect, stringFormat);

                // Draw rectangle to screen.
                e.Graphics.DrawRectangle(black_pen, rect);
            }
        }
    }
}

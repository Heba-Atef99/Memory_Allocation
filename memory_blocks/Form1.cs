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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //dimensions of the rectangel
            int width = 200;
            int[] height = { 20, 40, 60, 50, 30 };

            //margins of the rectangle inside the form  
            int blocks_number = 5;
            int x_margin = 300;
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

            for(int i = 0; i < blocks_number; i++)
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

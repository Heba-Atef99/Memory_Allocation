using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using classes;
namespace memory_blocks
{
    public partial class Output : Form
    {
        public List<Mem_History> hl_output = new List<Mem_History>();
        public List<Segment> segment_list = new List<Segment>();
        public List<Hole> hole_list = new List<Hole>();

        public Output(ref List<Mem_History> hl, ref List<Segment> s, ref List<Hole> h)
        {
            hl_output = hl;
            segment_list = s;
            hole_list = h;
            InitializeComponent();
        }

        private void Memory_Load(object sender, EventArgs e)
        {
        }

        private void Memory_Paint(object sender, PaintEventArgs e)
        {
            //dimensions of the rectangel
            int width = 200;
            int height = 25;

            //margins of the rectangle inside the form  
            int blocks_number = hl_output.Count;
            int x_margin = 360;
            int[] y_margin = new int[blocks_number];

            // Text specifications: pen, font
            Pen black_pen = new Pen(Color.White, 2);
            Font text_font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            string text;

            // Create a StringFormat object with the each line of text, and the block
            // of text centered on the page.
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;
            int i;
            for (i = 0; i < blocks_number; i++)
            {
                text = hl_output[i].get_Name();

                if (i == 0)
                    y_margin[i] = 90;
                else
                    y_margin[i] = y_margin[i - 1] + height;


                //draw the addresses beside the rectangle    
                e.Graphics.DrawString(hl_output[i].get_Start().ToString(), text_font, Brushes.White, x_margin - 35, y_margin[i] - 8);

                // Create rectangle.
                Rectangle rect = new Rectangle(x_margin, y_margin[i], width, height);
                e.Graphics.DrawString(text, text_font, Brushes.White, rect, stringFormat);

                // Draw rectangle to screen.
                e.Graphics.DrawRectangle(black_pen, rect);
            }

            e.Graphics.DrawString(hl_output[i - 1].get_End().ToString(), text_font, Brushes.White, x_margin - 35, y_margin[i - 1] - 8 + height);
        }

    }
}

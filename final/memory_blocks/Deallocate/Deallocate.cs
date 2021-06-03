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
using memory_blocks.AllocationMethods;

namespace memory_blocks
{
    public partial class Deallocate : Form
    {
        public static int p_id = Form3.p_id;
        public static int mem = Form1.mem_size;
        public List<Mem_History> hl_output = new List<Mem_History>();
        public List<Segment> segment_list = new List<Segment>();
        public List<Hole> hole_list = new List<Hole>();

        public Deallocate(ref List<Mem_History> hl, ref List<Segment> s, ref List<Hole> h)
        {
            hl_output = hl;
            segment_list = s;
            hole_list = h;
            InitializeComponent();
        }

        private void Deallocate_Load(object sender, EventArgs e)
        {
            string message = "Process " + p_id + " failed to allocate, do you want to deallocate another process from the memory?";
            string title = "Allocation Error";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);

            if (result == DialogResult.Yes)
            {
                Dictionary<int, string> comboSource = new Dictionary<int, string>();
                //List <Mem_History> hl_ot = hl_output.Distinct().ToList();
                List<Mem_History> hl_ot = hl_output.GroupBy(x => x.get_Id()).Select(x => x.First()).ToList();
                int size = hl_ot.Count;
                Nullable<int> id = 0;
                for(int i = 0; i < size; i++)
                {
                    id = hl_ot[i].get_Id();
                    if (id != null)
                    {
                        if(id < 0)
                            comboSource.Add((int)id, hl_ot[i].get_Name());
                        
                        else
                            comboSource.Add((int)id, "P"+id);

                    }
                }

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
                string value = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Value;
                int key = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;

                //call the function
                AlloctionMethods.deal(key, ref segment_list, ref hl_output, ref hole_list);

                bool error = true;
                switch (Form1.key)
                {
                    case 1:
                        //call first fit function
                        error = AlloctionMethods.First_Fit(ref segment_list, ref hl_output, ref hole_list, ref p_id);
                        break;

                    case 2:
                        //call best fil function
                        error = AlloctionMethods.Best_Fit(ref segment_list, ref hl_output, ref hole_list, ref p_id);
                        break;

                    case 3:
                        //call wosrt fit function
                        error = AlloctionMethods.Worst_Fit(ref segment_list, ref hl_output, ref hole_list, ref p_id);
                        break;
                }

                if (error == true)
                {
                    // go to output form
                    Output output = new Output(ref hl_output, ref segment_list, ref hole_list);
                    output.ShowDialog();
                }
                else
                {
                    // go to dealloction from
                    Deallocate deallocate = new Deallocate(ref hl_output, ref segment_list, ref hole_list);
                    deallocate.ShowDialog();
                }

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

            e.Graphics.DrawString((mem - 1).ToString(), text_font, Brushes.White, x_margin - 35, y_margin[i - 1] - 8 + height);
        }

    }
}


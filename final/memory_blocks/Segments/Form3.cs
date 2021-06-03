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
    public partial class Form3 : Form
    {
       
        public int no_of_processes = Form1.num_process;
        public int initial = 0;
        public static int p_id;
        public int key = Form1.key;

        public List<Mem_History> hl_output = new List<Mem_History>();
        public List<Segment> segment_list = new List<Segment>();
        public List<Hole> hole_list = new List<Hole>();

        public Form3(ref List<Mem_History> hl, ref List<Segment> s, ref List<Hole> h)
        {
            hl_output = hl;
            segment_list = s;
            hole_list = h;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lbl.Text ="Process"+ Form2.segInfo[0, 0].ToString();
            if (initial == no_of_processes - 1)
            {
                button1.Text = "Show Results";
            }
            else
            {
                button1.Text = "Enter new process information";
            }
            
            for (int i = 0; i <= Form2.segInfo[0, 1] - 1; i++)
            {
                 dgvSegInfo.Rows.Add();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //EX: 3 processes p1 i =1, p2 i = 2, p3 i = 3
            //no_of_processes - 1 = 2

            //i = 0 ==> i = 1
            //i = 2

            //first save inputs from user
            for (int r = 0; r < dgvSegInfo.Rows.Count; r++)
            {
                Segment segment = new Segment();
                segment.set_Process_ID(initial);
                segment.set_Name(dgvSegInfo.Rows[r].Cells[0].Value.ToString());
                segment.set_Size(Convert.ToInt32(dgvSegInfo.Rows[r].Cells[1].Value));
                segment_list.Add(segment);
            }

            //then show new table for another process
            if (initial < no_of_processes - 1)
            {
                for (int j = 0; j < Form2.segInfo[initial, 1]; j++)
                {
                    dgvSegInfo.Rows.RemoveAt(0);
                }

                lbl.Text = "Process" + (initial + 1).ToString();
                for (int j = 0; j < Form2.segInfo[initial + 1, 1]; j++)
                {
                    dgvSegInfo.Rows.Add();
                }
            }

            initial++;

            //change the button text for last process
            if (initial == no_of_processes - 1)
            {
                button1.Text = "Show Results";
            }

            //after user press show results then output is out or deallocation error
            if (initial == no_of_processes)
            {
                bool error = true;
                switch (key)
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
        }
    }
}

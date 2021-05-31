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

namespace Memory_Managment
{
    public partial class Form3 : Form
    {
       
        public int no_of_processes = (Form1.num_process);
        public int initial = 1;
        public List<Segment> segment_list = new List<Segment>();
        public int key = Form1.key;


        public Form3()
        {
            InitializeComponent();

            
        }

        private void Form3_Load(object sender, EventArgs e)
        { 
            
            lbl.Text ="Process"+ Form2.segInfo[0, 0].ToString();
            button1.Text = "Enter new process information";
            for (int i = 0; i <= Form2.segInfo[0, 1] - 1; i++)
            {
                 dgvSegInfo.Rows.Add();
              
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (initial == no_of_processes-1)
            {

                button1.Text = "Show Results"; 

            }

            if (initial == no_of_processes)
            {
                bool error=false;
               switch (key)
                    {
                    case 1:
                        //call first fit function
                        break;
                    case 2:
                        //call best fil function
                        break;
                    case 3:
                        //call wosrt fit function
                        break;
                }
                if (error == false)
                { // go to output form
                }
                else
                {
                    // go to dealloction from
                }
                Form4 form = new Form4();

                form.ShowDialog();

            }
            else
            {
                for (int j = 0; j < Form2.segInfo[initial-1, 1] ; j++)
               {
                    dgvSegInfo.Rows.RemoveAt(0);
              
                }
                
               
                lbl.Text = "Process" + initial.ToString();
                for (int j = 0; j <=Form2.segInfo[initial, 1]-1 ; j++)
                {
                    dgvSegInfo.Rows.Add();
                }

                for (int r = 0; r < dgvSegInfo.Rows.Count; r++)
                {
                    Segment segment = new Segment();
                    segment.set_Process_ID(initial);

                    segment.set_Name(dgvSegInfo.Rows[r].Cells[0].Value.ToString());
                    
                    segment.set_Size(Convert.ToInt32(dgvSegInfo.Rows[r].Cells[1].Value));
                    segment_list.Add(segment);
                }
               

                initial++;
            }
        }
    }
}

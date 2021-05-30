using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Managment
{
    public partial class Form3 : Form
    {
       
        public int no_of_processes = Int32.Parse(Form1.no_of_processes);
        public int initial = 1;
       
        
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
            
            if (initial == no_of_processes)
            {
               
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

                            dgvSegInfo.Rows[r].Cells[0].Value
                            dgvSegInfo.Rows[r].Cells[1].Value

                    for (int c = 0; c < dgvSegInfo.Rows[r].Cells.Count; c++)
                    {
                       segment_information[r, c] = Convert.ToInt32(dgvSegInfo.Rows[r].Cells[c].Value);
                    }
                }


                initial++;
            }
        }
    }
}

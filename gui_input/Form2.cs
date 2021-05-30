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
    public partial class Form2 : Form
    {
        public static int holesIndex;
        public static int processesIndex;
        public static int[,] segInfo = new int[100, 2];
        public int nH = 0;
        public int nP = 0;
        
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            holesIndex = Int32.Parse(Form1.no_of_holes);
            processesIndex = Int32.Parse(Form1.no_of_processes);
            for (int i = 0; i <= processesIndex - 1; i++)
            {
                nP = dgvProcesses.Rows.Add();
                dgvProcesses.Rows[nP].Cells[0].Value = nP;
            }
            for (int i = 0; i <= holesIndex - 1; i++)
            {
                nH = dgvHoles.Rows.Add();
                dgvHoles.Rows[nH].Cells[0].Value = nH;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[,] holesTable = new int[holesIndex, 3];
            int[,] processesTable = new int[processesIndex, 2];

            if (dgvHoles.Rows.Count == 1)
            {
                int r = 0;
                for (int c = 0; c < dgvHoles.Rows[r].Cells.Count; c++)
                {
                    holesTable[r, c] = Convert.ToInt32(dgvHoles.Rows[r].Cells[c].Value);
                }
            }
            else
            {
                for (int r = 0; r < dgvHoles.Rows.Count - 1; r++)
                {
                    for (int c = 0; c < dgvHoles.Rows[r].Cells.Count; c++)
                    {
                        holesTable[r, c] = Convert.ToInt32(dgvHoles.Rows[r].Cells[c].Value);
                    }
                }
            }
            if (dgvProcesses.Rows.Count == 1)
            {
                int r = 0;
                for (int c = 0; c < dgvProcesses.Rows[r].Cells.Count; c++)
                {
                    processesTable[r, c] = Convert.ToInt32(dgvProcesses.Rows[r].Cells[c].Value);
                }
            }
            else
            {
                for (int r = 0; r < dgvProcesses.Rows.Count ; r++)
                {
                    for (int c = 0; c < dgvProcesses.Rows[r].Cells.Count; c++)
                    {
                        processesTable[r, c] = Convert.ToInt32(dgvProcesses.Rows[r].Cells[c].Value);
                    }
                }
            }
            segInfo = processesTable;
            Form3 form = new Form3();

            form.ShowDialog();
        }

        private void btnNew_hole_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNew_Process_Click(object sender, EventArgs e)
        {
           
        }
    }
}

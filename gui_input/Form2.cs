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
    public partial class Form2 : Form
    {
        public static int holesIndex;
        public static int processesIndex;
        public static int mem_size;
        public static int[,] segInfo = new int[100, 2];
        public int nH = 0;
        public int nP = 0;
        public List<Hole> hole_list = new List<Hole>();
        public  List<Segment> segment_list = new List<Segment>();
        public List<Mem_History> history_list = new List<Mem_History>();
        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            holesIndex = (Form1.num_holes);
            processesIndex = (Form1.num_process);
            mem_size = Form1.mem_size;
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

           
                for (int r = 0; r <= dgvHoles.Rows.Count - 1; r++)
                {
                     Hole hole = new Hole();
                     hole.set_Hole_ID(r);
                for (int c = 0; c < dgvHoles.Rows[r].Cells.Count; c++)
                    {
                        holesTable[r, c] = Convert.ToInt32(dgvHoles.Rows[r].Cells[c].Value);
                    }
                    hole.set_Starting_Address(holesTable[r, 1]);
                   
                    hole.set_Size(holesTable[r, 2]);
                    hole_list.Add(hole);
            }

            Create_H_L(ref history_list, ref hole_list, ref segment_list, mem_size);

            for (int r = 0; r <= dgvProcesses.Rows.Count-1 ; r++)
                {
                    for (int c = 0; c < dgvProcesses.Rows[r].Cells.Count; c++)
                    {
                        processesTable[r, c] = Convert.ToInt32(dgvProcesses.Rows[r].Cells[c].Value);
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


        public static void Create_H_L(ref List<Mem_History> history_list, ref List<Hole> hole_list, ref List<Segment> segment_list, int mem_size)
        {
            for (int i = 0; i < hole_list.Count(); i++)
            {
                Mem_History history_element = new Mem_History();
                history_element.set_Name("Hole" + i);
                history_element.set_Start(hole_list[i].get_Starting_Address());
                history_element.set_End((hole_list[i].get_Starting_Address()) + (hole_list[i].get_Size()) - 1);
                history_list.Add(history_element);

            }
            // Handling Old Processes
            // sorting hole list by starting address
            hole_list = hole_list.OrderBy(Hole => Hole.get_Starting_Address()).ToList();
            int old_number = -1; // old process id
            int start = 0;
            for (int i = 0; i < hole_list.Count; i++)
            {
                if (i == 0 && hole_list.Count > 1)
                {
                    if (hole_list[i].get_Starting_Address() == 0)
                        continue;
                    else { start = 0; }
                }
                else if (i == (hole_list.Count - 1))
                {
                    if (i == 0 && (hole_list[i].get_Starting_Address() != 0) && ((hole_list[i].get_Starting_Address()) + (hole_list[i].get_Size()) == mem_size))
                    {
                        start = 0;

                    }

                    else if ((hole_list[i].get_Starting_Address()) + (hole_list[i].get_Size()) < mem_size)
                    {
                        if ((i > 0) | ((i == 0) && (hole_list[i].get_Starting_Address() != 0))) old_number -= 1;
                        // putting last old process in history
                        Mem_History history_element_last = new Mem_History();
                        history_element_last.set_Name("Old Process" + (-1 * (old_number)));
                        history_element_last.set_Start((hole_list[i].get_Starting_Address()) + hole_list[i].get_Size());
                        history_element_last.set_End(mem_size - 1);
                        history_element_last.set_Id(old_number);//here
                        history_list.Add(history_element_last);
                        // putting last old process in segment
                        Segment segment_last = new Segment();
                        segment_last.set_Name("Old Process" + (-1 * (old_number)));
                        segment_last.set_Process_ID(old_number);
                        segment_last.set_Size((history_element_last.get_End()) - (history_element_last.get_Start()) + 1);
                        segment_list.Add(segment_last);
                        if ((i == 0) && (hole_list[i].get_Starting_Address() == 0))
                            continue;
                        else
                        {
                            if (i > 0)
                            { start = (hole_list[i - 1].get_Starting_Address()) + (hole_list[i - 1].get_Size()); old_number += 1; }

                            else if (i == 0)
                            { start = 0; old_number += 1; }

                        }

                    }

                    else { start = (hole_list[i - 1].get_Starting_Address()) + (hole_list[i - 1].get_Size()); }
                }
                else { start = (hole_list[i - 1].get_Starting_Address()) + (hole_list[i - 1].get_Size()); }
                // putting old process in history_list
                Mem_History history_element = new Mem_History();
                history_element.set_Name("Old Process" + (-1 * old_number));
                history_element.set_Start(start);
                history_element.set_End(hole_list[i].get_Starting_Address() - 1);
                history_element.set_Id(old_number);
                history_list.Add(history_element);
                // putting old process in segment_list
                Segment segment = new Segment();
                segment.set_Name("Old Process" + (-1 * old_number));
                segment.set_Process_ID(old_number);
                segment.set_Size((hole_list[i].get_Starting_Address()) - start);
                segment_list.Add(segment);
                old_number--;
            }

        }

    }


}

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
    public partial class Form1 : Form
    {
        public static string memory_size;
        public static string no_of_processes;
        public static string no_of_holes;

        public Form1()
        {
            InitializeComponent();
        }

        private void Sub_initial_Click(object sender, EventArgs e)
        {
            memory_size = tbMem_Size.Text;
            no_of_holes = tbNo_holes.Text;
            no_of_processes = tbNo_processes.Text;

            Form2 form = new Form2();

            form.ShowDialog();
        }
    }
}

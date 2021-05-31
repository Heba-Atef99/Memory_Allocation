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
    public partial class Form1 : Form
    {
        public static int mem_size;
        public static int num_holes; //number of holes
        public static int num_process;//number of process
        public static int key;
        public Form1()
        {
            InitializeComponent();
        }

        private void Sub_initial_Click(object sender, EventArgs e)
        {

           
           
           
            
            mem_size =  Int32.Parse( tbMem_Size.Text);
            num_holes = Int32.Parse( tbNo_holes.Text);
            num_process =Int32.Parse( tbNo_processes.Text);
             key = ((KeyValuePair<int, string>)comboBox1.SelectedItem).Key;

            Form2 form = new Form2();

            form.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
           
            comboSource.Add(1, "First fit");
            comboSource.Add(2, "Best fit");
            comboSource.Add(3, "Worst fit");
            comboBox1.DataSource = new BindingSource(comboSource, null);
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.SelectedItem = null;


        }
    }
}

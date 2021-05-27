using System;
using System.Collections.Generic;
using System.Text;

namespace mem_allocation
{
    class Segment
    {
        
        private string Name;
        private int Size;
        private int Process_ID;
        public Segment()
        {

        }
        public void set_Name(string Name)
        {
            this.Name = Name;
        }
        public string get_Name()
        {
            return this.Name;
        }
        
        public void set_Size(int Size)
        {
            this.Size = Size;
        }
        public int get_Size()
        {
            return this.Size;
        }
        public void set_Process_ID(int Process_ID)
        {
            this.Process_ID = Process_ID;
        }
        public int get_Process_ID()
        {
            return this.Process_ID;
        }


    }
}

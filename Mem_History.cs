using System;
using System.Collections.Generic;
using System.Text;

namespace mem_allocation
{
    class Mem_History
    {
        private string Name;
        private int Start;
        private int End;
        public Mem_History()
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
        public void set_Start(int Start)
        {
            this.Start = Start;
        }
        public int get_Start()
        {
            return this.Start;
        }
        public void set_End(int End)
        {
            this.End = End;
        }
        public int get_End()
        {
            return this.End;
        }


    }
}

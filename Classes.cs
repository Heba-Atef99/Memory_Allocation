using System;
using System.Collections.Generic;
using System.Text;

namespace classes
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

    class Classes
    {
        private int Hole_ID;
        private int Starting_Address;
        private int Size;
        public Classes()
        {
        }
        public void set_Hole_ID(int Hole_ID)
        {
            this.Hole_ID = Hole_ID;
        }
        public int get_Hole_ID()
        {
            return this.Hole_ID;
        }
        public void set_Starting_Address(int Starting_Address)
        {
            this.Starting_Address = Starting_Address;
        }
        public int get_Starting_Address()
        {
            return this.Starting_Address;
        }
        public void set_Size(int Size)
        {
            this.Size = Size;
        }
        public int get_Size()
        {
            return this.Size;
        }

    }
}

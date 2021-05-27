using System;
using System.Collections.Generic;
using System.Text;

namespace classes
{
    class Hole
    {
        private int Hole_ID;
        private int Starting_Address;
        private int Size;
        public Hole()
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

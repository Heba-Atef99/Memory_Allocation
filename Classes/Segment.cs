using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace classes
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

        public void allocate( Hole h,ref List<Mem_History> history_list,ref List<Hole> hole_list)
        {

            //sort history_list 
            history_list = history_list.OrderBy(s => s.get_Start()).ToList();

            //sort holes_list
            hole_list=hole_list.OrderBy(s=>s.get_Starting_Address()).ToList();
            
            int difference = h.get_Size()-this.get_Size();
            if (difference < 0)
            {
                Console.WriteLine("the segment is larger than the hole");
                return;
            }
            //insert the segment in the hole choosen
            for (int i = 0; i < history_list.Count; i++)
            {
                if(history_list[i].get_Start()==h.get_Starting_Address())
                {
                    history_list[i].set_Name ("P"+this.get_Process_ID() +":"+this.get_Name());
                    history_list[i].set_End(history_list[i].get_Start()+this.get_Size()-1);
                    
                    break;
                }
            }
            // adjust the remaining part of the hole
            for (int i=0;i<hole_list.Count;i++)
            {
                if (hole_list[i].get_Hole_ID()==h.get_Hole_ID())
                {
                    //if there is no remaining space in the hole then remove the entry of this hole from holes_list
                    if (difference == 0)
                    {
                        hole_list.RemoveAt(i);
                        //renamin the holes after removing one 
                        hole_list = hole_list.OrderBy(Hole => Hole.get_Starting_Address()).ToList();
                        for (int j = 0; j < hole_list.Count; j++)
                        {
                            hole_list[j].set_Hole_ID(j);
                            int add = hole_list[j].get_Starting_Address();
                            history_list[history_list.FindIndex(a => a.get_Start() == add)].set_Name("Hole" + j);
                            
                        }

                    }
                    // add an entry in history_list for the remaining space in the hole
                    else
                    {
                        //adjust the size of the hole 
                        hole_list[i].set_Size(hole_list[i].get_Size() - this.get_Size());
                        hole_list[i].set_Starting_Address(hole_list[i].get_Starting_Address() + this.get_Size());
                        // add an entry in history_list for the remaining space in the hole
                        Mem_History m =new Mem_History();
                        m.set_Name("Hole" + h.get_Hole_ID());
                        m.set_Start(hole_list[i].get_Starting_Address());
                        m.set_End(hole_list[i].get_Starting_Address() + hole_list[i].get_Size()-1);
                        history_list.Add(m);
                        break;
                    }
                    
                }
            }
            history_list = history_list.OrderBy(s => s.get_Start()).ToList();
            hole_list = hole_list.OrderBy(s => s.get_Starting_Address()).ToList();
            
        }
    }
}

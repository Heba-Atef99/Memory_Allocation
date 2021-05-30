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

        public void allocate(Hole h, ref List<Mem_History> history_list, ref List<Hole> hole_list)
        {

            //sort history_list 
            history_list = history_list.OrderBy(s => s.get_Start()).ToList();

            //sort holes_list
            hole_list = hole_list.OrderBy(s => s.get_Starting_Address()).ToList();

            int difference = h.get_Size() - this.get_Size();
            if (difference < 0)
            {
                // Console.WriteLine("the segment is larger than the hole");
                return;
            }
            //insert the segment in the hole choosen
            for (int i = 0; i < history_list.Count; i++)
            {
                if (history_list[i].get_Start() == h.get_Starting_Address())
                {
                    history_list[i].set_Name("P" + this.get_Process_ID() + ":" + this.get_Name());
                    history_list[i].set_Id(this.get_Process_ID());
                    history_list[i].set_End(history_list[i].get_Start() + this.get_Size() - 1);

                    break;
                }
            }
            // adjust the remaining part of the hole
            for (int i = 0; i < hole_list.Count; i++)
            {
                if (hole_list[i].get_Hole_ID() == h.get_Hole_ID())
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
                        Mem_History m = new Mem_History();
                        m.set_Name("Hole" + h.get_Hole_ID());
                        m.set_Start(hole_list[i].get_Starting_Address());
                        m.set_End(hole_list[i].get_Starting_Address() + hole_list[i].get_Size() - 1);
                        history_list.Add(m);
                        break;
                    }

                }
            }
            history_list = history_list.OrderBy(s => s.get_Start()).ToList();
            hole_list = hole_list.OrderBy(s => s.get_Starting_Address()).ToList();

        }
        public void Deallocate(ref List<Mem_History> history_list, ref List<Hole> hole_list)
        {
            int find1 = 0; int find2 = 0; int find3 = 0;
            // history must be sorted before anything
            history_list = history_list.OrderBy(Hole => Hole.get_Start()).ToList();
            // to get name and search in history list
            string name;
            if (this.Name.StartsWith("O")) // old process
                name = this.Name;
            else // segment of a new process
                name = "P" + this.Process_ID + ":" + this.Name;
            // search in history by this name and get the index
            int history_index = history_list.FindIndex(a => a.get_Name() == name);
            if (history_index == -1)
            { }
            else
            {
                // To check for adjacent upper hole 
                if (history_index > 0)
                {
                    if ((history_list[history_index - 1].get_Name().StartsWith("H")))
                    {
                        // combine 2 holes
                        history_list[history_index].set_Start(history_list[history_index - 1].get_Start());
                        // remove upper hole from hole list
                        find1 = history_list[history_index - 1].get_Start();
                        hole_list.RemoveAt(hole_list.FindIndex(a => a.get_Starting_Address() == find1));
                        // remove upper hole from history list
                        history_list.RemoveAt(history_index - 1);
                        history_index--;

                    }
                }

                // To check for adjacent lower hole
                if (history_index < (history_list.Count - 1))
                {
                    if ((history_list[history_index + 1].get_Name().StartsWith("H")))
                    {
                        // combine 2 holes
                        history_list[history_index].set_End(history_list[history_index + 1].get_End());
                        // remove lower hole from hole list
                        find2 = history_list[history_index + 1].get_Start();
                        hole_list.RemoveAt(hole_list.FindIndex(a => a.get_Starting_Address() == find2));
                        // remove lower hole from history list
                        history_list.RemoveAt(history_index + 1);
                    }
                }

                // To insert the new hole in hole list
                Hole new_hole = new Hole();
                new_hole.set_Starting_Address(history_list[history_index].get_Start());
                new_hole.set_Size((history_list[history_index].get_End()) - (history_list[history_index].get_Start()) + 1);
                hole_list.Add(new_hole);
                // To give this new hole id and update rest of ids and change name in history 
                hole_list = hole_list.OrderBy(Hole => Hole.get_Starting_Address()).ToList();
                for (int i = 0; i < hole_list.Count; i++)
                {
                    hole_list[i].set_Hole_ID(i);
                    find3 = hole_list[i].get_Starting_Address();
                    history_list[history_list.FindIndex(a => a.get_Start() == find3)].set_Name("Hole" + i);
                }
                // to sort history again
                history_list = history_list.OrderBy(Hole => Hole.get_Start()).ToList();
            }


        }
    }
}

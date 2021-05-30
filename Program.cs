using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using classes;
namespace mem_allocation
{


    class Program
    {

        static void Main(string[] args)
        {
            int mem_size;
            int num_holes; //number of holes
            int num_process;//number of process
            List<Hole> hole_list = new List<Hole>();
            List<Segment> segment_list = new List<Segment>();
            List<Mem_History> history_list = new List<Mem_History>();
            //string type_method;
            //Console.WriteLine("enter mem_size ");
            mem_size = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("enter number of holes ");
            num_holes = Convert.ToInt32(Console.ReadLine());
            //enter all holes
            for (int i = 0; i < num_holes; i++)
            {
                Hole hole = new Hole();// var to take hole from user and adding to hole_list
                //Console.WriteLine("enter  starting address for hole " + i);
                hole.set_Hole_ID(i);
                hole.set_Starting_Address(Convert.ToInt32(Console.ReadLine()));
                //Console.WriteLine("enter size for hole " + i);
                hole.set_Size(Convert.ToInt32(Console.ReadLine()));
                hole_list.Add(hole);
                // Adding holes in history_list
                Mem_History history_element = new Mem_History();
                history_element.set_Name("Hole" + i);
                history_element.set_Start(hole.get_Starting_Address());
                history_element.set_End((hole.get_Starting_Address()) + (hole.get_Size()) - 1);
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

            //Console.WriteLine("enter number of process ");
            num_process = Convert.ToInt32(Console.ReadLine());
            //enter all processes
            for (int j = 0; j < num_process; j++)
            {
                int num_segment;//number of segment
                //Console.WriteLine("enter number of segment for process " + j);
                num_segment = Convert.ToInt32(Console.ReadLine());
                //enter all segments
                for (int i = 0; i < num_segment; i++)
                {
                    Segment segment = new Segment();// var to take Segment from user and adding to Segment_list
                    //Console.WriteLine("enter  name of Segment " + i);
                    segment.set_Process_ID(j);
                    segment.set_Name(Console.ReadLine());
                    //Console.WriteLine("enter size for Segment " + i);
                    segment.set_Size(Convert.ToInt32(Console.ReadLine()));
                    segment_list.Add(segment);

                }

            }
            //Console.WriteLine("enter  method of allocation (first fit or best fit). ");
            //type_method = Console.ReadLine();
            int p_id = 0;
            Boolean b = Worst_Fit(ref segment_list, ref history_list, ref hole_list, ref p_id);

           // Boolean b = First_Fit(ref segment_list, ref history_list, ref hole_list, ref p_id);
            if (b == false)
            {
                Console.WriteLine("enter Process Id you want to remove");

                int pn;
                pn = Convert.ToInt32(Console.ReadLine());
                deal(pn, ref segment_list, ref history_list, ref hole_list);
            }


        }
        //delete what user want remove from mem history and segment
        public static void deal(int pn, ref List<Segment> segment_list, ref List<Mem_History> history_list, ref List<Hole> hole_list)
        {
            for (int i = 0; i < segment_list.Count(); i++)
            {
                if (segment_list[i].get_Process_ID() == pn)
                {
                    
                    segment_list[i].Deallocate(ref history_list, ref hole_list);
                    segment_list.Remove(segment_list[i]);
                }

            }

        }
        public static Boolean First_Fit(ref List<Segment> segment_list, ref List<Mem_History> history_list, ref List<Hole> hole_list, ref int p_id)
        {
            int flag;
            //Mem_History index =new Mem_History();//result of find segment in meme history
            int index1;
            int index2;
            //Segment s = new Segment();
            for (int i = 0; i < segment_list.Count(); i++)
            {
                int add = segment_list[i].get_Process_ID();
                string s = segment_list[i].get_Name();
                flag = 0;
                history_list = history_list.OrderBy(s => s.get_Start()).ToList();//here
                index1 = history_list.FindIndex(x => x.get_Name() ==
                ("p" + Convert.ToString(add) + ":" + s));
                index2 = history_list.FindIndex(x => x.get_Name() == s);

                if (index1 == -1 && index2 == -1)
                {
                    for (int j = 0; j < history_list.Count(); j++)
                    {

                        if ((history_list[j].get_End() - history_list[j].get_Start() + 1)
                            >= segment_list[i].get_Size() && history_list[j].get_Id() == null)
                        {
                            Hole h = new Hole();
                            for (int k = 0; k < hole_list.Count(); k++)
                            {
                                if (hole_list[k].get_Starting_Address() == history_list[j].get_Start())
                                {
                                    h = hole_list[k];
                                }

                            }

                            segment_list[i].allocate(h, ref history_list, ref hole_list);
                            flag = 1;
                            break;
                        }

                    }
                    if (flag == 0)
                    {
                        p_id = segment_list[i].get_Process_ID();
                        for (int l = 0; l < segment_list.Count(); l++)
                        {
                            if (segment_list[l].get_Process_ID() == p_id)
                            {
                                segment_list[l].Deallocate(ref history_list, ref hole_list);
                            }

                        }
                        return false;
                    }
                }

            }

            return true;

        }
        public static Boolean Best_Fit(ref List<Segment> segment_list, ref List<Mem_History> history_list, ref List<Hole> hole_list, ref int p_id)
        {
            int flag;
            //Mem_History index =new Mem_History();//result of find segment in meme history
            int index1;
            int index2;
            //Segment s = new Segment();
            for (int i = 0; i < segment_list.Count(); i++)
            {
                int add = segment_list[i].get_Process_ID();
                string s = segment_list[i].get_Name();
                flag = 0;
                history_list = history_list.OrderBy(s => (s.get_End()- s.get_Start()+1)).ToList();//here
                index1 = history_list.FindIndex(x => x.get_Name() ==
                ("p" + Convert.ToString(add) + ":" + s));
                index2 = history_list.FindIndex(x => x.get_Name() == s);

                if (index1 == -1 && index2 == -1)
                {
                    for (int j = 0; j < history_list.Count(); j++)
                    {

                        if ((history_list[j].get_End() - history_list[j].get_Start() + 1)
                            >= segment_list[i].get_Size() && history_list[j].get_Id() == null)
                        {
                            Hole h = new Hole();
                            for (int k = 0; k < hole_list.Count(); k++)
                            {
                                if (hole_list[k].get_Starting_Address() == history_list[j].get_Start())
                                {
                                    h = hole_list[k];
                                }

                            }

                            segment_list[i].allocate(h, ref history_list, ref hole_list);
                            flag = 1;
                            break;
                        }

                    }
                    if (flag == 0)
                    {
                        p_id = segment_list[i].get_Process_ID();
                        for (int l = 0; l < segment_list.Count(); l++)
                        {
                            if (segment_list[l].get_Process_ID() == p_id)
                            {
                                segment_list[l].Deallocate(ref history_list, ref hole_list);
                            }

                        }
                        return false;
                    }
                }

            }

            return true;

        }
        public static Boolean Worst_Fit(ref List<Segment> segment_list, ref List<Mem_History> history_list, ref List<Hole> hole_list, ref int p_id)
        {
            int flag;
            //Mem_History index =new Mem_History();//result of find segment in meme history
            int index1;
            int index2;
            //Segment s = new Segment();
            for (int i = 0; i < segment_list.Count(); i++)
            {
                int add = segment_list[i].get_Process_ID();
                string s = segment_list[i].get_Name();
                flag = 0;
                history_list = history_list.OrderByDescending(s => (s.get_End() - s.get_Start() + 1)).ToList();//here
                index1 = history_list.FindIndex(x => x.get_Name() ==
                ("p" + Convert.ToString(add) + ":" + s));
                index2 = history_list.FindIndex(x => x.get_Name() == s);

                if (index1 == -1 && index2 == -1)
                {
                    for (int j = 0; j < history_list.Count(); j++)
                    {

                        if ((history_list[j].get_End() - history_list[j].get_Start() + 1)
                            >= segment_list[i].get_Size() && history_list[j].get_Id() == null)
                        {
                            Hole h = new Hole();
                            for (int k = 0; k < hole_list.Count(); k++)
                            {
                                if (hole_list[k].get_Starting_Address() == history_list[j].get_Start())
                                {
                                    h = hole_list[k];
                                }

                            }

                            segment_list[i].allocate(h, ref history_list, ref hole_list);
                            flag = 1;
                            break;
                        }

                    }
                    if (flag == 0)
                    {
                        p_id = segment_list[i].get_Process_ID();
                        for (int l = 0; l < segment_list.Count(); l++)
                        {
                            if (segment_list[l].get_Process_ID() == p_id)
                            {
                                segment_list[l].Deallocate(ref history_list, ref hole_list);
                            }

                        }
                        return false;
                    }
                }

            }

            return true;

        }


    }
}

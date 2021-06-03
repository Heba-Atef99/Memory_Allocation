using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using classes;

namespace memory_blocks.AllocationMethods
{
    public class AlloctionMethods
    {
        public static void deal(int pn, ref List<Segment> segment_list, ref List<Mem_History> history_list, ref List<Hole> hole_list)
        {
            int index = history_list.FindIndex(x => x.get_Id() == pn); ;

            for (int i = 0; i < segment_list.Count(); i++)
            {
                if (segment_list[i].get_Process_ID() == pn && index != -1)
                {

                    segment_list[i].Deallocate(ref history_list, ref hole_list);
                    segment_list.Remove(segment_list[i]);
                    i = i - 1;
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
                history_list = history_list.OrderBy(s1 => s1.get_Start()).ToList();//here
                index1 = history_list.FindIndex(x => x.get_Name() ==
                ("P" + Convert.ToString(add) + ":" + s));
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
                history_list = history_list.OrderBy(s1 => (s1.get_End() - s1.get_Start() + 1)).ToList();//here
                index1 = history_list.FindIndex(x => x.get_Name() ==
                ("P" + Convert.ToString(add) + ":" + s));
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
                history_list = history_list.OrderByDescending(s1 => (s1.get_End() - s1.get_Start() + 1)).ToList();//here
                index1 = history_list.FindIndex(x => x.get_Name() ==
                ("P" + Convert.ToString(add) + ":" + s));
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

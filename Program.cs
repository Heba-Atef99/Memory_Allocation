using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            string type_method;
            Console.WriteLine("enter mem_size ");
            mem_size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter number of holes ");
            num_holes = Convert.ToInt32(Console.ReadLine());
            //enter all holes
            for(int i = 0; i < num_holes; i++)
            {
                Hole hole = new Hole();// var to take hole from user and adding to hole_list
                Console.WriteLine("enter  starting address for hole "+ i);
                hole.set_Hole_ID(i);
                hole.set_Starting_Address(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("enter size for hole " + i);
                hole.set_Size(Convert.ToInt32(Console.ReadLine()));
                hole_list.Add(hole);


            }
            Console.WriteLine("enter number of process ");
            num_process = Convert.ToInt32(Console.ReadLine());
            //enter all processes
            for(int j=0;j< num_process; j++)
            {
                int num_segment;//number of segment
                Console.WriteLine("enter number of segment for process "+j);
                num_segment = Convert.ToInt32(Console.ReadLine());
                //enter all segments
                for (int i = 0; i < num_segment; i++)
                {             
                    Segment segment = new Segment();// var to take Segment from user and adding to Segment_list
                    Console.WriteLine("enter  name of Segment " + i);
                    segment.set_Process_ID(i);
                    segment.set_Name(Console.ReadLine());
                    Console.WriteLine("enter size for Segment " + i);
                    segment.set_Size(Convert.ToInt32(Console.ReadLine()));
                    segment_list.Add(segment);
                }

            }
            Console.WriteLine("enter  method of allocation (first fit or best fit). " );
            type_method = Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JCompareCS
{
    class Program
    {
        static void Main(string[] args)
        {
            JCompareCore core = new JCompareCore();

            string srcFile = "C:\\Users\\Lee SunHyung\\Documents\\Visual Studio 2012\\Projects\\AlgorithmsPractice\\Algorithm1\\Algorithm1.cpp";
            string dstFile = "C:\\Users\\Lee SunHyung\\Documents\\Visual Studio 2012\\Projects\\AlgorithmsPractice\\Algorithm2\\Algorithm2.cpp";

            StreamReader srSource = new StreamReader(srcFile);
            while (srSource.Peek() >= 0)
            {
                core.AddSourceLine(srSource.ReadLine());
            }
            srSource.Close();

            StreamReader srDest = new StreamReader(dstFile);
            while (srDest.Peek() >= 0)
            {
                core.AddDestinationLine(srDest.ReadLine());
            }
            srDest.Close();

            core.DoCompare();
            for (int i = 0; i < core.GetResultCount(); i++)
            {
                CompareElement item = core.GetResultItem(i);
                Console.WriteLine("Source line : {0}, Destination line : {1}, Line count of same contents : {2}", item.srcStartIndex, item.dstStartIndex, item.lineCountOfSameContext);
            }
        }
    }
}

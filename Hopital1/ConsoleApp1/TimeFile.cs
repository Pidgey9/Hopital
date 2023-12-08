using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ConsoleApp1
{
    class TimeFile
    {
        public void File()
        {
            string path = @"D:\GitHub\Hopital\fichiersPatients.txt";
            // incrément pas bon mais le texte avec temps bien
            int increment = 1;
            try
            {
                StreamReader sr = new StreamReader(path);
                string text = sr.ReadToEnd();
                sr.Close();
                text += increment + "\t" + DateTime.Now;
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(path);
                //Write a line of text
                sw.WriteLine(text);
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }
    }
}

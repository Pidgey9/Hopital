using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Gestions;

namespace ConsoleApp2
{
    class TimeFile
    {
        public void File(Patients p)
        {
            string path = @"D:\GitHub\Hopital\ProjetHopital\fichiersPatients.txt";
            try
            {
                StreamReader sr = new StreamReader(path);
                string text = sr.ReadToEnd();
                sr.Close();
                text += DateTime.Now + "\t" + p.Id + "\t" + p.Prenom + "\t" +p.Nom;
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

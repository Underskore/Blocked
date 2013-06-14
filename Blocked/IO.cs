using System.IO;

namespace Blocked
{
    class IO
    {

        public class get
        {

            public string[] objects(string filename)
            {
                string rawtext = getRawText(filename);
                int amountofobjects = getAmountOfObjects(rawtext);
                string[] rawobjects = getRawObjects(rawtext, amountofobjects);
                return rawobjects;
            }

            string getRawText(string filename)
            {
                StreamReader sr = new StreamReader(filename);
                return sr.ReadToEnd();
            }

            int getAmountOfObjects(string rawtext)
            {
                StringReader sr = new StringReader(rawtext);
                string line = sr.ReadLine(); int i = 0;
                while (line != "objects[") line = sr.ReadLine();
                while (line != "]") { line = sr.ReadLine(); if (line != "]") i++; }
                return i;
            }

            string[] getRawObjects(string rawtext, int amountofobjects)
            {
                StringReader sr = new StringReader(rawtext);
                string line = sr.ReadLine(); int i = 0; string[] objects = new string[amountofobjects];
                while (line != "objects[") line = sr.ReadLine();
                while (line != "]") { line = sr.ReadLine(); if (line != "]") { objects[i] = line; i++; } }
                return objects;
            }
            
        }

    }
}

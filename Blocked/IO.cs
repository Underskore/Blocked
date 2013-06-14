using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

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
                for (int i = 0; i < rawobjects.Length; i++) PutObjectsInList(rawobjects[i]);
                return rawobjects;
            }

            private string getRawText(string filename)
            {
                StreamReader sr = new StreamReader(filename);
                return sr.ReadToEnd();
            }

            private int getAmountOfObjects(string rawtext)
            {
                StringReader sr = new StringReader(rawtext);
                string line = sr.ReadLine(); int i = 0;
                while (line != "objects[") line = sr.ReadLine();
                while (line != "]") { line = sr.ReadLine(); if (line != "]") i++; }
                return i;
            }

            private string[] getRawObjects(string rawtext, int amountofobjects)
            {
                StringReader sr = new StringReader(rawtext);
                string line = sr.ReadLine(); int i = 0; string[] objects = new string[amountofobjects];
                while (line != "objects[") line = sr.ReadLine();
                while (line != "]") { line = sr.ReadLine(); if (line != "]") { objects[i] = line; i++; } }
                return objects;
            }

            public List<Object> objs = new List<Object>();
            private void addObject(string oclass, string oname, Point opoint, Size osize, string otext = "", string osource = "")
            {
                Object obj = new Object();
                obj.oclass = oclass;
                obj.oname = oname;
                obj.opoint = opoint;
                obj.osize = osize;
                obj.otext = otext;
                objs.Add(obj);
            }

            private void PutObjectsInList(string obj)
            {
             //   MessageBox.Show(obj);
                string oclass = getObjectMember(obj, "class");
                string oname, otext, osource;
                Point opoint;
                Size osize;
                oname = getObjectMember(obj, "name");
                osize = getObjectMemberS(obj, "size");
                opoint = getObjectMemberP(obj, "point");

                switch (oclass)
                {
                    case "textbox":
                        otext = getObjectMember(obj, "text");
                        addObject(oclass, oname, opoint, osize, otext);
                        break;

                    case "image":
                        osource = getObjectMember(obj, "source");
                        addObject(oclass, oname, opoint, osize, osource);
                        break;

                    case "link":
                        osource = getObjectMember(obj, "source");
                        addObject(oclass, oname, opoint, osize, osource);
                        break;
                }

            }

            private string getObjectMember(string obj, string member)
            {
                    string c1 = obj.Split(new string[] { member + "='" }, StringSplitOptions.None)[1];
                    int c2 = c1.IndexOf("'");
                    string o = c1.Remove(c2, c1.Length - c2);
                    return o;
            }

            private Point getObjectMemberP(string obj, string member)
            {
                string c1 = obj.Split(new string[] { member + "=(" }, StringSplitOptions.None)[1];
                int c2 = c1.IndexOf(")");
                string c3 = c1.Remove(c2, c1.Length - c2);
                int x = Convert.ToInt32((c3.Split(','))[0]);
                int y = Convert.ToInt32((c3.Split(','))[1]);
                Point pt = new Point(x,y);
                return pt;
            }

            private Size getObjectMemberS(string obj, string member)
            {
                string c1 = obj.Split(new string[] { member + "=(" }, StringSplitOptions.None)[1];
                int c2 = c1.IndexOf(")");
                string c3 = c1.Remove(c2, c1.Length - c2);
                int x = Convert.ToInt32((c3.Split(','))[0]);
                int y = Convert.ToInt32((c3.Split(','))[1]);
                Size sz = new Size(x,y);
                return sz;
            }
        }

    }
}

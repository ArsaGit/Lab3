using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Lab3
{
    class InputOutput
    {
        static public string GetPath(string path = "input.txt")
        {
            string filePath = Environment.CurrentDirectory;
            filePath = filePath.Substring(0, filePath.IndexOf("bin")) + path;
            return filePath;
        }
        static public string ReadInput()
        {
            string path = GetPath();
            string text;
            using (StreamReader sr=new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }
        static public void WriteOutput(string table)
        {
            string path = GetPath("output.txt");
            using (StreamWriter sw=new StreamWriter(path))
            {
                sw.Write(table);
            }
        }
    }
}

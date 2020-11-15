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
        static public string ReadFromFile(string file="input.txt")
        {
            string path = GetPath(file);
            string text;
            using (StreamReader sr=new StreamReader(path))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }
        static public void WriteInFile(string content,string file="output.txt")
        {
            string path = GetPath(file);
            using (StreamWriter sw=new StreamWriter(path))
            {
                sw.Write(content);
            }
        }
    }
}

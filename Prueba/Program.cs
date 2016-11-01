using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {

            string fichero = "Prueba.txt";
            string sourcePath = @"C:\Users\Pajar\Documents\GitHub\DI-07-Controls\Ejercicio ProgressBar\Ficheros";
            string targetPath = @"C:\Users\Pajar\Desktop\Prueba";
            string fileName, destFile;
            string[] files = System.IO.Directory.GetFiles(sourcePath);

            // Copy the files and overwrite destination files if they already exist.
            foreach (string s in files)
            {
                // Use static Path methods to extract only the file name from the path.
                fileName = System.IO.Path.GetFileName(s);
                destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(s, destFile, true);
                //Barrita.Value+= 10;
            }
            
        }
    }
}

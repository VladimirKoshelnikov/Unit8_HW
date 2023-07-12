using System;
using System.IO;

namespace Task2{
    class Program{
        static void Main(){
            FolderVolume fv1 = new FolderVolume(@"");
            FolderVolume fv2 = new FolderVolume(@"C:\SF");
            FolderVolume fv3 = new FolderVolume(@"snjasfokmweokmaw");
            FolderVolume fv4 = new FolderVolume(@"|");
            FolderVolume fv5 = new FolderVolume(@"D:\skill");
            Console.ReadLine();
        }
    }
}


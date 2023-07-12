using System;
using System.IO;

namespace Task1{
    class Program{
    
        static void Main(){

            FolderCleaner testTask1= new FolderCleaner("");
            FolderCleaner testTask2 = new FolderCleaner("UncorrectSymbol|"); 
            FolderCleaner testTask3 = new FolderCleaner(@"C:/PathOfDegrafation");        
            FolderCleaner testTask4 = new FolderCleaner("PathOfDegrafation");
            FolderCleaner testTask5 = new FolderCleaner(@"C:/SF");  
            FolderCleaner testTask6 = new FolderCleaner("SF");     
            Console.ReadLine();
        }
    }
}


using System;
using System.IO;

namespace Task3{
    class Program{
        static void Main(){
            
            FolderVolume fv = new FolderVolume();
            FolderCleaner fc = new FolderCleaner();
            long folderVolumeBefore;
            long folderVolumeAfter;

            Console.WriteLine("Введите директорию для очистки");
            string workDirectory = Console.ReadLine();
            
            Console.WriteLine($"Выбрана папка: {workDirectory}");
            
            folderVolumeBefore = fv.GetFolderVolume(workDirectory); 
            Console.WriteLine($"Исходный объем папки: {folderVolumeBefore} байт");
            

            fc.DeleteOldFiles(workDirectory);
            folderVolumeAfter = fv.GetFolderVolume(workDirectory); 
            
            Console.WriteLine($"Было удалено {folderVolumeBefore - folderVolumeAfter} байт");
            Console.WriteLine($"Текущий объем папки: {folderVolumeBefore} байт");
            Console.ReadLine();

        }
    }
}


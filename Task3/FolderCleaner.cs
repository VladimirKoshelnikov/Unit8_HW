using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task3
{
    public class FolderCleaner
    {
    private int CountFiles = 0;
    public ErrorCode isFolderPathValid(string folderPath)
    {
        int a = folderPath.IndexOfAny(Path.GetInvalidPathChars());
        if ((folderPath == null) || (folderPath =="")){  
            Console.WriteLine("Путь не введен");
            return ErrorCode.PathIsEmpty;
        }

        if ((folderPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)){
            Console.WriteLine("Введен некорректный путь к папке");
            return ErrorCode.PathIsNotCorrect;
        }
        
        try
        {
            var tempDirectoryInfo = new DirectoryInfo(folderPath);
            if (tempDirectoryInfo.Exists){
                return ErrorCode.None;
            }
            else{ 
                Console.WriteLine("Указанная папка не существует");
                return ErrorCode.FolderNotExist;    
            }    
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Не поддерживаемая ошибка");
                return ErrorCode.NotSupportedException;
            }            
        }
    public void DeleteOldFiles(string workDirectory){

        ErrorCode er = ErrorCode.None; 
        er = isFolderPathValid(workDirectory);
        if (er == ErrorCode.None){
            DirectoryInfo di = new DirectoryInfo(workDirectory);
            FileSystemInfo[] fileSystemInfos = di.GetFileSystemInfos();

            foreach(FileSystemInfo element in fileSystemInfos){
                if ((element.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly){
                    er = ErrorCode.FileOrDirectoryIsReadOnly;
                    Console.WriteLine($"Элемент {element.FullName} доступен только для чтения"); 
                }
                else
                {
                    TimeSpan interval = DateTime.Now - element.LastAccessTime;
                
                    if (interval.TotalMinutes > 30){
                        element.Delete();
                        CountFiles++;
                    }
                    else{
                        Console.WriteLine($"От последнего обращения к: {element.FullName} прошло менее 30 минут"); 
                    }
                }
            
            }
            
            Console.WriteLine($"Из папки {workDirectory} было удалено {CountFiles} файлов");    
            
        }
        
    }
    }
}
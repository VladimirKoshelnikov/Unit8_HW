using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task3
{
    
    public class FolderVolume
    {
    
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
    public long GetFolderVolume(string workDirectory){
        long result = 0;
        ErrorCode er = ErrorCode.None; 
        er = isFolderPathValid(workDirectory);
        if (er == ErrorCode.None){
                DirectoryInfo directoryInfo = new DirectoryInfo(workDirectory);
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                foreach (FileInfo fi in fileInfos){
                    result+=fi.Length;
                }
                DirectoryInfo[] directoryInfos = directoryInfo.GetDirectories();
                foreach (DirectoryInfo di in directoryInfos){
                    result+=GetFolderVolume(di.FullName);
                }
                return result;    
            }
            else{
                Console.WriteLine($"Возникла ошибка при работе с папкой {workDirectory}");
                return 0;
            }
        }    
    }


}

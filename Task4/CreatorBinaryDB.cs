using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    public class CreatorBinaryDB
    {


        public CreatorBinaryDB(){
        Student[] students = {
            new Student("Иван", "CDEV1", new DateTime(1995, 10, 25)),
            new Student("Владимир", "CDEV2", new DateTime(1995, 12, 2)),
            new Student("Илья", "CDEV3", new DateTime(1998, 1, 5)),
            new Student("Светлана", "CDEV4", new DateTime(1997, 9, 13)),
            new Student("Анастасия", "CDEV1", new DateTime(1995, 6, 8)),
            new Student("Пелагея", "CDEV2", new DateTime(1994, 3, 24)),
            new Student("Герман", "CDEV3", new DateTime(1992, 1, 12)),
            new Student("Макарий", "CDEV4", new DateTime(1998, 9, 23))
        };
        
        

              
        BinaryFormatter bf = new BinaryFormatter();
        using (var fs = new FileStream("Students.dat", FileMode.OpenOrCreate)){
            bf.Serialize(fs, students);
        }
        }
        
    }
}
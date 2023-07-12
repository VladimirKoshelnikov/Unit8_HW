using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace FinalTask{
    class Program{
        static void Main(){
            CreatorBinaryDB c1 = new CreatorBinaryDB(); 
            // Использовать файл с сайта неполучилось, потому первично пришлось создать базу данных
            BinaryFormatter formatter = new BinaryFormatter();

            Student[] students; 
            using (FileStream fs = new FileStream("Students.dat", FileMode.OpenOrCreate))
            {
                students = (Student[])formatter.Deserialize(fs);
                /* При попытке вызвать строку 16 с файлом с сайта возникает ошибка
                Exception has occurred: CLR/System.Runtime.Serialization.SerializationException
                Необработанное исключение типа "System.Runtime.Serialization.SerializationException" в System.Runtime.Serialization.Formatters.dll: 'Unable to find assembly 'FinalTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'.'
                в System.Runtime.Serialization.Formatters.Binary.BinaryAssemblyInfo.GetAssembly()
                в System.Runtime.Serialization.Formatters.Binary.ObjectReader.GetType(BinaryAssemblyInfo assemblyInfo, String name)
                в System.Runtime.Serialization.Formatters.Binary.BinaryTypeConverter.TypeFromInfo(BinaryTypeEnum binaryTypeEnum, Object typeInformation, ObjectReader objectReader, BinaryAssemblyInfo assemblyInfo, InternalPrimitiveTypeE& primitiveTypeEnum, String& typeString, Type& type, Boolean& isVariant)
                в System.Runtime.Serialization.Formatters.Binary.BinaryParser.ReadArray(BinaryHeaderEnum binaryHeaderEnum)
                в System.Runtime.Serialization.Formatters.Binary.BinaryParser.Run()
                в System.Runtime.Serialization.Formatters.Binary.ObjectReader.Deserialize(BinaryParser serParser)
                в System.Runtime.Serialization.Formatters.Binary.BinaryFormatter.Deserialize(Stream serializationStream)
                в FinalTask.Program.Main() в D:\skill\Unit8_HW\Task4\Program.cs:строка 16
                */
            }

            string pathFile = @"C:\Users\Владимир\Desktop\Students\";
            Directory.CreateDirectory(pathFile);

            //
            // По заданию необходимо загружать данные из бинарного формата в текст
            // Про удаление предыдущих в задании ничего не сказано, потому при повторном запуске возникают дубликаты 
            //

            foreach (Student student in students){
                string fullPathFile = pathFile + student.Group + ".txt";
                FileInfo fi = new FileInfo(fullPathFile);
                using (StreamWriter sw = fi.AppendText()){
                    sw.WriteLine(($"{student.Name}, {student.DateOfBirth}"));
                }
            }
        }

    }
}
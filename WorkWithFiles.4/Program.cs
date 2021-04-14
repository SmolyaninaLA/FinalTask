using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace FinalTask
{
    [Serializable]
    public class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public  DateTime DateOfBirth { get; set; }

        public Student(string name, string group, DateTime dateOfBirth)
        {
            Name = name;
            Group = group;
            DateOfBirth = dateOfBirth;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
         {
            
            string pathIn = @"C:\TaskDir\Students.dat";
            string pathOut = @"C:\Users\Smolyaninala\Desktop\Students";
         
            string newFile;

            if (!File.Exists(pathIn))
            {
                Console.WriteLine("Файл не сущемтвует.");
            }
            else
            {
                if (!Directory.Exists(pathOut))
                {
                    Directory.CreateDirectory(pathOut);
                }


                BinaryFormatter formatter = new BinaryFormatter();

                using (var fs = new FileStream(pathIn, FileMode.Open ))
                {
                    Student[] newStudent = (Student[])formatter.Deserialize(fs);
                    foreach (Student student in newStudent)
                    {
                        newFile = pathOut + student.Group + ".txt";
                        var fl = new FileInfo(newFile);
                        if (!File.Exists(newFile))
                        {

                            using (StreamWriter sw = fl.CreateText())
                            {
                                sw.WriteLine($"Имя: {student.Name} ---- Дата Рождения: {student.DateOfBirth}");
                            }
                        }
                        else
                        {
                            using (StreamWriter sw = fl.AppendText())
                            {
                                sw.WriteLine($"Имя: {student.Name} ---- Дата Рождения: {student.DateOfBirth}");
                            }

                        }
                    }  
                }
              
            }

            Console.ReadLine();
        }
            
     }
 

}
 



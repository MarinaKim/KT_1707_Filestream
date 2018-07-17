using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace FileStream_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the task num: ");
            int num = Int32.Parse(Console.ReadLine());
            Random rnd = new Random();
            string filePath = @"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\MarFile" + rnd.Next() + ".txt";

            switch (num)
            {
                case 1:
                    {
                        //1 способ
                        using (
                        FileStream fs = new FileStream(filePath, FileMode.Create)) { } // using сам закрывает файл, не остается открытых соединений

                        //2-й способ,позволяет 
                        using (FileStream fs2 = new FileStream(filePath, FileMode.Create, FileAccess.Write)) { }

                        // 3-й вариант 
                        using (FileStream fs3 = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            Console.WriteLine(filePath);
                            Thread.Sleep(50000000);
                        }
                    }
                    break;

                case 2:
                    {
                        Console.WriteLine(filePath);
                        FileInfo file = new FileInfo(filePath);
                        if (file.Exists)
                        {
                            //var data = file.Open(FileMode.Open);
                            Console.WriteLine("-");
                        }
                        else
                        {
                            var data = file.Open(FileMode.OpenOrCreate);
                            //необходимо закрыть файл
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("File create!");
                            FileStream fs = file.Create();

                            fs.Close();
                            Console.WriteLine("File close");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    break;
                //FileInfo
                case 3:
                    {
                        string filePath1 = @"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\khsh.txt";
                        Console.WriteLine(filePath1);
                        FileInfo file = new FileInfo(filePath1);
                        if (file.Exists)
                        {
                            //var data = file.Open(FileMode.Open);
                            Console.WriteLine("-");
                            Console.WriteLine(file.Name);
                            Console.WriteLine(file.Length);
                            Console.WriteLine(file.Extension);
                            Console.WriteLine(file.DirectoryName);
                            Console.WriteLine(file.CreationTime);
                            Console.WriteLine(file.Attributes);


                        }
                        else
                        {
                            var data = file.Open(FileMode.OpenOrCreate);
                            //необходимо закрыть файл
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("File create!");
                            FileStream fs = file.Create();

                            fs.Close();
                            Console.WriteLine("File close");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    break;

                case 4:
                    {
                        string filePath1 = @"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\khsh.txt";
                        Console.WriteLine(filePath1);
                        FileInfo file = new FileInfo(filePath1);
                        if (file.Exists)
                        {
                            //var data = file.Open(FileMode.Open);
                            Console.WriteLine("-");
                            Console.WriteLine(file.Name);
                            Console.WriteLine(file.Length);
                            Console.WriteLine(file.Extension);
                            Console.WriteLine(file.DirectoryName);
                            Console.WriteLine(file.CreationTime);
                            Console.WriteLine(file.Attributes);

                            file.MoveTo(@"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\zuk Move"); // переносит файл

                        }
                        else
                        {
                            var data = file.Open(FileMode.OpenOrCreate);
                            //необходимо закрыть файл
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("File create!");
                            FileStream fs = file.Create();

                            fs.Close();
                            Console.WriteLine("File close");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    break;

                //File
                case 5:
                    {
                        File.Create(filePath);

                    }
                    break;

                //считываем file
                case 6:
                    {
                        string filePath1 = @"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\khsh.txt";
                        Console.WriteLine(filePath1);
                        FileInfo file = new FileInfo(filePath1);
                        if (file.Exists)
                        {
                            //var data = file.Open(FileMode.Open);
                            Console.WriteLine("-");
                            Console.WriteLine(file.Name);
                            Console.WriteLine(file.Length);
                            Console.WriteLine(file.Extension);
                            Console.WriteLine(file.DirectoryName);
                            Console.WriteLine(file.CreationTime);
                            Console.WriteLine(file.Attributes);
                            using (StreamWriter sw = new StreamWriter(file.Open(FileMode.OpenOrCreate)))
                            {
                                sw.Write(rnd.Next());
                            }
                            using (StreamReader sr = new StreamReader(filePath1))
                            {
                                Console.WriteLine(sr.ReadToEnd());
                            }

                        }
                        else
                        {
                            var data = file.Open(FileMode.OpenOrCreate);
                            //необходимо закрыть файл
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("File create!");
                            FileStream fs = file.Create();

                            fs.Close();
                            Console.WriteLine("File close");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                        break;
                        
                        //directory
                        case 7:
                    {
                        string filePath1 = @"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\";
                        Console.WriteLine(filePath1);
                        FileInfo file = new FileInfo(filePath1);

                        DirectoryInfo dir = new DirectoryInfo(".");//  в корне приложения
                        dir.CreateSubdirectory("test1");

                        dir = new DirectoryInfo(filePath1 + @"NEW_FOLDER_m");
                        dir.Create();
                        }
                        break;
                case 8:
                    {
                        string filePath1 = @"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\";
                        Console.WriteLine(filePath1);
                        FileInfo file = new FileInfo(filePath1);

                        DirectoryInfo dir = new DirectoryInfo(@"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\");//  в корне приложения

                        DirectoryInfo[] dirs = dir.GetDirectories();
                        foreach (DirectoryInfo folder in dirs)
                        {
                            Console.WriteLine(folder.Name);//имя
                            //Console.WriteLine(folder.FullName);//весь путь
                            Console.WriteLine(folder.Attributes);
                            foreach (FileInfo fileFolder in folder.GetFiles())
                            {
                                Console.WriteLine("-->"+fileFolder.Name);
                            }
                        }
                    }
                    break;

                case 9:
                    {
                        string filePath1 = @"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\Konstantin\Konstantin_0.txt";
                        Console.WriteLine(filePath1);
                        FileInfo file = new FileInfo(filePath1);

                        using (StreamReader sr=new StreamReader(filePath1, System.Text.Encoding.Default))
                        {
                            char[] array = new char[4];
                            sr.Read(array, 0, 4);
                            foreach (var item in array)
                            {
                                Console.WriteLine(item);
                            }

                            
                            
                        }

                        Console.WriteLine("----------------------------------------------");
                        using (StreamReader sr = new StreamReader(filePath1, System.Text.Encoding.Default))
                        {
                            int i = 0;
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                Console.WriteLine("{0}-{1}", i++, line);
                            }
                        }
                        }
                    break;

                case 10:
                    {
                        filePath = @"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\Konstantin\Konstantin_0"+ DateTime.Now.Millisecond+".txt";
                        var f=File.Create(filePath);
                        f.Close();
                        using (StreamWriter sw = new StreamWriter(filePath))
                        {
                            for (int i = 0; i < DateTime.Now.Hour; i++)
                            {
                                sw.WriteLine(i);

                            }

                            DirectoryInfo dir = new DirectoryInfo(@"\\dc\Студенты\ПКО\SMB-172.1\C#\Модуль 11\");
                            DirectoryInfo[] dirSw = dir.GetDirectories();
                            foreach (DirectoryInfo folder in dirSw)
                            {
                                string user = System.IO.File.GetAccessControl(folder.FullName).GetOwner(typeof(System.Security.Principal.NTAccount)).ToString();

                                sw.WriteLine(folder.Name + "(" + user + ")");

                                foreach (FileInfo fileFolder in folder.GetFiles())
                                {
                                    sw.WriteLine("-->" + fileFolder.Name);
                                }
                            }
                        }
                    }break;
            }
            }
        }
    }


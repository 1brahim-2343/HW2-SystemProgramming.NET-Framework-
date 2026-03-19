using HW2_SystemProgramming.NET_Framework_;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace Hw2_SystemProgramming_
{
    static class Extension
    {
        public static void ShowError(this string txt)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(txt);
            Console.ResetColor();
        }
    }
    internal class Program
    {
        static string ErrorText = "Error, try again";
 
        static Dictionary<int, Thread> threads = new Dictionary<int, Thread>();

        static void FilesStart()
        {
            FileHelper fileHelper = new FileHelper();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("File[1]\nFile[2]\nFile[3]");
                Console.WriteLine($"[NO] start fileNO creation: ");
                Console.WriteLine($"[s-NO] stop fileNO creation: ");
                Console.WriteLine($"[stop all] to stop: ");
                Console.WriteLine("[0] to leave");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "0":
                        {
                            Environment.Exit(0);
                            break;
                        }
                    case "1":
                        {
                            if (threads.ContainsKey(1))
                            {
                                ErrorText.ShowError();
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Thread file1Thread = new Thread(() =>
                                {
                                    int counter = 0;
                                    while (true)
                                    {
                                        fileHelper.CreateFile(1, ++counter);
                                        Thread.Sleep(550);
                                    }
                                });
                                file1Thread.Start();
                                threads.Add(1, file1Thread);
                            }
                            break;
                        }
                    case "s-1":
                        {
                            Thread threadToAbort;
                            if (threads.TryGetValue(1, out threadToAbort))
                            {
                                threadToAbort.Abort();
                                threads.Remove(1);
                            }
                            else
                            {
                                ErrorText.ShowError();
                                Thread.Sleep(1000);
                            }

                            break;
                        }
                    case "2":
                        {
                            if (threads.ContainsKey(2))
                            {
                                ErrorText.ShowError();
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Thread file1Thread = new Thread(() =>
                                {
                                    int counter = 0;
                                    while (true)
                                    {
                                        fileHelper.CreateFile(2, ++counter);
                                        Thread.Sleep(550);
                                    }
                                });
                                file1Thread.Start();
                                threads.Add(2, file1Thread);
                            }
                            break;
                        }
                    case "s-2":
                        {
                            Thread threadToAbort;
                            if (threads.TryGetValue(2, out threadToAbort))
                            {
                                threadToAbort.Abort();
                                threads.Remove(2);
                            }
                            else
                            {
                                ErrorText.ShowError();
                                Thread.Sleep(1000);
                            }
                            break;
                        }
                    case "3":
                        {
                            if (threads.ContainsKey(3))
                            {
                                ErrorText.ShowError();
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                Thread file1Thread = new Thread(() =>
                                {
                                    int counter = 0;
                                    while (true)
                                    {
                                        fileHelper.CreateFile(3, ++counter);
                                        Thread.Sleep(550);
                                    }
                                });
                                file1Thread.Start();
                                threads.Add(3, file1Thread);
                            }
                            break;
                        }
                    case "s-3":
                        {
                            Thread threadToAbort;
                            if (threads.TryGetValue(3, out threadToAbort))
                            {
                                threadToAbort.Abort();
                                threads.Remove(1);
                            }
                            else
                            {
                                ErrorText.ShowError();
                                Thread.Sleep(1000);
                            }

                            break;
                        }
                    case "stop all":
                        {
                            foreach (var thread in threads)
                            {
                                thread.Value.Abort();
                            }
                            break;
                        }
                    default:
                        ErrorText.ShowError();
                        break;
                }

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("[1]Go to file choice menu");
            Console.WriteLine("[0] Close");
            var choice = Console.ReadKey();
            if (choice.Key == ConsoleKey.D0)
            {
                Environment.Exit(0);
            }
            else if (choice.Key == ConsoleKey.D1)
            {
                FilesStart();

            }
        }
    }
}

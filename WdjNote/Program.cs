﻿using System;
using System.Windows.Forms;
using Model;
using Control;
using Interface;
namespace WdjNote
{
    class Program
    {
        public static User user = null;
        public static login lo = null;
        public static Form1 form = null;

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            lo = new login();
            Application.Run(lo);
        }

        public static void StartMainForm()
        {
            form = new Form1(user);
            IFileOperate fileOperate = new FileOperate();
            form.of += fileOperate.OpenFileToString;
            form.sf += fileOperate.SaveFile;
            form.Show();
        }
        
        //展示实验二菜单
        /*private static void ShowExperiment2()
        {
            Show02.ShowMainMenu();
            int i = int.Parse(System.Console.ReadLine());
            FileOperate fileOperate = new FileOperate();
            switch (i)
            {
                case 1:
                    MyFile f = Show02.CreateFileMenu();
                    fileOperate.SaveFile(f);
                    break;
                case 2:
                    string s = Show02.OpenFileMenu();
                    fileOperate.OpenFile(s);
                    break;
                case 3:
                    Console.WriteLine("请输入删除路径：");
                    string deletepath = Console.ReadLine();
                    FileOprate02.DeleteFile(deletepath);
                    break;
                case 4:
                    Show02.ShowCategoryMenu();
                    int j = int.Parse(System.Console.ReadLine());
                    Category02 category = new Category02();
                    if (j == 1)
                    {
                        Console.WriteLine("请输入新的分类名：");
                        string newcate = Console.ReadLine();
                        category.AddCategory(newcate);
                    } else
                    {
                        Console.WriteLine("请输入要删除的分类名：");
                        string deletecate = Console.ReadLine();
                        category.DeleteCategory(deletecate);
                    }
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("请输入正确指令！");
                    break;
            }
            Console.WriteLine("操作完成！");
        }

        //展示实验一菜单
        private static void ShowExperiment1()
        {
            Show01.ShowMainMenu();
            int i = int.Parse(System.Console.ReadLine());
            FileOperate fileOperate = new FileOperate();
            switch (i)
            {
                case 1:
                    MyFile f = Show01.CreateFileMenu();
                    fileOperate.SaveFile(f);
                    break;
                case 2:
                    string s = Show01.OpenFileMenu();
                    fileOperate.OpenFile(s);
                    break;
                default:
                    Console.WriteLine("请输入正确指令！");
                    break;
            }
        }*/
    }
}

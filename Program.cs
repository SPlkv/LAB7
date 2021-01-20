using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LAB7
{
    public class EventLog
    {
        string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
        string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\Log_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";

        public void CreateFile()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
                //Создание файла для записи 
            using (StreamWriter sw = File.CreateText(filepath))
            {
               sw.WriteLine("Файл журнала создан!");
            }
        }
        public void WriteToFile(string Message)
        {
           using (StreamWriter sw = File.AppendText(filepath))
           {
                sw.Write("\r\nЗапись в журнале : ");
                          sw.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                          sw.WriteLine("  :{0}", Message);
                          sw.WriteLine("----------------------------------------------------");
            }
        }
         

    }

        class Program
        {
             static void Main(string[] args)
             {
                var logger = new EventLog();
                logger.CreateFile();
                Console.WriteLine("Введите сообщение для записи в журнал событий!");
                string Message = Console.ReadLine();
                logger.WriteToFile(Message);

             }
        }
    
}

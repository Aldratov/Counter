using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Counter_v1
{
    public partial class Form1 : Form
    {
        DateTime dt1,
                 dt2;


        // string dir1 = "C:\\placeALLSetup2016\\INT";

        string dir1 = @"D:\8_temp\123";
        string reportsPath = @"D:\8_temp\123\";
        string fitschDir = @"\\placeall-pc\INT";



        //строки определяющие начачало и конец
        string startprog = "StartPlc";
        string stopprog = "PlcComplete";
        //string progName = "";
        Dictionary<string, string> pName = new Dictionary<string,string>();
        


        //класс для работы с одним запуском
        public class Work
        {
            public DateTime start { get; set; }
            public DateTime end { get; set; }
            public TimeSpan duration { get; set; }
            public TimeSpan stop { get; set; }
            public string logName{ get; set; }

        }


        public Form1()
        {
            InitializeComponent();
            //формат выбора дат
            dateTimePicker1.Format = DateTimePickerFormat.Short;

        }

        //выбор папки
        private void bt_folder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    dir1 = fbd.SelectedPath;
                    reportsPath = fbd.SelectedPath + "\\";
                    tB_currentPath.Text = fbd.SelectedPath;
                    tB_path.Text = reportsPath;
                }
            }
        }



        //обработка кнопки count
        private void bt_count_Click(object sender, EventArgs e)
        {
            countwork();

        }

        //изменение даты
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            countwork();
        }


        // при загрузке формы загрузить путь
        private void Form1_Load(object sender, EventArgs e)
        {
            tB_currentPath.Text = dir1;
            tB_path.Text = reportsPath;
        }


        //загрузка данных
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor; //установить курсор ожидания
            try
            {

                DirectoryInfo dirInfo = new DirectoryInfo(fitschDir);
                foreach (FileInfo file in dirInfo.GetFiles().Where(d=>d.LastWriteTime.Date == dt1 && d.Name.Contains("prod")))
                {
                    File.Copy(file.FullName, dir1 + "\\" + file.Name, true);
                }
                var file2 = dirInfo.GetFiles().Where(d =>d.Name.Contains("system.log")).First();
                File.Copy(file2.FullName, dir1 + "\\" + file2.Name, true);
                MessageBox.Show("Файлы загружены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Cursor = Cursors.Default;//вернуть курсор по умолчанию

        }

        private void cB_report_CheckedChanged(object sender, EventArgs e)
        {

        }


        //функция посчёта
        private void countwork()
        {
           
            //очистить словарь
            pName.Clear();
            
            
            //clear textbox
            tB_out.Text = "";


            //get date
            dt1 = dateTimePicker1.Value.Date;// получаем только дату
            dt2 = dt1.AddDays(1);

            string fullpath = "";


            //Директория с файлами логов
            var mydir = new DirectoryInfo(dir1);
            // FileInfo[] files = mydir.GetFiles().Where(file => file.LastWriteTime >= dt1 && file.LastWriteTime <= dt2).OrderBy(p => p.LastWriteTime).ToArray(); //разница между датами  отбор по дате изменения
            //CreationTime  дата создания



            //Получаем список всех файлов в массив 
            FileInfo[] files2 = mydir.GetFiles().Where(p => p.LastWriteTime.Date == dt1 && p.Name.Contains("prod")).OrderBy(p => p.LastWriteTime).ToArray();
            //.Where(file => file.LastWriteTime >= dt1 && file.LastWriteTime <= dt2);


            // Work[] work = new Work[files2.Length];  //массив

            //Создаём список запуков
            List<Work> works = new List<Work>();

            int i = 0;
            int j = 1;//счётчик запусков
            TimeSpan allDuration = new TimeSpan();//общее время запусков
            TimeSpan allStop = new TimeSpan(); //общее время простоя
            DateTime laststop = new DateTime(); // остановка предыдущей программы
            TimeSpan maxStopDuration= new TimeSpan();
            maxStopDuration = TimeSpan.FromMinutes(3);


            //Получить имя программы
            printWork();

            //перебор файлов и записываем параметры запусков
            foreach (FileInfo file in files2)
            {
                // work[i] = new Work();

                //Создаём экземпляк класса для оценки времени
                Work w1 = new Work();

                string[] lines = File.ReadAllLines(file.FullName);

                foreach (string s in lines)
                {

                    //если строка содержит startprog
                    if (s.Contains(startprog))
                    {
                        w1.start = DateTime.Parse(s.Substring(0, 19));
                        //work[i].start = DateTime.Parse(s.Substring(0, 19));
                    }


                    //если строка содержит stopprog
                    if (s.Contains(stopprog))
                    {
                        w1.end = DateTime.Parse(s.Substring(0, 19));
                        // work[i].stop = DateTime.Parse(s.Substring(0, 19));
                    }
                                      
                }

                if (w1.end == DateTime.MinValue) //Minvale как null  у DateTime
                {
                    w1.end = DateTime.Parse(lines[lines.Length - 1].Substring(0,19));
                }

                if ((w1.start.Date == dt1.Date) && (w1.end.Date == dt1.Date))
                {
                    w1.duration = w1.end.Subtract(w1.start);
                    w1.logName = file.Name;
                    works.Add(w1);
                }
                i++;

            }


            //если нужен файл отчёта
            if (cB_report.Checked)
            {
                //создаём файл отчёта
                string filename = "Report_" + dateTimePicker1.Value.ToString("ddd_dd_MMM_yyyy");
                fullpath = reportsPath + filename;

                //если файл не сущестувует
                if (!File.Exists(fullpath + ".txt"))
                {
                    File.Create(fullpath + ".txt").Dispose();
                    fullpath += ".txt";
                }
                else //создаём с новым именем добавляя число
                {
                    int i_2 = 1;
                    bool newname = false;

                    while (!newname)
                    {
                        string fullpath1 = fullpath + "_" + i_2.ToString() + ".txt";
                        if (!File.Exists(fullpath1))
                        {
                            File.Create(fullpath1).Dispose();
                            fullpath = fullpath1;
                            newname = true;
                            break;
                        }
                        i_2++;
                        if (i_2 > 100) break;
                    }
                }
            }


            //выводим содержимое в Textbox
            StringBuilder sb = new StringBuilder();
            foreach (Work w in works)
            {

                if (j != 1)
                {
                   
                    w.stop = w.start.Subtract(laststop);
                    string s = w.stop > maxStopDuration ? "     ###" : "";
                    sb.Append("------------------------------------------------------------------------------------------\r\n");
                    sb.Append(" Простой" + "\t" + w.stop.ToString() + s +"\r\n");
                    sb.Append("------------------------------------------------------------------------------------------\r\n");
                    allStop += w.stop;
                }

                sb.Append("\t" + "Запуск №" + j.ToString() + "\r\n" + "\r\n");
               // sb.Append(" Файл" + "\t" + "\t" + w.logName + "\r\n" + "\r\n");

                sb.Append(" Старт" + "\t" + "\t" + w.start.ToLongTimeString() + "\r\n");
                sb.Append(" Остановка" + "\t" + w.end.ToLongTimeString() + "\r\n" + "\r\n");

                //выводим время работы и добавляем стрелку html код для unikod с помощью char
                sb.Append(" Время работы" + "\t" + w.duration.ToString() + " " + char.ConvertFromUtf32(8592) + "\r\n" + "\r\n");


                laststop = w.end;
                allDuration += w.duration;
                j++;

            }

            //больше среднего запусков

            double everWork = allDuration.TotalMilliseconds / j;//среднее время запуска
            int aboveEverwor=0;// количество выше среднего
            foreach (Work w in works)
            {
                if (w.duration.TotalMilliseconds>everWork)
                {
                    aboveEverwor++;
                }
            }


                if (j - 1 == 0)
            {
                sb.Append("=============================================" + "\r\n");
                sb.Append("\t" + "     НЕТ ДАННЫХ НА ЭТУ ДАТУ" + "\r\n");
                sb.Append("=============================================" + "\r\n");
            }
            else
            {
                TimeSpan res;
                res = TimeSpan.FromMilliseconds(allStop.TotalMilliseconds / j );
                sb.Append("=============================================" + "\r\n");
                //tB_out.Text += " Плата " + tB_in.Text + "\r\n";
                sb.Append(" Количество запусков:" + "\t" + j.ToString() + "\r\n");
                TimeSpan everTime = TimeSpan.FromMilliseconds(everWork);
                sb.Append(" Запусков > "+ everTime.ToString(@"mm\:ss") +" среднего " +"\t" + aboveEverwor.ToString() + "\r\n");
                sb.Append(" Время работы всей:" + "\t" + allDuration.ToString() + "\r\n");
                sb.Append(" Общее время простоя:" + "\t" + allStop.ToString() + "\r\n" + "\r\n");
                sb.Append(" Среднее время простоя:" + "\t" + res.ToString(@"mm\:ss") + "\r\n" + "\r\n"); // формат вывода timespan                


                if (pName.Count > 0)
                {
                    foreach (var progr in pName)
                    {
                        sb.Append("Время загрузки: " + progr.Key + "\r\n");
                        sb.Append("Имя программы: " + progr.Value + "\r\n" + "\r\n");
                    }
                }else
                {
                    sb.Append("Файл system.log не найден!"+"\r\n");
                }


            }
            tB_out.Text=sb.ToString();


            //прокрутка вниз
            tB_out.SelectionStart = tB_out.Text.Length;
            tB_out.ScrollToCaret();


            //tB_out.Text = dt2.ToString();


            //Записываем в файл
            if (cB_report.Checked)
            {
                using (TextWriter tw = new StreamWriter(fullpath))
                {
                    tw.Write(tB_out.Text);
                }
            }
        }
        //вывод на печать
        private void bt_print_Click(object sender, EventArgs e)
        {
            // объект для печати
            PrintDocument pD = new PrintDocument();
            // обработчик события печати
            pD.PrintPage += PrintPageHandler;
            pD.PrinterSettings.PrintRange = PrintRange.AllPages;
            
            // диалог настройки печати
            PrintDialog printDialog = new PrintDialog();

            // установка объекта печати для его настройки
            printDialog.Document = pD;


            // если в диалоге было нажато ОК
            if (printDialog.ShowDialog() == DialogResult.OK)
                printDialog.Document.Print(); // печатаем

        }

        private void PrintPageHandler(object sender, PrintPageEventArgs e)
        {
            // печать строки result
            e.Graphics.DrawString(tB_out.Text, new Font("Arial", 6), Brushes.Black, 0, 0);
        }

        //получить имя программ

        private void printWork()
        {
            
            string logpath = reportsPath + "system.log";
            if (File.Exists(logpath))
            {
                string[] lines = File.ReadAllLines(logpath);
                string progTime;
                string progName;

                foreach (string s in lines)
                {
                    if (s.Contains(dateTimePicker1.Value.ToString("yyyy-MM-dd")))
                    {
                        if (s.Contains("Load File"))
                        {
                            progName = s.Substring(s.LastIndexOf("\\") + 1, (s.IndexOf(".spp") - s.LastIndexOf("\\")));
                            progTime = s.Substring(11, 8);
                            pName.Add(progTime, progName);

                        }
                    }
                }
            }
        }
    }
}

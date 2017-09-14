using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TimeForExam
{
    static void Main()
    {
        int hourOfExam = int.Parse(Console.ReadLine());
        int minuteOfExam = int.Parse(Console.ReadLine());
        int hourOfComing = int.Parse(Console.ReadLine());
        int minuteOfComing = int.Parse(Console.ReadLine());

        DateTime exam = new DateTime(2016, 03, 06, hourOfExam, minuteOfExam, 00);
        //Console.WriteLine(exam);
        DateTime coming = new DateTime(2016, 03, 06, hourOfComing, minuteOfComing, 00);
        //Console.WriteLine(coming);

        TimeSpan timeSpan = new TimeSpan();
        timeSpan = exam - coming;
        //Console.WriteLine(Math.Abs(timeSpan.Minutes));

        if (hourOfExam == hourOfComing && minuteOfExam == minuteOfComing)
        {
            Console.WriteLine("On time");
        }
        else
        {
            if (timeSpan.Hours == 0)
            {
                if (timeSpan.Minutes < 0)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine("{0} minutes after the start", Math.Abs(timeSpan.Minutes));
                }
                else
                {
                    if (Math.Abs(timeSpan.Minutes) <= 30)
                    {
                        Console.WriteLine("On time");
                        Console.WriteLine("{0} minutes before the start", Math.Abs(timeSpan.Minutes));
                    }
                    else
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine("{0} minutes before the start", Math.Abs(timeSpan.Minutes));
                    }
                }
            }
            else
            {
                if (timeSpan.Hours < 0)
                {
                    if (Math.Abs(timeSpan.Minutes) < 10)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine("{0}:0{1} hours after the start", Math.Abs(timeSpan.Hours), Math.Abs(timeSpan.Minutes));
                    }
                    else
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine("{0}:{1} hours after the start", Math.Abs(timeSpan.Hours), Math.Abs(timeSpan.Minutes));
                    }
                    
                }
                else
                {
                    if (timeSpan.Minutes < 10)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine("{0}:0{1} hours before the start", Math.Abs(timeSpan.Hours), Math.Abs(timeSpan.Minutes));
                    }
                    else
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine("{0}:{1} hours before the start", Math.Abs(timeSpan.Hours), Math.Abs(timeSpan.Minutes));
                    }
                    
                }
            }
        }

    }
}

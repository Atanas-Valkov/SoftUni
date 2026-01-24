using System;

namespace P08.OnTimeForTheExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
             int examHour = int.Parse(Console.ReadLine());
             int examMinutes = int.Parse(Console.ReadLine());  
             int arriveHour = int.Parse(Console.ReadLine());   
             int arriveMinutes = int.Parse(Console.ReadLine());

           int examTime = examHour * 60 + examMinutes;
           int  arriveTime = arriveHour * 60 + arriveMinutes;

            if (arriveTime > examTime)
            {
                Console.WriteLine("Late");

                if (arriveTime - examTime<60)
                {
                    Console.WriteLine($"{arriveTime - examTime} minutes after the start");
                }
                else
                {
                    Console.WriteLine($"{(arriveTime - examTime)/60}:{(arriveTime - examTime)%60:D2} hours after the start");
                }

            }
            else if (arriveTime == examTime || examTime-arriveTime<=30)
            {
                Console.WriteLine("On time");
                Console.WriteLine($"{(examTime - arriveTime)} minutes before the start");
            }
            else if (examTime - arriveTime>30)
            {
                Console.WriteLine("Early");

                if (examTime - arriveTime<60)
                {
                    Console.WriteLine($"{examTime - arriveTime} minutes before the start");
                }
                else
                {
                    Console.WriteLine($"{(examTime - arriveTime)/60}:{(examTime - arriveTime)%60:D2} hours before the start");
                }
            }


        }
    }
}

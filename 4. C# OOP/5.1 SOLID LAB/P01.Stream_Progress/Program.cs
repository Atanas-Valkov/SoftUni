using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {   
            StreamProgressInfo streamProgress = new StreamProgressInfo(
                new Music("Imagine Dragons - Believer", "5000", 2500 , 10));
            streamProgress.CalculateCurrentPercent();



        }
    }
}

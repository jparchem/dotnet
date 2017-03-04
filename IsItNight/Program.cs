using System;

namespace ConsoleApplication
{
    // Sample .net core program to determine if it is night (after sunset but before sunrise)
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isNight = false;   
            for (int hour=0; hour<24; hour++)
            {
                for (int minute = 0; minute < 60; minute++)
                {
                    // test with an arbitrary date
                    DateTime testDate = new DateTime (2017,3,4,hour,minute,0);
                    isNight = IsNightTime(testDate, 6, 35, 18, 45);
                    Console.WriteLine("Is {0} night? {1}",testDate,isNight);
                }
            }
        }

        static bool IsNightTime(DateTime currentTime, int sunriseHour, int sunriseMinute, int sunsetHour, int sunSetMinute)
        {  
            DateTime todaySunrise = new DateTime(currentTime.Year,currentTime.Month,currentTime.Day,sunriseHour,sunriseMinute,0);
            DateTime todaySunset = new DateTime(currentTime.Year, currentTime.Month, currentTime.Day,sunsetHour, sunSetMinute,0);            
            
            // Are we at a point before today's sunrise?
            if (todaySunrise > currentTime)
            {
                return true;
            }

            // Are we at a point after today's sunset?
             if (todaySunset <= currentTime)
             {
                 return true;
             }
            
            return false;
        }
    }
}

using System;
using System.Data;
using System.Globalization;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start time:");
            var startingTime = Console.ReadLine();
            
            Console.WriteLine("End time:");
            var endingTime = Console.ReadLine();

            var date = startingTime.Split(" ")[0];

            var startDateTime = Convert.ToDateTime(startingTime);
            var finishDateTime = Convert.ToDateTime(endingTime);

            double totalMoney = 0;
            while (DateTime.Compare(startDateTime, finishDateTime) < 0)
            {
                var temp = startDateTime.AddSeconds(20);

                if ((startDateTime >= AddDate(date, "12:00:00 am")) && (temp <= AddDate(date, "8:59:59 am")))
                {
                    totalMoney += 0.20;
                }
                
                else if (startDateTime >= AddDate(date, "11:00:00 pm") && temp <= AddDate(date, "11:59:59 pm"))
                {
                    totalMoney += 0.20;
                }
                else
                {
                    totalMoney += 0.30;
                }


                startDateTime = temp.AddSeconds(1);
            }

            
            Console.WriteLine($"Output: {totalMoney} Taka");
        }

        private static DateTime AddDate(string date, string time)
        {
            var splitDate = date.Split("-");
            var reformDate = splitDate[1] + "/" + splitDate[2] + "/" + splitDate[0];

            var dateTime = reformDate + " " + time;
            return DateTime.ParseExact(dateTime,
                "M/d/yyyy h:mm:ss tt",
                CultureInfo.InvariantCulture);
        } 
    }
}

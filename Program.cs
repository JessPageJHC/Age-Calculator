using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections.Generic;
using static System.Console;

class Program
{
    static int CurrentDay = DateTime.Now.Day;
    static int CurrentMonth = DateTime.Now.Month;
    static int CurrentYear = DateTime.Now.Year;

    class Date
    {
        public int Day { get; set; } = CurrentDay;
        public int Month { get; set; } = CurrentMonth;
        public int Year { get; set; } = CurrentYear;

        public void CorrectDate()
        {
            // Make sure year is not negative or in the future
            if (Year > CurrentYear) { Year = CurrentYear; }
            if (Year < 1) { Year = 1; }

            // Make sure month is a valid month and is not in the future
            if (Month > 12) { Month = 12; }
            if (Month < 1) { Month = 1; }
            if (Year == CurrentYear && Month > CurrentMonth) { Month = CurrentMonth; }

            // Make sure day is a valid day within current month and is not in the future
            if (Day < 1) { Day = 1; }
            if (Month == 1 && Day > 31) { Day = 31; }
            if (Month == 2 && DateTime.IsLeapYear(Year) == false && Day > 28) { Day = 28; }
            if (Month == 2 && DateTime.IsLeapYear(Year) == true && Day > 29) { Day = 29; }
            if (Month == 3 && Day > 31) { Day = 31; }
            if (Month == 4 && Day > 30) { Day = 30; }
            if (Month == 5 && Day > 31) { Day = 31; }
            if (Month == 6 && Day > 30) { Day = 30; }
            if (Month == 7 && Day > 31) { Day = 31; }
            if (Month == 8 && Day > 31) { Day = 31; }
            if (Month == 9 && Day > 30) { Day = 30; }
            if (Month == 10 && Day > 31) { Day = 31; }
            if (Month == 11 && Day > 30) { Day = 30; }
            if (Month == 12 && Day > 31) { Day = 31; }
            if (Year == CurrentYear && Month == CurrentMonth && Day > CurrentDay) { Day = CurrentDay; }
        }

        public string DayString()
        {
            string day = Day.ToString();
            if (day.Length == 1) { day = "0" + day; }
            return day;
        }

        public string MonthString()
        {
            string month = Month.ToString();
            if (month.Length == 1) { month = "0" + month; }
            return month;
        }

        public string YearString()
        {
            string year = Year.ToString();
            if (year.Length == 1) { year = "000" + year; }
            else if (year.Length == 2) { year = "00" + year; }
            else if (year.Length == 3) { year = "0" + year; }
            return year;
        }

        public override string ToString()
        {
            return DayString() + "/" + MonthString() + "/" + YearString();
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Date date = new Date();
        int selection = 3;

        while (true)
        {
            Console.Clear();
            date.CorrectDate();
            Console.WriteLine(" Enter your date of birth.");
            Console.WriteLine("             ▲            ");
            Console.WriteLine("        " + date.ToString() + "       ");
            Console.WriteLine("             ▼            ");

            if (selection == 1)
            {
                Console.SetCursorPosition(8, 2);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(date.DayString());
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
            }
            else if (selection == 2)
            {
                Console.SetCursorPosition(11, 2);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(date.MonthString());
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
            }
            else
            {
                Console.SetCursorPosition(14, 2);
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(date.YearString());
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 0);
            }

            switch (ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    if (selection == 1) { date.Day += 1; }
                    else if (selection == 2) { date.Month += 1; }
                    else if (selection == 3) { date.Year += 1; }
                    break;
                case ConsoleKey.DownArrow:
                    if (selection == 1) { date.Day -= 1; }
                    else if (selection == 2) { date.Month -= 1; }
                    else if (selection == 3) { date.Year -= 1; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (selection != 1) { selection -= 1; }
                    break;
                case ConsoleKey.RightArrow:
                    if (selection != 3) { selection += 1; }
                    break;
            }
        }
    }
}
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
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

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

        public override string ToString()
        {
            string day, month, year;
            day = Day.ToString();
            month = Month.ToString();
            year = Year.ToString();

            if (day.Length == 1) { day = "0" + day; }
            if (month.Length == 1) { month = "0" + month; }
            if (year.Length == 1) { year = "000" + year; }
            else if (year.Length == 2) { year = "00" + year; }
            else if (year.Length == 3) { year = "0" + year; }

            return day + "/" + month + "/" + year;
        }
    }

    static void Main()
    {
        Date date = new Date();
        date.Day = 50;
        date.Month = 2;
        date.Year = 1996;
        date.CorrectDate();
        Console.WriteLine(date.ToString());
    }
}
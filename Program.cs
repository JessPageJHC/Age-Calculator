using static System.Console;

class Program
{
    // Get current date
    static int CurrentDay = DateTime.Now.Day;
    static int CurrentMonth = DateTime.Now.Month;
    static int CurrentYear = DateTime.Now.Year;

    // Class "Date" is for storing the entered day, month and year
    class Date
    {
        public int Day { get; set; } = CurrentDay;
        public int Month { get; set; } = CurrentMonth;
        public int Year { get; set; } = CurrentYear;

        // CorrectDate ensures the date is a valid date, and if not, changes it to a valid one
        public void CorrectDate()
        {
            // Year cannot be negative or in the future
            if (Year > CurrentYear) { Year = CurrentYear; }
            if (Year < 1) { Year = 1; }

            // Month must be 1-12, and cannot be in the future
            if (Month > 12) { Month = 12; }
            if (Month < 1) { Month = 1; }
            if (Year == CurrentYear && Month > CurrentMonth) { Month = CurrentMonth; }

            // Day must be a valid day within the currently selected month, and cannot be in the future
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

        // Get the day as a 2-character string
        public string DayString()
        {
            string day = Day.ToString();
            if (day.Length == 1) { day = "0" + day; }
            return day;
        }

        // Get the month as a 2-character string
        public string MonthString()
        {
            string month = Month.ToString();
            if (month.Length == 1) { month = "0" + month; }
            return month;
        }

        // Get the year as a 2-character string
        public string YearString()
        {
            string year = Year.ToString();
            if (year.Length == 1) { year = "000" + year; }
            else if (year.Length == 2) { year = "00" + year; }
            else if (year.Length == 3) { year = "0" + year; }
            return year;
        }

        // Outputs date as a string in DD/MM/YYYY format
        public override string ToString()
        {
            return DayString() + "/" + MonthString() + "/" + YearString();
        }
    }

    static void Main()
    {
        // Allow special characters to be visible, and disable cursor
        OutputEncoding = System.Text.Encoding.UTF8;
        CursorVisible = false;

        // Initialize variables
        Date date = new Date();
        int selection = 3;
        bool selectionFinished = false;

        // Get date of birth
        while (!selectionFinished)
        {
            Clear();
            date.CorrectDate();
            WriteLine("   Enter your date of birth.");
            WriteLine("              ▲            ");
            WriteLine("          " + date.ToString() + "       ");
            WriteLine("              ▼            ");
            WriteLine("\n   Press ENTER to calculate. ");

            // Highlights the current selection
            if (selection == 1)
            {
                SetCursorPosition(10, 2);
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.Black;
                Write(date.DayString());
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.White;
                SetCursorPosition(0, 0);
            }
            else if (selection == 2)
            {
                SetCursorPosition(13, 2);
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.Black;
                Write(date.MonthString());
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.White;
                SetCursorPosition(0, 0);
            }
            else
            {
                SetCursorPosition(16, 2);
                BackgroundColor = ConsoleColor.White;
                ForegroundColor = ConsoleColor.Black;
                Write(date.YearString());
                BackgroundColor = ConsoleColor.Black;
                ForegroundColor = ConsoleColor.White;
                SetCursorPosition(0, 0);
            }

            // Gets user input
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
                case ConsoleKey.Enter:
                    selectionFinished = true;
                    break;
            }
        }

        // Calculate age
        double daysOld = (new DateTime(CurrentYear, CurrentMonth, CurrentDay) - new DateTime(date.Year, date.Month, date.Day)).TotalDays;
        double yearsOld = Math.Floor(daysOld / 365.2425);
        daysOld = Math.Floor(daysOld - (yearsOld * 365.2425));
        double monthsOld = Math.Floor(daysOld / (365.25 / 12));
        daysOld = Math.Floor(daysOld - (monthsOld * (365.25 / 12)));

        // Display age
        Clear();
        WriteLine(" You are:");
        WriteLine("  " + yearsOld + " years,");
        WriteLine("  " + monthsOld + " months and");
        WriteLine("  " + daysOld + " days");
        WriteLine(" old.");
        WriteLine("\n This is a total of " + (new DateTime(CurrentYear, CurrentMonth, CurrentDay) - new DateTime(date.Year, date.Month, date.Day)).TotalDays + " days.");

        // Dumb Easter egg comments
        if (yearsOld == 0 && monthsOld == 0 && daysOld == 0)
        {
            WriteLine(" Welcome to the world!");
        }
        else if (date.Year == 1 && date.Month == 1 && date.Day == 1)
        {
            WriteLine(" Are you God?");
        }
        else if (date.Year == 1111 && date.Month == 11 && date.Day == 11)
        {
            WriteLine(" 111111 111 1111111.");
        }
        else if (date.Year == 2005 && date.Month == 6 && date.Day == 30)
        {
            WriteLine(" Hey Jess.");
        }
        else if (monthsOld == 0 && daysOld == 0)
        {
            WriteLine(" Happy birthday!");
        }
        else if (yearsOld < 3)
        {
            WriteLine(" Goo goo ga ga");
        }
        else if (yearsOld > 300)
        {
            WriteLine(" How the hell.");
        }
        else if (yearsOld > 121)
        {
            WriteLine(" You should really tell Guinness about this.");
        }

        // Finish program
        Console.WriteLine("\n Press ENTER to finish.");
        Read();
        Console.Clear();
    }
}
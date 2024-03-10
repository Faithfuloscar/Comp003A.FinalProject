using System.Runtime.InteropServices;

namespace Final_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SectionSeparator();
            Console.WriteLine("\tWelcome to Heart");
            DrawHeart();
            SectionSeparator();

            Console.WriteLine("Let's get you started on your journey to love");
            Console.WriteLine("What is your first name?");
            Console.Write("");
            string name1 = GetValidName();
           

            Console.WriteLine("Last name?");
            Console.Write("");
            string name2 = GetValidName();
            Console.WriteLine("Welcome "+ name1 +" "+ name2);
            SectionSeparator();

            // Getting the birthdate of user.
            int minYear = 1900;
            int currentYear = DateTime.Now.Year;
            int birthYear = GetValidBirthYear(minYear, currentYear);
            int birthMonth = GetValidMonth();
            int birthDay = GetValidDay(birthMonth);
            DateTime birthDate = new DateTime(birthYear, birthMonth, birthDay);
            int age = CalculatorAge(birthDate, DateTime.Now);
            Console.WriteLine($"You're {age} years old.");


            // Gender identification
            string gender = "";
            do
            {
                Console.WriteLine("Please enter your gender (M,F,O)");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                gender = input.ToUpper();

                if (gender != "F" && gender != "M" && gender !="O")
                {
                    Console.WriteLine("Invalid input.");
                }

            } while (gender == "F" && gender == "M" && gender =="O");

            switch(gender)
            {
                case "F":
                    Console.WriteLine("Female");
                    break;
                case "M":
                    Console.WriteLine("Male");
                    break;
                case "O":
                    Console.WriteLine("Other");
                    break;
            }

            SectionSeparator();
            Console.WriteLine("Now Tells us about your self");
            SectionSeparator();

            // Question 1
            Console.WriteLine("What's your ideal first date?");
            Console.Write("");
            string Q1 = GetValidName();
            Console.WriteLine("Your ideal date is " + Q1);
            SectionSeparator();

            // Question 2
            Console.WriteLine("Describe your ideal weekend or free time activity.");
            Console.Write("");
            string Q2 = GetValidName();
            Console.WriteLine("Your ideal weekend or free time activity is " + Q2);
            SectionSeparator();

            // Question 3
            Console.WriteLine("What kind of music do you enjoy listening to?");
            Console.Write("");
            string Q3 = GetValidName();
            Console.WriteLine("You enjoy listening to "+ Q3);
            SectionSeparator();

            // Question 4
            Console.WriteLine("What is your favorite movie?");
            Console.Write("");
            string Q4 = GetValidName();
            Console.WriteLine("Your favorite move is "+ Q4);
            SectionSeparator();

            // Question 5
            Console.WriteLine("Are you a morning person or a night owl?");
            Console.Write("");
            string Q5 = GetValidName();
            Console.WriteLine("You are a "+ Q5);
            SectionSeparator();

            // Question 6
            Console.WriteLine("Do you enjoy any physical fitness activities?");
            Console.Write("");
            string Q6 = GetValidName();
            Console.WriteLine("You enjoy " + Q6);
            SectionSeparator();

            // Question 7
            Console.WriteLine("What values are important to you in a relationship");
            Console.Write("");
            string Q7 = GetValidName();
            Console.WriteLine("Your important values in a relationship are " + Q7);
            SectionSeparator();

            // Question 8
            Console.WriteLine("What qualities do you look for in a potential partner?");
            Console.Write("");
            string Q8 = GetValidName();
            Console.WriteLine("You are looking for " + Q8 ," in a person");
            SectionSeparator();

            // Question 9
            Console.WriteLine("What's something you are passionate about?");
            Console.Write("");
            string Q9 = GetValidName();
            Console.WriteLine("You are passionate about " + Q9);
            SectionSeparator();

            // Question 10
            Console.WriteLine("Do you have any pets?");
            Console.Write("");
            string Q10 = GetValidName();
            Console.WriteLine("You have " + Q10);
            SectionSeparator();

        }
        // Provides for the seperation of sections using the * symbol.
        static void SectionSeparator()
        {
            Console.WriteLine("".PadRight(50,'*'));
        }

        // Draws a heart.
        static void DrawHeart()
        {
            Console.WriteLine("\t    ***   ***");
            Console.WriteLine("\t    **** ****");
            Console.WriteLine("\t     *******");
            Console.WriteLine("\t      *****");
            Console.WriteLine("\t       ***");
            Console.WriteLine("\t        *");
        }

        // States the output if input is null/blank/number/ or special character.
        static string GetValidName()
        {
            string input;
            do
            {
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a valid input");
                }
                else if (ContainsNumbersOrSpecialChars(input))
                {
                    Console.WriteLine("Please refrain from using special characters or numbers");
                }
            } while (string.IsNullOrWhiteSpace(input) || ContainsNumbersOrSpecialChars(input));
            return input;
        }
        
        /// <summary>
        /// Checks if the input is special characters or numbers.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static bool ContainsNumbersOrSpecialChars(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c) || char.IsPunctuation(c) || char.IsSymbol(c))
                  {
                    return true;
                  }
            }
            return false;
        }

        /// <summary>
        /// Has the user enter a valid birth year within range.
        /// </summary>
        /// <param name="minYear">Minimum allowed birth year</param>
        /// <param name="maxYear">Maximum allowed birth year</param>
        /// <returns>valid birth year of user.</returns>
        static int GetValidBirthYear(int minYear, int maxYear)
        {
            int birthYear;
            while (true)
            {
                Console.WriteLine($"Please enter your birth year between {minYear} and {maxYear}:");

                if (int.TryParse(Console.ReadLine(), out birthYear))
                {
                    if (birthYear >= minYear && birthYear <= maxYear)
                    {
                        return birthYear;
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a valid year");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid year ");
                }
            }
        }

        /// <summary>
        /// user enters a valid month (1-12).
        /// </summary>
        /// <returns>valid birth month.</returns>
        static int GetValidMonth()
        {
            int month;
            while (true)
            {
                Console.WriteLine("Please enter the month you were born (1-12) ");

                if(int.TryParse(Console.ReadLine(),out month) && month >= 1 && month <= 12)
                {
                    return month;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        /// <summary>
        /// User enters a valid day between (1-30).
        /// </summary>
        /// <param name="month">User's birth month.</param>
        /// <returns>User's valid birth day for the month given.</returns>
        static int GetValidDay(int month)
        {
            int day;

            while (true)
            {
                Console.WriteLine($"Please enter your birthday for {month} (1-{DateTime.DaysInMonth(DateTime.Now.Year, month)}) ");

                if (int.TryParse(Console.ReadLine(), out day) && day >= 1 && day <= DateTime.DaysInMonth(DateTime.Now.Year, month))
                {
                    return day;
                }
                else
                {
                    Console.WriteLine($"Invalid input.");
                }
            }
        }

        /// <summary>
        /// Will calculate the age based on the information inputed and current date.
        /// </summary>
        /// <param name="birthDate">User's birth date.</param>
        /// <param name="currentDate">Current date.</param>
        /// <returns>User's age.</returns>
        static int CalculatorAge(DateTime birthDate, DateTime currentDate)
        {
            int age = currentDate.Year - birthDate.Year;

            if (currentDate < birthDate.AddYears(age))
            {
                age--;
            }

            return age;
        }


    }
}

/*
 * Author: Oscar Mendez
 * Class: COMP-003A
 * Purpose: To create a dating profile
 */

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
            string FirstName = GetValidName();


            Console.WriteLine("Last name?");
            Console.Write("");
            string LastName = GetValidName();
            Console.WriteLine("Welcome "+ FirstName +" "+ LastName);
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
            Console.WriteLine("Please enter your gender (M,F,O)");
            char genderChar = '\0';
            do
            {
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || input.Length != 1)
                {
                    Console.WriteLine("Invalid input.");
                        continue;
                }
                genderChar = input[0];

            } while (!IsValidGenderChar(genderChar));

            string gender = GetGenderDescription(genderChar);
            Console.WriteLine($"You are a {gender}");

            SectionSeparator();
            Console.WriteLine("Now Tells us about your self");
            SectionSeparator();

            // List of questions to ask user.
            List<string> Answers = new List<string>();
            char userInput = default;

            do
            {
                Console.WriteLine("What's your ideal first date?"); 
                Console.Write("");
                string answer1 = Console.ReadLine();
                Answers.Add(answer1);
                

                Console.WriteLine("Describe your ideal weekend or free time activity.");
                Console.Write("");
                string answer2 = Console.ReadLine();
                Answers.Add(answer2 );
                

                Console.WriteLine("What kind of music do you enjoy listening to?");
                Console.Write("");
                string answer3 = Console.ReadLine();
                Answers.Add (answer3);

                Console.WriteLine("What is your favorite movie?");
                Console.Write("");
                string answer4 = Console.ReadLine();
                Answers.Add(answer4 );

                Console.WriteLine("Are you a morning person or a night owl?");
                Console.Write("");
                string answer5 = Console.ReadLine();
                Answers.Add(answer5 );

                Console.WriteLine("Do you enjoy any physical fitness activities?");
                Console.Write("");
                string answer6 = Console.ReadLine();
                Answers.Add(answer6 );

                Console.WriteLine("What values are important to you in a relationship");
                Console.Write("");
                string answer7 = Console.ReadLine();
                Answers.Add(answer7 );

                Console.WriteLine("What qualities do you look for in a potential partner?");
                Console.Write("");
                string answer8 = Console.ReadLine();
                Answers.Add(answer8 );

                Console.WriteLine("What's something you are passionate about?");
                Console.Write("");
                string answer9 = Console.ReadLine();
                Answers.Add(answer9 );

                Console.WriteLine("Do you have any pets?");
                Console.Write("");
                string answer10 = Console.ReadLine();
                Answers.Add(answer10 );

            } while (false);

            SectionSeparator();
            Console.WriteLine("Profile");
            SectionSeparator();

            Console.WriteLine("Name: "+ FirstName + "" + LastName);
            Console.WriteLine("Age: "+ age);
            Console.WriteLine("Gender: "+ gender);
            Console.WriteLine("Your answers to our question were:");
            foreach (string answer in Answers)
            {
                Console.WriteLine(answer);
            }
        }
        /// <summary>
        /// Provides for the seperation of sections using the * symbol.
        /// </summary>
        static void SectionSeparator()
        {
            Console.WriteLine("".PadRight(50, '*'));
        }

        /// <summary>
        /// Creates the image of a heart utilizing the * symbol, \t is used to help center the heart.
        /// </summary>
        static void DrawHeart()
        {
            Console.WriteLine("\t    ***   ***");
            Console.WriteLine("\t    **** ****");
            Console.WriteLine("\t     *******");
            Console.WriteLine("\t      *****");
            Console.WriteLine("\t       ***");
            Console.WriteLine("\t        *");
        }

        /// <summary>
        /// states the output if input is null/blank/number/ or special character.
        /// </summary>
        /// <returns>Invalid input for null/blank, asks users to refrain from using special characters or digits if used.</returns>
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
        /// <param name="input">String to be checked.</param>
        /// <returns> True if the input string contains numbers, punctuation, or symbols anything else returns false.</returns>
        static bool ContainsNumbersOrSpecialChars(string input)
        {
            foreach (char c in input)
            {
                // char.IsDigit() is used to refer to check if the input was a number.
                // char.IsPunctuation is used to check if the input was a punctuation mark.
                // char.IsSymbol is used to check if the input was a symbol.
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

                // The purpose of int.TryParse() is to ensure the program doesn't crash from an invalid input.
                // The purpose of the out keyword is to assign a value to birthYear.
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

                // The purpose of int.TryParse() is to prompt the user to enter a correct input.
                // The purpose of the out keyword is to assign a value to month.
                if (int.TryParse(Console.ReadLine(), out month) && month >= 1 && month <= 12)
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

            // The if statement stops the loop from being infinite as soon as a valid input is made.
            while (true)
            {
                Console.WriteLine($"Please enter your birthday for {month} (1-{DateTime.DaysInMonth(DateTime.Now.Year, month)}) ");

                // The purpose is to get the number of days in a specified month of a specified year.
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
        
        /// <summary>
        /// Determines if the character is valid.
        /// </summary>
        /// <param name="genderChar">The character representing gender.</param>
        /// <returns>True if valid character otherwise false.</returns>
        static bool IsValidGenderChar(char genderChar)
        {
            return (genderChar == 'M' || genderChar == 'm' || genderChar == 'F' || genderChar == 'f' || genderChar =='O' || genderChar == 'o');
        }

        /// <summary>
        /// Outputs the gender based on provided answer.
        /// </summary>
        /// <param name="gender"> character representing gender.</param>
        /// <returns>The gender description as a string.</returns>
        static string GetGenderDescription(char gender)
        {
            if (gender == 'M' || gender == 'm')
            {
                return "Male";
            }
            else if (gender == 'F' || gender == 'f')
            {
                return "Female";
            }
            else if (gender == 'O' || gender == 'o')
            {
                return "Other";
            }
            else
            {
                return "invalid input";
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program : IAgeCalculator
    {
        static void Main(string[] args)
        {
            IAgeCalculator Calculator = new Program();
            DateTime ParsedDoB = new DateTime();

            do
            {
                Console.Write("Please enter Date of Birth: ");
                Console.WriteLine( (Calculator.ParseInput(Console.ReadLine(), out ParsedDoB)) ? String.Format("You are {0} years old.", Calculator.CalculateAge(ParsedDoB)) : "Invalid format/date of birth entered, please try again!");
            } while (true);
        }

        public int CalculateAge(DateTime dateOfBirth)
        {
            int Years = DateTime.Now.Year - dateOfBirth.Year;
            return ((dateOfBirth.Month > DateTime.Now.Month) || (dateOfBirth.Month == DateTime.Now.Month && dateOfBirth.Day > DateTime.Now.Day)) ? Years-- : Years;
        }

        public bool ParseInput(string input, out DateTime result)
        {
            return DateTime.TryParseExact(input, "dd-mm-yyyy", null, System.Globalization.DateTimeStyles.None, out result);
        }
    }
}

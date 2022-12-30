using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingConsole
{
    internal class Dog
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfFirstDeWorming => DateOfBirth.AddDays(3 * 7);
        public DateTime DateOfSecondDeWorming => DateOfBirth.AddDays(5 * 7);
        public DateTime DateOfThirdDeWorming => DateOfBirth.AddDays(7 * 7);
        public DateTime DateOfFirstVaccination => DateOfBirth.AddDays(8 * 7);
    }
}

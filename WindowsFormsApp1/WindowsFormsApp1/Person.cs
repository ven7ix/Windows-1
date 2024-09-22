using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Person : IPerson
    {
        public int CardNumber { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int CalcAge(DateTime date)
        {
            int age = date.Year - Birthday.Year;
            if (date.Month < Birthday.Month && date.Day < Birthday.Day) age--;
            return age;
        }
    }
}

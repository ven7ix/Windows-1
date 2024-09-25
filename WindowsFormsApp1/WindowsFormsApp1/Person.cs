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
        public int _CardNumber { get; set; }
        public string _Name { get; set; }
        public DateTime _Birthday { get; set; }

        public Person(int CardNumber, string Name, DateTime Birthday)
        {
            _CardNumber = CardNumber;
            _Name = Name;
            _Birthday = Birthday;
        }

        public int CalcAge(DateTime date)
        {
            int age = date.Year - _Birthday.Year;
            if (date.Month < _Birthday.Month || (date.Month < _Birthday.Month && date.Day < _Birthday.Day)) age--;
            return age;
        }
    }
}

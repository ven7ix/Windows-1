using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IPerson
    {
        int _CardNumber { get; set; }
        string _Name { get; set; }
        DateTime _Birthday { get; set; }
        int CalcAge(DateTime date);
    }
}

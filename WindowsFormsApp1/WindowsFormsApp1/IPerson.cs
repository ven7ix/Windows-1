using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IPerson
    {
        int _CardNumber { get; }
        string _Name { get; }
        DateTime _Birthday { get; }
        int CalcAge(DateTime date);
    }
}

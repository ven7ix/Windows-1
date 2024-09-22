using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public interface IPerson
    {
        int CardNumber { get; }
        string Name { get; }
        DateTime Birthday { get; }
        int CalcAge(DateTime date);
    }
}

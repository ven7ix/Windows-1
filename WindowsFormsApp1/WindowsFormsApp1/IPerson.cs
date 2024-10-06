using System;

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

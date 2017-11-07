using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment
{
    [Serializable]
    public class BetClass
    {

        public string HorseName { get; set; }
        public string RaceCourse { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool Result { get; set; }



        public BetClass(string racecourse, string horsename, DateTime date, decimal amount, bool result)
        {
            HorseName = horsename;
            RaceCourse = racecourse;
            Date = date;
            Amount = amount;
            Result = result;
        }
        public void Bet()
        {

        }

        public override string ToString()
        {
            return HorseName + " " + RaceCourse + " " + Date + " " + Amount + " " + Result;
        }
    }

}
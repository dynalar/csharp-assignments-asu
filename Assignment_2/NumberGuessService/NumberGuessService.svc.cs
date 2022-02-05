using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NumberGuessService
{
    public class NumberGuessService : INumberGuessService
    {
        // this code stays the same from the previous project for our service
        public string CheckNumber(int userNum, int secretNum)
        {
            if (userNum == secretNum)
                return "correct";
            else
                if (userNum > secretNum)
                return "too big";
            else return "too small";
        }

        // this code stays the same from the previous project for our service
        public int SecretNumber(int lower, int upper)
        {
            DateTime currentDate = DateTime.Now;
            int seed = (int)currentDate.Ticks;
            Random random = new Random(seed);
            int sNumber = random.Next(lower, upper);
            return sNumber;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
    }
}

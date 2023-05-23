using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NumberSortService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class NumberSortService : INumberSortService
    {
        public string sortString(string s)
        {
            // trim spaces and convert strings to ints
            int[] splitInts = {};

            try
            {
                splitInts = Array.ConvertAll(s.Split(','), p => int.Parse(p.Trim()));
            }
            catch (Exception e)
            {
                return "Please enter valid data!";
            }

            // sort the array
            Array.Sort(splitInts);

            // return joined string with ordered numbers
            return string.Join(",", splitInts);
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

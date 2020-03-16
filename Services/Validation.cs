using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AFIAPITest.Services
{
    /// <summary>
    /// Allows Validations to be reused
    /// </summary>
    public class Validation
    {
        string validationError = "";
        string policyPattern = @"[A-Z]{2}-\d{6}";
        string emailPattern = @"[a-zA-Z0-9.]{4,}@[a-zA-Z0-9]{2,}\.(com|co.uk)";

        public bool NameLength(string val)
        {
            if (val.Length < 3 || val.Length > 50)
                return false;
            else
                return true;

        }

        public bool PolicyCheck(string val)
        {
            Match policyMatch = Regex.Match(val, policyPattern);
            if (policyMatch.Success)
                return true;
            else
                return false;
        }

        public bool EmailCheck(string val)
        {
            Match emailMatch = Regex.Match(val, emailPattern);
            if (emailMatch.Success)
                return true;
            else
                return false;
        }



        /// <summary>
        /// Calculate the age of a person from provided DOB
        /// </summary>
        /// <param name="dob"></param>
        /// <returns></returns>
        public int CalcAge(DateTime dob)
        {
            DateTime dateNow = DateTime.Now;

            // get the difference in years
            int age = dateNow.Year - dob.Year;

            // subtract a year if day of birth greater than today
            if (dateNow.Month < dob.Month || (dateNow.Month == dob.Month && dateNow.Day < dob.Day))
                age = age - 1;

            return age;
        }
    }
   
}

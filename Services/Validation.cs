using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AFIAPITest.Interfaces;

namespace AFIAPITest.Services
{
    /// <summary>
    /// Allows Validations to be reused
    /// </summary>
    public class Validation : IValidation
    {
        string policyPattern = @"[A-Z]{2}-\d{6}";
        string emailPattern = @"[a-zA-Z0-9.]{4,}@[a-zA-Z0-9]{2,}\.(com|co.uk)";

        /// <summary>
        /// Check the length of the string passed
        /// At least 3 characters long but no longer than 50 characters in length
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public async Task<bool> NameLength(string val)
        {
            if (val.Length < 3 || val.Length > 50)
                return false;
            else
                return true;

        }

        /// <summary>
        /// Check passed Poilcy Reference string passed matches required pattern
        /// XX-999999. Where XX are any capitalised alpha character followed by a hyphen and 6 numbers
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public async Task<bool> PolicyCheck(string val)
        {

            Match policyMatch = Regex.Match(val, policyPattern);
            return policyMatch.Success;
        }

        /// <summary>
        /// Check passed email string matches required pattern
        /// 4 alpha numeric chars followed by an ‘@’ sign and then another string of at least 2 alpha numeric chars. The email address should end in either ‘.com’ or ‘.co.uk
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public async Task<bool> EmailCheck(string val)
        {
            Match emailMatch = Regex.Match(val, emailPattern);
            return emailMatch.Success;
        }



        /// <summary>
        /// Pass in the date to then calculate the age of the registrant
        /// returning the integer value of the age
        /// </summary>
        /// <param name="dob"></param>
        /// <returns></returns>
        public async Task<int> CalcAge(DateTime dob)
        {
            try
            {
                DateTime dateNow = DateTime.Now;

                // get the difference in years
                int age = dateNow.Year - dob.Year;

                // subtract a year if day of birth greater than today
                if (dateNow.Month < dob.Month || (dateNow.Month == dob.Month && dateNow.Day < dob.Day))
                    age = age - 1;

                return age;
            }
            // You could add logging here to log errors 
            catch
            {
                return 0;
            }
        }



    }

}

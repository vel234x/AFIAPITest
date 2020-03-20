using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AFIAPITest.Interfaces
{
    public interface IValidation
    {

        Task<bool> NameLength(string val);

        Task<bool> PolicyCheck(string val);

        Task<bool> EmailCheck(string val);

        Task<int> CalcAge(DateTime val);

    }
}

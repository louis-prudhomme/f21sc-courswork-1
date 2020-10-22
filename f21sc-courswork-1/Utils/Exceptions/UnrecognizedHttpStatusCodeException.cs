using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f21sc_courswork_1.Utils.Exceptions
{
    class UnrecognizedHttpStatusCodeException : Exception
    {
        public int Code { get; }

        public UnrecognizedHttpStatusCodeException(int code) : base("Unrecognized HTTP status code : " + code)
        {
            Code = code;
        }
    }
}

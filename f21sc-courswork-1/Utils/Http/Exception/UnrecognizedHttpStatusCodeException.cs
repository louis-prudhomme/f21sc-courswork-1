using System;

namespace f21sc_coursework_1.Utils.Http.Exceptions
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

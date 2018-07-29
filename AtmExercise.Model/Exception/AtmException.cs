using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Model.Exception
{
    public class AtmException : ApplicationException
    {
        public AtmException(string message) : base(message) { }
    }
}

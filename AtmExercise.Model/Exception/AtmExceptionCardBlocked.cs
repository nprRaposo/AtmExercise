using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Model.Exception
{
    public class AtmExceptionCardBlocked : ApplicationException
    {
        public AtmExceptionCardBlocked(string message) : base(message) { }
    }
}

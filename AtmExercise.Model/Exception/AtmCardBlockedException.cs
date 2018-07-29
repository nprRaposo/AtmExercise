using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Model.Exception
{
    public class AtmCardBlockedException : ApplicationException
    {
        public AtmCardBlockedException(string message) : base(message) { }
    }
}

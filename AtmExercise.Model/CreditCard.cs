using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Model
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool Blocked { get; set; }
        public string Pin { get; set; }
        public double Balance { get; set; }
        public int Attempts { get; set; }
    }
}

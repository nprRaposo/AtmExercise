using System;
using System.Collections.Generic;
using System.Text;

namespace AtmExercise.Model
{
    public class Operation
    {
        public int Id { get; set; }
        public OperationTypeEnum Code { get; set; }
        public DateTime Time { get; set; }
        public string Detail { get; set; }
        public int CreditCardId { get; set; }
    }
}

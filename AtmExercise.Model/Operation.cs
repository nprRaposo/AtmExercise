using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AtmExercise.Model
{
    public class Operation
    {
        [Key]
        public int Id { get; set; }
        public OperationTypeEnum Code { get; set; }
        public DateTime Time { get; set; }
        public string Detail { get; set; }
        public int CreditCardId { get; set; }

        public CreditCard CreditCard { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriftTuner
{
    class Calculator
    {
        //calculate tuning value based of the maximum, minimum, and weight distribution values
        public decimal CalculateTune(decimal a, decimal b, decimal c)
        {
            return (((a - b) * c) + b);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator
{
    class Tip
    {
        public String BillAmount { get; set; }
        public String TotalTip { get; set; }
        public String TotalAmount { get; set; }

        public Tip()
        {
            this.BillAmount = String.Empty;
            this.TotalAmount = String.Empty;
            this.TotalTip = String.Empty;
        }

        public void CalculateTip(string originalAmmount, double tipPercentage)
        {
            double billAmount = 0.0;
            double tipAmount = 0.0;
            double totalAmount = 0.0;

            if (double.TryParse(originalAmmount.Replace('$',' '), out billAmount))
            {
                tipAmount = billAmount * tipPercentage;
                totalAmount = billAmount + tipAmount;
            }
            this.BillAmount = String.Format("{0:C}", billAmount);
            this.TotalTip = String.Format("{0:C}", tipAmount);
            this.TotalAmount = String.Format("{0:C}", totalAmount);
        }
    }
}

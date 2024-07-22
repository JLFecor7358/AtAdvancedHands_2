using System.Diagnostics.CodeAnalysis;

namespace AtAdvancedHands2
{
    internal class Program
    {
        public delegate float TaxCalc<in T>(T firstNumber, T secondNumber);
        //Method to calc tax
        private float GetTaxCalculation(float firstNumber, float secondNumber)
        {
            return firstNumber * secondNumber;
        }
        //Method to calc total
        private float GetTotal(float firstNumber, float secondNumber)
        {

            return firstNumber + GetTaxCalculation(firstNumber, secondNumber); ;
        }
        //Method to receive delegate and two decimals, can call calc tax and total methods
        private float DoCalc(TaxCalc<float> delegat, float firstNumber, float secondNumber)
        {
            return delegat(firstNumber, secondNumber);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            Dictionary<float, float> amounts = new Dictionary<float, float>();
            amounts.Add(100, 0.15f);//115
            amounts.Add(200, 0.17f);//234
            amounts.Add(300, 0.19f);//357
            amounts.Add(2500.15f, 0.25f);//3125.18
            amounts.Add(2700.99f, 0.27f);//3430.25
            foreach (KeyValuePair<float, float> row in amounts)
            {
                Console.WriteLine(String.Format("Tax amount is {0}", program.DoCalc(program.GetTaxCalculation, row.Key, row.Value)));
                Console.WriteLine(String.Format("Total amount (Subtotal + Tax) is {0}", program.DoCalc(program.GetTotal, row.Key, row.Value)));
            }
        }
    }   
}

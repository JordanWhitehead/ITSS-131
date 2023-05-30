// Loan amortization calculator
using static System.Console;
namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int month = 0;
            double monthlyInterestAmount;
            double principlePaid;
            double principlePaidFinalLine;
            double interestPaidTotal = 0;

            WriteLine("Enter the amount of the car loan");
            Write("Car Loan Amount >> ");
            double carLoanAmount = Convert.ToDouble(ReadLine());
            double carLoanAmountFinal = carLoanAmount; // to simplify the last line
            WriteLine();

            WriteLine("Enter the interest rate");
            WriteLine("Example: if your interest rate is 4.5%, enter \"4.5\"");
            Write("Interest Rate >> ");
            double interestRate = Convert.ToDouble(ReadLine());
            WriteLine();

            WriteLine("Enter the monthly payment");
            Write("Monthly Payment >> ");
            double monthlyPayment = Convert.ToDouble(ReadLine());

            double monthlyInterestRate = interestRate / 12 / 100;

            WriteLine("Month" + " - " + "Interest" + " - " + "Principle" + " - " + "{0,11}", "Balance");
            do
            {
            Write("{0, 5}" + "   ", ++month); // Month section
            monthlyInterestAmount = Math.Round(carLoanAmount * monthlyInterestRate, 2);
            Write("{0,8}" + "   ", monthlyInterestAmount.ToString("C")); // Interest section
            interestPaidTotal = interestPaidTotal + monthlyInterestAmount;
            principlePaid = monthlyPayment - monthlyInterestAmount;
            Write("{0,9}" + "   ", principlePaid.ToString("C")); // Principle section
            carLoanAmount = carLoanAmount - principlePaid;
            Write("{0,11}", carLoanAmount.ToString("C")); // Balance section
            WriteLine();
            } while (carLoanAmount >= monthlyPayment);
            
            // final line of amortization
            Write("{0, 5}" + "   ", ++month);
            monthlyInterestAmount = Math.Round(carLoanAmount * monthlyInterestRate, 2);
            Write("{0,8}" + "   ", monthlyInterestAmount.ToString("C"));
            interestPaidTotal = interestPaidTotal + monthlyInterestAmount;
            principlePaidFinalLine = carLoanAmount;
            Write("{0,9}" + "   ", principlePaidFinalLine.ToString("C"));
            carLoanAmount = carLoanAmount - principlePaidFinalLine;
            Write("{0,11}", carLoanAmount.ToString("C"));
            WriteLine();

            // line showing totals
            double totalPaid = carLoanAmountFinal + interestPaidTotal;
            Write("Total Paid: {0}" + "    ", totalPaid.ToString("C"));
            Write("Total Interest: {0}" + "    ", interestPaidTotal.ToString("C"));
            Write("Months: {0}", month);
        }
    }
}

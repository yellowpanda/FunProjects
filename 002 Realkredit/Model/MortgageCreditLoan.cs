namespace Model
{
    public class MortgageCreditLoan
    {
        public uint Terms { get; }

        public decimal ContributionMargin { get; }

        /// <summary>
        /// Skatteprocenten du skal angive er kommune-, sundheds- og kirkeskatteprocenterne lagt sammen.
        /// https://www.skm.dk/skattetal/satser/danmarkskort-over-kommuneskatter/#/kommune/fredericia
        /// </summary>
        public decimal TaxRate { get; }

        /// <summary>
        /// The yearly interest percentage. Like 5.00 for 5%.
        /// </summary>
        public decimal YearlyInterest { get; }

        public decimal LoanAmount { get; }

        public MortgageCreditLoan(decimal loanAmount, uint terms, decimal yearlyInterest, decimal contributionMargin, decimal taxRate)
        {
            Terms = terms;
            ContributionMargin = contributionMargin;
            TaxRate = taxRate;
            YearlyInterest = yearlyInterest;
            LoanAmount = loanAmount;
        }

        public AmortizationSchedule GetAmortizationSchedule()
        {
            var schedule = new AmortizationSchedule();

            var currentAmount = LoanAmount;
            var installment = GetInstallment();

            for (int i = 0; i < Terms; i++)
            {
                var interest = currentAmount * YearlyInterest / 4 / 100;
                var margin = currentAmount * ContributionMargin / 4 / 100;
                var amountLeft = currentAmount - (installment - interest);
                var taxReduction = (interest + margin) * TaxRate/100;

                var payment = new Payment(i + 1, interest, margin, amountLeft, installment, taxReduction);

                schedule.AddPayment(payment);

                currentAmount = amountLeft;
            }

            return schedule;
        }

        public decimal GetInstallment()
        {
            var m = 1;
            var r = (YearlyInterest / 100M) / 4;
            var n = Terms;
            var g = LoanAmount;


            var parentes1 = m + 0.5M * r * (m - 1);
            var parentes2 = (1 - (decimal)Math.Pow((double)(1 + r), -n)) / r;

            return g / (parentes1 * parentes2);
        }

    }

    public class Payment
    {
        public decimal Interest { get; }
        public decimal Margin { get; }
        public decimal AmountLeft { get; }
        public decimal Installment { get; }
        public decimal TaxReduction { get; }
        public int Number { get; }

        public Payment(int number, decimal interest, decimal margin, decimal amountLeft, decimal installment, decimal taxReduction)
        {
            Number = number;
            Interest = interest;
            Margin = margin;
            AmountLeft = amountLeft;
            Installment = installment;
            TaxReduction = taxReduction;
        }
    }

    public class AmortizationSchedule
    {
        public List<Payment> Payments { get; } = new List<Payment>();

        public void AddPayment(Payment payment)
        {
            Payments.Add(payment);
        }
    }
}

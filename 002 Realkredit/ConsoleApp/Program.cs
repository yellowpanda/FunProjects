

using Model;

var loan = new MortgageCreditLoan(995658, 12*4, 2, 0.5112M, 25.5M);
var schedule = loan.GetAmortizationSchedule();

Console.WriteLine("Nummer   Ydelse       Skattefradrag   Renter og afdrag   Afdrag    Ny restgæld");

foreach (var payment in schedule.Payments)
{
    Console.WriteLine($"{payment.Number,6} {payment.Installment+payment.Margin,10:0.00}  {payment.TaxReduction,10:0.00} {payment.Margin+payment.Interest,15:0.00} {payment.Installment-payment.Interest,19:0.00} {payment.AmountLeft,10:0.00}" );
}

Console.WriteLine();
Console.WriteLine($"Total omkostning:{schedule.Payments.Sum(x => x.Interest + x.Margin),10:0.00}");
Console.WriteLine($"Total omkostning efter skat:{schedule.Payments.Sum(x => x.Interest + x.Margin - x.TaxReduction),10:0.00}");


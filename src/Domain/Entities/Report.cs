using Domain.Entities.Base;

namespace Domain.Entities;

public class Report : Entity
{
    public DateTime Date { get; private set; }
    public decimal Amount { get; private set; }
    public decimal DebitAmount { get; private set; }
    public decimal CreditAmount { get; private set; }

    public Report(DateTime date,  decimal debitAmount, decimal creditAmount)
    {
        Date = date;
        DebitAmount = debitAmount;
        CreditAmount = creditAmount;

        Amount = CreditAmount - DebitAmount;
    }
    
    protected Report(){}

    public void UpdateDailyReport(decimal debitAmount, decimal creditAmount)
    {
        DebitAmount += debitAmount;
        CreditAmount += creditAmount;

        Amount = CreditAmount - DebitAmount;
    }
}
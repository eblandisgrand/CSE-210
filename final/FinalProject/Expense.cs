public class Expense : Transaction
{
    public Expense(string name, decimal amount)
        : base(name, amount) { }

    public override decimal Apply() => -_amount;

    public override string GetDisplay()
        => $"{_date:d} - {_name}: {_amount:C}";
}

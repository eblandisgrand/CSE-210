public class Income : Transaction
{
    public Income(string name, decimal amount)
        : base(name, amount) { }

    public override decimal Apply() => _amount;

    public override string GetDisplay()
        => $"{_date:d} + {_name}: {_amount:C}";
}

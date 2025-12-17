public abstract class Transaction
{
    protected string _name;
    protected decimal _amount;
    protected DateTime _date;

    public Transaction(string name, decimal amount)
    {
        _name = name;
        _amount = amount;
        _date = DateTime.Now;
    }

    public abstract decimal Apply();
    public abstract string GetDisplay();
}

public class BankAccount
{
    private string _name;
    private List<Transaction> _transactions = new();

    public BankAccount(string name)
    {
        _name = name;
    }

    public string GetName() => _name;

    public void AddTransaction(Transaction t)
    {
        _transactions.Add(t);
    }

    public decimal GetBalance()
    {
        decimal balance = 0;
        foreach (var t in _transactions)
            balance += t.Apply();
        return balance;
    }

    public void DisplayHistory()
    {
        Console.WriteLine($"\n--- {_name} History ---");
        foreach (var t in _transactions)
            Console.WriteLine(t.GetDisplay());
            Console.WriteLine("\n\n");
    }
}

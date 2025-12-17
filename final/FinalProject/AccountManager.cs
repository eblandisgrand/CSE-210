public class AccountManager
{
    private List<BankAccount> _accounts = new();

    public void AddAccount(string name)
    {
        _accounts.Add(new BankAccount(name));
    }

    public void RemoveAccount(int index)
    {
        if (index >= 0 && index < _accounts.Count)
            _accounts.RemoveAt(index);
    }

    public BankAccount GetAccount(int index)
    {
        if (index >= 0 && index < _accounts.Count)
            return _accounts[index];
        return null;
    }

    public int Count() => _accounts.Count;

    public void DisplayAccounts()
    {
        Console.WriteLine("\n--- Accounts ---");
        for (int i = 0; i < _accounts.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_accounts[i].GetName()} : {_accounts[i].GetBalance():C}"
            );
        }
    }
}

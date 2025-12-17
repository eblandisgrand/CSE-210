public class Menu
{
    private AccountManager _manager;

    public Menu(AccountManager manager)
    {
        _manager = manager;
    }

    private BankAccount SelectAccount()
    {
        _manager.DisplayAccounts();
        Console.Write("Select account #: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
            return _manager.GetAccount(choice - 1);

        Console.WriteLine("Invalid selection.");
        return null;
    }

    public void Run()
    {
        bool running = true;

        while (running)
        {
            Calendar.DisplayCalendar(DateTime.Now);
            _manager.DisplayAccounts();
            Console.WriteLine("\n  ----- Menu -----");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Delete Account");
            Console.WriteLine("3. Add Income");
            Console.WriteLine("4. Add Expense");
            Console.WriteLine("5. View History");
            Console.WriteLine("6. Quit");
            Console.Write("Choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Account name: ");
                    _manager.AddAccount(Console.ReadLine());
                    break;

                case "2":
                    _manager.DisplayAccounts();
                    Console.Write("Delete #: ");
                    if (int.TryParse(Console.ReadLine(), out int del))
                        _manager.RemoveAccount(del - 1);
                    break;

                case "3":
                    var accI = SelectAccount();
                    if (accI == null) break;
                    Console.Write("Income name: ");
                    string iname = Console.ReadLine();
                    Console.Write("Amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal iam))
                        accI.AddTransaction(new Income(iname, iam));
                    break;

                case "4":
                    var accE = SelectAccount();
                    if (accE == null) break;
                    Console.Write("Expense name: ");
                    string ename = Console.ReadLine();
                    Console.Write("Amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal eam))
                        accE.AddTransaction(new Expense(ename, eam));
                    break;

                case "5":
                    var accH = SelectAccount();
                    accH?.DisplayHistory();
                    break;

                case "6":
                    running = false;
                    break;
            }
        }
    }
}

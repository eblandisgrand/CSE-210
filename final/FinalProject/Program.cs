class Program
{
    static void Main()
    {
        AccountManager manager = new();
        Menu menu = new(manager);
        menu.Run();
    }
}

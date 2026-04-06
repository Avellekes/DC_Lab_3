public class Account
{
    public string Id { get; set; }
    public int Balance { get; set; }

    public Account(string id)
    {
        Id = id;
        Balance = 100;
    }

    public override string ToString()
    {
        return $"{Id}: {Balance}";
    }
}
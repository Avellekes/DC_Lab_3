public class Transaction
{
    public string Sender { get; set; }
    public string Receiver { get; set; }
    public int Amount { get; set; }

    public Transaction(string sender, string receiver, int amount)
    {
        Sender = sender;
        Receiver = receiver;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{Sender} -> {Receiver}: {Amount}";
    }
}
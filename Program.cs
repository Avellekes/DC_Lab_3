using System;
using System.Security.Principal;
using System.Transactions;

class Program
{
    static void Main()
    {
        Blockchain blockchain = new Blockchain();

        Account user1 = new Account("Will");
        Account user2 = new Account("Bartender");

        Console.WriteLine("Users:");
        Console.WriteLine(user1);
        Console.WriteLine(user2);

        // Транзакція
        Transaction tx1 = new Transaction(user1.Id, user2.Id, 20);

        // Оновлення балансу
        user1.Balance -= 20;
        user2.Balance += 20;

        blockchain.AddTransaction(tx1);

        // "Майнінг" блоку
        blockchain.MineBlock();

        Console.WriteLine("\nAfter transaction:");
        Console.WriteLine(user1);
        Console.WriteLine(user2);

        Console.WriteLine("\nBlockchain:");

        foreach (var block in blockchain.Chain)
        {
            Console.WriteLine($"Block #{block.Index}");
            Console.WriteLine($"Hash: {block.Hash}");
            Console.WriteLine($"PrevHash: {block.PreviousHash}");

            foreach (var tx in block.Transactions)
                Console.WriteLine("  " + tx);

            Console.WriteLine();
        }
    }
}
using System.Collections.Generic;

public class Blockchain
{
    public List<Block> Chain { get; set; } = new List<Block>();
    public List<Transaction> PendingTransactions { get; set; } = new List<Transaction>();

    public Blockchain()
    {
        Chain.Add(CreateGenesisBlock());
    }

    private Block CreateGenesisBlock()
    {
        return new Block(0, new List<Transaction>(), "0");
    }

    public Block GetLatestBlock()
    {
        return Chain[Chain.Count - 1];
    }

    public void AddTransaction(Transaction transaction)
    {
        PendingTransactions.Add(transaction);
    }

    public void MineBlock()
    {
        Block block = new Block(Chain.Count, PendingTransactions, GetLatestBlock().Hash);
        Chain.Add(block);
        PendingTransactions = new List<Transaction>();
    }
}
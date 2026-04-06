using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

public class Block
{
    public int Index { get; set; }
    public DateTime Timestamp { get; set; }
    public List<Transaction> Transactions { get; set; }
    public string PreviousHash { get; set; }
    public string Hash { get; set; }

    public Block(int index, List<Transaction> transactions, string previousHash)
    {
        Index = index;
        Transactions = transactions;
        PreviousHash = previousHash;
        Timestamp = DateTime.Now;
        Hash = CalculateHash();
    }

    public string CalculateHash()
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            string rawData = Index + Timestamp.ToString() + PreviousHash;

            foreach (var tx in Transactions)
                rawData += tx.ToString();

            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
                builder.Append(b.ToString("x2"));

            return builder.ToString();
        }
    }
}
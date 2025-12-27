using System;

public class SaleTransaction{
    public string InvoiceNo { get; set; } = string.Empty;
    public string CustomerName { get; set; } = string.Empty;
    public string ItemName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal PurchaseAmount { get; set; }
    public decimal SellingAmount { get; set; }
    public string ProfitOrLossStatus { get; set; } = string.Empty;
    public decimal ProfitOrLossAmount { get; set; }
    public decimal ProfitMarginPercent { get; set; }

    static SaleTransaction? LastTransaction = null;
    static bool HasLastTransaction = false;

    public static void Register(){
        SaleTransaction SObj = new SaleTransaction();

        Console.Write("Enter Invoice No: ");
        var invoiceInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(invoiceInput)){
            Console.WriteLine("Invoice No cannot be empty");
            return;
        }
        SObj.InvoiceNo = invoiceInput;

        Console.Write("Enter Customer Name: ");
        var customerInput = Console.ReadLine();
        SObj.CustomerName = customerInput ?? string.Empty;

        Console.Write("Enter Item Name: ");
        var itemInput = Console.ReadLine();
        SObj.ItemName = itemInput ?? string.Empty;

        Console.Write("Enter Quantity: ");
        var qtyInput = Console.ReadLine();
        int qtyParsed;
        if(!int.TryParse(qtyInput, out qtyParsed) || qtyParsed <= 0){
            Console.WriteLine("Quantity must be greater than zero");
            return;
        }
        SObj.Quantity = qtyParsed;

        Console.Write("Enter Purchase Amount (total): ");
        var purchaseInput = Console.ReadLine();
        decimal purchaseParsed;
        if(!decimal.TryParse(purchaseInput, out purchaseParsed) || purchaseParsed <= 0){
            Console.WriteLine("Purchase Amount must be greater than zero");
            return;
        }
        SObj.PurchaseAmount = purchaseParsed;

        Console.Write("Enter Selling Amount (total): ");
        var sellingInput = Console.ReadLine();
        decimal sellingParsed;
        if(!decimal.TryParse(sellingInput, out sellingParsed) || sellingParsed < 0){
            Console.WriteLine("Selling Amount must be zero or positive");
            return;
        }
        SObj.SellingAmount = sellingParsed;

        if(SObj.SellingAmount > SObj.PurchaseAmount){
            SObj.ProfitOrLossStatus = "PROFIT";
            SObj.ProfitOrLossAmount = SObj.SellingAmount - SObj.PurchaseAmount;
        }
        else if(SObj.SellingAmount < SObj.PurchaseAmount){
            SObj.ProfitOrLossStatus = "LOSS";
            SObj.ProfitOrLossAmount = SObj.PurchaseAmount - SObj.SellingAmount;
        }
        else{
            SObj.ProfitOrLossStatus = "BREAK-EVEN";
            SObj.ProfitOrLossAmount = 0;
        }

        SObj.ProfitMarginPercent = SObj.PurchaseAmount != 0 ? (SObj.ProfitOrLossAmount / SObj.PurchaseAmount) * 100 : 0;

        LastTransaction = SObj;
        HasLastTransaction = true;

        Console.WriteLine("\nTransaction saved successfully.");
        Console.WriteLine("Status: " + SObj.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + SObj.ProfitOrLossAmount);
        Console.WriteLine("Profit Margin (%): " + SObj.ProfitMarginPercent);
    }

    public static void View(){
        if (!HasLastTransaction)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }

        Console.WriteLine("\n-------------- Last Transaction --------------");
        Console.WriteLine("InvoiceNo: " + LastTransaction.InvoiceNo);
        Console.WriteLine("Customer: " + LastTransaction.CustomerName);
        Console.WriteLine("Item: " + LastTransaction.ItemName);
        Console.WriteLine("Quantity: " + LastTransaction.Quantity);
        Console.WriteLine("Purchase Amount: " + LastTransaction.PurchaseAmount);
        Console.WriteLine("Selling Amount: " + LastTransaction.SellingAmount);
        Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAmount);
        Console.WriteLine("Profit Margin (%): " + LastTransaction.ProfitMarginPercent);
    }

    public static void Calculate(){
        if(!HasLastTransaction){
            Console.WriteLine("No transaction available. Please create a new transaction first");
            return;
        }

        if(LastTransaction.SellingAmount > LastTransaction.PurchaseAmount){
            LastTransaction.ProfitOrLossStatus = "PROFIT";
            LastTransaction.ProfitOrLossAmount = LastTransaction.SellingAmount - LastTransaction.PurchaseAmount;
        }
        else if (LastTransaction.SellingAmount < LastTransaction.PurchaseAmount){
            LastTransaction.ProfitOrLossStatus = "LOSS";
            LastTransaction.ProfitOrLossAmount = LastTransaction.PurchaseAmount - LastTransaction.SellingAmount;
        }
        else{
            LastTransaction.ProfitOrLossStatus = "BREAK-EVEN";
            LastTransaction.ProfitOrLossAmount = 0;
        }

        LastTransaction.ProfitMarginPercent = (LastTransaction.ProfitOrLossAmount / LastTransaction.PurchaseAmount) * 100;

        Console.WriteLine("\nRecalculated Result:");
        Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAmount);
        Console.WriteLine("Profit Margin (%): " + LastTransaction.ProfitMarginPercent);
    }

    public static void Main(string[] args){
        while (true){
            Console.WriteLine("\n================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            string? choice = Console.ReadLine();

            switch (choice){
                case "1":
                    Register();
                    break;

                case "2":
                    View();
                    break;

                case "3":
                    Calculate();
                    break;

                case "4":
                    Console.WriteLine("Thank you. Application closed normally");
                    return;

                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
using System;

public class PatientBill{
    public string BillId { get; set; }
    public string PatientName { get; set; }
    public bool HasInsurance { get; set; }
    public decimal ConsultationFee { get; set; }
    public decimal LabCharges { get; set; }
    public decimal MedicineCharges { get; set; }
    public decimal GrossAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalAmount { get; set; }

    static PatientBill LastBill = null;
    static bool HasLastBill = false;

    public static void BillService(){
        PatientBill billObj = new PatientBill();

        Console.Write("Enter Bill Id: ");
        billObj.BillId = Console.ReadLine();
        if (billObj.BillId == ""){
            Console.WriteLine("Validate BillId is  can't be non-empty");
            return;
        }



        Console.Write("PatientName: ");
        billObj.PatientName = Console.ReadLine();

        Console.Write("Is the patient insured? (Y/N): ");
        string ins = Console.ReadLine();
        billObj.HasInsurance = (ins == "Y" || ins == "y");



        Console.Write("Enter Consultation Fee: ");
        decimal consultationFee;
        if (!decimal.TryParse(Console.ReadLine(), out consultationFee) || consultationFee <= 0){
            Console.WriteLine("ConsultationFee must be greater than zero.");
            return;
        }
        billObj.ConsultationFee = consultationFee;



        Console.Write("Enter Lab Charges: ");
        decimal labCharges;
        if (!decimal.TryParse(Console.ReadLine(), out labCharges) || labCharges < 0){
            Console.WriteLine("Lab Charges must be zero or positive.");
            return;
        }
        billObj.LabCharges = labCharges;



        Console.Write("Enter Medicine Charges: ");
        decimal medicineCharges;
        if (!decimal.TryParse(Console.ReadLine(), out medicineCharges) || medicineCharges < 0){
            Console.WriteLine("Medicine Charges must be zero or positive.");
            return;
        }
        billObj.MedicineCharges = medicineCharges;



        billObj.GrossAmount = billObj.ConsultationFee + billObj.LabCharges + billObj.MedicineCharges;

        if (billObj.HasInsurance == true){
            billObj.DiscountAmount = billObj.GrossAmount * 0.10m;
        }
        else{
            billObj.DiscountAmount = 0;
        }

        billObj.FinalAmount = billObj.GrossAmount - billObj.DiscountAmount;

        LastBill = billObj;
        HasLastBill = true;

        Console.WriteLine("\nBill created successfully.");
        Console.WriteLine("Gross Amount: " + billObj.GrossAmount);
        Console.WriteLine("Discount Amount: " + billObj.DiscountAmount);
        Console.WriteLine("FinalAmount: " + billObj.FinalAmount);
    }

    public static void View()
    {
        if (!HasLastBill){
            Console.WriteLine("No bill available. Please create a new bill first");
            return;
        }

        Console.WriteLine("\n----------- Last Bill -----------");
        Console.WriteLine("BillId: " + LastBill.BillId);
        Console.WriteLine("Patient: " + LastBill.PatientName);
        Console.WriteLine("Insured: " + (LastBill.HasInsurance ? "Yes" : "No"));
        Console.WriteLine("Consultation Fee: " + LastBill.ConsultationFee);
        Console.WriteLine("Lab Charges: " + LastBill.LabCharges);
        Console.WriteLine("Medicine Charges: " + LastBill.MedicineCharges);
        Console.WriteLine("Gross Amount: " + LastBill.GrossAmount);
        Console.WriteLine("Discount Amount: " + LastBill.DiscountAmount);
        Console.WriteLine("FinalAmount: " + LastBill.FinalAmount);
    }

    public static void ClearLastBill(){
        LastBill = null;
        HasLastBill = false;
        Console.WriteLine("Last bill cleared.");
    }

    public static void Main(string[] args){
        while (true){
            Console.WriteLine("\n===== MediSure Clinic Billing ======");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BillService();
                    break;

                case "2":
                    View();
                    break;

                case "3":
                    ClearLastBill();
                    break;

                case "4":
                    Console.WriteLine("Thank you. Application closed normally.");
                    return;

                default:
                    Console.WriteLine("Invalid option.Please choose between 1 and 4.");
                    break;
            }
        }
    }
}
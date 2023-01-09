using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(String cardNum, int pin, String firstName, String lastName, double balance) 
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum()
    {
        return cardNum;
    }
    public int getpin()
    {
        return pin;
    }
    public String getFirstName()
    {
        return firstName;
    }
    public String getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    public void setNum(String newCarNum) {
        cardNum = newCarNum;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }
    public void setBalanace(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args) 
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalanace(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw? ");
            double withdrawl = Double.Parse(Console.ReadLine());
            // to check if user has enough money
            if(currentUser.getBalance() > withdrawl)
            {
                Console.WriteLine("Insufficient balabnce :(");
            }
            else 
            {
                currentUser.setBalanace(currentUser.getBalance() - withdrawl);
                Console.WriteLine("You are good to go! Thanks you :)");
            }
        }

        void balabnce(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("123456789", 1234, "John", "Doe", 150.31));
        cardHolders.Add(new cardHolder("12345623", 2341, "Jane", "Doe", 321.13));
        cardHolders.Add(new cardHolder("125436789", 3412, "Sara", "Smith", 540.50));
        cardHolders.Add(new cardHolder("178456789", 4123, "Baby", "Doe", 175.00));
        cardHolders.Add(new cardHolder("123456123", 1324, "Dawn", "Smith", 350.75));

        // Prompt user
        Console.WriteLine("Welcome to Simple ATM");
        Console.WriteLine("Please insert your debit cared: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                // check against db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch { Console.WriteLine("Card not recognized. Please try again"); }
        }
        Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                //check against the db
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if(currentUser.getpin() == userPin) { break; }
                else { Console.WriteLine("Incorrect pin. Please try again"); }
            }
            catch { Console.WriteLine("Incorrect pin. Please try again"); }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch {  }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balabnce(currentUser); }
            else if(option == 4) { break; }
            else { option = 0; }
        } 
        while (option != 4);
        Console.WriteLine("Thank you! Have a nice day: :)");
    }

}

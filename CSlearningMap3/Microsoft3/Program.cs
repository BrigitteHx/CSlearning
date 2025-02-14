// See https://aka.ms/new-console-template for more information

// UNIT 2

//Console.WriteLine("a" == "a");
//Console.WriteLine("a" == "A");
//Console.WriteLine(1 == 2);

//string myValue = "a";
//Console.WriteLine(myValue == "a");

//string value1 = " a";
//string value2 = "A ";
//Console.WriteLine(value1.Trim().ToLower() == value2.Trim().ToLower());

//Console.WriteLine("a" != "a");
//Console.WriteLine("a" != "A");
//Console.WriteLine(1 != 2);

//string myValue = "a";
//Console.WriteLine(myValue != "a");

//Console.WriteLine(1 > 2);
//Console.WriteLine(1 < 2);
//Console.WriteLine(1 >= 1);
//Console.WriteLine(1 <= 1);

//string pangram = "The quick brown fox jumps over the lazy dog.";
//Console.WriteLine(!pangram.Contains("fox"));
//Console.WriteLine(!pangram.Contains("cow"));

// UNIT 3

//int saleAmount = 1001;
//int discount = saleAmount > 1000 ? 100 : 50;
//Console.WriteLine($"Discount: {discount}");

//int saleAmount = 1001;
//// int discount = saleAmount > 1000 ? 100 : 50;

//Console.WriteLine($"Discount: {(saleAmount > 1000 ? 100 : 50)}");

//// UNIT 4

//// random object voor de muntworp
//Random coin = new Random();

//// random 0 of 1
//int flip = coin.Next(0, 2);

//// bij value 0 = heads, anders tails
//Console.WriteLine(flip == 0 ? "Heads" : "Tails");

// UNIT 6 

string userRole = "Admin|Manager";
int accessLevel = 53;

if (userRole.Contains("Admin"))
{
    if (accessLevel > 55)
    {
        // super admin
        Console.WriteLine("Welcome, Super Admin user.");
    }
    else
    {
        // admin 
        Console.WriteLine("Welcome, Admin user.");
    }
}
else if (userRole.Contains("Manager"))
{
    if (accessLevel >= 20)
    {
        // vraag aan admin
        Console.WriteLine("Contact an Admin for access.");
    }
    else
    {
        // geen rechten 
        Console.WriteLine("You do not have sufficient privileges.");
    }
}
else
{
    // ook geen rechten
    Console.WriteLine("You do not have sufficient privileges.");
}


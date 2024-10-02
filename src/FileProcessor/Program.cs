using static System.Console;
// See https://aka.ms/new-console-template for more information

WriteLine("File Processor");
WriteLine("--------------");

while (true)
{
    WriteLine();
    WriteLine("(V)erify Only ");
    WriteLine("(I)mport Into Database ");
    WriteLine("(P)rint ");
    WriteLine("(E)xit ");

    WriteLine("Enter choice: ");

    var input = ReadLine();

    switch (input.ToUpper())
    {
        case "V":
            Verify();
            break;
        case "I":
            Import();
            break;
        case "P":
            Print();
            break;
        case "C":
            Convert();
            break;
        case "E":
            return;
        default:
            WriteLine("Invalid choice. Please try again.");
            break;
    }
}

void Convert()
{
    throw new NotImplementedException();
}

void Print()
{
    WriteLine("Printing...");
}

void Import()
{
    WriteLine("Importing...");
}

void Verify()
{
    WriteLine("Verifying...");
}

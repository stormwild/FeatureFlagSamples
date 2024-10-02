using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.FeatureManagement;

using static System.Console;
// See https://aka.ms/new-console-template for more information

IFeatureManager FeatureManagerService;

InitializeFeatures();


void InitializeFeatures()
{
    var flags = new Dictionary<string, string>
    {
        { nameof(FileProcessorFeatures.Convert), "true" },
    };

    IConfigurationBuilder builder = new ConfigurationBuilder();
    builder.AddInMemoryCollection(flags);

    var configuration = builder.Build();

    IServiceCollection services = new ServiceCollection();
    services.AddFeatureManagement(configuration);

    var serviceProvider = services.BuildServiceProvider();

    FeatureManagerService = serviceProvider.GetRequiredService<IFeatureManager>();

}

WriteLine("File Processor");
WriteLine("--------------");

while (true)
{
    WriteLine();
    WriteLine("(V)erify Only ");
    WriteLine("(I)mport Into Database ");

    if (await FeatureManagerService.IsEnabledAsync(nameof(FileProcessorFeatures.Convert)))
    {
        WriteLine("(C)onvert ");
    }

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
            if (await FeatureManagerService.IsEnabledAsync(nameof(FileProcessorFeatures.Convert)))
            {
                Convert();
            }
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


enum FileProcessorFeatures
{
    Convert
}
namespace TableGamesManagementSystem;

class TableGamesManagementSystem
{
    private TableGamesMenu menu = new();

    public void Run()
    {
        Console.WriteLine("Running the Table Games Management System...");
        Console.WriteLine("Welcome to Noah's Table Game Management System!");

        bool running = true;
        while (running)
        {
            Console.WriteLine("\nPlease select an option: \n");
            Console.WriteLine("1. Current Tables\n2. Add New Table\n3. Request a Fill\n4. Request a Credit\n5. Exit\n");

            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        menu.DisplayTables();
                        break;
                    case 2:
                        Console.WriteLine("Add New Table selected");
                        break;
                    case 3:
                        Console.WriteLine("Request a Fill selected");
                        break;
                    case 4:
                        Console.WriteLine("Request a Credit selected");
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
    }
}

class TableGamesMenu
{
    public void DisplayTables()
    {
        // There are 8 tables in total, 4 Blackjack, 2 Ultimate Texas Hold'em, and 2 Three Card Poker
        Console.WriteLine("\n--- Available Tables ---");
        Console.WriteLine("1. Blackjack Table 1");
        Console.WriteLine("2. Blackjack Table 2");
        Console.WriteLine("3. Blackjack Table 3");
        Console.WriteLine("4. Blackjack Table 4");
        Console.WriteLine("5. Ultimate Texas Hold'em Table 1");
        Console.WriteLine("6. Ultimate Texas Hold'em Table 2");
        Console.WriteLine("7. Three Card Poker Table 1");
        Console.WriteLine("8. Three Card Poker Table 2");
    }

    public string GetTableChoice(int choice)
    {
        return choice switch
        {
            1 => "Blackjack Table 1",
            2 => "Blackjack Table 2",
            3 => "Blackjack Table 3",
            4 => "Blackjack Table 4",
            5 => "Ultimate Texas Hold'em Table 1",
            6 => "Ultimate Texas Hold'em Table 2",
            7 => "Three Card Poker Table 1",
            8 => "Three Card Poker Table 2",
            _ => "Invalid Choice"
        };
    }
}

public enum ChipColor
{
    Yellow,
    White,
    Red,
    Green,
    Black,
    Purple
}

public enum TableType
{
    Blackjack,
    UltimateTexasHoldem,
    ThreeCardPoker
}

public class Chip
{
    public ChipColor Color { get; }
    public decimal Value => ChipValues[Color];

    private static readonly Dictionary<ChipColor, decimal> ChipValues = new()
    {
        { ChipColor.Yellow, .5m },
        { ChipColor.White, 1 },
        { ChipColor.Red, 5 },
        { ChipColor.Green, 25 },
        { ChipColor.Black, 100 },
        { ChipColor.Purple, 500 }
    };

    public Chip(ChipColor color)
    {
        Color = color;
    }

    public override string ToString() => $"{Color} chip (${Value})";
}


public class Tray
{
    private List<Chip> chips = new();

    public Tray(TableType tableType)
    {
        // Assuming we are creating a new table, we will initialize the tray with a standard set of chips based on the table type
        switch (tableType)
        {
            case TableType.Blackjack:
                AddChips(ChipColor.Purple, 40);
                AddChips(ChipColor.Black, 60);
                AddChips(ChipColor.Green, 120);
                AddChips(ChipColor.Red, 300);
                AddChips(ChipColor.White, 60);
                AddChips(ChipColor.Yellow, 60);
                break;
            case TableType.ThreeCardPoker:
                AddChips(ChipColor.Purple, 40);
                AddChips(ChipColor.Black, 60);
                AddChips(ChipColor.Green, 120);
                AddChips(ChipColor.Red, 300);
                AddChips(ChipColor.White, 60);
                AddChips(ChipColor.Yellow, 60);
                break;
            case TableType.UltimateTexasHoldem:
                AddChips(ChipColor.Purple, 40);
                AddChips(ChipColor.Black, 40);
                AddChips(ChipColor.Green, 140);
                AddChips(ChipColor.Red, 300);
                AddChips(ChipColor.White, 60);
                AddChips(ChipColor.Yellow, 60);
                break;
        }
    }
    public void AddChips(ChipColor color, int count)
    {
        for (int i = 0; i < count; i++)
            chips.Add(new Chip(color));
    }

    public void PrintTray()
    {
        Console.WriteLine("Tray contains: ");
        var grouped = chips.GroupBy(c => c.Color);
        foreach (var group in grouped)
            Console.WriteLine($"{group.Count()} x {group.Key} chip (${group.First().Value})");
    }
}


public class Table
{
    public TableType Type { get; }
    public Tray Tray { get; }

    public Table(TableType type)
    {
        Type = type;
        Tray = new Tray(type);
    }

    public void PrintTableInfo()
    {
        Console.WriteLine($"Table Type: {Type}");
        Tray.PrintTray();
    }
}
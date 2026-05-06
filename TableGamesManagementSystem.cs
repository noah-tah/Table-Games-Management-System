Console.WriteLine("Hello, World!");

Console.WriteLine("Welcome to Noah's Table Game Management System!");

class TableGamesManagementSystem
{
    public void Run()
    {
        Console.WriteLine("Running the Table Games Management System...");
        Console.WriteLine("Welcome to Noah's Table Game Management System!");
        Console.WriteLine("Please select one of the following tables to manage:");
        // Add your game management logic here
    }
}

class TableGamesMenu
{
    public void DisplayTables()
    {
        // There are 8 tables in total, 4 Blackjack, 2 Ultimate Texas Hold'em, and 2 Three Card Poker
        Console.WriteLine("1. Blackjack Table 1");
        Console.WriteLine("2. Blackjack Table 2");
        Console.WriteLine("3. Blackjack Table 3");
        Console.WriteLine("4. Blackjack Table 4");
        Console.WriteLine("5. Ultimate Texas Hold'em Table 1");
        Console.WriteLine("6. Ultimate Texas Hold'em Table 2");
        Console.WriteLine("7. Three Card Poker Table 1");
        Console.WriteLine("8. Three Card Poker Table 2");
    }

    string GetTableChoice(int choice)
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

// TODO: Default Tray values based upon the table
// TODO: Fill table function to add chips to the tray to match default fill amounts to the table
public class Tray
{
    private List<Chip> chips = new();

    public Tray()
    {
        // We will initialize the tray with default amounts of chips based upon on the table
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
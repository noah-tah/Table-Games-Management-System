using System.Runtime.CompilerServices;

namespace TableGamesManagementSystem;


class TableGamesManagementSystem
{
    private TableGamesMenu menu = new();
    // This is NOT getting a list of tables, it is creating an empty list to STORE them.
    private List<Table> tables = new();
    // tables is now: [ ] 

    public void Run()
    {
        Console.WriteLine("Running the Table Games Management System...");
        Console.WriteLine("Welcome to Noah's Table Game Management System!");

        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Current Tables\n2. Add New Table\n3. Request a Fill\n4. Request a Credit\n5. Exit\n");

            Console.Write("Enter your choice: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
            {
                switch (choice)
                {
                    case 1:
                        menu.DisplayTables(tables);
                        break;
                    case 2:
                        CreateTable();
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

    private void CreateTable()
    {
        Console.WriteLine("\nWhat type of table would you like to create? \n");
        Console.WriteLine("1. Blackjack\n2. Ultimate Texas Hold'em\n3. Three Card Poker\n");

        string? input = Console.ReadLine();

        if (int.TryParse(input, out int choice))
        {
            TableType? tableType = choice switch
            {
                1 => TableType.Blackjack,
                2 => TableType.UltimateTexasHoldem,
                3 => TableType.ThreeCardPoker,
                _ => null
            };

            if (tableType.HasValue)
            {
                Console.WriteLine("\nEnter a name for this table: ");
                string? tableName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(tableName))
                {
                    tableName = "Unnamed Table";
                }

                Table newTable = new(tableType.Value, tableName);
                tables.Add(newTable);
                Console.WriteLine($"\nSuccessfully created {tableType.Value} table!");
                newTable.PrintTableInfo();
                Console.WriteLine("Would you like to manage this table now? (y/n)");

                string? manageInput = Console.ReadLine();

                if (manageInput != null && manageInput.Trim().ToLower() == "y")
                {
                    // Here we would call a method to manage the table, but since we haven't implemented that yet, we'll just print a message for now.
                    Console.WriteLine($"Managing {newTable.Name}...");
                    // ManageTable(newTable); // This is where we would implement the management functionality in the future.
                }

                if (manageInput != null && manageInput.Trim().ToLower() == "n")
                {
                    Console.WriteLine("Returning to main menu...");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}

class TableGamesMenu
{
    public void DisplayTables(List<Table> tables)
    {
        if (tables.Count == 0)
        {
            Console.WriteLine("No tables created yet");
            return;
        }

        Console.WriteLine("\n--- Current Tables ---");
        foreach (var table in tables)
        {
            table.PrintTableInfo();
            Console.WriteLine();
        }
    }

    // Eventually going to need to be updated to return Table objects instead of strings
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

    public static readonly Dictionary<ChipColor, decimal> ChipValues = new()
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
    private Dictionary<ChipColor, int> chipCounts = new();

    // This is the constructor, and we are initialzing the tray here with its initial set of chips based on the table type
    public Tray(TableType tableType)
    {
        // Assuming we are creating a new table, we will initialize the tray with a standard set of chips based on the table type
        switch (tableType)
        {
            case TableType.Blackjack:
                chipCounts[ChipColor.Purple] = 40;
                chipCounts[ChipColor.Black] = 60;
                chipCounts[ChipColor.Green] = 120;
                chipCounts[ChipColor.Red] = 300;
                chipCounts[ChipColor.White] = 60;
                chipCounts[ChipColor.Yellow] = 60;
                break;
            case TableType.ThreeCardPoker:
                chipCounts[ChipColor.Purple] = 40;
                chipCounts[ChipColor.Black] = 60;
                chipCounts[ChipColor.Green] = 120;
                chipCounts[ChipColor.Red] = 300;
                chipCounts[ChipColor.White] = 60;
                chipCounts[ChipColor.Yellow] = 60;
                break;
            case TableType.UltimateTexasHoldem:
                chipCounts[ChipColor.Purple] = 40;
                chipCounts[ChipColor.Black] = 40;
                chipCounts[ChipColor.Green] = 140;
                chipCounts[ChipColor.Red] = 300;
                chipCounts[ChipColor.White] = 60;
                chipCounts[ChipColor.Yellow] = 60;
                break;
        }
    }

    public static Tray NewTray(TableType tableType)
    {
        return new Tray(tableType);
    }

    public void AddChips(ChipColor color, int count)
    {
        chipCounts[color] = chipCounts.GetValueOrDefault(color, 0) + count;
    }

    public bool RemoveChips(ChipColor color, int count)
    {
        if (chipCounts.TryGetValue(color, out int current) && current >= count)
        {
            chipCounts[color] = current - count;
            if (chipCounts[color] == 0)
            {
                chipCounts.Remove(color);
            }
            return true;
        }
        return false; // Not enough chips
    }

    public void PrintTray()
    {
        Console.WriteLine("Tray contains: ");
        foreach (var kvp in chipCounts.OrderBy(kvp => kvp.Key))
            Console.WriteLine($"{kvp.Value} x {kvp.Key} chip (${Chip.ChipValues[kvp.Key]})");
    }
}


public class Table
{
    public string Name { get; set; }
    public TableType Type { get; }
    public Tray Tray { get; }


    public Table(TableType type, string name = "Unnamed Table")
    {
        Type = type;
        Name = name;
        Tray = Tray.NewTray(type);
    }

    public void PrintTableInfo()
    {
        Console.WriteLine($"Table Name: {Name}");
        Console.WriteLine($"Table Type: {Type}");
        Tray.PrintTray();
    }

    public void ManageTable(Table table)
    {
        Console.WriteLine($"Managing {table.Name}...");
        // Here we would implement the management functionality, such as requesting fills or credits, but for
    }
}

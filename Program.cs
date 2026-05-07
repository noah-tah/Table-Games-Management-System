using System;
using System.Collections.Generic;
using System.Text;
using TableGamesManagementSystem;

namespace Table_Games_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var system = new TableGamesManagementSystem.TableGamesManagementSystem();
            system.Run();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageManagementSystem.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            OperatingSystem garageOperatingSystem = new OperatingSystem();
            garageOperatingSystem.UIManager();
        }
    }
}

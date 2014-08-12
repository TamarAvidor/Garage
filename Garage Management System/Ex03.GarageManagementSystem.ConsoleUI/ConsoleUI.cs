namespace Ex03.GarageManagementSystem.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic;

    /// <summary>
    /// User Interface Class.
    /// Asking user for relevant information, checking its ligability and insert to specific vehicle.
    /// this class will also print messages to communicate with user. 
    /// </summary>
    public static class ConsoleUI
    {
        /// <summary>
        /// Console message for user. will print detailed vehicle types the system supports.
        /// </summary>
        internal static void DetailingSupportingGarageVehicleTypes()
        {
            Console.WriteLine("The vehicles types that the system supports are:\n(1)Regular Car\n(2)Electric Car\n(3)Regular Motorcycle\n(4)Electric Motorcycle\n(5)Truck");
        }

        /// <summary>
        /// Welcome console message for user.
        /// </summary>
        internal static void WelcomeToGarageMessage()
        {
            Console.WriteLine("Hello, Welcome to your garage managment system");
        }

        /// <summary>
        /// GoodBye console message for user.
        /// </summary>
        internal static void GoodByeMessage()
        {
            Console.WriteLine("GoodBye, thank you for using garage managment system\nPlease enter any key to exit");
            Console.ReadLine();
        }

        /// <summary>
        /// Asks user to input the vehicle's model name.
        /// No logical check up as names can contain any chars.
        /// </summary>
        /// <returns>return vehicle's model name</returns>
        internal static string ModelNameInput()
        {
            string modelName = string.Empty;
            Console.WriteLine("Model Name:");
            StringInputAndCheckNotEmpty(out modelName);
            return modelName;
        }

        /// <summary>
        /// Asks user to input the vehicle's licesne number.
        /// No logical check up as license number can contain any chars.
        /// </summary>
        /// <returns>return vehicle's license number</returns>
        internal static string LicenseNumberInput()
        {
            string licenseNumber = string.Empty;
            Console.WriteLine("License Number:");
            StringInputAndCheckNotEmpty(out licenseNumber);
            return licenseNumber;
        }

        /// <summary>
        /// Asks user to input the vehicle's wheel manufacturer.
        /// No logical check up as names can contain any chars.
        /// </summary>
        /// <returns>return vehicle's wheel manufacturer</returns>
        internal static string WheelManufacturerInput()
        {
            string wheelManufacturer = string.Empty;
            Console.WriteLine("Wheel Manufacturer:");
            StringInputAndCheckNotEmpty(out wheelManufacturer);
            return wheelManufacturer;
        }

        /// <summary>
        /// Asks user to input the vehicle's owner name.
        /// No logical check up as names can contain any chars.
        /// </summary>
        /// <returns>return vehicle's owner name</returns>
        internal static string OwnerNameInput()
        {
            string ownerName;
            Console.WriteLine("Owner Name:");
            StringInputAndCheckNotEmpty(out ownerName);
            return ownerName;
        }

        internal static void StringInputAndCheckNotEmpty(out string io_propertyString)
        {
            io_propertyString = Console.ReadLine();
            while (io_propertyString.Length == 0)
            {
                Console.WriteLine("Wrong Input, Please Enter Again");
                io_propertyString = Console.ReadLine();
            }
        }

        /// <summary>
        /// Asks user to input the vehicle's owner phone number.
        /// Exception will be throw incase of input not containing digits only.
        /// </summary>
        /// <returns>return vehicle's owner phone number after logical check up</returns>
        internal static string OwnerPhoneInput()
        {
            string ownerPhone;
            Console.WriteLine("Owner Phone:");
            StringInputAndCheckNotEmpty(out ownerPhone);
            foreach (char digit in ownerPhone)
            {
                if (digit < '0' || digit > '9')
                {
                    throw new ValueOutOfRangeException(0, 9);
                }
            }

            return ownerPhone;
        }

        internal static Engine.e_EnergyType EnergyTypeToAppointInput()
        {
            string energyStringType = string.Empty;
            int energyIntType = int.MinValue;
            Engine.e_EnergyType energyType = Engine.e_EnergyType.Soler;
            Console.WriteLine(
@"Energy Type To Appoint:
1) Soler
2) Octan95
3) Octan96
4) Octan98
5) Battery");
            energyIntType = UserChoiceForRangeCheck(GlobalConstants.lowerRangeOfVehicleChoice, GlobalConstants.upperRangeOfVehicleChoice);
            energyType = (Engine.e_EnergyType)Enum.ToObject(typeof(Engine.e_EnergyType), energyIntType);
            return energyType;
        }

        /// <summary>
        /// Getting from user the amount of whatever energy time to appoint to specific vehicle.
        /// Will throw exception in two conditions: input is not digits or input is out of logical range to appoint. 
        /// </summary>
        /// <param name="currentEnergyAmount">current evergy amount to caculate the legality of user's input</param>
        /// <param name="maximumEnergyAmount">maximum evergy amount to caculate the legality of user's input</param>
        /// <returns>The energy amount to appoint after all check up are positives</returns>
        internal static float EnergyAmountToAppointInput(float i_currentEnergyAmount, float i_maximumEnergyAmount)
        {
            bool allGoodForParsing = false;
            float energyAmountToAppoint = float.MinValue;
            string energyAmountToAppointString = string.Empty;

            while (allGoodForParsing == false)
            {
                Console.WriteLine("Amount of energy to appoint: between 0 to {0}", i_maximumEnergyAmount - i_currentEnergyAmount);
                energyAmountToAppointString = Console.ReadLine();
                if (float.TryParse(energyAmountToAppointString, out energyAmountToAppoint) == true)
                {
                    if (energyAmountToAppoint > 0 && energyAmountToAppoint <= (i_maximumEnergyAmount - i_currentEnergyAmount))
                    {
                        allGoodForParsing = true;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(0, i_maximumEnergyAmount - i_currentEnergyAmount);
                    }
                }
                else
                {
                    throw new FormatException("Energy amount must be only numbers");
                }
            }

            return energyAmountToAppoint;
        }

        /// <summary>
        /// Asking user for the current value of a specific part of the vehcile such as fuel tank, batter capacity or air pressure of wheels.
        /// </summary>
        /// <param name="i_maxVehicleComponent">maximum component amount to caculate the legality of user's input</param>
        /// <returns>The specific current item/ object of the vehicle we wanted to measure</returns>
        internal static float CurrentMeasurementOfVehicleComponentInput(float i_maximumVehicleComponent)
        {
            bool allGoodForParsingAndRange = false;
            string currentStringVehicleComponent;
            float currentFloatVehicleComponent = float.MinValue;

            while (allGoodForParsingAndRange == false)
            {
                currentStringVehicleComponent = Console.ReadLine();
                if (float.TryParse(currentStringVehicleComponent, out currentFloatVehicleComponent) == true)
                {
                    if (currentFloatVehicleComponent >= 0 && currentFloatVehicleComponent <= i_maximumVehicleComponent)
                    {
                        allGoodForParsingAndRange = true;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(0, i_maximumVehicleComponent);
                    }
                }
                else
                {
                    throw new FormatException("This component must contain only numbers, Please enter again:");
                }
            }

            return currentFloatVehicleComponent;
        }

        /// <summary>
        /// Getting user choice for car colour by a numbered list of the options to choose from.
        /// User will choose 1-4 out of four possible colours.
        /// </summary>
        /// <returns>Returns the car colour after logical check up for colour presents as an optional colour from the list</returns>
        internal static Car.e_Color CarColorInput()
        {
            string carStringColor = string.Empty;
            int carIntColor = int.MinValue;
            Car.e_Color carColor = Car.e_Color.Black;
            carStringColor = string.Format(
@"Car color:
1) Red
2) Yellow
3) Black
4) Silver");
            Console.WriteLine(carStringColor);
            carIntColor = UserChoiceForRangeCheck(GlobalConstants.lowerRangeOfVehicleEnumChoice, GlobalConstants.upperRangeOfVehicleEnumChoice);
            carColor = (Car.e_Color)Enum.ToObject(typeof(Car.e_Color), carIntColor);
            return carColor;
        }

        /// <summary>
        /// Getting user choice for car doors by a numbered list of the options to choose from.
        /// User will choose 1-4 out of four possible doors amount per car.
        /// </summary>
        /// <returns>Returns the car number of doors after logical check up for amount presents as an optional number from the list</returns>
        internal static Car.e_NumberOfDoors NumberOfCarDoorsInput()
        {
            string carStringNumberOfDoors = string.Empty;
            int carIntNumberOfDoors = int.MinValue;
            Car.e_NumberOfDoors numberOfCarDoors = Car.e_NumberOfDoors.Five;
            carStringNumberOfDoors = string.Format(
@"Number of Doors:
1) Two
2) Three
3) Four
4) Five");
            Console.WriteLine(carStringNumberOfDoors);
            carIntNumberOfDoors = UserChoiceForRangeCheck(GlobalConstants.lowerRangeOfVehicleEnumChoice, GlobalConstants.upperRangeOfVehicleEnumChoice);
            numberOfCarDoors = (Car.e_NumberOfDoors)Enum.ToObject(typeof(Car.e_NumberOfDoors), carIntNumberOfDoors);
            return numberOfCarDoors;
        }

        /// <summary>
        /// Getting user choice for motorcycle license type by a numbered list of the options to choose from.
        /// User will choose 1-4 out of four possible license types exists.
        /// </summary>
        /// <returns>Returns the motorcycle license type after logical check up for type presents as an optional license from the list</returns>
        internal static Motorcycle.e_LicenseType LicenseTypeInput()
        {
            string licenseStringType = string.Empty;
            int licenseIntType = int.MinValue;
            Motorcycle.e_LicenseType licenseType = Motorcycle.e_LicenseType.A;
            licenseStringType = string.Format(
@"License Type:
1) A
2) A1
3) AA
4) B1");
            Console.WriteLine(licenseStringType);
            licenseIntType = UserChoiceForRangeCheck(GlobalConstants.lowerRangeOfVehicleEnumChoice, GlobalConstants.upperRangeOfVehicleEnumChoice);
            licenseType = (Motorcycle.e_LicenseType)Enum.ToObject(typeof(Motorcycle.e_LicenseType), licenseIntType);
            return licenseType;
        }

        /// <summary>
        /// Asking user if the truck has an hazardous carriage.
        /// yes/ no question, User will choose '1' for yes and '2' for no, out of two possible answers to the question presented as a list.
        /// </summary>
        /// <returns>Returns the users answer for carraying lugage after logical check up as an optional answer from the list</returns>
        internal static bool IsCarryingHazardousMaterialsInput()
        {
            string isStringCarrying = string.Empty;
            int isIntCarring = int.MinValue;
            bool isBoolCarrying = true;
            isStringCarrying = string.Format(
@"Is Truck Carrying Hazardous Materials?:
1) Yes
2) No");
            Console.WriteLine(isStringCarrying);
            isIntCarring = UserChoiceForRangeCheck(GlobalConstants.yes, GlobalConstants.no);
            if (isIntCarring == 2)
            {
                isBoolCarrying = false;
            }

            return isBoolCarrying;
        }

        /// <summary>
        /// Asking user for trucks capacity volume.
        /// Will throw exception in two conditions: input is not digits or input is negative.
        /// </summary>
        /// <returns>Returns the volume capacity after logical check up</returns>
        internal static float TruckVolumeCapacityInput()
        {
            bool allGoodForParsingAndPositivity = false;
            string volumeCapacityString;
            float volumeCapacity = float.MinValue;
            while (allGoodForParsingAndPositivity == false)
            {
                Console.WriteLine("Please enter the truck's volume capacity: ");
                volumeCapacityString = Console.ReadLine();
                if (float.TryParse(volumeCapacityString, out volumeCapacity) == true)
                {
                    if (volumeCapacity >= 0)
                    {
                        allGoodForParsingAndPositivity = true;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException("Volume Capacity cannot be negative");
                    }
                }
                else
                {
                    throw new FormatException("Volume Capacity must be only numbers");
                }
            }

            return volumeCapacity;
        }

        /// <summary>
        /// Asking user for motorcycle engine capacity volume.
        /// Will throw exception in two conditions: input is not digits or input is negative.
        /// </summary>
        /// <returns>Returns the engine volume capacity after logical check up</returns>
        internal static int MotorcycleEngineCapacityInput()
        {
            bool allGoodForParsingAndPositivity = false;
            string engineCapacityStr;
            int engineCapacity = int.MinValue;
            while (allGoodForParsingAndPositivity == false)
            {
                Console.WriteLine("Please enter the motorcycle engine capacity: ");
                engineCapacityStr = Console.ReadLine();
                if (int.TryParse(engineCapacityStr, out engineCapacity) == true)
                {
                    if (engineCapacity > 0)
                    {
                        allGoodForParsingAndPositivity = true;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException("Engine capacity must be above zero");
                    }
                }
                else
                {
                    throw new FormatException("Engine capacity must be only numbers");
                }
            }

            return engineCapacity;
        }

        /// <summary>
        /// A print out method to give the user a detailed list of the optional functionality of the system.
        /// User will choose 1-7 and will be giving direct instructions to the next steps by his choice.
        /// </summary>
        internal static void DetailingMenuSystemFunctionality()
        {
            string menu = string.Format(
@"1) New vehicle to garage
2) Display list of vehicles in garage
3) Change vehicle status
4) Wheel infaltion to maximum
5) Fuel vehicle / Charge vehicle's battery
6) Display full information of a specific vehicle
7) Exit");
            Console.WriteLine(menu);
        }

        /// <summary>
        /// User will be asked for a choice wether to sort the list of vehicles in garage or not.
        /// yes/ no question, User will choose '1' for yes and '2' for no, out of two possible answers to the question presented as a list.
        /// </summary>
        /// <returns>Returns the users answer for sorting the list after logical check up as an optional answer from the list</returns>
        internal static bool AskUserIfToSortTheListInput()
        {
            bool toSortOptionQuestionBool = false;
            int toSortOptionQuestionInt = int.MinValue;
            string toSortOptionQuestionString = string.Format(
@"Would you like to sort the display list by vehicle status?
1)Yes
2)No");
            Console.WriteLine(toSortOptionQuestionString);
            toSortOptionQuestionInt = UserChoiceForRangeCheck(GlobalConstants.yes, GlobalConstants.no);
            if (toSortOptionQuestionInt == 1)
            {
                toSortOptionQuestionBool = true;
            }

            return toSortOptionQuestionBool;
        }

        /// <summary>
        /// If user chose to sort the list by the previous question we will now ask if what type of status he would like to see in the printed list.
        /// User will choose 1-3 out of 3 possible status of vehicles in garage.
        /// The status "WaitForStartingRepair" will be presented as "InRepairProcess" (as asked for in assignment).
        /// </summary>
        /// <returns>Returns the users answer after logical check up as an optional answer from the list</returns>
        internal static int AskUserForTypeToSortTheList() // oren
        {
            int specificTypeToSortQuestion = int.MinValue;
            string specificTypeToSortQuestionString = string.Format(
@"What vehicle status would you like to see?
1)In repair process
2)Repair Completed
3)Paid");
            Console.WriteLine(specificTypeToSortQuestionString);
            specificTypeToSortQuestion = UserChoiceForRangeCheck(GlobalConstants.lowerRangeOfSortingDisplayVehiclesList, GlobalConstants.upperRangeOfSortingDisplayVehiclesList);
            return specificTypeToSortQuestion;
        }
        
        /// <summary>
        /// Method will be called when user chooses to watch list of ALL vehicles currently in garage.
        /// </summary>
        /// <param name="i_listOfLicenseNumbers">Method recieves a list of strings to put in each individual index a license number that is currently in garage.</param>
        internal static void PrintLicenseNumbersList(List<string> i_listOfLicenseNumbers)
        {
            Console.WriteLine("List of license numbers currently in gargae: ");
            foreach (string specificLicenseNumber in i_listOfLicenseNumbers)
            {
                Console.WriteLine(specificLicenseNumber);
            }
        }

        /// <summary>
        /// A console message to let user now the operation he chose ended successfully.
        /// </summary>
        internal static void PrintSuccessAndPressAnyKeyToContinue()
        {
            OperationEndedSuccesfullyMessage();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Ex02.ConsoleUtils.Screen.Clear();
        }

        /// <summary>
        /// A console message to let user now the operation he chose failed and input was not stored.
        /// </summary>
        internal static void PrintFailedAndPressAnyKeyToContinue()
        {
            OperationDidNotEndedSuccesfullyMessage();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
            Ex02.ConsoleUtils.Screen.Clear();
        }

        /// <summary>
        /// If user chose to change vehicle status is garage we will now ask what is the new vehicles status by a given list.
        /// User will choose 1-3 out of 3 possible status of vehicles in garage.
        /// </summary>
        /// <returns>Returns the users answer to the new status after logical check up as an optional answer from the list</returns>
        internal static Garage.e_VehicleState NewVehicleStateToChangeInput()
        {
            string newStringStatus = string.Empty;
            int newIntStatus = int.MinValue;
            Garage.e_VehicleState newStatus = Garage.e_VehicleState.WaitForStartingRepair;
            newStringStatus = string.Format(
@"What is the new vehicle status for change:
1) In repair process
2) Repair Completed
3) Paid");
            Console.WriteLine(newStringStatus);
            newIntStatus = UserChoiceForRangeCheck(GlobalConstants.lowerRangeOfSortingDisplayVehiclesList, GlobalConstants.upperRangeOfSortingDisplayVehiclesList);
            newStatus = (Garage.e_VehicleState)Enum.ToObject(typeof(Garage.e_VehicleState), newIntStatus);
            return newStatus;
        }

        /// <summary>
        /// Method will check users input for logical range input.
        /// Method receives the lower and upper range to compare with, and will throw out of range exception if needed.
        /// </summary>
        /// <param name="lowerRange">receieves lower range from relevant field</param>
        /// <param name="upperRange">receieves upper range from relevant field</param>
        /// <returns>Returns user choice after check up for logical input</returns>
        internal static int UserChoiceForRangeCheck(int lowerRange, int upperRange)
        {
            bool allGoodForParsing = false;
            string userChoiceString;
            int userChoice = int.MinValue;
            while (allGoodForParsing == false)
            {
                userChoiceString = Console.ReadLine();
                if (int.TryParse(userChoiceString, out userChoice) == true)
                {
                    if (userChoice >= lowerRange && userChoice <= upperRange)
                    {
                        allGoodForParsing = true;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(lowerRange, upperRange);
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }

            return userChoice;            
        }

        /// <summary>
        /// Console message to update user for success.
        /// </summary>
        internal static void OperationEndedSuccesfullyMessage()
        {
            Console.WriteLine("\nOperation Completed Successfully");
        }

        /// <summary>
        /// Console message to update user for failure.
        /// </summary>
        internal static void OperationDidNotEndedSuccesfullyMessage()
        {
            Console.WriteLine("\nOperation Did Not Ended Successfully,\nThe current information you entered was not stored in memory. ");
        }

        /// <summary>
        /// A gathering method for all information stored in memory for a specific vehicle.
        /// This method will be used when user asked to see information of a chosen vehicle by it's license number.
        /// </summary>
        /// <param name="i_ownerAndVehicleInformation">Method recieves a struct holding this information.</param>
        internal static void PrintGeneralInformationOfSpecificVehicle(Garage.OwnerAndVehicleDetails i_ownerAndVehicleInformation)
        {
            string allInformationMessage = string.Format(
@"License Number: {0}
Model Name: {1}
Owner's Name: {2}
Owner's Phone: {3}
Vehicle State In Garage: {4}
Wheels:
{5}
Energy Resource Capacity : {6}%
Energy Type: {7}", 
                 i_ownerAndVehicleInformation.OwnerVehicle.LicenseNumber, 
                 i_ownerAndVehicleInformation.OwnerVehicle.ModelName,
                 i_ownerAndVehicleInformation.OwnerName, 
                 i_ownerAndVehicleInformation.OwnerPhone, 
                 i_ownerAndVehicleInformation.ToString(),
                 PrintWheelsInFormation(i_ownerAndVehicleInformation.OwnerVehicle.ListOfWheels),
                 i_ownerAndVehicleInformation.OwnerVehicle.EngineType.GeneralEnergyPercentageLeft,
                 i_ownerAndVehicleInformation.OwnerVehicle.EngineType.EnergyType.ToString());
            Console.WriteLine(allInformationMessage);
        }

        /// <summary>
        /// Method prints all the specific details for the chosen vehicle type
        /// </summary>
        /// <param name="i_ownerAndVehicleInformation">given stuct which hold all relevant information </param>
        internal static void PrintSpecificInformationForSpecificVehicle(Garage.OwnerAndVehicleDetails i_ownerAndVehicleInformation)
        {
            string specifcInformationDetailingMessage = string.Empty;
            Type specificVehicleClassType = i_ownerAndVehicleInformation.OwnerVehicle.GetType();
            if ((specificVehicleClassType == typeof(RegularCar)) || (specificVehicleClassType == typeof(ElectricCar)))
            {
                specifcInformationDetailingMessage = string.Format(
@"Car's Colour: {0}
Car's Number Of Doors: {1}",
((Car)i_ownerAndVehicleInformation.OwnerVehicle).CarColor,
((Car)i_ownerAndVehicleInformation.OwnerVehicle).NumberOfDoors);
            }
            else if ((specificVehicleClassType == typeof(RegularMotorcycle)) || (specificVehicleClassType == typeof(ElectricMotorcycle)))
            {
                specifcInformationDetailingMessage = string.Format(
@"Motorcycle's Engine Capacity: {0}
Motorcycle's License Type: {1}",
((Motorcycle)i_ownerAndVehicleInformation.OwnerVehicle).EngineCapacity,
((Motorcycle)i_ownerAndVehicleInformation.OwnerVehicle).LicenseType);    
            }
            else if(specificVehicleClassType == typeof(Truck))
            {
                specifcInformationDetailingMessage = string.Format(
@"Truck's Carriage Volume Capacity: {0}
Motorcycle's License Type: {1}",
((Truck)i_ownerAndVehicleInformation.OwnerVehicle).VolumeCapacity,
((Truck)i_ownerAndVehicleInformation.OwnerVehicle).IsCarringHazardousMaterials);
            }
         
            Console.WriteLine(specifcInformationDetailingMessage);
        }

        internal static string PrintWheelsInFormation(List<Wheel> i_listOfWheels)
        {
            StringBuilder info = new StringBuilder();
            int WheelindexNumber = 1;
            foreach (Wheel currentWheel in i_listOfWheels)
            {
                string allWheelInformation = string.Format(
@"Wheel Number {0}:
Manufacturer Name: {1}
Maximum Air Pressure: {2}
Current Air Presuure: {3}
", 
 WheelindexNumber,
 currentWheel.ManufacturerName, 
 currentWheel.MaximumAirPressure, 
 currentWheel.CurrentAirPressure);
                info.Append(allWheelInformation);
                WheelindexNumber++;
            }

            return info.ToString();
        }

        /// <summary>
        /// Method gets by sub methods all basic information for vehicle
        /// </summary>
        /// <param name="basicInformationOfVehicle">stroes given information in struct at vehicle class</param>
        /// <param name="i_vehicleType">get the specific vehicle type</param>
        internal static void EnterBasicInformationOfVehicle(out Vehicle.BasicInformationOfVehicleAndOwner basicInformationOfVehicle, int i_vehicleType)
        {
            string currentStringInfoToPutInStruct = string.Empty;
            float currentAirPressureInfoToPutInStruct = float.MinValue;
            float currentEnergyAmountInfoToPutInStruct = float.MinValue;
            bool isGood = false;

            currentStringInfoToPutInStruct = ModelNameInput();
            basicInformationOfVehicle.m_ModelName = currentStringInfoToPutInStruct;

            currentStringInfoToPutInStruct = LicenseNumberInput();
            basicInformationOfVehicle.m_LicenseNumber = currentStringInfoToPutInStruct;

            currentStringInfoToPutInStruct = WheelManufacturerInput();
            basicInformationOfVehicle.m_WheelManufacturer = currentStringInfoToPutInStruct;

            currentStringInfoToPutInStruct = OwnerNameInput();
            basicInformationOfVehicle.m_OwnerName = currentStringInfoToPutInStruct;

            while (isGood == false)
            {
                try
                {
                    currentStringInfoToPutInStruct = OwnerPhoneInput();
                    isGood = true;
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
            }

            basicInformationOfVehicle.m_OwnerPhone = currentStringInfoToPutInStruct;

            float maximumAirPressureValue = float.MinValue;
            float maximumEnergyValue = float.MinValue;

            SetMaximumAirPressureAndEnergyValueByVehicleType(i_vehicleType, out maximumAirPressureValue, out maximumEnergyValue);
            
            Console.WriteLine(string.Format("Current Air Pressure: (Maximum: {0})", maximumAirPressureValue));
            TryCatchForCurrentNumericInformation(out currentAirPressureInfoToPutInStruct, maximumAirPressureValue);
           
            Console.WriteLine(string.Format("Current Fuel Amount: (Maximum: {0})", maximumEnergyValue));
            TryCatchForCurrentNumericInformation(out currentEnergyAmountInfoToPutInStruct, maximumEnergyValue);
            
            basicInformationOfVehicle.m_CurrentAirPressure = currentAirPressureInfoToPutInStruct;
            basicInformationOfVehicle.m_AmountEnergyResource = currentEnergyAmountInfoToPutInStruct;
        }

        /// <summary>
        /// Methos sets maximum values for energy and air pressure by different vehicle types recived as int argument
        /// </summary>
        /// <param name="i_vehicleType">method sets the values by that vehicle type given</param>
        /// <param name="o_maximumAirPressureValue">out parameter for the maximum air pressure to set</param>
        /// <param name="o_maximumEnergyValue">out parameter for the maximum energy amount to set</param>
        internal static void SetMaximumAirPressureAndEnergyValueByVehicleType(int i_vehicleType, out float o_maximumAirPressureValue, out float o_maximumEnergyValue)
        {
            o_maximumAirPressureValue = float.MinValue;
            o_maximumEnergyValue = float.MinValue;

            switch (i_vehicleType)
            {
                case 1: // RegularCar
                    o_maximumAirPressureValue = GlobalConstants.carMaxAirPressure;
                    o_maximumEnergyValue = GlobalConstants.regularCarMaxFuelTank;
                    break;
                case 2: // ElectricCar
                    o_maximumAirPressureValue = GlobalConstants.carMaxAirPressure;
                    o_maximumEnergyValue = GlobalConstants.electricCarMaxBatteryCapacity;
                    break;
                case 3: // RegularMotorcycle
                    o_maximumAirPressureValue = GlobalConstants.motorcycleMaxAirPressure;
                    o_maximumEnergyValue = GlobalConstants.regularMotorcycleMaxFuelTank;
                    break;
                case 4: // ElectricMotorcycle
                    o_maximumAirPressureValue = GlobalConstants.motorcycleMaxAirPressure;
                    o_maximumEnergyValue = GlobalConstants.electricMotorcycleMaxBatteryCapacity;
                    break;
                case 5: // Truck
                default:
                    o_maximumAirPressureValue = GlobalConstants.truckMaxAirPressure;
                    o_maximumEnergyValue = GlobalConstants.truckMaxFuelTank;
                    break;
            }
        }

        internal static void TryCatchForCurrentNumericInformation(out float io_currentValue, float i_maximumValue)
        {
            io_currentValue = float.MinValue;
            bool isGood = false;
            while (isGood == false)
            {
                try
                {
                    io_currentValue = CurrentMeasurementOfVehicleComponentInput(i_maximumValue);
                    isGood = true;
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
            }
        }
    }
}

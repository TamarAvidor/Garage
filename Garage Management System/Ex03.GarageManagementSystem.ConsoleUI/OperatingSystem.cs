namespace Ex03.GarageManagementSystem.ConsoleUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Ex03.GarageLogic;

    public class OperatingSystem
    {
        private Garage m_garage;
        
        public OperatingSystem()
        {
            m_garage = new Garage();
        }

        /// <summary>
        /// Details main for user to choose from list of functionality options.
        /// </summary>
        public void UIManager()
        {
            int mainUserChoiceInt = int.MinValue;
            string licenseNumber = string.Empty;
            bool mainUserChoiceBool = true;
            bool allGoodForEnterInput = false;
            Garage.OwnerAndVehicleDetails informationOfSpecificVehicle;
            Garage.e_VehicleState newVehicleState = Garage.e_VehicleState.WaitForStartingRepair;
            ConsoleUI.WelcomeToGarageMessage();

            while (mainUserChoiceBool == true)
            {
                try
                {
                    ConsoleUI.DetailingMenuSystemFunctionality();
                    mainUserChoiceInt = ConsoleUI.UserChoiceForRangeCheck(GlobalConstants.lowerRangeOfFunctionalityChoice, GlobalConstants.upperRangeOfFunctionalityChoice);
                    Ex02.ConsoleUtils.Screen.Clear();
                    switch (mainUserChoiceInt)
                    {
                        case 1:
                            allGoodForEnterInput = InputInformationToCreateNewSpecificVehicle();
                            break;
                        case 2:
                            MethodForMainUserChoiceCase2();
                            break;
                        case 3:
                            licenseNumber = ConsoleUI.LicenseNumberInput();
                            newVehicleState = ConsoleUI.NewVehicleStateToChangeInput();
                            m_garage.ChangeVehicleState(licenseNumber, newVehicleState);
                            break;
                        case 4:
                            licenseNumber = ConsoleUI.LicenseNumberInput();
                            m_garage.InflateWheelAirPressureToMaximum(licenseNumber);
                            break;
                        case 5:
                            MethodForMainUserChoiceCase5();
                            break;
                        case 6:
                            licenseNumber = ConsoleUI.LicenseNumberInput();
                            informationOfSpecificVehicle = m_garage.StructOfAllDetailsOfVehicle(licenseNumber);
                            ConsoleUI.PrintGeneralInformationOfSpecificVehicle(informationOfSpecificVehicle);
                            ConsoleUI.PrintSpecificInformationForSpecificVehicle(informationOfSpecificVehicle);
                            break;
                        case 7:
                            mainUserChoiceBool = false;
                            break;
                    }

                    if (allGoodForEnterInput == true)
                    {
                        ConsoleUI.PrintSuccessAndPressAnyKeyToContinue();
                    }
                    else
                    {
                        ConsoleUI.PrintFailedAndPressAnyKeyToContinue();
                    }
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Console.WriteLine(valueOutOfRangeException.Message);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            ConsoleUI.GoodByeMessage();
        }

        /// <summary>
        /// Method for the 2'nd case of the main menu user choice.
        /// </summary>
        internal void MethodForMainUserChoiceCase2()
        {
            bool allGoodForEnterInput = false;
            bool innerUserChoiceBool = false;
            int innerUserChoiceInt = int.MinValue;
            List<string> listOfLicenseNumbers = null;

            while (allGoodForEnterInput == false)
            {
                try
                {
                    innerUserChoiceBool = ConsoleUI.AskUserIfToSortTheListInput();
                    allGoodForEnterInput = true;
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

            if (innerUserChoiceBool == false)
            {
                innerUserChoiceInt = GlobalConstants.dummyIntConst;
            }
            else
            {
                allGoodForEnterInput = false;
                while (allGoodForEnterInput == false)
                {
                    try
                    {
                        innerUserChoiceInt = ConsoleUI.AskUserForTypeToSortTheList();
                        allGoodForEnterInput = true;
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

            listOfLicenseNumbers = m_garage.PresentListOfVehiclesInTheGarage(innerUserChoiceBool, innerUserChoiceInt);
            ConsoleUI.PrintLicenseNumbersList(listOfLicenseNumbers);
        }

        /// <summary>
        /// Method for the 5'th case of the main menu user choice.
        /// Case 5 takes care both for battery charging and tank feuling.
        /// </summary>
        internal void MethodForMainUserChoiceCase5()
        {
            string licenseNumber = string.Empty;
            float fuelAmountToAdd = float.MinValue;
            float currentEnergyAmount = float.MinValue;
            float maximumEnergyAmount = float.MinValue;
            Engine.e_EnergyType energyType = Engine.e_EnergyType.Soler;
            Vehicle currentVehicle;

            licenseNumber = ConsoleUI.LicenseNumberInput();
            if (m_garage.OwnerVehicleDictionary.ContainsKey(licenseNumber) == true)
            {
                energyType = ConsoleUI.EnergyTypeToAppointInput();
                currentVehicle = m_garage.GetVehicleByLicenseNumber(licenseNumber);
                if (currentVehicle.EngineType.EnergyType == energyType)
                {
                    currentEnergyAmount = currentVehicle.EngineType.CurrentEnergyResource;
                    maximumEnergyAmount = currentVehicle.EngineType.MaximumEnergyResource;
                    fuelAmountToAdd = ConsoleUI.EnergyAmountToAppointInput(currentEnergyAmount, maximumEnergyAmount);
                    m_garage.ReEnergyVehicleByGivenAmount(licenseNumber, energyType, fuelAmountToAdd);
                }
                else
                {
                    throw new ArgumentException("The Energy Type does not fit the engine\n");
                }
            }
            else
            {
                throw new Exception("The specific vehicle is not in the dictionary\n");
            }
        }

        /// <summary>
        /// Method sets all specific details for specific vehicles by swtich cases. 
        /// </summary>
        /// <returns>return true for successful input process.</returns>
        public bool InputInformationToCreateNewSpecificVehicle()
        {
            int vehicleType;
            bool allGoodForInputEnter = true;
            bool isCarringHazardousMaterials = false;
            int engineCapacity = int.MinValue;
            float volumeCapacity = float.MinValue;
            Vehicle vehicleToCreate;
            Car.e_Color color;
            Car.e_NumberOfDoors numberOfDoors;
            Motorcycle.e_LicenseType licenseType;

            ConsoleUI.DetailingSupportingGarageVehicleTypes();

            try
            {
                vehicleType = ConsoleUI.UserChoiceForRangeCheck(GlobalConstants.lowerRangeOfVehicleChoice, GlobalConstants.upperRangeOfVehicleChoice);
                Vehicle.BasicInformationOfVehicleAndOwner informationOfVehicleAndOwner = InputInformationForVehicle(vehicleType);
                switch (vehicleType)
                {
                    case 1: // RegularCar
                        CarColourAndNumbersOfDoorsTryCatch(out color, out numberOfDoors);
                        vehicleToCreate = VehicleCreator.CreateRegularCar(informationOfVehicleAndOwner, color, numberOfDoors);
                        break;
                    case 2: // ElectricCar
                        CarColourAndNumbersOfDoorsTryCatch(out color, out numberOfDoors);
                        vehicleToCreate = VehicleCreator.CreateElectricCar(informationOfVehicleAndOwner, color, numberOfDoors);
                        break;
                    case 3:  // RegularMotorcycle
                        InputInformationToCreateNewSpecificVehicleCase3(out licenseType, out engineCapacity);
                        vehicleToCreate = VehicleCreator.CreateRegularMotorcycle(informationOfVehicleAndOwner, licenseType, engineCapacity);
                        break;
                    case 4:  // ElectricMotorcycle
                        InputInformationToCreateNewSpecificVehicleCase4(out licenseType, out engineCapacity);
                        vehicleToCreate = VehicleCreator.CreateElectricMotorcycle(informationOfVehicleAndOwner, licenseType, engineCapacity);
                        break;
                    case 5:  // Truck
                    default:
                        InputInformationToCreateNewSpecificVehicleCase5(out isCarringHazardousMaterials, out volumeCapacity);
                        vehicleToCreate = VehicleCreator.CreateTruck(informationOfVehicleAndOwner, isCarringHazardousMaterials, volumeCapacity);
                        break;
                }

                m_garage.AddNewVehicleToGarageContentsList(
                    informationOfVehicleAndOwner.m_OwnerName,
                    informationOfVehicleAndOwner.m_OwnerPhone,
                    informationOfVehicleAndOwner.m_LicenseNumber,
                    vehicleToCreate);
            }
            catch (FormatException formatException)
            {
                allGoodForInputEnter = false;
                Console.WriteLine(formatException.Message);
            }

            return allGoodForInputEnter;
        }

        public Vehicle.BasicInformationOfVehicleAndOwner InputInformationForVehicle(int i_vehicleType)
        {
            Vehicle.BasicInformationOfVehicleAndOwner basicInformationOfVehicleAndOwner = new Vehicle.BasicInformationOfVehicleAndOwner();
            ConsoleUI.EnterBasicInformationOfVehicle(out basicInformationOfVehicleAndOwner, i_vehicleType);
            return basicInformationOfVehicleAndOwner;
        }

        /// <summary>
        /// "sub" method helps confirm logical (range and argument) input by while loop for input.
        /// </summary>
        /// <param name="o_carColor">car colour for motorcycle to set inside method (out argument)</param>
        /// <param name="o_numberOfDoors">number of doors for cars to set inside method (out argument)</param>
        internal void CarColourAndNumbersOfDoorsTryCatch(out Car.e_Color o_carColor, out Car.e_NumberOfDoors o_numberOfDoors)
        {
            bool allGoodPerValueCheck = false;
            o_carColor = Car.e_Color.Black;
            o_numberOfDoors = Car.e_NumberOfDoors.Four;

            while (allGoodPerValueCheck == false)
            {
                try
                {
                    o_carColor = ConsoleUI.CarColorInput();
                    allGoodPerValueCheck = true;
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

            allGoodPerValueCheck = false;
            while (allGoodPerValueCheck == false)
            {
                try
                {
                    o_numberOfDoors = ConsoleUI.NumberOfCarDoorsInput();
                    allGoodPerValueCheck = true;
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

        /// <summary>
        /// "sub" method helps confirm logical (range and argument) input by while loop for input.
        /// </summary>
        /// <param name="o_licenseType">license type for motorcycle to set inside method (out argument)</param>
        /// <param name="o_engineCapacity">engine capacity to set inside method (out argument)</param>
        internal void InputInformationToCreateNewSpecificVehicleCase3(out Motorcycle.e_LicenseType o_licenseType, out int o_engineCapacity)
        {
            bool allGoodPerValueCheck = false;
            o_engineCapacity = int.MinValue;
            o_licenseType = Motorcycle.e_LicenseType.A;

            while (allGoodPerValueCheck == false)
            {
                try
                {
                    o_engineCapacity = ConsoleUI.MotorcycleEngineCapacityInput();
                    allGoodPerValueCheck = true;
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

            allGoodPerValueCheck = false;
            while (allGoodPerValueCheck == false)
            {
                try
                {
                    o_licenseType = ConsoleUI.LicenseTypeInput();
                    allGoodPerValueCheck = true;
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

        /// <summary>
        /// "sub" method helps confirm logical (range and argument) input by while loop for input.
        /// </summary>
        /// <param name="o_licenseType">license type for motorcycle to set inside method (out argument)</param>
        /// <param name="o_engineCapacity">engine capacity to set inside method (out argument)</param>
        internal void InputInformationToCreateNewSpecificVehicleCase4(out Motorcycle.e_LicenseType o_licenseType, out int o_engineCapacity)
        {
            bool allGoodPerValueCheck = false;
            o_engineCapacity = int.MinValue;
            o_licenseType = Motorcycle.e_LicenseType.A;

            while (allGoodPerValueCheck == false)
            {
                try
                {
                    o_engineCapacity = ConsoleUI.MotorcycleEngineCapacityInput();
                    allGoodPerValueCheck = true;
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

            allGoodPerValueCheck = false;
            while (allGoodPerValueCheck == false)
            {
                try
                {
                    o_licenseType = ConsoleUI.LicenseTypeInput();
                    allGoodPerValueCheck = true;
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
        
        /// <summary>
        /// "sub" method helps confirm logical (range and argument) input by while loop for input.
        /// </summary>
        /// <param name="o_isCarringHazardousMaterials">bool argument for carrying hazardous materials (out argument)</param>
        /// <param name="o_volumeCapacity">vlume capacity to set inside method (out argument)</param>
        internal void InputInformationToCreateNewSpecificVehicleCase5(out bool o_isCarringHazardousMaterials, out float o_volumeCapacity)
        {
            o_isCarringHazardousMaterials = false;
            o_volumeCapacity = float.MinValue;
            bool allGoodPerValueCheck = false;
            
            while (allGoodPerValueCheck == false)
            {
                try
                {
                    o_isCarringHazardousMaterials = ConsoleUI.IsCarryingHazardousMaterialsInput();
                    allGoodPerValueCheck = true;
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

            allGoodPerValueCheck = false;
            while (allGoodPerValueCheck == false)
            {
                try
                {
                    o_volumeCapacity = ConsoleUI.TruckVolumeCapacityInput();
                    allGoodPerValueCheck = true;
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

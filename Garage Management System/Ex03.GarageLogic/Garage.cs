namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Garage
    {
        public struct OwnerAndVehicleDetails
        {
            private e_VehicleState m_vehicleState;
            private string m_ownerName;
            private string m_ownerPhone;
           
            private Vehicle m_ownerVehicle;

            public string OwnerName
            {
                get
                {
                    return m_ownerName;
                }

                set
                {
                    m_ownerName = value;
                }
            }

            public string OwnerPhone
            {
                get
                {
                    return m_ownerPhone;
                }

                set
                {
                    m_ownerPhone = value;
                }
            }

            public e_VehicleState VehicleState
            {
                get
                {
                    return m_vehicleState;
                }

                set
                {
                    m_vehicleState = value;
                }
            }

            public Vehicle OwnerVehicle
            {
                get
                {
                    return m_ownerVehicle;
                }

                set
                {
                    m_ownerVehicle = value;
                }
            }

            public override string ToString()
            {
                string returnString = string.Empty;

                switch (m_vehicleState)
                {
                    case e_VehicleState.WaitForStartingRepair:
                    case e_VehicleState.InRepairProcess:
                        returnString = "In Repair Process";
                        break;
                    case e_VehicleState.RepairCompleted:
                        returnString = "Repair Completed";
                        break;
                    case e_VehicleState.Paid:
                        returnString = "Paid";
                        break;
                }

                return returnString;
            }
        }

        /// <summary>
        /// Four possible statuses for vehicle in grage,
        /// the "WaitForStartingRepair" and "InRepairProcess" are treated the same (and togther always) as assigtment requested.
        /// </summary>
        public enum e_VehicleState
        {
            WaitForStartingRepair = 0,
            InRepairProcess = 1,
            RepairCompleted = 2,
            Paid = 3
        }

        private OwnerAndVehicleDetails m_ownerDetailsAndVehicle;
        private Dictionary<string, OwnerAndVehicleDetails> m_ownerVehicleDictionary;

        public Garage()
        {
            m_ownerVehicleDictionary = new Dictionary<string, OwnerAndVehicleDetails>();
        }

        public Dictionary<string, OwnerAndVehicleDetails> OwnerVehicleDictionary
        {
            get
            {
                return m_ownerVehicleDictionary;
            }
        }

        /// <summary>
        /// Method adds the current chosen vehicle state to a list of strings that holds the license number
        /// </summary>
        /// <param name="i_listOfDetailedStructs"> list of structs, each holding owner & vehicle details</param>
        /// <param name="i_vehicleState">get the current vehicle state</param>
        /// <returns>returns the list of license numbers as individual string</returns>
        public static List<string> MakeSpecificTypeOfListByStatus(List<OwnerAndVehicleDetails> i_listOfDetailedStructs, e_VehicleState i_vehicleState)
        {
            List<string> listOfLicenseNumbers = new List<string>();
            foreach (OwnerAndVehicleDetails individualStructInList in i_listOfDetailedStructs)
            {
                if (individualStructInList.VehicleState == i_vehicleState)
                {
                    listOfLicenseNumbers.Add(individualStructInList.OwnerVehicle.LicenseNumber);
                }
            }

            return listOfLicenseNumbers;
        }

        public void AddNewVehicleToGarageContentsList(string i_ownerName, string i_ownerPhone, string i_licenseNumber, Vehicle i_ownerVehicle)
        {
            if (m_ownerVehicleDictionary.ContainsKey(i_licenseNumber) == false) 
            {
                m_ownerDetailsAndVehicle = new OwnerAndVehicleDetails();
                m_ownerDetailsAndVehicle.OwnerName = i_ownerName;
                m_ownerDetailsAndVehicle.OwnerPhone = i_ownerPhone;
                m_ownerDetailsAndVehicle.VehicleState = e_VehicleState.WaitForStartingRepair;
                m_ownerDetailsAndVehicle.OwnerVehicle = i_ownerVehicle;
                m_ownerVehicleDictionary.Add(i_licenseNumber, m_ownerDetailsAndVehicle);
            }
            else
            {
                ChangeVehicleState(i_licenseNumber, e_VehicleState.InRepairProcess);
                throw new ArgumentException("The license number already exsists in the garage.");
            }
        }

        /// <summary>
        /// Method will make a list to hold the license numbers as string of each vehicle that is suitable for the status user requested.
        /// </summary>
        /// <param name="i_choiceForFilteringList">yes/no question for filtering or not the list of vehicles currently in garage</param>
        /// <param name="i_choiceForSortType">if the previous boolean question was answered positivly, user should not choose which status he vehicles he would like to be presented</param>
        /// <returns>returns the made list(sub method "MakeSpecificTypeOfListByStatus").</returns>
        public List<string> PresentListOfVehiclesInTheGarage(bool i_choiceForFilteringList, int i_choiceForSortType)
        {
            if (CheckIfDictionaryNotEmpty() == true)
            {
                List<string> listOfLicenseNumbers = new List<string>();
                List<OwnerAndVehicleDetails> listOfDetailedStructs = new List<OwnerAndVehicleDetails>();
                Dictionary<string, OwnerAndVehicleDetails>.ValueCollection collectionOfDetailedStructsByValue = m_ownerVehicleDictionary.Values;

                foreach (OwnerAndVehicleDetails detailedStruct in collectionOfDetailedStructsByValue)
                {
                    listOfDetailedStructs.Add(detailedStruct);
                }

                if (i_choiceForFilteringList == true)
                {
                    switch (i_choiceForSortType)
                    {
                        case 1:
                            listOfLicenseNumbers = MakeSpecificTypeOfListByStatus(listOfDetailedStructs, e_VehicleState.InRepairProcess);
                            listOfLicenseNumbers = MakeSpecificTypeOfListByStatus(listOfDetailedStructs, e_VehicleState.WaitForStartingRepair);
                            break;
                        case 2:
                            listOfLicenseNumbers = MakeSpecificTypeOfListByStatus(listOfDetailedStructs, e_VehicleState.RepairCompleted);
                            break;
                        case 3:
                            listOfLicenseNumbers = MakeSpecificTypeOfListByStatus(listOfDetailedStructs, e_VehicleState.Paid);
                            break;
                    }
                }
                else
                {
                    foreach (OwnerAndVehicleDetails detailedStruct in listOfDetailedStructs)
                    {
                        listOfLicenseNumbers.Add(detailedStruct.OwnerVehicle.LicenseNumber);
                    }
                }

                return listOfLicenseNumbers;
            }
            else
            {
                throw new Exception("The Dictionary is Empty\n");
            }
        }

        /// <summary>
        /// Methos changes the chosen vehicle state
        /// </summary>
        /// <param name="i_licenseNumber">the change is made by the given license number</param>
        /// <param name="i_vehicleState">current vehicle change</param>
        public void ChangeVehicleState(string i_licenseNumber, e_VehicleState i_vehicleState)
        {
            if (CheckIfDictionaryNotEmpty() == true)
            {
                if (m_ownerVehicleDictionary.TryGetValue(i_licenseNumber, out m_ownerDetailsAndVehicle) == true)
                {
                    m_ownerDetailsAndVehicle = m_ownerVehicleDictionary[i_licenseNumber];
                    m_ownerDetailsAndVehicle.VehicleState = i_vehicleState;
                    if (m_ownerVehicleDictionary.Remove(i_licenseNumber) == true)
                    {
                        m_ownerVehicleDictionary.Add(i_licenseNumber, m_ownerDetailsAndVehicle);
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new Exception("Vehicle Does not exsist in this garage\n");
            }
        }

        /// <summary>
        /// Method inflates wheel pressure to the possible maximum by its vehicle type
        /// </summary>
        /// <param name="i_licenseNumber">the change is made by the given license number</param>
        public void InflateWheelAirPressureToMaximum(string i_licenseNumber)
        {
            if (CheckIfDictionaryNotEmpty() == true)
            {
                if (m_ownerVehicleDictionary.TryGetValue(i_licenseNumber, out m_ownerDetailsAndVehicle) == true)
                {
                    List<Wheel> listOfWheelsInVehicle = m_ownerDetailsAndVehicle.OwnerVehicle.ListOfWheels;
                    foreach (Wheel specificWheelInVehicle in listOfWheelsInVehicle)
                    {
                        float deltaAirPressureToInflate = specificWheelInVehicle.MaximumAirPressure - specificWheelInVehicle.CurrentAirPressure;
                        specificWheelInVehicle.InflationWheel(deltaAirPressureToInflate);
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new Exception("Vehicle Does not exsist in this garage\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i_licenseNumber">the change is made by the given license number</param>
        /// <param name="i_energyType">the chosen energy type to appoint- input will be check for right type</param>
        /// <param name="i_amountToAppoint">the amount to appoint- input will be checked for logical amount to put in tank/battery </param>
        public void ReEnergyVehicleByGivenAmount(string i_licenseNumber, Engine.e_EnergyType i_energyType, float i_amountToAppoint)
        {
            if (CheckIfDictionaryNotEmpty() == true)
            {
                if (m_ownerVehicleDictionary.TryGetValue(i_licenseNumber, out m_ownerDetailsAndVehicle) == true)
                {
                    m_ownerDetailsAndVehicle.OwnerVehicle.EngineType.EnergyAdder(i_amountToAppoint, i_energyType);
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new Exception("Vehicle Does not exsist in this garage\n");
            }
        }

        public OwnerAndVehicleDetails StructOfAllDetailsOfVehicle(string i_licenseNumber)
        {
            if (CheckIfDictionaryNotEmpty() == true)
            {
                if (m_ownerVehicleDictionary.TryGetValue(i_licenseNumber, out m_ownerDetailsAndVehicle) == true)
                {
                    return m_ownerDetailsAndVehicle;
                }
                else
                {
                    throw new FormatException();
                }
            }
            else
            {
                throw new Exception("Vehicle Does not exsist in this garage\n");
            }
        }

        private bool CheckIfDictionaryNotEmpty()
        {
            bool isDictionaryNotEmpty = false;
            if (m_ownerVehicleDictionary.Count != 0)
            {
                isDictionaryNotEmpty = true;
            }

            return isDictionaryNotEmpty;
        }

        public Vehicle GetVehicleByLicenseNumber(string i_licenseNumber)
        {
            if (m_ownerVehicleDictionary.TryGetValue(i_licenseNumber, out m_ownerDetailsAndVehicle) == true)
            {
                return m_ownerDetailsAndVehicle.OwnerVehicle;
            }
            else
            {
                throw new Exception("Vehicle Does not exsist in this garage\n");
            }
        }
    }
}

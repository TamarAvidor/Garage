namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Vehicle
    {
        public struct BasicInformationOfVehicleAndOwner
        {
            public string m_ModelName;
            public string m_LicenseNumber;
            public string m_WheelManufacturer;
            public string m_OwnerName;
            public string m_OwnerPhone;
            public float m_CurrentAirPressure;
            public float m_AmountEnergyResource;
        }

        protected readonly int m_numOfWheelsNeeded;
        protected readonly string m_modelName;
        protected readonly string m_licenseNumber;

        protected List<Wheel> m_listOfWheels;
        protected Engine m_vehicleEngine;

        public Vehicle(
            string i_modelName, 
            string i_licenseNumber, 
            string i_wheelManufacturer, 
            int i_numOfWeels,
            float i_maximalAirPressure, 
            float i_currentAirPressure, 
            float i_amountEnergyResource)
        {
            m_modelName = i_modelName;
            m_licenseNumber = i_licenseNumber;
            m_numOfWheelsNeeded = i_numOfWeels;

            m_listOfWheels = new List<Wheel>(i_numOfWeels);
            for (int i = 0; i < i_numOfWeels; i++)
            {
                m_listOfWheels.Add(new Wheel(i_wheelManufacturer, i_maximalAirPressure, i_currentAirPressure));
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_licenseNumber;
            }
        }

        public string ModelName
        {
            get
            {
                return m_modelName;
            }
        }

        public List<Wheel> ListOfWheels
        {
            get
            {
                return m_listOfWheels;
            }

            set
            {
                m_listOfWheels = value;
            }
        }

        public Engine EngineType
        {
            get
            {
                return m_vehicleEngine;
            }

            set
            {
                m_vehicleEngine = value;
            }
        }
    }
}
namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Motorcycle : Vehicle
    {
        public enum e_LicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B1 = 4
        }

        protected readonly int m_engineCapacity;
        protected e_LicenseType m_licenseType;

        public Motorcycle(
            string i_modelName, 
            string i_licenseNumber, 
            string i_wheelManufacturer,
            float i_currentAirPressure, 
            float i_amountEnergyResource,
            int i_engineCapacity, 
            e_LicenseType i_licenseType)
            : base(i_modelName, i_licenseNumber, i_wheelManufacturer, GlobalConstants.motorcycleNumberOfWheels, GlobalConstants.motorcycleMaxAirPressure, i_currentAirPressure, i_amountEnergyResource)
        {
            this.m_licenseType = i_licenseType;
            this.m_engineCapacity = i_engineCapacity;
        }

        public e_LicenseType LicenseType
        {
            get
            {
                return this.m_licenseType;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return this.m_engineCapacity;
            }
        }
    }
}
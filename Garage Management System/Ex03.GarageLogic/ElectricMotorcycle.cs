namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ElectricMotorcycle : Motorcycle
    {
        public ElectricMotorcycle(
            string i_modelName, 
            string i_licenseNumber, 
            string i_wheelManufacturer,
            float i_currentAirPressure, 
            float i_remainingBatteryTime,
            int i_engineCapacity, 
            e_LicenseType i_licenseType)
            : base(i_modelName, i_licenseNumber, i_wheelManufacturer, i_currentAirPressure, i_remainingBatteryTime, i_engineCapacity, i_licenseType)
        {
            this.m_vehicleEngine = new Engine(Engine.e_TypeOfEngine.Electric, Engine.e_EnergyType.Battery, i_remainingBatteryTime, GlobalConstants.electricMotorcycleMaxBatteryCapacity);
        }
    }
}

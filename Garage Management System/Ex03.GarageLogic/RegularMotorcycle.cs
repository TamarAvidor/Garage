namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RegularMotorcycle : Motorcycle
    {
        public RegularMotorcycle(
            string i_modelName, 
            string i_licenseNumber, 
            string i_wheelManufacturer,
            float i_currentAirPressure, 
            float i_remainingFuelAmount,
            int i_engineCapacity, 
            e_LicenseType i_licenseType)
            : base(i_modelName, i_licenseNumber, i_wheelManufacturer, i_currentAirPressure, i_remainingFuelAmount, i_engineCapacity, i_licenseType)
        {
            this.m_vehicleEngine = new Engine(Engine.e_TypeOfEngine.Fuel, Engine.e_EnergyType.Octan95, i_remainingFuelAmount, GlobalConstants.regularMotorcycleMaxFuelTank);
        }
    }
}

namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RegularCar : Car
    {
        public RegularCar(
            string i_modelName, 
            string i_licenseNumber, 
            string i_wheelManufacturer,
            float i_currentAirPressure, 
            float i_remainingFuelAmount,
            e_Color i_color, 
            e_NumberOfDoors i_numberOfDoors)
            : base(i_modelName, i_licenseNumber, i_wheelManufacturer, i_currentAirPressure, i_remainingFuelAmount, i_color, i_numberOfDoors)
        {
            this.m_vehicleEngine = new Engine(Engine.e_TypeOfEngine.Fuel, Engine.e_EnergyType.Octan98, i_remainingFuelAmount, GlobalConstants.regularCarMaxFuelTank);
        }
    }
}

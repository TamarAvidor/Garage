namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Truck : Vehicle
    {
        private bool m_isCarringHazardousMaterials;
        private float m_volumeCapacity;

        public Truck(
            string i_modelName, 
            string i_licenseNumber, 
            string i_wheelManufacturer,
            float i_currentAirPressure, 
            float i_amountEnergyResource,
            bool i_isCarringHazardousMaterials, 
            float i_volumeCapacity)
            : base(i_modelName, i_licenseNumber, i_wheelManufacturer, GlobalConstants.truckNumberOfWheels, GlobalConstants.truckMaxAirPressure, i_currentAirPressure, i_amountEnergyResource)
        {
            this.m_isCarringHazardousMaterials = i_isCarringHazardousMaterials;
            this.m_volumeCapacity = i_volumeCapacity;

            this.m_vehicleEngine = new Engine(Engine.e_TypeOfEngine.Fuel, Engine.e_EnergyType.Octan96, i_amountEnergyResource, GlobalConstants.truckMaxFuelTank);
        }

        public bool IsCarringHazardousMaterials
        {
            get
            {
                return this.m_isCarringHazardousMaterials;
            }
        }

        public float VolumeCapacity
        {
            get
            {
                return this.m_volumeCapacity;
            }
        }
    }
}

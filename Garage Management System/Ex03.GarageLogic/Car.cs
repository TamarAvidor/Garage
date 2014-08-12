namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Car : Vehicle
    {
        public enum e_Color
        {
            Red = 1,
            Yellow = 2,
            Black = 3,
            Silver = 4
        }

        public enum e_NumberOfDoors
        {
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4
        }

        protected e_Color m_color;
        protected e_NumberOfDoors m_numberOfDoors;

        public Car(
            string i_modelName, 
            string i_licenseNumber, 
            string i_wheelManufacturer,
            float i_intialAirPressure, 
            float i_amountEnergyResource,
            e_Color i_color, 
            e_NumberOfDoors i_numberOfDoors)
            : base(i_modelName, i_licenseNumber, i_wheelManufacturer, GlobalConstants.carNumberOfWheels, GlobalConstants.carMaxAirPressure, i_intialAirPressure, i_amountEnergyResource)
        {
            this.m_color = i_color;
            this.m_numberOfDoors = i_numberOfDoors;
        }

        public e_Color CarColor
        {
            get
            {
                return this.m_color;
            }
        }

        public e_NumberOfDoors NumberOfDoors
        {
            get 
            {
                return this.m_numberOfDoors;
            }
        }
    }
}

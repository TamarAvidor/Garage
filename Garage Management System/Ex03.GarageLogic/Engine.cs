namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Class Engine will support both fuel engine and electric engine.
    /// </summary>
    public class Engine
    {
        public enum e_TypeOfEngine
        {
            Fuel = 0,
            Electric = 1
        }

        public enum e_EnergyType
        {
            Soler = 1,
            Octan95 = 2,
            Octan96 = 3,
            Octan98 = 4,
            Battery = 5
        }

        protected float m_remainingEnergy;
        protected readonly float m_maximumEnergyCapacity;
        protected float m_generalEnergyPercentageLeft;

        protected readonly e_TypeOfEngine m_typeOfEngine;
        protected e_EnergyType m_energyType;

        public Engine(e_TypeOfEngine i_typeOfEngine, e_EnergyType i_energyType, float i_remainingEnergy, float i_maximumEnergyCapacity)
        {
            m_typeOfEngine = i_typeOfEngine;
            m_energyType = i_energyType;
            m_remainingEnergy = i_remainingEnergy;
            m_maximumEnergyCapacity = i_maximumEnergyCapacity;
            m_generalEnergyPercentageLeft = m_remainingEnergy * 100 / m_maximumEnergyCapacity;
        }

        public Engine(e_TypeOfEngine i_typeOfEngine, float i_remainingEnergy, float i_maximumEnergyCapacity)
        {
            m_typeOfEngine = i_typeOfEngine;
            m_remainingEnergy = i_remainingEnergy;
            m_maximumEnergyCapacity = i_maximumEnergyCapacity;
            m_generalEnergyPercentageLeft = m_remainingEnergy * 100 / m_maximumEnergyCapacity;
        }

        public void EnergyAdder(float i_energyChargeAmount, e_EnergyType i_energyType)
        {
            if (m_energyType == i_energyType)
            {
                if (m_remainingEnergy + i_energyChargeAmount <= m_maximumEnergyCapacity)
                {
                    m_remainingEnergy += i_energyChargeAmount;
                    m_generalEnergyPercentageLeft = m_remainingEnergy * 100 / m_maximumEnergyCapacity;
                }
                else
                {
                    throw new ValueOutOfRangeException(0f, m_maximumEnergyCapacity - m_remainingEnergy);
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public float MaximumEnergyResource
        {
            get
            {
                return m_maximumEnergyCapacity;
            }
        }

        public float CurrentEnergyResource
        {
            get
            {
                return m_remainingEnergy;
            }

            set
            {
                m_remainingEnergy = value;
            }
        }

        public float GeneralEnergyPercentageLeft
        {
            get
            {
                return m_generalEnergyPercentageLeft;
            }

            set
            {
                m_generalEnergyPercentageLeft = value;
            }
        }

        public e_TypeOfEngine EngineType
        {
            get
            {
                return m_typeOfEngine;
            }
        }

        public e_EnergyType EnergyType
        {
            get
            {
                return m_energyType;
            }
        }
    }
}

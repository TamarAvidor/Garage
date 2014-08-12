namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Wheel
    {
        private readonly string m_manufacturerName;
        private readonly float m_maximumAirPressure;
        private float m_currentAirPressure;

        public Wheel(string i_manufacturerName, float i_maximumAirPressure, float i_currentAirPressure)
        {
            m_manufacturerName = i_manufacturerName;
            m_maximumAirPressure = i_maximumAirPressure;
            m_currentAirPressure = i_currentAirPressure;
        }

        public void InflationWheel(float i_airPressureToIncrease)
        {
            if (m_currentAirPressure + i_airPressureToIncrease <= m_maximumAirPressure)
            {
                m_currentAirPressure += i_airPressureToIncrease;
            }
            else
            {
                throw new ValueOutOfRangeException(0f, m_maximumAirPressure - m_currentAirPressure);
            }
        }

        public float MaximumAirPressure
        {
            get
            {
                return m_maximumAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_currentAirPressure;
            }

            set
            {
                m_currentAirPressure = value;
            }
        }

        public string ManufacturerName
        {
            get
            {
                return m_manufacturerName;
            }
        }
    }
}

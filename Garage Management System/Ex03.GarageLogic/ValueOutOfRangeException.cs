namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ValueOutOfRangeException : Exception
    {
        private float m_maxValue;
        private float m_minValue;
        private string m_message;

        public ValueOutOfRangeException()
            : base()
        {
        }

        public ValueOutOfRangeException(string message) 
            : base(message) 
        { 
        }

        public ValueOutOfRangeException(string message, System.Exception innerException)
            : base(message, innerException)
        { 
        }

        public ValueOutOfRangeException(float i_minValue, float i_maxValue)
        {
            this.m_maxValue = i_maxValue;
            this.m_minValue = i_minValue;
            this.m_message = string.Format("The value you entered is out of range.\nPlease enter a value between {0}-{1}.", this.m_minValue, this.m_maxValue);
        }

        public override string Message
        {
            get
            {
                return this.m_message; 
            }
        }

        public float MaxValue
        {
            get
            {
                return this.m_maxValue;
            }

            set
            {
                this.m_maxValue = value;
            }
        }

        public float MinValue
        {
            get
            {
                return this.m_minValue;
            }

            set
            {
                this.m_minValue = value;
            }
        }
    }
}

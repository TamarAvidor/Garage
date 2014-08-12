using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class GlobalConstants
    {
        public const float carMaxAirPressure = 28f;
        public const float motorcycleMaxAirPressure = 31f;
        public const float truckMaxAirPressure = 27f;

        public const float regularCarMaxFuelTank = 55f;
        public const float electricCarMaxBatteryCapacity = 2.5f;
        public const float regularMotorcycleMaxFuelTank = 7f;
        public const float electricMotorcycleMaxBatteryCapacity = 2.2f;
        public const float truckMaxFuelTank = 150f;

        public const int motorcycleNumberOfWheels = 2;
        public const int carNumberOfWheels = 4;
        public const int truckNumberOfWheels = 8;

        public const int lowerRangeOfFunctionalityChoice = 1;
        public const int upperRangeOfFunctionalityChoice = 7;

        public const int lowerRangeOfVehicleChoice = 1;
        public const int upperRangeOfVehicleChoice = 5;

        public const int lowerRangeOfVehicleEnumChoice = 1;
        public const int upperRangeOfVehicleEnumChoice = 4;

        public const int lowerRangeOfSortingDisplayVehiclesList = 1;
        public const int upperRangeOfSortingDisplayVehiclesList = 3;

        public const int yes = 1;
        public const int no = 2;

        public const int dummyIntConst = -1;
    }
}
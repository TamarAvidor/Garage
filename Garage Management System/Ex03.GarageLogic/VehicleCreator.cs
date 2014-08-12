namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class VehicleCreator
    {
        public static Vehicle CreateRegularCar(Vehicle.BasicInformationOfVehicleAndOwner informationOfVehicleAndOwner, Car.e_Color i_color, Car.e_NumberOfDoors i_numberOfDoors)
        {
            Vehicle regularCar = new RegularCar(
                informationOfVehicleAndOwner.m_ModelName,
                informationOfVehicleAndOwner.m_LicenseNumber,
                informationOfVehicleAndOwner.m_WheelManufacturer,
                informationOfVehicleAndOwner.m_CurrentAirPressure,
                informationOfVehicleAndOwner.m_AmountEnergyResource,
                i_color, 
                i_numberOfDoors);
            return regularCar;
        }

        public static Vehicle CreateElectricCar(Vehicle.BasicInformationOfVehicleAndOwner informationOfVehicleAndOwner, Car.e_Color i_color, Car.e_NumberOfDoors i_numberOfDoors)
        {
            Vehicle electricCar = new ElectricCar(
                informationOfVehicleAndOwner.m_ModelName,
                informationOfVehicleAndOwner.m_LicenseNumber,
                informationOfVehicleAndOwner.m_WheelManufacturer,
                informationOfVehicleAndOwner.m_CurrentAirPressure,
                informationOfVehicleAndOwner.m_AmountEnergyResource,
                i_color, 
                i_numberOfDoors);
            return electricCar;
        }

        public static Vehicle CreateRegularMotorcycle(Vehicle.BasicInformationOfVehicleAndOwner informationOfVehicleAndOwner, Motorcycle.e_LicenseType i_licenseType, int i_engineCapacity)
        {
            Vehicle regularMotorcycle = new RegularMotorcycle(
                informationOfVehicleAndOwner.m_ModelName,
                informationOfVehicleAndOwner.m_LicenseNumber,
                informationOfVehicleAndOwner.m_WheelManufacturer,
                informationOfVehicleAndOwner.m_CurrentAirPressure,
                informationOfVehicleAndOwner.m_AmountEnergyResource,
                i_engineCapacity, 
                i_licenseType);
            return regularMotorcycle;
        }

        public static Vehicle CreateElectricMotorcycle(Vehicle.BasicInformationOfVehicleAndOwner informationOfVehicleAndOwner, Motorcycle.e_LicenseType i_licenseType, int i_engineCapacity)
        {
            Vehicle electricMotorcycle = new ElectricMotorcycle(
                informationOfVehicleAndOwner.m_ModelName,
                informationOfVehicleAndOwner.m_LicenseNumber,
                informationOfVehicleAndOwner.m_WheelManufacturer,
                informationOfVehicleAndOwner.m_CurrentAirPressure,
                informationOfVehicleAndOwner.m_AmountEnergyResource,
                i_engineCapacity, 
                i_licenseType);
            return electricMotorcycle;
        }

        public static Vehicle CreateTruck(Vehicle.BasicInformationOfVehicleAndOwner informationOfVehicleAndOwner, bool i_isCarringHazardousMaterials, float i_volumeCapacity)
        {
            Vehicle truck = new Truck(
                informationOfVehicleAndOwner.m_ModelName,
                informationOfVehicleAndOwner.m_LicenseNumber,
                informationOfVehicleAndOwner.m_WheelManufacturer,
                informationOfVehicleAndOwner.m_CurrentAirPressure,
                informationOfVehicleAndOwner.m_AmountEnergyResource,
                i_isCarringHazardousMaterials, 
                i_volumeCapacity);
            return truck;
        }
    }
}

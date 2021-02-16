using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ASa.ApartmentManagement.Core.BaseInfo.Managers
{
    public class BuildingManager
    {
        ITableGatwayFactory _tablegatwayFactory;
        public BuildingManager(ITableGatwayFactory tablegatwayFactory)
        {
            _tablegatwayFactory = tablegatwayFactory;
        }
        public int JustForTest(int a, int b)
        {
            return a + b;
        }

        public async Task AddPerson(PersonDTO person)
        {
            ValidatePerson(person);
            var tableGateway = _tablegatwayFactory.CreateIPersonTableGateway();
            var pid = await tableGateway.InsertPersonAsync(person).ConfigureAwait(false);
            person.Id = pid;
        }


        public async Task AddBuilding(BuildingDTO building)
        {
            ValidateBuilding(building);
            var tableGateway = _tablegatwayFactory.CreateBuildingTableGateway();
            var id = await tableGateway.InsertBuildingAsync(building).ConfigureAwait(false);
            building.Id = id;

        }

        public async Task AddAparmentUnit(ApartmentUnitDTO unit)
        {
            ValidateUnit(unit);
            var tablegateway = _tablegatwayFactory.CreateIApartmentTableGateway();
            var apartmentid = await tablegateway.InsertUnitAsync(unit).ConfigureAwait(false);
            unit.Id = apartmentid;
        }

        private static void ValidateBuilding(BuildingDTO building)
        {
            const int MAX_BUILDING_NAME_LENGTH = 50;
            var buildingNameIsValid = string.IsNullOrWhiteSpace(building.Name) || building.Name.Length > MAX_BUILDING_NAME_LENGTH;
            if (buildingNameIsValid)
            {
                throw new ValidationException(ErrorCodes.Invalid_Building_Name, $"Building name cannot be neither empty nor larger than {MAX_BUILDING_NAME_LENGTH} character");
            }
            const int MINIMUM_BUILDING_UNITS_COUNT = 1;
            if (building.NumberOfUnits < MINIMUM_BUILDING_UNITS_COUNT)
            {
                throw new ValidationException(ErrorCodes.Invalid_Number_Of_Units, $"The number of units cannot be less than {MINIMUM_BUILDING_UNITS_COUNT }.");
            }
        }

        private static void ValidateUnit(ApartmentUnitDTO unit)
        {
            const int MAX_AREA = 10;
            if (unit.Area < MAX_AREA || unit.Number < 0)
            {
                throw new ValidationException(ErrorCodes.Invalid_Number_Unit, $"The Number must not be smaller thatn zero");
            }
        }


        private static void ValidatePerson(PersonDTO person)
        {
            //TODO:validation for person 
        }


        public async Task<IEnumerable<ApartmentUnitDTO>> GetAllApartmentUnits(int buildingId)
        {
            var tableGateway = _tablegatwayFactory.CreateIApartmentTableGateway();
            return  await tableGateway.GetAllByBuildingId(buildingId).ConfigureAwait(false);            
        }

        public async Task<IEnumerable<OwnerTenantInfoDto>> GetAllOwnerTenantByUnitId(int unitId)
        {
            if (unitId < 1)
            {
                return new List<OwnerTenantInfoDto>();
            }
            var tableGateway = _tablegatwayFactory.CreateIApartmentTableGateway();
            return await tableGateway.GetAllOwnerTenant(unitId).ConfigureAwait(false);
        }




    }
}

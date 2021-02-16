using Asa.ApartmentSystem.Infra.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.BaseInfo.Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.ApplicationService
{
    public class BaseInfoApplicationService
    {
        ITableGatwayFactory tableGatwayFactory;
        public BaseInfoApplicationService(string connectionString)
        {
            //HACK: This approach is not the best one, we will change it as soon as DI tools get introduced
            tableGatwayFactory = new SqlTableGatewayFactory(connectionString);
        }
        public async Task<int> CreateBuilding(string Name, int numberofUnits)
        {
            var buildingManager = new BuildingManager(tableGatwayFactory);
            var buildingDto = new BuildingDTO { Name = Name, NumberOfUnits = numberofUnits };
            await buildingManager.AddBuilding(buildingDto);
            return buildingDto.Id;
        }
        public async Task<int> CreateAparmentUnit(int number, int buildingId, decimal area, string description)
        {
            var buildingManager = new BuildingManager(tableGatwayFactory);
            var unitDTO = new ApartmentUnitDTO { Number = number, Area = area, BuidlingId = buildingId, Description = description };
            await buildingManager.AddAparmentUnit(unitDTO);
            return unitDTO.Id;
        }

        public async Task<int> CreatePerson(string fullname , string phone_number)
        {
            var buildingmanager = new BuildingManager(tableGatwayFactory);
            var personDto = new PersonDTO { FullName = fullname, PhoneNumber = phone_number };
            await buildingmanager.AddPerson(personDto);
            return personDto.Id;
        }


        public async Task<IEnumerable<ApartmentUnitDTO>> GetUnitsForBuilding(int buildingId)
        {
            var buildingManager = new BuildingManager(tableGatwayFactory);
            var result = await buildingManager.GetAllApartmentUnits(buildingId);
            return result;
        }
        public async Task<IEnumerable<OwnerTenantInfoDto>> GetAllOwnerTenantByUnitId(int unitid)
        {
            var buildingManager = new BuildingManager(tableGatwayFactory);
            return await buildingManager.GetAllOwnerTenantByUnitId(unitid);
        }


    }
}

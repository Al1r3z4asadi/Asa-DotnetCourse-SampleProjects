using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using System.Threading.Tasks;

namespace ASa.ApartmentManagement.Core.BaseInfo.DataGateways
{
    public interface IPersonTableGateway
    {
        Task<int> InsertPersonAsync(PersonDTO person);
    }
}
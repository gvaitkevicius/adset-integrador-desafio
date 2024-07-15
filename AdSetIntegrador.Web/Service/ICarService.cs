using System.ServiceModel;
using AdSetIntegrador.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdSetIntegrador.Web.Services
{
    [ServiceContract]
    public interface ICarService
    {
        [OperationContract]
        Task<List<Car>> GetAllCars();

        [OperationContract]
        Task<Car> GetCarById(int id);

        [OperationContract]
        Task AddCar(Car car);

        [OperationContract]
        Task UpdateCar(Car car);

        [OperationContract]
        Task DeleteCar(int id);
    }
}

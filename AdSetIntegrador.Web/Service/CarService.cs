using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdSetIntegrador.Data.Entities;
using AdSetIntegrador.Data.Repositories;

namespace AdSetIntegrador.Web.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;

        public CarService(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<List<Car>> GetAllCars()
        {
            return (await _carRepository.GetAllAsync()).ToList();
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _carRepository.GetByIdAsync(id);
        }

        public async Task AddCar(Car car)
        {
            await _carRepository.AddAsync(car);
            await _carRepository.SaveChangesAsync();
        }

        public async Task UpdateCar(Car car)
        {
            _carRepository.Update(car);
            await _carRepository.SaveChangesAsync();
        }

        public async Task DeleteCar(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            _carRepository.Remove(car);
            await _carRepository.SaveChangesAsync();
        }
    }
}

namespace CarDealer.Services.Contracts
{
    using System.Collections.Generic;
    using Models.Cars;

    public interface ICarService
    {
        IEnumerable<CarModel> CarsInfo(string make);

        IEnumerable<CarWithPartsModel> CarWithPartsInfo();

        void AddCarWithParts(AddCarWithPartsModel car);
    }
}
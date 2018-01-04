namespace CarDealer.Services.Contracts
{
    using System.Collections.Generic;
    using Data.Models;
    using Models.Parts;

    public interface IPartService
    {
        bool AddPart(string name, double price, string supplier, int quantity);

        IEnumerable<Part> All();

        IEnumerable<PartModel> AllPartNamesAndPrices();

        bool DeletePart(int id);

        void EditPart(int id, double? price, int quantity);

        PartEditModel GetById(int id);
    }
}
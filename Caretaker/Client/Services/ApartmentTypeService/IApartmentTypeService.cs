namespace Caretaker.Client.Services.ApartmentTypeService
{
    public interface IApartmentTypeService
    {
         IEnumerable<ApartmentType> ApartmentTypes { get; set; }

        Task<IEnumerable<ApartmentType>> GetApartmentTypes();
        Task<ApartmentType> GetSingleApartmentType(int id);
        Task CreateApartmentType(ApartmentType apartmentType);
        Task DeleteApartmentType(int id);
        Task UpdateApartmentType(ApartmentType apartmentType);
    }
}

using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Caretaker.Client.Services.ApartmentTypeService
{
    public class ApartmentTypeService : IApartmentTypeService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ApartmentTypeService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public IEnumerable<ApartmentType> ApartmentTypes { get; set; } = new List<ApartmentType>();

        public Task CreateApartmentType(ApartmentType apartmentType)
        {
            throw new NotImplementedException();
        }

        public Task DeleteApartmentType(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApartmentType>> GetApartmentTypes()
        {
            var result = await _http.GetFromJsonAsync<IEnumerable<ApartmentType>>("ApartmentType");
            if (result != null)
                ApartmentTypes = result;
            return ApartmentTypes;
        }

        public Task<ApartmentType> GetSingleApartmentType(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateApartmentType(ApartmentType apartmentType)
        {
            throw new NotImplementedException();
        }
    }
}

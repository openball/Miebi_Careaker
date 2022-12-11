using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace Caretaker.Client.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public PersonService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public IEnumerable<Person> people { get; set; } = new List<Person>();
        public List<Gender> genders { get; set; } = new List<Gender>();
        public List<PersonCategory> personcategories { get; set; } = new List<PersonCategory>(); //{ new PersonCategory() };

        public async Task GetGenders()
        {
            var result = await _http.GetFromJsonAsync<List<Gender>>("Person/genders");
            if (result != null)
                genders = result;
        }
        public async Task GetPersonCategories()
        {
            var result = await _http.GetFromJsonAsync<List<PersonCategory>>("Person/personcategories");
            if (result != null)
                personcategories = result;
        }
        public async Task<IEnumerable<Person>> GetPeople()
        {
            var result = await _http.GetFromJsonAsync<IEnumerable<Person>>("Person");
            if(result != null)
                people = result;
            return people;
        }

        public async Task<Person> GetSinglePerson(int id)
        {
            var result = await _http.GetFromJsonAsync<Person>($"Person/{id}");
            if (result != null)
                return result;
            throw new Exception("Sorry, Person not found");            
        }

        public async Task CreatePerson(Person person)
        {
            var result = await _http.PostAsJsonAsync("Person", person);
            var response = await result.Content.ReadFromJsonAsync<List<Person>>();
            people = response;
        }

        public async Task DeletePerson(int id)
        {
            var result = await _http.DeleteAsync($"Person/{id}");
            var response = await result.Content.ReadFromJsonAsync<List<Person>>();
            people = response;
        }

        public async Task UpdatePerson(Person person)
        {
            var result = await _http.PutAsJsonAsync($"Person/{person.PersonId}", person);
            var response = await result.Content.ReadFromJsonAsync<List<Person>>();
            people = response;
            _navigationManager.NavigateTo("people");
        }
    }
}

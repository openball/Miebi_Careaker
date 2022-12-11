namespace Caretaker.Client.Services.PersonService
{
    public interface IPersonService
    {
        IEnumerable<Person> people { get; set; }
        List<Gender> genders { get; set; }
        List<PersonCategory> personcategories { get; set; }

        Task GetPersonCategories();
        Task GetGenders();
        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetSinglePerson(int id);
        Task CreatePerson(Person person);
        Task DeletePerson(int id);
        Task UpdatePerson(Person person);

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caretaker.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;

        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPeople()
        {
            var people = await _context.People
                .Include(g => g.Gender)
                .Include(g => g.PersonCategory)
                .ToListAsync();
            return Ok(people);
        }

        [HttpGet("genders")]
        public async Task<ActionResult<List<Gender>>> GetGenders()
        {
            var genders = await _context.Genders.ToListAsync();
            return Ok(genders);
        }

        [HttpGet("personcategories")]
        public async Task<ActionResult<List<PersonCategory>>> GetPersonCategories()
        {
            var personcategories = await _context.PersonCategories.ToListAsync();
            return Ok(personcategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Person>>> GetPerson(int id)
        {
            var person = await _context.People
                .Include(g => g.Gender)
                .Include(g => g.PersonCategory)
                .FirstOrDefaultAsync(p => p.PersonId == id);
            if (person == null)
            {
                return NotFound("Person not found. :/");
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> CreatePerson(Person person)
        {
            //
            person.Gender = null;
            person.PersonCategory = null;
            _context.People.Add(person);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPeople());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person person, int id)
        {
            var dbPerson = await _context.People
                .Include(g => g.Gender)
                .Include(g => g.PersonCategory)
                .FirstOrDefaultAsync(g => g.PersonId == id);
            if (dbPerson == null)
                return NotFound("Person not found. :/");

            dbPerson.Firstname = person.Firstname;
            dbPerson.Middlename = person.Middlename;
            dbPerson.Lastname = person.Lastname;
            dbPerson.GenderId = person.GenderId;
            dbPerson.Mobile = person.Mobile;
            dbPerson.EmailAddress = person.EmailAddress;
            dbPerson.PersonCategoryId = person.PersonCategoryId;
            dbPerson.Active = person.Active;

            await _context.SaveChangesAsync();

            return Ok(await GetDbPeople());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson( int id)
        {
            var dbPerson = await _context.People
                .Include(g => g.Gender)
                .Include(g => g.PersonCategory)
                .FirstOrDefaultAsync(g => g.PersonId == id);
            if (dbPerson == null)
                return NotFound("Person not found. :/");

            _context.People.Remove(dbPerson);
            await _context.SaveChangesAsync();

            return Ok(await GetDbPeople());
        }

        private async Task<List<Person>> GetDbPeople()
        {
            return await _context.People.Include(g => g.Gender).Include(p => p.PersonCategory).ToListAsync();
        }
    }
}

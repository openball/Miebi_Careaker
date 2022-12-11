using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Caretaker.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApartmentTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public ApartmentTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApartmentType>>> GetApartmentTypes()
        {
            var apartmenttypes = await _context.ApartmentTypes.ToListAsync();
            return Ok(apartmenttypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApartmentType>> GetApartmentType(int id)
        {
            var apartmenttype = await _context.ApartmentTypes.FirstOrDefaultAsync(p => p.ApartmentTypeId == id);
            if (apartmenttype == null)
                return NotFound("ApartmentType Not Found. :/");

            return Ok(apartmenttype);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ApartmentType>>> CreateApartmentType(ApartmentType apartmentType)
        {
            _context.ApartmentTypes.Add(apartmentType);
            await _context.SaveChangesAsync();
            return Ok(await GetApartmentTypes());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<ApartmentType>>> UpdateApartmentType(ApartmentType apartmentType, int id)
        {
            var dbApartmentType = await _context.ApartmentTypes.FirstOrDefaultAsync(p => p.ApartmentTypeId == id);
            if (dbApartmentType == null)
                return NotFound($"ApartmntType with that id= {id} not found. :/");

            dbApartmentType.Description = apartmentType.Description;

            await _context.SaveChangesAsync();

            return Ok(await GetApartmentTypes());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<ApartmentType>>> DeleteApartmentType(int id)
        {
            var dbapartmentType = await _context.ApartmentTypes.FirstOrDefaultAsync(p => p.ApartmentTypeId == id);
            if (dbapartmentType == null)
                return BadRequest($"Bad Request to delete @ ApartmentTypeId = {id}. :/");

            _context.ApartmentTypes.Remove(dbapartmentType);
            await _context.SaveChangesAsync();

            return Ok(await GetApartmentTypes());
        }
        //private async Task<List<ApartmentType>> GetDbApartmentTypes()
        //{
        //    return await _context.ApartmentTypes.ToListAsync();
        //}
    }
}

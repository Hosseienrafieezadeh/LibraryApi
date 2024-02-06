using book.Entitis;
using book_web_api.Services.Shelfs;
using book_web_api.Services.Shelfs.ShelfsDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace book_web_api.Controllers
{
    [ApiController]
    [Route("api/Shelfs")]
    public class ShelfsController : ControllerBase
    {
        private readonly ShelfServices _shelfServices;

        public ShelfsController(ShelfServices shelfServices)
        {
            _shelfServices = shelfServices ?? throw new ArgumentNullException(nameof(shelfServices));
        }

        [HttpPost("add-shelf")]
        public IActionResult AddShelf([FromBody] AddShelfDto dto)
        {
            _shelfServices.AddShelf(dto);
            return NoContent();
        }

        [HttpDelete("delete-shelf/{name}")]
        public IActionResult DeleteShelf(string name)
        {
            _shelfServices.DeleteShelf(name);
            return NoContent();
        }

        [HttpPatch("update-shelf/{name}")]
        public IActionResult UpdateShelf(string name, [FromBody] UpdateShelfDto dto)
        {
            _shelfServices.UpdateShelf(name, dto);
            return NoContent();
        }

        [HttpGet("get-shelf")]
        public ActionResult<List<Shelf>> GetShelf()
        {
            var shelves = _shelfServices.GetShelves();
            return Ok(shelves);
        }
    }
}

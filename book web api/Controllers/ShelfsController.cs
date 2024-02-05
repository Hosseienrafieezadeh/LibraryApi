using book.Entitis;
using book_web_api.Services.Shelfs;
using book_web_api.Services.Shelfs.ShelfsDto;
using Microsoft.AspNetCore.Mvc;

namespace book_web_api.Controllers
{
        [ApiController]
        [Route("api/Shelfs")]
    public class ShelfsController
    {
      
            ShelfServices _ShelfServices = new ShelfServices();
            [HttpPost("add-shelf")]
            public void AddShelf([FromBody] AddShelfDto dto)
            {
                _ShelfServices.AddShelf(dto);
            }
            [HttpDelete("delete-shelf/{id}")]
            public void DeleteShelf([FromRoute] int id)
            {
                _ShelfServices.DeleteShelfs(id);
            }
            [HttpPatch("update-shelf/{id}")]
            public void UpdateShelf([FromRoute] int id, [FromBody] UpdateShelfDto dto)
            {
                _ShelfServices.UpdateBook(id, dto);
            }
            [HttpGet("get-shelf")]
            public List<Shelf> GetShelf()
            {
                return _ShelfServices.GetShelfs();
            }
        }
    }


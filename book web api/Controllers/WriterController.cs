using book.Entitis;
using book_web_api.Services.Writers;
using book_web_api.Services.Writers.WriterDto;
using Microsoft.AspNetCore.Mvc;

namespace book_web_api.Controllers
{
        [ApiController]
        [Route("api/writer")]
    public class WriterController:ControllerBase
    {
      
            WriterServices _WriterService = new WriterServices();
            [HttpPost("add-writer")]
            public void AddWriter([FromBody] AddWriterDTo dto)
            {
                _WriterService.AddWriter(dto);
            }
            [HttpPatch("update-writer/{id}")]
            public void UpdateWriter([FromRoute] int id, [FromBody] UpdateWriterDto dto)
            {
                _WriterService.UpdateWriter(id, dto);
            }
            [HttpDelete("delete-writer/{id}")]
            public void DeleteWriter([FromRoute] int id)
            {
                _WriterService.DeleteWriter(id);
            }
            [HttpGet("get-writer")]
            public List<Writer> GetWriter()
            {
                return _WriterService.GetWriter();
            }
        }
    }


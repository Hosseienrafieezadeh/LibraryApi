using book.Entitis;
using book_web_api.Services.Writers;
using book_web_api.Services.Writers.WriterDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace book_web_api.Controllers
{
    [ApiController]
    [Route("api/writers")]
    public class WriterController : ControllerBase
    {
        private readonly WriterServices _writerService;

        public WriterController(WriterServices writerService)
        {
            _writerService = writerService ?? throw new ArgumentNullException(nameof(writerService));
        }

        [HttpPost("add")]
        public IActionResult AddWriter([FromBody] AddWriterDTo dto)
        {
            try
            {
                _writerService.AddWriter(dto);
                return Ok("Writer added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("update/{name}")]
        public IActionResult UpdateWriter(string name, [FromBody] UpdateWriterDto dto)
        {
            try
            {
                _writerService.UpdateWriter(name, dto);
                return Ok("Writer updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete/{name}")]
        public IActionResult DeleteWriter(string name)
        {
            try
            {
                _writerService.DeleteWriter(name);
                return Ok("Writer deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get")]
        public IActionResult GetWriters()
        {
            try
            {
                var writers = _writerService.GetWriters();
                return Ok(writers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

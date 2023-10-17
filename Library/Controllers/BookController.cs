using Library.Business.Models;
using Library.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add([FromBody] BookDTO model)
        {
            if (model == null)
            {
                return BadRequest("No model was provided");
            }

            await _bookService.AddAsync(model);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            if (!Guid.TryParse(id, out Guid parsedGuid))
            {
                return BadRequest("Invalid id");
            }

            BookDTO result = await _bookService.GetByIdAsync(parsedGuid);
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid parsedGuid))
            {
                return BadRequest("Invalid id");
            }

            await _bookService.DeleteAsync(parsedGuid);
            return Ok();
        }

        [HttpGet]
        [Route("filter")]
        public async Task<IActionResult> Filter([FromQuery] FiltersDTO filters)
        {
            GridResult<BookDTO> result = await _bookService.FilterAsync(filters);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] BookDTO model)
        {
            if (model == null)
            {
                return BadRequest("No model was provided");
            }

            await _bookService.UpdateAsync(model);
            return Ok();
        }
    }
}
using Library.Business.Models;
using Library.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("api/authors")]
    //[Authorize(Roles = "Admin")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(AuthorDTO model)
        {
            if (model == null)
                return BadRequest();

            await _authorService.AddAsync(model);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest("Id is empty");

            if (!Guid.TryParse(id, out Guid result))
                return BadRequest("Invalid id");

            await _authorService.DeleteAsync(result);
            return Ok();
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<AuthorDTO> result = await _authorService.GetAllAsync();
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update([FromBody] AuthorDTO model)
        {
            if (model == null)
            {
                return BadRequest("No model was provided");
            }

            await _authorService.UpdateAsync(model);
            return Ok();
        }
    }
}
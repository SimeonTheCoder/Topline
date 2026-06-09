using Microsoft.AspNetCore.Mvc;
using Topline.Core.Contracts;
using Topline.Core.DTO;
using Topline.Infrastructure.Data.Models;

namespace Topline.API.Controllers
{
    [Route("api/items")]
    public class ItemController : ControllerBase
    {
        private IItemService itemService;

        public ItemController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<Item> items = await itemService.GetAll();

            List<ItemResponseDTO> dtoList = items.Select(curr => new ItemResponseDTO()
            {
                Id = curr.Id,
                Name = curr.Name,
                Artist = curr.Artist,
                Description = curr.Description,
                Year = curr.Year,
                Type = curr.Type.ToString(),
            }).ToList();

            if (dtoList.Count == 0) return NoContent();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                Item item = await itemService.GetById(id);

                return Ok(new ItemResponseDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Artist = item.Artist,
                    Description = item.Description,
                    Year = item.Year,
                    Type = item.Type.ToString(),
                });
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ItemCreateFormDTO form)
        {
            if (!ModelState.IsValid)
                return BadRequest(string.Join(
                    "; ",
                    ModelState.Values.Select(e => e.Errors).Select(e => string.Join("; ", e.Select(e => e.ErrorMessage)))
                ));

            if (form.Year == 0 || form.Year < 1000) return BadRequest("Invalid year!");

            Item result = await itemService.CreateItem(form);

            return Ok(new ItemResponseDTO()
            {
                Id = result.Id,
                Name = result.Name,
                Artist = result.Artist,
                Description = result.Description,
                Year = result.Year,
                Type = result.Type.ToString(),
            });
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody] ItemCreateFormDTO form)
        {
            if (!ModelState.IsValid)
                return BadRequest(string.Join(
                    "; ",
                    ModelState.Values.Select(e => e.Errors).Select(e => string.Join("; ", e.Select(e => e.ErrorMessage)))
                ));

            if (form.Year == 0 || form.Year < 1000) return BadRequest("Invalid year!");

            Item result = await itemService.EditItem(id, form);

            return Ok(new ItemResponseDTO()
            {
                Id = result.Id,
                Name = result.Name,
                Artist = result.Artist,
                Description = result.Description,
                Year = result.Year,
                Type = result.Type.ToString(),
            });
        }
    }
}

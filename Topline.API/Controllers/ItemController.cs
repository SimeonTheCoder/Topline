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
        private ITaggedItemService taggedItemService;

        public ItemController(IItemService itemService, ITaggedItemService taggedItemService)
        {
            this.itemService = itemService;
            this.taggedItemService = taggedItemService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] string tagId)
        {
            List<Item> items;

            if (string.IsNullOrWhiteSpace(tagId)) items = await itemService.GetAll();
            else items = await taggedItemService.GetByTagId(tagId);

            if (items.Count == 0) return NoContent();

            List<ItemResponseDTO> dtoList = new();

            foreach (Item item in items)
                dtoList.Add(await itemService.Dto(item));

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                Item item = await itemService.GetById(id);
                return Ok(await itemService.Dto(item));
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
            return Ok(await itemService.Dto(result));
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

            return Ok(await itemService.Dto(result));
        }
    }
}

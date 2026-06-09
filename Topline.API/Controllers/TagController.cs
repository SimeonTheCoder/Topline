using Microsoft.AspNetCore.Mvc;
using Topline.Core.Contracts;
using Topline.Core.DTO;
using Topline.Infrastructure.Data.Models;

namespace Topline.API.Controllers
{
    [Route("api/tags")]
    public class TagController : ControllerBase
    {
        private ITagService tagService;

        public TagController(ITagService tagService)
        {
            this.tagService = tagService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            List<Tag> tags = await tagService.GetAll();

            List<TagResponseDTO> dtoList = tags.Select(curr => new TagResponseDTO()
            {
                Id = curr.Id,
                Name = curr.Name
            }).ToList();

            if (dtoList.Count == 0) return NoContent();

            return Ok(dtoList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            try
            {
                Tag tag = await tagService.GetById(id);

                return Ok(new TagResponseDTO()
                {
                    Id = tag.Id,
                    Name = tag.Name
                });
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] TagCreateFormDTO form)
        {
            if (!ModelState.IsValid)
                return BadRequest(string.Join(
                    "; ",
                    ModelState.Values.Select(e => e.Errors).Select(e => string.Join("; ", e.Select(e => e.ErrorMessage)))
                ));

            Tag result = await tagService.CreateTag(form);

            return Ok(new TagResponseDTO()
            {
                Id = result.Id,
                Name = result.Name
            });
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody] TagCreateFormDTO form)
        {
            if (!ModelState.IsValid)
                return BadRequest(string.Join(
                    "; ",
                    ModelState.Values.Select(e => e.Errors).Select(e => string.Join("; ", e.Select(e => e.ErrorMessage)))
                ));

            Tag result = await tagService.EditTag(id, form);

            return Ok(new TagResponseDTO()
            {
                Id = result.Id,
                Name = result.Name
            });
        }
    }
}

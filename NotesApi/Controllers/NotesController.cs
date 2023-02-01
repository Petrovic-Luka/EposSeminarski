using DataAccess.Data;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using NotesApi.Helpers;
using System.Net;
using System.Net.Http;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        // GET: api/<NotesController>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var temp= await DataHelper.NotesGetAllAsync();
            return Ok(temp);
        }

        // GET api/<NotesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var temp=await DataHelper.NotesGetAsync(id);
            if(temp==null||temp.Count()<1)
            {
                throw new AppException("There are no notes with given id");
            }
            return Ok(temp);
        }

        // POST api/<NotesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NoteModel value)
        {

            try
            {
                DataValidation.CheckData(value);
            }
            catch (AppException ex)
            {
                throw ex;
            }
            DataHelper.NotesCreateAsync(value);
            return Ok("Note has been created");

        }

        // PUT api/<NotesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] NoteModel value)
        {
            try
            {
                var temp = await DataHelper.NotesGetAsync(id);
                if (temp == null || temp.Count() < 1)
                {
                    throw new AppException("There are no notes with given id");
                }
                DataValidation.CheckData(value);
            }
            catch (AppException ex)
            {
                throw ex;
            }
            DataHelper.Notesupdate(id, value);
            return Ok("Note has been updated");
        }

        // DELETE api/<NotesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var temp = await DataHelper.NotesGetAsync(id);
            if (temp == null || temp.Count() < 1)
            {
                throw new AppException("There are no notes with given id");
            }
            DataHelper.NotesDeleteAsync(id);
            return Ok("Note has been deleted");
        }
    }
}

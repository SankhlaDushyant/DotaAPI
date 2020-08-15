using System.Collections.Generic;
using DotaAPI.Data;
using DotaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaAPI.Controllers
    ///hello
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class DotasController : ControllerBase
    {
        private readonly MockDotaRepo _repository = new MockDotaRepo();
        //GET api/DotaAPI
        [HttpGet]
        public ActionResult <IEnumerable<Dota>> GetAllCharacters()
        {
            var DotaItems = _repository.GetAllCharacters();
            return Ok(DotaItems);
        }

        //GET api/DotaAPI/5
        [HttpGet("{id}")]
        public ActionResult <Dota> GetCharacterbyId(int id)
        {
            var DotaItem = _repository.GetCharacterbyId(id);
            return Ok(DotaItem);
        }
    }
}
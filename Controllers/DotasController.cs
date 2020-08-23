using System;
using System.Collections.Generic;
using DotaAPI.Data;
using DotaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotaAPI.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class DotasController : ControllerBase
    {
        private readonly IDotaRepo _repository;

        public DotasController(IDotaRepo repository)
        {
            _repository = repository;
        }
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

        //POST api/DotaAPI
        [HttpPost]

        public ActionResult <Dota> AddCharacter(Dota Character)
        {
            var DotaItem = _repository.AddCharacter(Character);
            return Ok(DotaItem);
        }

        //DELETE api/DotaAPI/2
        [HttpDelete("{id}")]
        public ActionResult DeleteCharacter(int id)
        {
            _repository.DeleteCharacter(id);
            return Ok(200);
        }

        //PUT api/DotaAPI
        [HttpPut]
        public ActionResult UpdateCharacter(Dota Character)
        {
            var DotaItem = _repository.UpdateCharacter(Character);
            return Ok(DotaItem);
        }
    }
}
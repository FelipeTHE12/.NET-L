using System;
using API_MONGO.Data.Collections;
using API_MONGO.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace API_MONGO.Controllers
{

[ApiController]
[Route("[controller]")]

    public class InfectedController : ControllerBase
    {

 
        
            Data.MongoDB _mongoDB;

            IMongoCollection<Infected> _infectedCollection;

            public InfectedController(Data.MongoDB mongoDB)
            {
                _mongoDB = mongoDB;
                _infectedCollection = _mongoDB.DB.GetCollection<Infected>(typeof(Infected).Name.ToLower());
            }

            [HttpPost]

            public ActionResult SaveInfected([FromBody] InfectedDto dto)
            {
                var infected = new Infected(dto.BirthDate, dto.Sex, dto.Latitude, dto.Longitude);

                _infectedCollection.InsertOne(infected);

                return StatusCode(201, "Infected has been add");
            }

            [HttpGet]

            public ActionResult GetInfected()
            {
                var infectedGroup = _infectedCollection.Find(Builders<Infected>.Filter.Empty).ToList();

                return Ok(infectedGroup);
            }

            [HttpPut]

            public ActionResult UpadteInfected([FromBody] InfectedDto dto)
            {
                var infected = new Infected(dto.BirthDate, dto.Sex, dto.Latitude, dto.Longitude);
                _infectedCollection.UpdateOne(Builders<Infected>.Filter.Where(_ => _.BirthDate == dto.BirthDate), Builders<Infected>.Update.Set("Sex",dto.Sex));
                return Ok("Updated!");
            }

            [HttpDelete("{BirthDate}")]
            public ActionResult DeleteInfected(DateTime BirthDate)
            {
                _infectedCollection.DeleteOne(Builders<Infected>.Filter.Where(_ => _.BirthDate == BirthDate));
                return Ok("Deleted!");
            }

        }
    }

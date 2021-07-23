using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeriesApi.Models;
using SeriesApi.Services;

namespace SeriesApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SeriesController : ControllerBase
    {
        private readonly IMongoService _mongoService;
        public SeriesController(IMongoService mongoService)
        {
            this._mongoService = mongoService;
        }

        [HttpGet]
        public ActionResult GetAllSeries()
        {
            var series = _mongoService.GetCollection();
            return Ok(series);
        }

        [HttpPost("Insert")]
        public ActionResult InsertOneSerie([FromBody] Serie serie)
        {
            var serieCreated = _mongoService.PostDocument(serie).ToString();
            return StatusCode(201, "Documento inserido com sucesso" + Environment.NewLine + serieCreated);

        }

        [HttpPut("Update/{id}")]
        public ActionResult UpdateOneSerie([FromBody] Serie serie, [FromRoute] string id)
        {
            var serieUpdated = _mongoService.UpdateDocument(serie, id);
            return Accepted(serieUpdated);
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteOneSerie([FromRoute] string id)
        {
            var serieDeleted = _mongoService.DeleteDocument(id);
            return Accepted(serieDeleted);
        }

    }
}
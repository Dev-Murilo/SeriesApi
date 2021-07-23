using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeriesApi.Models;

namespace SeriesApi.Services
{
    public interface IMongoService
    {
        List<Serie> GetCollection();
        SerieViewModel PostDocument(Serie newSerie);
        SerieViewModel UpdateDocument(Serie updateSerie, string id);
        SerieViewModel DeleteDocument(string id);

    }
}
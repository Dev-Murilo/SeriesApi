using SeriesApi.Models;
using MongoDB.Driver;
using SeriesApi.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;
using MongoDB.Bson;

namespace SeriesApi.Services
{
    public class MongoService : IMongoService
    {
        MongoDb _mongodb;
        IMongoCollection<Serie> _serieCollection;
        public MongoService(MongoDb mongodb)
        {
            this._mongodb = mongodb;
            this._serieCollection = _mongodb.DB.GetCollection<Serie>(typeof(Serie).Name.ToLower());
        }

        public List<Serie> GetCollection()
        {
            var series = _serieCollection.Find(Builders<Serie>.Filter.Empty).ToList();
            return series;
        }

        public SerieViewModel PostDocument(Serie newSerie)
        {
            var serie = new SerieViewModel(
                newSerie.Genero,
                newSerie.Titulo,
                newSerie.Descricao,
                newSerie.AnoLancamento,
                newSerie.Autor
            );

            _serieCollection.InsertOne(newSerie);
            Serie PostedSerie = _serieCollection.Find(Builders<Serie>.Filter.Where(_ => _.Titulo == newSerie.Titulo)).FirstOrDefault();
            serie.Id = PostedSerie.Id;
            return serie;
        }

        public SerieViewModel UpdateDocument(Serie updateSerie, string id)
        {
            var serieUpdated = new SerieViewModel(
                updateSerie.Genero,
                updateSerie.Titulo,
                updateSerie.Descricao,
                updateSerie.AnoLancamento,
                updateSerie.Autor
            );
            updateSerie.Id = id;
            serieUpdated.Id = id;

            Expression<Func<Serie, bool>> filter = x => x.Id.Equals(ObjectId.Parse(id));
            Serie serie = _serieCollection.Find(filter).FirstOrDefault();
            if (serie != null)
            {
                ReplaceOneResult result = _serieCollection.ReplaceOne(filter, updateSerie);
            }

            return serieUpdated;
        }

        public SerieViewModel DeleteDocument(string id)
        {
            Expression<Func<Serie, bool>> filter = x => x.Id.Equals(ObjectId.Parse(id));
            Serie serie = _serieCollection.Find(filter).FirstOrDefault();

            var serieDeleted = new SerieViewModel(
            serie.Genero,
            serie.Titulo,
            serie.Descricao,
            serie.AnoLancamento,
            serie.Autor
            );

            if (serie != null)
            {

                serieDeleted.Id = serie.Id;
                _serieCollection.DeleteOne(filter);

                return serieDeleted;

            }

            return serieDeleted;

        }
    }
}
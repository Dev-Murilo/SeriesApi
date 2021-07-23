using System;

namespace SeriesApi.Models
{
    public class SerieViewModel
    {
        public SerieViewModel(string genero, string titulo, string descricao, int anoLancamento, string autor)
        {

            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.AnoLancamento = anoLancamento;
            this.Autor = autor;
        }
        public string Id { get; set; }
        public string Genero { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int AnoLancamento { get; set; }
        public string Autor { get; set; }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Id: " + this.Id + Environment.NewLine;
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de lançamento: " + this.AnoLancamento + Environment.NewLine;
            retorno += "Autor" + this.Autor + Environment.NewLine;
            return retorno;
        }
    }
}
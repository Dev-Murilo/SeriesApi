using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SeriesApi.Models
{
    public class Serie
    {
        public Serie(string genero, string titulo, string descricao, int anoLancamento, string autor)
        {

            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.AnoLancamento = anoLancamento;
            this.Autor = autor;
        }
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Display(Name = "Gênero")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Genero { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Campo obrigatorio")]
        [StringLength(maximumLength: 600, ErrorMessage = "máximo de 600 palavras")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Ano de lançamento")]
        [Required(ErrorMessage = "Campo obrigatorio")]
        public int AnoLancamento { get; set; }

        [Required]
        [StringLength(maximumLength: 60, ErrorMessage = "O nome deve ter no máximo 60 caracteres")]
        public string Autor { get; set; }
    }
}



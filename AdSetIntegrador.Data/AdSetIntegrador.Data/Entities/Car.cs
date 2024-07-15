using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdSetIntegrador.Data.Entities
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Marca é obrigatório.")]
        public string Marca { get; set; }

        [Required(ErrorMessage = "O campo Modelo é obrigatório.")]
        public string Modelo { get; set; }

        [Range(2000, 2024, ErrorMessage = "O ano deve estar entre 2000 e 2024.")]
        public int Ano { get; set; }

        [Required(ErrorMessage = "O campo Placa é obrigatório.")]
        public string Placa { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A quilometragem deve ser maior ou igual a zero.")]
        public int? Km { get; set; }

        [Required(ErrorMessage = "O campo Cor é obrigatório.")]
        public string Cor { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        public List<string> Opcionais { get; set; }

        public List<CarPhoto> Fotos { get; set; }

        public Car()
        {
            Opcionais = new List<string>();
            Fotos = new List<CarPhoto>();
        }
    }
}

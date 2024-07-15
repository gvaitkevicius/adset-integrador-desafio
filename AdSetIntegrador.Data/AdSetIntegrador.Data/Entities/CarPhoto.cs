using System.ComponentModel.DataAnnotations;

namespace AdSetIntegrador.Data.Entities
{
    public class CarPhoto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A URL da foto é obrigatória.")]
        public string Url { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}

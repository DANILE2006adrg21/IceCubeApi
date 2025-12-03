using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace IceCube.Models
{
    public class CatIdioma
    {

        [Key]
        public int id {  get; set; }

        [StringLength(50)]
        public string strValor { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IceCube.Models;

namespace IceCube.Dto

{
    public class CatIdiomaDto
    {

        public int id {  get; set; }

        [StringLength(50)]
        public string strValor { get; set; }

    }
}

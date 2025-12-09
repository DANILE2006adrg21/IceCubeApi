using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IceCube.Models;

namespace IceCube.Dto
{
    public class UsuPerfilDto
    {

        public int id { get; set; }

        [StringLength(50)]
        public string strNombreUsuario { get; set; }

        [StringLength(20)]
        public string strGenero { get; set; }

        public DateTime? dtFechaNacimiento { get; set; }

        [StringLength(300)]
        public string strDescripcion { get; set; }

        [StringLength(250)]
        public string strFotoPerfil { get; set; }

        [StringLength(100)]
        public string strCiudad { get; set; }

        [StringLength(100)]
        public string strPais { get; set; }

        [StringLength(20)]
        public string strPreferenciaGenero { get; set; }


        public int? idCatIdioma { get; set; }

        //Tabla catalogo
        public CatIdioma? CatIdioma { get; set; }


        // 🔥 NUEVOS CAMPOS
        public string? strOcupacion { get; set; }   
        public string? strEscuelaEmpresa { get; set; }
        public string? strObjetivo { get; set; }
        public string? strSituaciones { get; set; }
        public string? strIntereses { get; set; }

    }
}

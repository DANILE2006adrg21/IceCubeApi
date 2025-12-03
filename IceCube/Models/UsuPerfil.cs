using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceCube.Models
{
    public class UsuPerfil
    {

        [Key]
        public int id {  get; set; }

        [StringLength(50)]
        public string strNombreUsuario { get; set; }

        [StringLength(20)]
        public string strGenero {  get; set; }

        public DateTime? dtFechaNacimiento { get; set; }

        [StringLength(300)]
        public string strDescripcion {  get; set; }

        [StringLength(250)]
        public string strFotoPerfil { get; set; }

        [StringLength(100)]
        public string strCiudad {  get; set; }

        [StringLength(100)]
        public string strPais {  get; set; }

        [StringLength(20)]
        public string strPreferenciaGenero { get; set; }


        public int idCatIdioma { get; set; }
        
        //Tabla catalogo
        public CatIdioma? CatIdioma { get; set; }

        // ───────────────────────────────
        // 🔥 NUEVOS CAMPOS (AGREGADOS)
        // ───────────────────────────────

        [StringLength(100)]
        public string? strOcupacion { get; set; }

        [StringLength(150)]
        public string? strEscuelaEmpresa { get; set; }

        [StringLength(300)]
        public string? strObjetivo { get; set; }

        [StringLength(300)]
        public string? strSituaciones { get; set; }

        [StringLength(300)]
        public string? strIntereses { get; set; }

    }
}

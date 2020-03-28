namespace MuseosBogotaWeb.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Administrador")]
    public partial class Administrador
    {
        [Key]
        public int IdAdministrador { get; set; }

        [StringLength(50)]
        public string NombreAddministrador { get; set; }

        public int? IdUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}

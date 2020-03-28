namespace MuseosBogotaWeb.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Boleta")]
    public partial class Boleta
    {
        [Key]
        public int idBoleta { get; set; }

        [StringLength(50)]
        public string NombreBoleta { get; set; }

        public int? IdTipoBoleta { get; set; }

        public virtual TipoBoleta TipoBoleta { get; set; }
    }
}

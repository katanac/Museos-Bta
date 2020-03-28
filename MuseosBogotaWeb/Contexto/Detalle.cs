namespace MuseosBogotaWeb.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Detalle")]
    public partial class Detalle
    {
        [Key]
        public int IdDetalle { get; set; }

        [StringLength(100)]
        public string DescripcionCompra { get; set; }

        public int? IdBoleta { get; set; }

        public int? IdFactura { get; set; }

        public int? valorCompra { get; set; }

        public virtual Factura Factura { get; set; }
    }
}

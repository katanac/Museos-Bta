namespace MuseosBogotaWeb.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservas
    {
        [Key]
        public int IdReserva { get; set; }

        public DateTime? FechaReserva { get; set; }

        public int? numeroBoletas { get; set; }

        public int? IdEvento { get; set; }

        public int? Idusuario { get; set; }

        public int? idFactura { get; set; }

        public virtual Factura Factura { get; set; }

        public virtual TipoEvento TipoEvento { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}

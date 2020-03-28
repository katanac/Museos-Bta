namespace MuseosBogotaWeb.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Factura")]
    public partial class Factura
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Factura()
        {
            Detalle = new HashSet<Detalle>();
            Reservas = new HashSet<Reservas>();
        }

        [Key]
        public int IdFactura { get; set; }

        public DateTime? FechaCompra { get; set; }

        public int? idUsuario { get; set; }

        public int? idTipoPago { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detalle> Detalle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservas> Reservas { get; set; }

        public virtual TipoPago TipoPago { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}

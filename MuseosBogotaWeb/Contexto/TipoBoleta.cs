namespace MuseosBogotaWeb.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TipoBoleta")]
    public partial class TipoBoleta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TipoBoleta()
        {
            Boleta = new HashSet<Boleta>();
        }

        [Key]
        public int IdTipoBoleta { get; set; }

        [StringLength(20)]
        public string NombreTipoEvento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Boleta> Boleta { get; set; }
    }
}

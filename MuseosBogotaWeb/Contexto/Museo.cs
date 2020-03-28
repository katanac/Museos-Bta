namespace MuseosBogotaWeb.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Museo")]
    public partial class Museo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Museo()
        {
            Evento = new HashSet<Evento>();
        }

        [Key]
        public int IdMuseo { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int? Telefono { get; set; }

        [StringLength(50)]
        public string Direccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Evento> Evento { get; set; }
    }
}

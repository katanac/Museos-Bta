namespace MuseosBogotaWeb.Contexto
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Evento")]
    public partial class Evento
    {
        [Key]
        public int Idevento { get; set; }

        [StringLength(20)]
        public string NombreEvento { get; set; }

        public DateTime? Fecha { get; set; }

        public int? CantidadAsistentes { get; set; }

        public int? IdMuseo { get; set; }

        public int? IdTipo { get; set; }

        public virtual Museo Museo { get; set; }

        public virtual TipoEvento TipoEvento { get; set; }
    }
}

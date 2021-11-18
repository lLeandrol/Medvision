namespace Leandro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Citas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Citas()
        {
            MotivoDeCita = new HashSet<MotivoDeCita>();
        }

        public int ID { get; set; }

        public DateTime FechaCita { get; set; }

        public int IdPersona { get; set; }

        [Required]
        [StringLength(255)]
        public string TipoCita { get; set; }

        [Required]
        [StringLength(255)]
        public string NivelUrgencia { get; set; }

        public virtual Pacientes Pacientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MotivoDeCita> MotivoDeCita { get; set; }
    }
}

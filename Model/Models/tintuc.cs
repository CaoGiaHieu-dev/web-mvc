namespace Model.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tintuc")]
    public partial class tintuc
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(30)]
        public string img { get; set; }

        public string description { get; set; }

        public string link { get; set; }

        [Column(TypeName = "ntext")]
        public string detail { get; set; }

        public string meta { get; set; }

        public bool? hide { get; set; }

        public int? position { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? datebegin { get; set; }

        public int id_m { get; set; }

        public virtual menu menu { get; set; }
    }
}

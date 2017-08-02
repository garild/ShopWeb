namespace Shop.Web.BLL.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Book
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataMember]
        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [DataMember]
        [Column(TypeName = "date")]
        public DateTime DateRelease { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        [Required]
        [StringLength(500)]
        public string Author { get; set; }

        [DataMember]
        [Required]
        [StringLength(500)]
        public string Publisher { get; set; }

        [DataMember]
        public int? BookType_Id { get; set; }
       
        [DataMember]
        public virtual Books_D_BookType Books_D_BookType { get; set; }
    }
}

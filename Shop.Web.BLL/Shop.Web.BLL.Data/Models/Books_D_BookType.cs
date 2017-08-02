namespace Shop.Web.BLL.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;

    [Serializable]
    [DataContract]
    public partial class Books_D_BookType
    {
        [DataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataMember]
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [DataMember]
        [StringLength(500)]
        public string Description { get; set; }

        [DataMember]
        public ICollection<Book> Books { get; set; }
    }
}

namespace EntityFrameworkPerformanceTests.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Person.ContactType")]
    public partial class ContactType
    {
        public ContactType()
        {
            BusinessEntityContacts = new HashSet<BusinessEntityContact>();
        }

        public int ContactTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
    }
}

namespace EntityFrameworkPerformanceTests.CodeFirst
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.vIndividualCustomer")]
    public partial class vIndividualCustomer
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        [StringLength(8)]
        public string Title { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string Suffix { get; set; }

        [StringLength(25)]
        public string PhoneNumber { get; set; }

        [StringLength(50)]
        public string PhoneNumberType { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmailPromotion { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string AddressType { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(60)]
        public string AddressLine1 { get; set; }

        [StringLength(60)]
        public string AddressLine2 { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(30)]
        public string City { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string StateProvinceName { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(15)]
        public string PostalCode { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string CountryRegionName { get; set; }

        [Column(TypeName = "xml")]
        public string Demographics { get; set; }
    }
}

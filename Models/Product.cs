namespace MVC_Machine_Test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        internal static object GetAllRecords()
        {
            throw new NotImplementedException();
        }

        public int? CategoryId { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }        
    }
}

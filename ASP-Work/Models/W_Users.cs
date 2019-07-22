namespace ASP_Work.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class W_Users
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string NickName { get; set; }

        [StringLength(11)]
        public string PhoneNumber { get; set; }

        [StringLength(5)]
        public string flag { get; set; }
    }
}

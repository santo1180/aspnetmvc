using MvcApplication.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NewMvcApplication.Models
{
    [Table("Persons")]
    public class Person : DbEntity
    {
        [Key]
        public Int64 Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [StringLength(30, ErrorMessage = "First name cannot be longer than 30 letters")]
        [DisplayName("First Name")]
        public String FirstName { get; set; }

        public String MI { get; set; }  


        [Required]
        public String LastName { get; set; }

        public String FaceBookId { get; set; }

        [EmailAddress]
        public String Email { get; set; }

        public String TwitterId { get; set; }

        public String LinkedInId { get; set; }

        [Url]
        public string BlogUrl { get; set; }

    }
}
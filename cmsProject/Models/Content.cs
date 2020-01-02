using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cmsProject.Models
{
    public class Content
    {
        [Key]
        public int ContentId { get; set; }
        [Required]
        [DisplayName("Title")]
        public string ContentHeader { get; set; }
        [Required]
        [DisplayName("Body")]
        public string ContentBody { get; set; }
        [Required]
        public string Category { get; set; }

        [ForeignKey("Username")]
        [DisplayName("Posted By")]
        public string Username { get; set; }
        public UserAccount UserAccount { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenzPlatformApp.Data.Model
{
    [Table("tblDeployedDetails")]
    public class DeployedDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ContainerName { get; set; }

        [ForeignKey("tblUser")]
        public int UserId { get; set; }

        [Required]
        public string URL { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime UpdateDate { get; set; }

    }

}

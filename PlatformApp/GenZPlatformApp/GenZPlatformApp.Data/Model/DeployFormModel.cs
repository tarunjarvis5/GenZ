using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenZPlatformApp.Data.Model
{
    public class DeployFormModel
    {
        [Required(ErrorMessage ="Github link should not be empty")]
        public string GitHubLink { get; set; }
        [Required(ErrorMessage = "App Name should not be empty")]
        public string AppName { get; set; }
        [Required(ErrorMessage ="Custom Url should not be empty")]
        public string CustomUrl { get; set; }
    }
}

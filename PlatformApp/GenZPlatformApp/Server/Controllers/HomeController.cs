using GenZPlatformApp.Server.Data;
using Microsoft.AspNetCore.Mvc;

namespace GenZPlatformApp.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        ApplicationDBContext db;

        public HomeController(ApplicationDBContext db)
        {
            this.db = db;
        }


        [HttpGet("UserDeployedApps/{id}")]
        public ActionResult Get_UserDeployedApps(int id)
        {
            var Apps_lst = db.DeployedDetails.Where(o => o.UserId == id).ToList();

            return Ok(Apps_lst);
        }

        
    
}
}

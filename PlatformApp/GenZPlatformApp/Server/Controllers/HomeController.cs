using GenzPlatformApp.Data.Model;
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
        public List<DeployedDetails> Get_UserDeployedApps(int id)
        {
            var Apps_lst = db.DeployedDetails.Where(o => o.UserId == id).ToList();

            return Apps_lst;
        }

        [HttpGet("Users")]
        public List<User> GetUsers()
        {
            List<User> users = db.Users.ToList();   

            return users;
        }

        [HttpGet("Users/{id}")]
        public User GetUserDetails(int id)
        {
            User user = db.Users.Where(o => o.UserId == id).First();

            return user;
        }

        [HttpPost("AddUser")]
        public void PostDeployApp(User user)
        {

            db.Users.Add(user);
            db.SaveChanges();

            
        }

    }
}

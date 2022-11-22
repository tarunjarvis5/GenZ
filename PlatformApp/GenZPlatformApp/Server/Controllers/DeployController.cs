using GenzPlatformApp.Data.Model;
using GenZPlatformApp.Data.Model;
using GenZPlatformApp.Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GenZPlatformApp.Server.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class DeployController : Controller
    {
        ApplicationDBContext dB;

        public DeployController(ApplicationDBContext db)
        {
            this.dB = db;

        }


        [HttpPost("DeployApp")]
        public void PostDeployApp(DeployFormModel deployFormModel)
        {

            var url = $"http://localhost:8081/{deployFormModel.AppName}/{deployFormModel.AppName}/{deployFormModel.CustomUrl}/{deployFormModel.GitHubLink}";


            DeployedDetails deployedDetails = new DeployedDetails();

            deployedDetails.ContainerName = deployFormModel.AppName;
            deployedDetails.UserId = deployFormModel.UserId;
            deployedDetails.URL = deployFormModel.CustomUrl;
            deployedDetails.CreateDate = DateTime.Now;
            deployedDetails.UpdateDate = DateTime.Now;

            dB.DeployedDetails.Add(deployedDetails);
            dB.SaveChanges();

            var request1 = (HttpWebRequest)WebRequest.Create(url);
            request1.GetResponse();

        }



    }


}

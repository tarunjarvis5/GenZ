using SimpleHttp;
using System.Diagnostics;

namespace GenZServer
{
    class Program
    {
        //netsh http add urlacl url=http://+:8081/ user="Everyone"

        // To start listener
        static void Main(string[] args)
        {
            DeploymentManager.Deployer deployer = new DeploymentManager.Deployer();


            

            Route.Add("/{containername}/{imagename}/{customurl}/{githubLink}", (req, res, props) =>
            {
                if (req.RawUrl != "/favicon.ico")
                {

                    string githubLink = props["githubLink"];
                    string containerName = props["containername"];
                    string imageName = props["imagename"];
                    string customURL = props["customurl"];


                    DeploymentManager.Deployer deployer = new DeploymentManager.Deployer();

                    deployer.GitOperate(githubLink, containerName, imageName, customURL);


                    //res.AsText("Welcome to the Simple Http Server");

                }

            });




            HttpServer.ListenAsync(
                    8081,
                    CancellationToken.None,
                    Route.OnHttpRequestAsync
                )
                .Wait();

        }


        static public void alpha()
        {


            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();

            cmd.StandardInput.WriteLine("docker stop staticpagetest2");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());

        }

    }


}
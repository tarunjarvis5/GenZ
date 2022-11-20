




using Deploy;
using System.Diagnostics;
using YamlDotNet.RepresentationModel;

namespace DeploymentManager
{
    public class Deployer
    {

        public Deployer()
        {

        }

        /// <summary>
        /// create docker compose file for application with specified configuration 
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="imageName"></param>
        /// <param name="customURL"></param>
        /// <returns></returns>
        public string CreateDeploymentDockerComposeFile(string containerName , string imageName , string customURL )
        {

            var stream = new YamlStream(
            new YamlDocument(
            new YamlMappingNode(
                new YamlScalarNode("version"), new YamlScalarNode("\"3\""),
                new YamlScalarNode("services"), new YamlMappingNode(
                    new YamlScalarNode(containerName), new YamlMappingNode(
                        new YamlScalarNode("image") , new YamlScalarNode(imageName),
                        new YamlScalarNode("restart") , new YamlScalarNode("always"),
                        new YamlScalarNode("environment") , new YamlMappingNode(
                            new YamlScalarNode("VIRTUAL_HOST") , new YamlScalarNode(customURL + ".localhost")
                            ),
                        new YamlScalarNode("container_name") , new YamlScalarNode(containerName)
                        )
                    ) , 
                new YamlScalarNode("networks") , new YamlMappingNode(
                    new YamlScalarNode("default") , new YamlMappingNode(
                        new YamlScalarNode("external") , new YamlMappingNode(
                            new YamlScalarNode("name") , new YamlScalarNode("local-nginx-rproxy")
                            )
                        )
                    )
                )));

            stream.Save(Console.Out);

            using (TextWriter writer = File.CreateText(Constants.AppDockerComposeFolder + $"\\{containerName}" + "\\docker-compose.yaml"))
            {
                stream.Save(writer, false);
            }

            return $"D:\\Genz\\AppDockerComposeFolder\\{containerName}";

        }

        /// <summary>
        /// creates docker image and runs it
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="imageName"></param>
        /// <param name="customURL"></param>
        public void DockerOperate(string containerName, string imageName, string customURL , string codePath)
        {
            // start a cmd process
            Process cmd = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;
            cmd.StartInfo = info;
            cmd.Start();

            Directory.CreateDirectory(Constants.AppDockerComposeFolder + $"\\{containerName}");

            string ComposeFileDirectory = Constants.AppDockerComposeFolder + $"\\{containerName}";

            CreateDeploymentDockerComposeFile(containerName , imageName , customURL);

            // Run commands in cmd 
            using (StreamWriter sw = cmd.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine($"docker login");
                    sw.WriteLine($"docker build -t {imageName} {codePath}");
                    sw.WriteLine($"d:");
                    sw.WriteLine($"cd {ComposeFileDirectory}");
                    sw.WriteLine($"docker-compose up -d");
                }
            }

        }


        /// <summary>
        /// Clones the project
        /// </summary>
        /// <param name="githubLink"></param>
        public string GitOperate(string githubLink, string containerName , string imageName , string customURL)
        {
            // start a cmd process
            Process cmd = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "cmd.exe";
            info.RedirectStandardInput = true;
            info.UseShellExecute = false;
            cmd.StartInfo = info;
            cmd.Start();

            string projectFolderPath = "";

            // Get repo name to create a folder and store the code
            string repositoryName = githubLink.Substring( githubLink.LastIndexOf('/') + 1 ).Replace( ".git" , "" );

            // Run commands in cmd 
            using (StreamWriter sw = cmd.StandardInput)
            {
                if (sw.BaseStream.CanWrite)
                {
                    sw.WriteLine($"git clone {githubLink} " + $"{Constants.AppCodeFolder}\\{repositoryName}");
                    
                }
            }

            DockerOperate(containerName, imageName , customURL , $"{Constants.AppCodeFolder}\\{repositoryName}" );

            return projectFolderPath;

        }

    }

}
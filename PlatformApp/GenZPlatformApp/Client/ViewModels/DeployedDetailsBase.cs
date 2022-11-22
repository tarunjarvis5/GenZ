using GenZPlatformApp.Data.Model;
using Microsoft.AspNetCore.Components;

namespace GenZPlatformApp.Client.ViewModels
{
    public class DeployedDetailsBase : ComponentBase
    { 
        public DeployFormModel DeployFormModel { get; set; } = new();
    }
}

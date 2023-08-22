using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TerraformPluginDotNet.ResourceProvider;

namespace TerraformPluginDotNet;

public interface ITerraformPluginHostBuilder : IHostBuilder
{
    ITerraformPluginHostBuilder ConfigureResourceRegistry(Action<IServiceCollection, IResourceRegistryContext> configureDelegate);
}

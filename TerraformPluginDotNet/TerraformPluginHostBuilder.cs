using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TerraformPluginDotNet.ResourceProvider;

namespace TerraformPluginDotNet;

internal class TerraformPluginHostBuilder : ITerraformPluginHostBuilder
{
    private readonly IHostBuilder _hostBuilder;

    public TerraformPluginHostBuilder(
        IHostBuilder hostBuilder)
    {
        _hostBuilder = hostBuilder;
    }

    public IDictionary<object, object> Properties => _hostBuilder.Properties;

    public ITerraformPluginHostBuilder ConfigureResourceRegistry(Action<IServiceCollection, IResourceRegistryContext> configureDelegate)
    {
        _hostBuilder.ConfigureWebHostDefaults(webBuilder => webBuilder.ConfigureTerraformPlugin(configureDelegate));
        return this;
    }

    public IHost Build() => _hostBuilder.Build();

    public IHostBuilder ConfigureAppConfiguration(Action<HostBuilderContext, IConfigurationBuilder> configureDelegate)
        => _hostBuilder.ConfigureAppConfiguration(configureDelegate);

    public IHostBuilder ConfigureContainer<TContainerBuilder>(Action<HostBuilderContext, TContainerBuilder> configureDelegate)
        => _hostBuilder.ConfigureContainer(configureDelegate);

    public IHostBuilder ConfigureHostConfiguration(Action<IConfigurationBuilder> configureDelegate)
        => _hostBuilder.ConfigureHostConfiguration(configureDelegate);

    public IHostBuilder ConfigureServices(Action<HostBuilderContext, IServiceCollection> configureDelegate)
        => _hostBuilder.ConfigureServices(configureDelegate);

    public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(IServiceProviderFactory<TContainerBuilder> factory)
        where TContainerBuilder : notnull
        => _hostBuilder.UseServiceProviderFactory(factory);

    public IHostBuilder UseServiceProviderFactory<TContainerBuilder>(Func<HostBuilderContext, IServiceProviderFactory<TContainerBuilder>> factory)
        where TContainerBuilder : notnull
        => _hostBuilder.UseServiceProviderFactory(factory);
}

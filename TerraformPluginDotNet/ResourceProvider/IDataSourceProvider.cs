namespace TerraformPluginDotNet.ResourceProvider;

public interface IDataSourceProvider<T>
{
    Task<T> ReadAsync(T request);

    Task<T> ReadAsync(T request, TerraformContext context) => ReadAsync(request);
}

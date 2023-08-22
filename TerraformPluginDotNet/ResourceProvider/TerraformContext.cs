using Tfplugin5;

namespace TerraformPluginDotNet.ResourceProvider;

public class TerraformContext
{
    internal List<Diagnostic> Diagnostics { get; set; } = new();

    public void AddDiagnostic(Diagnostic diagnostic)
    {
        Diagnostics.Add(diagnostic);
    }
}

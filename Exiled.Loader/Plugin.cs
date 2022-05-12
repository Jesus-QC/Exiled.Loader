using System;
using System.IO;
using PluginAPI.Core;
using PluginAPI.Loader;

namespace Exiled.Loader
{
    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "Exiled.Loader";
        public override string Author { get; } = "Jesus-QC";
        public override Version Version { get; } = new Version(1, 0, 0);

        public override void OnEnabled()
        {
            string rootPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EXILED");
            
            if (!AssemblyLoader.TryGetAssembly(Path.Combine(rootPath, "Exiled.Loader.dll"), out var loader) || !AssemblyLoader.TryGetAssembly(Path.Combine(rootPath, "Plugins", "dependencies", "Exiled.API.dll"), out var api) || !AssemblyLoader.TryGetAssembly(Path.Combine(rootPath, "Plugins", "dependencies", "YamlDotNet.dll"), out var yaml))
            {
                Log.Warning("Exiled was not found. Skipping.");
                return;
            }
            
            loader.GetType("Exiled.Loader.Loader").GetMethod("Run")?.Invoke(null, new object[] { new[] {api, yaml} });

            base.OnEnabled();
        }
    }
}
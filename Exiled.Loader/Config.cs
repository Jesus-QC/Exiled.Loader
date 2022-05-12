using PluginAPI.Core.Interfaces;

namespace Exiled.Loader
{
    public class Config : IPluginConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool ShowDebugMessages { get; set; } = false;
    }
}
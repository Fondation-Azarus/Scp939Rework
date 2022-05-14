using Synapse.Api.Plugin;

namespace Scp939Rework
{
    [PluginInformation(
        Name = "Scp939Rework",
        Author = "Bonjemus",
        Description = "A plug-in that adds features to SCP-939-XX.",
        LoadPriority = 1,
        SynapseMajor = SynapseController.SynapseMajor,
        SynapseMinor = SynapseController.SynapseMinor,
        SynapsePatch = SynapseController.SynapsePatch,
        Version = "1.0.0"
        )]
    public class PluginClass : AbstractPlugin
    {
        [Config(section = "Scp939Rework")]
        public static Configs Configs;

        public override void Load()
        {
            if (!Configs.disabled)
                new EventHandler();
        }
    }
}
using Synapse.Config;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Synapse.Api.Enum;

namespace Scp939Rework
{
    public class Configs : AbstractConfigSection
    {
        [Description("Disabled ? :")]
        public bool disabled = false;

        [Description("The broadcast SCP-939-XXs receive when they spawn :")]
        public string bcMessage = "The lower your health is, the more you inflict damages, you also get helpful effects when receiving damage.";

        [Description("The duration of the broadcast (0 to disable) :")]
        public ushort bcDuration = 7;

        [Description("Start health (put a negative value if you don't want this plug-in to affect start health) :")]
        public float health = -1;

        [Description("Max health (put a negative value if you don't want this plug-in to affect max health) :")]
        public float maxHealth = -1;


        [Description("SCP-939-XXs' scale :")]
        public Vector3 scale = Vector3.one;


        [Description("What effects do SCP-939-XXs get when they spawn (duration: -1 = infinity) ? :")]
        public List<EffectConfig> spawnEffectConfigs = new List<EffectConfig>()
        {
            new EffectConfig() { effect = Effect.MovementBoost, intensity = 20, duration = 10 },
            new EffectConfig() { effect = Effect.DamageReduction, intensity = 30, duration = -1},
        };

        //[Description("The amount of health SCP-939-XX regenerates when killing (works with negative values) :")]
        //public float healthKillRegen = 20; just use BetterScp :T


        [Description("The base amount of damage SCP-939-XX's attacks deal (put a negative value if you don't want this plug-in to affect base damage) :")]
        public float damageAmount = -1;

        [Description("x value (put 0 or less to disable damage multiplier based on health) :")]
        public float xValue = 2.5f;

        [Description("The maximum distance between 2 SCP-939-XXs for them to receive extra damage :")]
        public float maxDistance = 10;

        [Description("The multiplier which affects damage if 2 SCP-939-XXs are close enough (put 1 to disable) :")]
        public float damageMultiplier = 1.1f;

        [Description("What effects do SCP-939-XXs inflict (duration: -1 = infinity) ? :")]
        public List<EffectConfig> inflictEffectConfigs = new List<EffectConfig>()
        {
            new EffectConfig() { effect = Effect.Hemorrhage, intensity = 1, duration = 5 }
        };

        [Description("The amount of stamina the victim receives (can be negative) :")]
        public float staminaBoost = 100;

        [Description("What effects do SCP-939-XXs get when they receive damage (duration: -1 = infinity) ? :")]
        public List<EffectConfig> damageEffectConfigs = new List<EffectConfig>()
        {
            new EffectConfig() { effect = Effect.MovementBoost, intensity = 30, duration = 5 }
        };

        public struct EffectConfig
        {
            public Effect effect;
            public byte intensity;
            public float duration;
        }
    }
}
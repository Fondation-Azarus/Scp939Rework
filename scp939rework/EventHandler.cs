using Synapse;
using Synapse.Api;
using Synapse.Api.Events.SynapseEventArguments;
using UnityEngine;
using System.Linq;

namespace Scp939Rework
{
    public class EventHandler
    {
        public EventHandler()
        {
            Server.Get.Events.Player.PlayerSetClassEvent += OnSetClass;
            Server.Get.Events.Player.PlayerDamageEvent += OnDamage;
        }

        private bool Is939(int roleID) => roleID == (int)RoleType.Scp93953 || roleID == (int)RoleType.Scp93989;

        private void OnSetClass(PlayerSetClassEventArgs ev)
        {
            try
            {
                MEC.Timing.CallDelayed(0.3f, () =>
                {
                    if (ev.Player == null || !Is939(ev.Player.RoleID))
                        return;

                    if (PluginClass.Configs.bcDuration > 0)
                        ev.Player.SendBroadcast(PluginClass.Configs.bcDuration, PluginClass.Configs.bcMessage);

                    if (PluginClass.Configs.maxHealth >= 0)
                        ev.Player.Health = PluginClass.Configs.maxHealth;

                    if (PluginClass.Configs.health >= 0)
                        ev.Player.Health = PluginClass.Configs.health;

                    ev.Player.Scale = PluginClass.Configs.scale;

                    if (PluginClass.Configs.spawnEffectConfigs != null)
                        foreach (Configs.EffectConfig ec in PluginClass.Configs.spawnEffectConfigs)
                            ev.Player.GiveEffect(ec.effect, ec.intensity, ec.duration);
                });
            }
            catch (System.Exception e)
            {
                Server.Get.Logger.Error(e);
            }
        }

        private void OnDamage(PlayerDamageEventArgs ev)
        {
            if (ev.Victim == null) return;

            if (ev.Killer != null && Is939(ev.Killer.RoleID)) //ev.DamageType == DamageType.Scp939) bugged
            {
                if (PluginClass.Configs.damageAmount >= 0)
                    ev.Damage = PluginClass.Configs.damageAmount;

                if (PluginClass.Configs.xValue > 0)
                    ev.Damage *= PluginClass.Configs.xValue - ev.Killer.Health / ev.Killer.MaxHealth * (PluginClass.Configs.xValue - 1);

                Player second939 = Server.Get.Players.FirstOrDefault(p => p != ev.Killer && Is939(p.RoleID));
                if (PluginClass.Configs.damageMultiplier != 1 && second939 != null)
                    if (Vector3.Distance(ev.Killer.Position, second939.Position) <= PluginClass.Configs.maxDistance)
                        ev.Damage *= PluginClass.Configs.damageMultiplier;

                foreach (Configs.EffectConfig ec in PluginClass.Configs.inflictEffectConfigs)
                    ev.Victim.GiveEffect(ec.effect, ec.intensity, ec.duration);
            }

            else if (Is939(ev.Victim.RoleID))
            {
                ev.Victim.Stamina += PluginClass.Configs.staminaBoost;
                foreach (Configs.EffectConfig ec in PluginClass.Configs.damageEffectConfigs)
                    ev.Victim.GiveEffect(ec.effect, ec.intensity, ec.duration);
            }
        }
    }
}
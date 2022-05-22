# Scp939rework
A plug-in that adds features to SCP-939-XX.

***

## Description
With this plug-in you can :
- [x] Add a broadcast on spawn.
- [x] Add effects on spawn.
- [x] Change SCP-939-XXs' health and max health. 
- [x] Adjust SCP-939-XXs' scale.
- [x] Add effects to the victim.
- [x] Add effects to SCP-939-XX when they receive damage.
- [x] Change the base damage of SCP-939-XX.
- [x] Modify the amount of damage dealt depending on SCP-939-XX's health and max health.
- [x] Adjust the victim's stamina when he receives damage.
- [x] Boost or lower SCP-939-XXs' damage depending on whether they are close enough or not.

And more...

**I strongly recommend using [Betterscp](https://github.com/SynapseSL/BetterScp) for things like regeneration as I won't add them.**

Default configs :
```
[Scp939Rework]
{
# Disabled ? :
disabled: false
# The broadcast SCP-939-XXs receive when they spawn :
bcMessage: The lower your health is, the more you inflict damages, you also get helpful effects when receiving damage.
# The duration of the broadcast (0 to disable) :
bcDuration: 7
# Start health (put a negative value if you don't want this plug-in to affect start health) :
health: -1
# Max health (put a negative value if you don't want this plug-in to affect max health) :
maxHealth: -1
# SCP-939-XXs' scale :
scale:
  x: 1
  y: 1
  z: 1
# What effects do SCP-939-XXs get when they spawn (duration: -1 = infinity) ? :
spawnEffectConfigs:
- effect: MovementBoost
  intensity: 20
  duration: 10
- effect: DamageReduction
  intensity: 30
  duration: -1
# The base amount of damage SCP-939-XX's attacks deal (put a negative value if you don't want this plug-in to affect base damage) :
damageAmount: -1
# x value (put 0 or less to disable damage multiplier based on health) :
xValue: 2.5
# The maximum distance between 2 SCP-939-XXs for them to receive extra damage :
maxDistance: 10
# The multiplier which affects damage if 2 SCP-939-XXs are close enough (put 1 to disable) :
damageMultiplier: 1.10000002
# What effects do SCP-939-XXs inflict (duration: -1 = infinity) ? :
inflictEffectConfigs:
- effect: Hemorrhage
  intensity: 1
  duration: 5
# The amount of stamina the victim receives (can be negative) :
staminaBoost: 100
# What effects do SCP-939-XXs get when they receive damage (duration: -1 = infinity) ? :
damageEffectConfigs:
- effect: MovementBoost
  intensity: 30
  duration: 5
}
```

***

## Installation
1. [Install Synapse](https://docs.synapsesl.xyz/setup/setup).
2. Place the `.dll` file that you can download [here](https://github.com/Fondation-Azarus/Scp939Rework/releases/latest) in your plug-in directory.
3. Restart/Start your server.

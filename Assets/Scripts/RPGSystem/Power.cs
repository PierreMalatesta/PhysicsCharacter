using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Power", menuName = "Power", order = 1)]
public class Power : ScriptableObject
{

    // cost to use this power
    public float energyCost;

    // how much damage it does
    public float damage;

    // TODO - an enumeration for damage types, eg Crushing, Fire, Cold, Magic...

    // TODO - visual FX
    // TODO - icon for use in HUD or levelling screens
    // TODO - description string?

    // status effects that get put on the target
    public Status[] effects;
    // status effects that get put on the caster
    public Status[] selfEffects;

    // animation names
    public enum Anim
    {
        PunchLeft,
        PunchRight,
        KickLeft,
        KickRight
    }

    // animation played for this power
    public Anim animation;

    public void Apply(PlayerStats caster, PlayerStats target)
    {
        // cant use if we dont have the mana
        if (caster.energy < energyCost)
            return;
        caster.energy -= energyCost;

        // TODO - cooldown?
        // TODO - accuracy and dodge check?
        // TODO - check range?

        // multiply damage by any buffs/debuffs we have
        float multiplier = 1.0f + caster.GetAttribute(PlayerStats.Attribute.Damage) * 0.01f;

        // apply modified damage
        target.ApplyDamage(damage * multiplier);

        // apply power effects to the target
        foreach (Status s in effects)
            target.ApplyStatus(s);

        // apply effects to the caster
        foreach (Status s in selfEffects)
            caster.ApplyStatus(s);

        // play the animation for the power
        caster.PlayAnimation(animation);

        // TODO - just play the animation, and have a Hit animation event that triggers the actual damge and so on.
        // Store a activePower in the character if you do this.

        // TODO - make some visual effects on the caster and target? beams in between maybe?

    }
}

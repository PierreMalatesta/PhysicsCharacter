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

    public float range = 5f;

    // TODO - an enumeration for damage types, eg Crushing, Fire, Cold, Magic...

    // TODO - visual FX
    // TODO - icon for use in HUD or levelling screens
    // TODO - description string?

    // status effects that get put on the target
    public Status[] effects;
    // status effects that get put on the caster
    public Status[] selfEffects;

    public Sprite icon;
    public Color color;
    public string description;

    // TODO - cooldown?
    //add a bool that is cooldown
    public  float cooldown = 0;
    private float cooldownTimer = 0;

    // if this is not null, the power spawns one of these to cary it to the target
    public Projectile projectilePrefab;

    public VisualFXSystem.VisualFX fireEffect;
    public VisualFXSystem.VisualFX impactEffect;

    public float CooldownPercent()
    {
        if (cooldown == 0)
            return 0;
        return cooldownTimer / cooldown;
    }

    public void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0)
            cooldownTimer = 0;
    }

    // animation names
    public enum Anim
    {
        PunchLeft,
        PunchRight,
        KickLeft,
        KickRight,
        Shield,
        BasePunch,
        BaseKick
    }

    // animation played for this power
    public Anim animation;

    public void Apply(PlayerStats caster, PlayerStats target)
    {
        // STARTING THE POWER OFF
        if (cooldownTimer > 0)
            return;

        // cant use if we dont have the mana
        if (caster.energy < energyCost)
            return;
        caster.energy -= energyCost;

        cooldownTimer = cooldown;

        //using enums to choose animation, this is used too select what animation each power does
        Animator animator = caster.GetComponent<Animator>();
        animator.SetTrigger(animation.ToString());

        // TODO - accuracy and dodge check?
        // TODO - check range?

        // play the animation for the power
        caster.PlayAnimation(animation);

        // if we have no animation, do this straight away
        //Activate(caster, target);


        // otherwise let Activate get triggered by an animation event
        caster.currentPower = this;
    }

    //Activating the power, spawning in the visualFx etc
    public void Activate(PlayerStats caster, PlayerStats target)
    {
        //make some visual effects on the caster and target? beams in between maybe?
        if (fireEffect != null)
        {
            fireEffect.Begin(caster.transform);
        }

        if (projectilePrefab == null)
            ApplyToTarget(caster, target);
        else
        {
            // make a projectile
            Projectile projectile = Instantiate(projectilePrefab, caster.transform.position + Vector3.up, caster.transform.rotation);

            // point it at the target
            projectile.transform.forward = target.transform.position - caster.transform.position;

            // tell the projectile who its caster and power are
            projectile.power = this;
            projectile.caster = caster;

            Physics.IgnoreCollision(projectile.GetComponent<Collider>(), caster.GetComponent<CharacterController>());
        }
    }

    public void ApplyToTarget(PlayerStats caster, PlayerStats target)
    { 
        // APPLYING THE POWER TO THE TARGET
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


        if (impactEffect != null)
        {
            impactEffect.Begin(target.transform);
        }


    }
}

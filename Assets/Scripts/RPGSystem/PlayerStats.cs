using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;

public class PlayerStats : MonoBehaviour
{
    // who we're aiming at
    // TODO - write a class that can change this by tabbing, clicking etc. (COMPLETED)
    public PlayerStats target;

    // hit points and mana
    public float health = 100;
    public float maxHealth = 100;
    public float energy = 100;
    public float maxEnergy = 100;

    // status effects currently affecting the character
    public List<Status> statusEffects;

    // these are the values that can be buffed/debuffed
    // TODO - add more: damage types, speed, jump, energy recovery, health regen
    public enum Attribute
    {
        Resistance,
        Damage
    };

    // list of named attributes that affect the character
    public Dictionary<Attribute, float> attributes = new Dictionary<Attribute, float>();

    // the powers the character can use
    public Power[] powers;

    Ragdoll ragdoll;
    TargetController targetController;

    void Start()
    {
        // add a health bar to each character
        HealthBarManager.instance.AddHealthBar(this);
        ragdoll = GetComponent<Ragdoll>();

        targetController = GetComponent<TargetController>();

    }

    public void Update()
    {
        UpdateStatus();

        // TODO make energy regen a variable? Allow it to be buffed/debuffed?
        energy = Mathf.Clamp(energy + 10 * Time.deltaTime, 0, maxEnergy);

        foreach (Power power in powers)
            power.Update();

        // passive health regen?

        OnDeath();
    }

    void UpdateStatus()
    {
        // status we will retire this frame because they expire
        List<Status> deathRow = new List<Status>();

        // update all our statusEffects, marking those which will retire
        foreach (Status s in statusEffects)
        {
            s.timer += Time.deltaTime;
            if (s.timer > s.duration)
                deathRow.Add(s);
            else
                s.UpdateStatus(this);
        }

        // clean up expired oens now we've finished iterating over list
        foreach (Status s in deathRow)
        {
            // do any special code for once it wears off
            s.RemoveStatus(this);
            // and remove from list
            statusEffects.Remove(s);
        }
    }

    // error-checking function for getting named attributes
    public float GetAttribute(Attribute a)
    {
        if (attributes.ContainsKey(a))
            return attributes[a];
        return 0;
    }

    public void ApplyDamage(float dam)
    {
        // factor in damage resistance 
        // TODO - cap damage resistance?
        // TODO - damage shields 
        dam = dam * (1.0f - 0.01f * GetAttribute(Attribute.Resistance));

        // subtract from health
        health = Mathf.Clamp(health - dam, 0, maxHealth);
    }

    // add a status to our list and call its apply function
    public Status ApplyStatus(Status s)
    {
        if (s == null)
            return null;
        Status inst = Instantiate(s);
        inst.name = s.name;
        statusEffects.Add(inst);
        inst.ApplyStatus(this);
        return inst;
    }

    public void PlayAnimation(Power.Anim anim)
    {
        // TODO - hook up to Animator

        //eg 
        // Animator animator = GetComponent<Animator>();
        // animator.Play(anim.name);
    }

    public void OnDeath()
    {
        // TODO - death - COMPLETED
        //if health is less than or equal to 0
        if (health <= 0)
        {
            //ragdoll is true, making the enemy or character ragdoll
            ragdoll.RagdollOn = true;
        }

        targetController.TargetDisable();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff", menuName = "Buff", order = 1)]
public class Buff : Status 
{

    // which attribute does this affect?
    public PlayerStats.Attribute attribute;
    // how much do we modify it (-ve or +ve)?
    public float delta;

    public override void ApplyStatus(PlayerStats ch)
    {
        base.ApplyStatus(ch);
        // do the mod to this stat
        ch.attributes[attribute] = ch.GetAttribute(attribute) + delta;
    }

    public override void UpdateStatus(PlayerStats ch) { }

    public override void RemoveStatus(PlayerStats ch)
    {
        base.RemoveStatus(ch);
        // undo the modification to this stat
        ch.attributes[attribute] = ch.GetAttribute(attribute) - delta;
    }
}

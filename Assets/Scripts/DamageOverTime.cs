using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using VisualFXSystem;

[CreateAssetMenu(fileName = "DoT", menuName = "DoT", order = 1)]
public class DamageOverTime : Status
{

    public float damagePerTick;
    public float frequency;

    // per-instance data
    public float nextTick = 0;

    public VisualFX fx;
    VisualFXInstance fxInstance;

    // do nothing
    public override void ApplyStatus(PlayerStats ch)
    {
        fxInstance = fx.Begin(ch.transform);
    }
    public override void RemoveStatus(PlayerStats ch) 
    { 
        fxInstance.Stop();

    }

    // DoT's tick down every frame
    public override void UpdateStatus(PlayerStats ch)
    {
        if (timer > nextTick)
        {
            ch.ApplyDamage(damagePerTick);
            nextTick += frequency;
        }
    }
}

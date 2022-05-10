using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using VisualFXSystem;

public abstract class Status : ScriptableObject
{
    // how long this status effect lasts
    public float duration;

    // how long its been running currently (per-instance)
    public float timer;

    // TODO visual FX  that are played by this status
    public VisualFX fx;
    VisualFXInstance fxInstance;

    // TODO icon - if we want icons on the HUD to represent them

    public virtual void ApplyStatus(PlayerStats ch)
    {
        // create the visual fx and keep a reference to it
        fxInstance = fx.Begin(ch.transform);
    }

    public abstract void UpdateStatus(PlayerStats ch);
    public virtual void RemoveStatus(PlayerStats ch)
    {
        // remove the visual fx that we have kept a reference to
        fxInstance.Stop();
    }
}

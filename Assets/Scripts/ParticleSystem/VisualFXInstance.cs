using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VisualFXSystem;

public class VisualFXInstance : MonoBehaviour
{
    float countdown;
    private ParticleSystem[] particles;
    public bool countingDown;

    public void Init(VisualFX fx, bool autoStop)
    {
        countingDown = autoStop;
        countdown = fx.duration;

        int index = 0;
        particles = GetComponentsInChildren<ParticleSystem>();
        foreach (ParticleSystem ps in particles)
        {
            ParticleSystem.MainModule main = ps.main;
            main.startColor = fx.colors[index];

            ParticleSystem.ColorOverLifetimeModule col = ps.colorOverLifetime;
            if (col.enabled)
                col.color = TintGradient(col.color, fx.colors[index]);
            index++;
            index %= fx.colors.Length;
        }
    }

    public void Update()
    {
        if (!countingDown)
            return;

        countdown -= Time.deltaTime;

        if (countdown < 0)
        {
            Destroy(gameObject);
        }
    }
    public void Stop()
    {
        Destroy(gameObject);
    }

    public bool isFinished() { return countdown <= 0; }

    public static ParticleSystem.MinMaxGradient
    TintGradient(ParticleSystem.MinMaxGradient gradient, Color color)
    {
        switch (gradient.mode)
        {
            case ParticleSystemGradientMode.Color:
                gradient.color = color;
                break;
            case ParticleSystemGradientMode.Gradient:
                {
                    Gradient g = gradient.gradient;
                    GradientColorKey[] colorKeys = g.colorKeys;
                    for (int i = 0; i < colorKeys.Length; i++)
                        colorKeys[i].color = color;
                    g.SetKeys(colorKeys, g.alphaKeys);
                    gradient.gradient = g;
                }
                break;
        }
        return gradient;
    }
}

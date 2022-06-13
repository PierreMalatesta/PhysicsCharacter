using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public static XpBar instance;

    private Slider slider;
    public float fillSpeed = 0.5f;

    //this is too check that the bar is actually moving
    private float targetProgress = 0;

    private ParticleSystem xpEffect;

    private void Awake()
    {
        //fairly certain this goes in awake because we have to call this before we call incrementProgress
        slider = gameObject.GetComponent<Slider>();
        xpEffect = GameObject.Find("Progress Bar Particles").GetComponent<ParticleSystem>();

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //IncrementProgress(0.75f);
        //TODO use a singleton for the xp bar
    }

    // Update is called once per frame
    void Update()
    {
        //this makes the slider move in game
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
            if (!xpEffect.isPlaying)
                xpEffect.Play();
        }

        else
            xpEffect.Stop();
    }

    //add progress bar
    public void IncrementProgress(float newProgress)
    {   
        targetProgress = slider.value + newProgress;
    }
}

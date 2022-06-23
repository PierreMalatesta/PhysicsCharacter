using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG;

public class XpBar : MonoBehaviour
{
    public static XpBar instance;

    public Slider slider;
    public float fillSpeed = 0.5f;

    //this is too check that the bar is actually moving
    public PlayerXp player;

    private ParticleSystem xpEffect;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        xpEffect = GameObject.Find("Progress Bar Particles").GetComponent<ParticleSystem>();

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //this makes the slider move in game
        if (slider.value < player.playerXpAmount)
        {
            slider.value += fillSpeed * Time.deltaTime;

            if (slider.value > player.playerXpAmount)
                slider.value = player.playerXpAmount;

            if (!xpEffect.isPlaying)
                xpEffect.Play();
        }


        else if (slider.value > player.playerXpAmount)
        {
            slider.value += fillSpeed * Time.deltaTime;

            if (slider.value >= slider.maxValue)
                slider.value = 0;
            
        }

        else 
            xpEffect.Stop();
    }
}

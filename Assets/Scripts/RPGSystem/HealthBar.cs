using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG
{
    public class HealthBar : MonoBehaviour
    {

        // the character this healthbar represents
        public PlayerStats ch;

        // image to scale as health bar
        public Image image;
        // image to scale as energy bar
        public Image image2;

        Rect initialRect;

        // Update is called once per frame
        void Update()
        {
            // TODO - variable character height instead of the 2 below?
            // position the meter above the character's head
            transform.position = ch.transform.position + Vector3.up * 2;
            transform.forward = Camera.main.transform.forward;

            // scale the meters (health and energy)
            // they need to be Filled type for this to work
            image.fillAmount = Mathf.Clamp01(ch.health / ch.maxHealth);
            image2.fillAmount = Mathf.Clamp01(ch.energy / ch.maxEnergy);
        }
    }
}

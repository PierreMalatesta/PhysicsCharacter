using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VisualFXSystem
{
    [CreateAssetMenu(fileName = "VisualFX", menuName = "VisualFX/VisualFX", order = 1)]
    public class VisualFX : ScriptableObject
    {
        public GameObject prefab;
        public float duration;
        private bool autoStop;
        public bool detach;
        public Color[] colors = new Color[] { Color.white };

        public VisualFXInstance Begin(Transform t)
        {
            //instantiating obj which contains dust particle effect
            GameObject obj = Instantiate(prefab, detach ? null : t);
            if (detach)
                obj.transform.position = t.position + prefab.transform.localPosition;
            else
                obj.transform.localPosition = prefab.transform.localPosition;
            VisualFXInstance instance = obj.GetComponent<VisualFXInstance>();
            if (instance == null)
                instance = obj.AddComponent<VisualFXInstance>();
            instance.Init(this, autoStop);
            return instance;
        }
    }
}


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

        public VisualFXInstance Begin(Transform t)
        {
            GameObject obj = Instantiate(prefab, t);

            VisualFXInstance instance = obj.GetComponent<VisualFXInstance>();
            if (instance == null)
                instance = obj.AddComponent<VisualFXInstance>();
            instance.Init(this, autoStop);
            return instance;
        }
    }
}


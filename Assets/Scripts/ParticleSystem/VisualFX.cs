//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//namespace VisualFXSystem
//{
//    [CreateAssetMenu(fileName = "VisualFX", menuName = "VisualFX/VisualFX", order = 1)]
//    public class VisualFX : ScriptableObject
//    {
//        public GameObject prefab;
//        public float duration;
//    }

//    public class VisualFXInstance : MonoBehaviour
//    {
//        float countdown;
//        public bool countingDown;

//        public void Init(VisualFX fx, bool autoStop)
//        {
//            countingDown = autoStop;
//            countdown = fx.duration;
//        }

//        public void Update()
//        {
//            if (!countingDown)
//                return false;

//            countdown -= Time.deltaTime;

//            if (countdown < 0)
//            {
//                GameObject.Destroy(gameObject);
//            }
//        }

//        public bool isFinished() { return countdown <= 0; }
//    }
//    public VisualFXInstance Begin(Transform t)
//    {
//        GameObject obj = Instantiate(prefab, t);

//        VisualFXInstance instance = obj.GetComponent<VisualFXInstance>();
//        if (instance == null)
//            instance = obj.AddComponent<VisualFXInstance>();
//        instance.Init(this, autoStop);
//        return instance;
//    }
//}


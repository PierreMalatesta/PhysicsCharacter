using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tweener : MonoBehaviour
{
    public AnimationCurve curve;

    float timer = 0;
    float startScale;

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < 1)
        {
            timer += Time.deltaTime;
            transform.localScale = curve.Evaluate(timer) * Vector3.one * startScale;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float life = 0f;
    public Material material;
    MeshRenderer mr;
    
    public float circle;
    public float circlePercent;
    public AnimationCurve lifeCurve;

    void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisplayLife()
    {
        float circlePercent = circle / 27f;
        life += lifeCurve.Evaluate(circlePercent);
        life -= 0.35f;
        life = Mathf.Clamp(life, 0f, 1f);
        mr.material.SetFloat("_AlphaOfLife", life);
    }
}

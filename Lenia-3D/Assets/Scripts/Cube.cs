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
        DisplayLife();
    }

    public void DisplayLife()
    {
        float circlePercent = circle / 27;
        if (circlePercent < 0.2) {
            life -= 0.1f;
        }
        else if (circlePercent >= 0.2 && circlePercent < 0.4)
        {
            life += 0.1f;
        }
        else if (circlePercent >= 0.4 && circlePercent < 0.5 )
        {
            life += 0.2f;
        }
        // else if (circlePercent >= 0.5 && circlePercent < 0.8)
        // {
        //     life -= 0.3f;
        // }
        else if (circlePercent >= 0.8)
        {
            life = 0;
        }
        life = Mathf.Clamp(life, 0, 1);
        mr.material.SetFloat("_AlphaOfLife", life);
        circle = 0;
    }
}

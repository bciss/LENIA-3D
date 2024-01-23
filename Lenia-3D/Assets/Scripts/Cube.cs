using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float life = 0f;
    public Material material;
    MeshRenderer mr;

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
        mr.material.SetFloat("_AlphaOfLife", life);
    }
}

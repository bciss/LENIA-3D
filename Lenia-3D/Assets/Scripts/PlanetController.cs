using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public Vector3 gridDimension = new Vector3(5, 5, 5);
    public Transform grille;
    public GameObject cubePrefabs;
    public float cubeDimension = 1;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        for (int x = 0; x < gridDimension.x; x++)
        {
            for (int y = 0; y < gridDimension.y; y++)
            {
                for (int z = 0; z < gridDimension.y; z++)
                {
                    // Calculate the position for each cube
                    Vector3 position = new Vector3(x * cubeDimension, y * cubeDimension, z * cubeDimension);

                    Instantiate(cubePrefabs, position, Quaternion.identity, grille);
                }
            }
        }
    }
}

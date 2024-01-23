using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public Vector3Int gridDimension = new Vector3Int(5, 5, 5);
    public Cube[][][] cubes;
    public Transform grille;
    public GameObject cubePrefabs;
    public float cubeDimension = 1;
    public float circle;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateCircle();
        UpdateLife();
    }

    public void GenerateGrid()
    {
        cubes = new Cube[gridDimension.x][][];
        for (int x = 0; x < gridDimension.x; x++)
        {
             cubes[x] = new Cube[gridDimension.y][];
            for (int y = 0; y < gridDimension.y; y++)
            {
                cubes[x][y] = new Cube[gridDimension.z];
                for (int z = 0; z < gridDimension.y; z++)
                {
                    // Calculate the position for each cube
                    Vector3 position = new Vector3(x * cubeDimension, y * cubeDimension, z * cubeDimension);

                    cubes[x][y][z] = Instantiate(cubePrefabs, position, Quaternion.identity, grille).GetComponent<Cube>();
                }
            }
        }
    }

    public void UpdateCircle()
    {
        for (int x = 0; x < gridDimension.x; x++)
        {
            for (int y = 0; y < gridDimension.y; y++)
            {
                for (int z = 0; z < gridDimension.y; z++)
                {
                    GetAdjacentCubes(new Vector3Int(x, y, z));
                }
            }
        }
    }

    public void UpdateLife()
    {
        for (int x = 0; x < gridDimension.x; x++)
        {
            for (int y = 0; y < gridDimension.y; y++)
            {
                for (int z = 0; z < gridDimension.y; z++)
                {
                    cubes[x][y][z].DisplayLife();
                }
            }
        }
    }
    void GetAdjacentCubes(Vector3Int targetPosition)
    {
        int startX = Mathf.Max(0, Mathf.FloorToInt(targetPosition.x) - 1);
        int startY = Mathf.Max(0, Mathf.FloorToInt(targetPosition.y) - 1);
        int startZ = Mathf.Max(0, Mathf.FloorToInt(targetPosition.z) - 1);

        int endX = Mathf.Min(gridDimension.x - 1, Mathf.CeilToInt(targetPosition.x) + 1);
        int endY = Mathf.Min(gridDimension.y - 1, Mathf.CeilToInt(targetPosition.y) + 1);
        int endZ = Mathf.Min(gridDimension.z - 1, Mathf.CeilToInt(targetPosition.z) + 1);

        for (int x = startX; x <= endX; x++)
        {
            for (int y = startY; y <= endY; y++)
            {
                for (int z = startZ; z <= endZ; z++)
                {
                    if (x != targetPosition.x || y != targetPosition.y || z != targetPosition.z)
                    {
                        // Do something with the adjacent cube at position (x, y, z)
                        Cube adjacentCube = cubes[x][y][z];
                        if (adjacentCube != null)
                        {
                            // You can perform operations on the adjacent cube here
                            cubes[targetPosition.x][targetPosition.y][targetPosition.z].circle += adjacentCube.life;
                        }
                    }
                }
            }
        }
    }
}

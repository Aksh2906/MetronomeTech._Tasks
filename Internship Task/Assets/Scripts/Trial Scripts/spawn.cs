using UnityEngine;
using System.Collections.Generic;

public class spawn : MonoBehaviour
{
    public GameObject spherePrefab;
    public int numberOfSpheres;
    public float minDistance;
    public GameObject[] enemies;
    
    void Start()
    {
        
        GenerateSpheres();
    }
    
    void GenerateSpheres()
    {
        List<Vector3> positions = new List<Vector3>();
        for (int i = 0; i < numberOfSpheres; i++)
        {
            Vector3 position = GenerateRandomPosition();
            while (IsOverlapping(position, positions))
            {
                position = GenerateRandomPosition();
            }
            positions.Add(position);
            GameObject police = Instantiate(spherePrefab, position, Quaternion.identity);
            police.transform.parent = gameObject.transform;
            enemies[i] = police;

        }
    }
    
    Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(-10.5f, 9f);
        float y = 1f;
        float z = Random.Range(-6f, 12f);
        return new Vector3(x, y, z);
    }
    
    bool IsOverlapping(Vector3 position, List<Vector3> positions)
    {
        foreach (Vector3 pos in positions)
        {
            if (Vector3.Distance(position, pos) < minDistance)
            {
                return true;
            }
        }
        return false;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.R))
        {
            foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
            GenerateSpheres();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenrator : MonoBehaviour
{
    public GameObject spherePrefab;
    public int numSpheres = 10;
    public float sphereRadius = 0.8f;
    public float gapDistance = 1.5f;
    public GameObject[] enemies;
    
private void Start () 
{
    GenerateSpheres();    
}

    void GenerateSpheres()
    {
        Vector3 position = Vector3.zero;
        float sphereDiameter = sphereRadius * 2;
        float totalDistance = (sphereDiameter + gapDistance) * numSpheres;
        
        for (int i = 0; i < numSpheres; i++)
        {
            position.x = Random.Range(-totalDistance / 2f, totalDistance / 2f);
            position.y = 1f;
            position.z = Random.Range(-totalDistance / 2f, totalDistance / 2f);
            
            Collider[] colliders = Physics.OverlapSphere(position, sphereRadius);
            
            if (colliders.Length == 0)
            {
                GameObject sphere = Instantiate(spherePrefab, position, Quaternion.identity);
                sphere.transform.parent = transform;
                // playerController enemies[i] = sphere;
                enemies[i] = sphere;
            }
            else
            {
                i--;
            }
        }
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


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trial : MonoBehaviour
{
    public GameObject objectForSpawn;
    private List<SpawnObject> spawnObjectList;
    public int objectCount = 5;
    private double a,b;
    private float Distance;


        void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                //delete the object and create new
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
                CreateCollections();
                Generate(objectCount);
            }
        }
 
        private void Start()
        {
            CreateCollections();
            Generate(objectCount);
        }
        void CreateCollections()
        {
            spawnObjectList = new List<SpawnObject>();
        }
        void Generate(int objectCount)
        {
            CreateObjects();
            void CreateObjects()
            {
                for (int i = 0; i < objectCount; i++)
                {
                    Vector3 objectPosition = GetPosition();
                    SpawnObject sO = new SpawnObject(objectPosition);
                    spawnObjectList.Add(sO);
                }
            }    
            SpawnGameObjects();
            // void SpawnGameObjects()
            // {
           
            //     List<SpawnObject> spawnedObjects = new List<SpawnObject>();
            //     List<SpawnObject> notSpawnedObjects = new List<SpawnObject>();
 
            //     foreach (SpawnObject item in spawnObjectList)
            //     {
            //         Vector3 spawnPosition = GetPosition();
            //         if (System.Math.Round(item.objectPosition.x,3) != a && System.Math.Round(item.objectPosition.z,3) != b )
            //         {
            //             GameObject police = Instantiate(objectForSpawn, spawnPosition, transform.rotation);
            //             police.transform.parent = gameObject.transform;
            //             spawnedObjects.Add(item);
            //         }
            //         else
            //         {
            //             notSpawnedObjects.Add(item);
            //         }
            //     }
            //     Debug.Log("Object spawned :" + spawnedObjects.Count);
            //     Debug.Log("Object notSpawned :" + notSpawnedObjects.Count);
            // }

            void SpawnGameObjects()
            {
           
                List<SpawnObject> spawnedObjects = new List<SpawnObject>();
                List<SpawnObject> notSpawnedObjects = new List<SpawnObject>();
 
                foreach (SpawnObject item in spawnObjectList)
                {
                    Vector3 spawnPosition = GetPosition();
                    Distance = Vector3.Distance(item.objectPosition,item.objectPosition);
                    if (Mathf.Round(Distance)>=0.6  )
                    {
                        // GameObject police = Instantiate(objectForSpawn, spawnPosition, transform.rotation);
                        // police.transform.parent = gameObject.transform;
                        // spawnedObjects.Add(item);
                        notSpawnedObjects.Add(item);
                    }
                    else
                    {
                        GameObject police = Instantiate(objectForSpawn, spawnPosition, transform.rotation);
                        police.transform.parent = gameObject.transform;
                        spawnedObjects.Add(item);
                        // notSpawnedObjects.Add(item);
                    }
                }
                Debug.Log("Object spawned :" + spawnedObjects.Count);
                Debug.Log("Object notSpawned :" + notSpawnedObjects.Count);
            }
        }
        Vector3 GetPosition()
        {
            Vector3 randmPosition;
            randmPosition.x = Random.Range(-10.5f, 9f);
            randmPosition.y = 1f;
            randmPosition.z = Random.Range(-6f, 12f);
            this.a = System.Math.Round(randmPosition.x,3);
            this.b = System.Math.Round(randmPosition.z,3);
            return randmPosition;
        }
    }
    public class SpawnObject
    {
        public Vector3 objectPosition;
        public SpawnObject(Vector3 objectPosition)
        {
            this.objectPosition = objectPosition;
        }
 

    
}

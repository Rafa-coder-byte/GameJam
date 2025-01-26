using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector2 areaMin;
    public Vector2 areaMax;
 // Distancia para eliminar objetos

    public int numberOfObjects;
    public float deleteDistance = 0.3f; // Distancia para eliminar objetos
    public List<Vector2> spawnedPositions = new List<Vector2>();
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private Transform playerTransform;
    public int destroyed_garbage = 0;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        numberOfObjects = 50;
        SpawnObjects();
    }

    void Update()
    {
        CheckDistanceToPlayer();
        Check_Garbage_Counter();
    }

    public void SpawnObjects()
    {
        
        for (int i = 0; i < numberOfObjects; i++)
        {
            float randomX = Random.Range(areaMin.x, areaMax.x);
            float randomY = Random.Range(areaMin.y, areaMax.y);
            Vector2 randomPosition = new Vector2(randomX, randomY);
            spawnedPositions.Add(randomPosition);

            GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
            spawnedObjects.Add(spawnedObject);
        }
    }
    void Check_Garbage_Counter(){
        if(destroyed_garbage == numberOfObjects){
            Application.Quit();
        }
    }

    void CheckDistanceToPlayer()
    {
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i] != null)
            {
                float distance = Vector2.Distance(spawnedObjects[i].transform.position, playerTransform.position);
                if (distance < deleteDistance)
                {
                    Destroy(spawnedObjects[i]);
                    destroyed_garbage += 1;
                    Debug.Log(destroyed_garbage);
                    spawnedObjects.RemoveAt(i);
                    spawnedPositions.RemoveAt(i);
                }
            }
        }
    }

    public List<Vector2> GetSpawnedPositions()
    {
        return spawnedPositions;
    }
}



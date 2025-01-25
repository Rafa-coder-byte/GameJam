using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // El objeto que deseas colocar
    public Vector2 areaMin; // Coordenadas mínimas del área
    public Vector2 areaMax; // Coordenadas máximas del área
    public int numberOfObjects = 4; // Cantidad de objetos a generar

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            // Generar una posición aleatoria dentro del área definida
            float randomX = Random.Range(areaMin.x, areaMax.x);
            float randomY = Random.Range(areaMin.y, areaMax.y);
            Vector2 randomPosition = new Vector2(randomX, randomY);

            // Instanciar el objeto en la posición aleatoria
            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }
}


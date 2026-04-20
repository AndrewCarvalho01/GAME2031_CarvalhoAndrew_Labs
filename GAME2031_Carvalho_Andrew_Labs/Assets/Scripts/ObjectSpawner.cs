using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private GameObject fallingObjectPrefab;
    [SerializeField] private float ySpawnPosition;
    [SerializeField] private Vector2 xSpawnRange;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float enemySpawnChance = 0.3f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnFallingObject());
    }   

    private IEnumerator SpawnFallingObject()
    {
        while (true)
        {
            bool spawnEnemy = Random.value < enemySpawnChance;
            GameObject prefabToSpawn = spawnEnemy ? enemyPrefab : fallingObjectPrefab;
            GameObject go = Instantiate(prefabToSpawn, GetSpawnPosition(), Quaternion.identity);

            if (spawnEnemy)
                go.GetComponent<EnemyObject>();
            else
                go.GetComponent<FallingObject>().Initialize();

            yield return new WaitForSeconds(1.0f);
        }
    }

    private Vector3 GetSpawnPosition()
    {
        return new Vector3(Random.Range(xSpawnRange.x, xSpawnRange.y), ySpawnPosition, 0.0f);
    }
}

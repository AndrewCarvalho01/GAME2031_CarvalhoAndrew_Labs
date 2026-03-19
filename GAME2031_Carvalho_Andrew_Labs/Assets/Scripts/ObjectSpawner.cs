using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    [SerializeField] private GameObject fallingObjectPrefab;
    [SerializeField] private float ySpawnPosition;
    [SerializeField] private Vector2 xSpawnRange;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnFallingObject());
    }   

    private IEnumerator SpawnFallingObject()
    {
        while (true)
        {
            GameObject go = Instantiate(fallingObjectPrefab, GetSpawnPosition(), Quaternion.identity);
            go.GetComponent<FallingObject>().Initialize();

            yield return new WaitForSeconds(1.0f);
        }
    }

    private Vector3 GetSpawnPosition()
    {


        return new Vector3(Random.Range(xSpawnRange.x, xSpawnRange.y), ySpawnPosition, 0.0f);
    }
}

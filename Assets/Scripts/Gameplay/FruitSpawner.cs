using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FruitSpawner : MonoBehaviour
{
    // Cached reference to this GameObject's Transform component
    private Transform _transform;

    [Header("Fruit Settings")]
    [Tooltip("List of fruit prefabs that can be randomly spawned.")]
    [SerializeField] private List<GameObject> fruitPrefabs;
    [Header("Spawn Timing")]
    [Tooltip("Shortest possible delay between fruit spawns, in seconds.")]
    [Range(0.1f, 3f)] [SerializeField] private float minSpawnInterval = 0.6f;
    [Tooltip("Longest possible delay between fruit spawns, in seconds.")]
    [Range(0.1f, 3f)] [SerializeField] private float maxSpawnInterval = 1.4f;
    [Header("Spawn Area")]
    [Tooltip("Fruit spawns at a random X between -spawnRangeX and +spawnRangeX.")]
    [SerializeField] private float spawnRangeX = 6f;
    [Tooltip("Fruit spawns at a specific Y Position spawnPosY.")]
    [SerializeField] private float spawnPosY = 10f;

    private Coroutine spawnRoutine;

    void Awake() 
    {
        _transform = transform; 
    }

    void OnEnable()
    {
        spawnRoutine = StartCoroutine(SpawnLoop());
    }

    void OnDisable()
    {
        if (spawnRoutine != null) StopCoroutine(spawnRoutine);
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            if (GameManager.Instance != null &&
                GameManager.Instance.CurrentState == GameState.Playing)
            {
                SpawnFruit();
            }

            float wait = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(wait);
        }
    }

    void SpawnFruit()
    {
        float x = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPos = _transform.position + new Vector3(x, spawnPosY, 0);
        int randomIndex = Random.Range(0, fruitPrefabs.Count);
        GameObject fruit = Instantiate(fruitPrefabs[randomIndex], spawnPos, fruitPrefabs[randomIndex].transform.rotation);
        fruit.name = "Fruit_" + Time.frameCount; // unique, sortable, easy to spot in Hierarchy while debugging        
    }
}
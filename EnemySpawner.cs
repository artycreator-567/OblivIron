using Unity.Mathematics;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    public Transform[] spawnPoints;   // drag your 10 empty GameObjects here
    [SerializeField]
    public GameObject enemyPrefab;    // drag your enemy prefab here
    [SerializeField]
    public Transform tank;            // drag your tank here

    public float spawnInterval = 3.5f;  // seconds between spawns
    private float timer = 0f;
    private void FixedUpdate()
    {
        spawnInterval = UnityEngine.Random.Range(1.0f, 3.5f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // Pick a random spawn point
        int index = UnityEngine.Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[index];

        // Create a clone at that position
        GameObject enemyClone = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Tell the clone who to chase
        EnemyAI ai = enemyClone.GetComponent<EnemyAI>();
        ai.target = tank;
    }
}

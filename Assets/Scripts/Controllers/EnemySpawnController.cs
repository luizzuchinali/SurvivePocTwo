using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public EnemyController[] controllers;
    public float spawnRate = 2.0f;

    private float _nextSpawnTime;

    private void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            SpawnEnemy();
            _nextSpawnTime = Time.time + spawnRate;
        }
    }

    private void SpawnEnemy()
    {
        //TODO: use object pool if we have performance problems
        var random = new System.Random();
        var index = random.Next(1, controllers.Length) - 1;
        Instantiate(controllers[index], transform.position, Quaternion.identity);
    }
}
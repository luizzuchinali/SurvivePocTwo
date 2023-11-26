using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public EnemyController[] controllers;
    public float spawnRate = 2.0f;
    public GameObject portalEffectPrefab;

    private float _nextSpawnTime;

    private void Update()
    {
        if (Time.time > _nextSpawnTime)
        {
            StartCoroutine(SpawnEnemy());
            _nextSpawnTime = Time.time + spawnRate;
        }
    }


    private IEnumerator SpawnEnemy()
    {
        var transformPosition = transform.position;
        yield return new WaitForSeconds(spawnRate / 2);
        var portalInstance = Instantiate(portalEffectPrefab, transformPosition + Vector3.up, Quaternion.identity);
        Destroy(portalInstance, spawnRate / 2);

        //TODO: use object pool if we have performance problems
        var random = new System.Random();
        var index = random.Next(1, controllers.Length) - 1;
        var instance = Instantiate(controllers[index], transformPosition, Quaternion.identity);
        SceneEnemies.AddEnemy(instance.GetInstanceID(), instance.transform);
    }
}
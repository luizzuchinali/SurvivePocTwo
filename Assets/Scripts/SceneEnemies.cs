using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class SceneEnemies
{
    private static readonly ConcurrentDictionary<int, Transform> Enemies = new();

    public static void AddEnemy(int id, Transform enemy)
    {
        Enemies.TryAdd(id, enemy);
    }

    public static void DestroyEnemy(int id)
    {
        if (Enemies.TryRemove(id, out var enemy))
        {
            Object.Destroy(enemy.gameObject);
        }
    }

    public static IEnumerable<Transform> GetAllEnemies()
    {
        return Enemies.Values;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPoolObject enemyPool;
    public Transform player;
    public float minSpawnDistance = 10f;

    private void Start()
    {
        // Создаем врагов из пула при запуске
        
    }

    public void SpawnEnemies(Vector3 position)
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject enemy = enemyPool.GetObjectFromPool();
            enemy.transform.position = position;
            //enemy.transform.position = GetRandomSpawnPosition();
        }
    }

    /*private Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomPosition = Vector3.zero;
        bool validPosition = false;

        while (!validPosition)
        {
            randomPosition = new Vector3(Random.Range(-20f, 20f), 1f, Random.Range(-20f, 20f));
            float distance = Vector3.Distance(randomPosition, player.position);

            if (distance >= minSpawnDistance)
            {
                validPosition = true;
            }
        }

        return randomPosition;
    }*/
}

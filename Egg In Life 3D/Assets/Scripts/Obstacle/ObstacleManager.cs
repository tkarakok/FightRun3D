using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : Singleton<ObstacleManager>
{
    public Transform spawnPoint;
    public Transform obstacleParent;

    [System.Serializable]
    public struct Obstacle
    {
        public Queue<GameObject> obstacleQueue;
        public GameObject obstaclePrefab;
        public int objectSize;
    }

    [SerializeField] Obstacle[] obstaclesPool;

    private void Awake()
    {
        for (int i = 0; i < obstaclesPool.Length; i++)
        {

            obstaclesPool[i].obstacleQueue = new Queue<GameObject>();

            for (int j = 0; j < obstaclesPool[i].objectSize; j++)
            {
                GameObject obstacle = Instantiate(obstaclesPool[i].obstaclePrefab, obstacleParent);
                obstacle.SetActive(false);
                obstaclesPool[i].obstacleQueue.Enqueue(obstacle);
            }
        }
    }

    

    public GameObject GetObstacle(int value)
    {
        if (value >= obstaclesPool.Length)
        {
            return null;
        }

        GameObject obstacle = obstaclesPool[value].obstacleQueue.Dequeue();

        obstacle.SetActive(true);

        obstaclesPool[value].obstacleQueue.Enqueue(obstacle);
        return obstacle;
    }

    public void StartSpawnObstacle()
    {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle()
    {
        bool spawn = true;
        while (spawn)
        {
            for (int i = 0; i < GameManager.Instance.TotalObstacleInRaund; i++)
            {
                var obstacle = GetObstacle(Random.Range(0,obstaclesPool.Length));
                obstacle.transform.position = spawnPoint.position;
                yield return new WaitForSeconds(GameManager.Instance.SpawnTime);
            }
            spawn = false;
        }
    }

}

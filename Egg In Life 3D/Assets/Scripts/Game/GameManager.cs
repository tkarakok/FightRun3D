using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameSettings gameSettings;

    private float _spawnTime;
    private int _totalObstacleInRaund;

    public float SpawnTime { get => _spawnTime; set => _spawnTime = value; }
    public int TotalObstacleInRaund { get => _totalObstacleInRaund; set => _totalObstacleInRaund = value; }


    private void Start()
    {
        SpawnTime = gameSettings.spawnTime;
        TotalObstacleInRaund = gameSettings.totalObstacleInRaund;
    }
}

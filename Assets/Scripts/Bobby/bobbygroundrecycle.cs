using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobbygroundrecycle : MonoBehaviour
{
    public CoinSpawner coinSpawner;
    public ObstacleSpawner obstacleSpawner;
    public Transform player;      

    public playermovement playerSript;
    
    public float groundLength = 20f; 
    

    void Update()
    {
       
        if (transform.position.z + groundLength < player.position.z)
        {
            RecycleGround();
        }
    }

    void RecycleGround()
    {
        Vector3 moveAmount = Vector3.forward * groundLength * 3f;
        transform.position += moveAmount;

        int PlayerLane = GetplayerLane();

        obstacleSpawner.SpawnObstacle(PlayerLane);
        coinSpawner.SpawnCoinLine(obstacleSpawner.obstacleSpawnlanes);
    }

    int GetplayerLane()
    {
        if(playerSript.targetX>0) return 2;
        if(playerSript.targetX<0) return 0;
        return 1;

    }
}

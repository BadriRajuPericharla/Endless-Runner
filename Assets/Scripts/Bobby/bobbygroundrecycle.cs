using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobbygroundrecycle : MonoBehaviour
{
    public ObstacleSpawner obstacleSpawner;
    public Transform player;      
    
    public float groundLength = 20f; 
    

    void Update()
    {
        // If ground is behind the player
        if (transform.position.z + groundLength < player.position.z)
        {
            RecycleGround();
        }
    }

    void RecycleGround()
    {
        Vector3 moveAmount = Vector3.forward * groundLength * 2f;
        transform.position += moveAmount;
        obstacleSpawner.SpawnObstacle();
    }

}

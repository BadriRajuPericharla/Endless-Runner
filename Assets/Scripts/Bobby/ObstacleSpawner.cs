using System.Collections.Generic;
using UnityEngine;
public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform[] lanes;   
    public float spawnZ = 10f;  
    public float spawnY = 0.5f; 
        
    public Transform ObstacleSpawnPoint;

    // public int obstacleSpawnlane ;

    public List<int> obstacleSpawnlanes = new List<int>() ;
    public void SpawnObstacle(int playerLine)
    {
        obstacleSpawnlanes.Clear();
        
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Obstacle"))
                Destroy(child.gameObject);
        }


        int PlayerlaneIndex = playerLine+1;
        PlayerlaneIndex = Mathf.Clamp(PlayerlaneIndex, 0, lanes.Length - 1);

        obstacleSpawnlanes.Add(PlayerlaneIndex);  


        List<int> otherLanes = new List<int>{0,1,2};

        otherLanes.Remove(PlayerlaneIndex); 

        int secondLane = otherLanes[Random.Range(0,otherLanes.Count)];
        obstacleSpawnlanes.Add(secondLane);


        foreach (int laneIndex in obstacleSpawnlanes)
        {
            Vector3 spawnPos = new Vector3(
            lanes[laneIndex].position.x,             
            spawnY,                                  
            ObstacleSpawnPoint.position.z + spawnZ    
            );
       
            GameObject obs = Instantiate(
            obstaclePrefab,
            spawnPos,
            Quaternion.identity
            );

            obs.transform.SetParent(transform);

        }
    }
}

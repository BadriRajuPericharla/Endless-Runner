using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform[] lanes;   
    
    public Player player;
    public float spawnZ = 10f;  
    public float spawnY = 0.5f; 
        

    public void SpawnObstacle()
    {
        
        
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Obstacle"))
                Destroy(child.gameObject);
        }

        
        
        int laneIndex = Random.Range(0, lanes.Length);

       
        GameObject obs = Instantiate(obstaclePrefab, transform);

       
        obs.transform.localPosition = new Vector3(lanes[laneIndex].localPosition.x, spawnY,spawnZ);
    }
}

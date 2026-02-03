using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRecycle : MonoBehaviour
{
  public Transform player;
  public GameObject groundPrefab;

  public int poolSize = 5;          // Always 5 chunks
  public float chunkLength = 20f;   // Length of one chunk

  private List<GameObject> groundPool = new List<GameObject>();
  private float spawnZ = 0f;

  void Start()
  {
    // Spawn initial pool of 5 chunks
    for (int i = 0; i < poolSize; i++)
    {
      SpawnChunk();
    }
  }

  void Update()
  {
    RecycleChunks();
  }

  // ✅ Spawn a chunk from prefab
  void SpawnChunk()
  {
    GameObject chunk = Instantiate(groundPrefab);
    chunk.transform.position = new Vector3(0, 0, spawnZ);

    groundPool.Add(chunk);

    spawnZ += chunkLength;
  }

  // ✅ Recycle the oldest chunk
  void RecycleChunks()
  {
    // If player moved beyond first chunk
    if (player.position.z - groundPool[0].transform.position.z > chunkLength)
    {
      GameObject oldChunk = groundPool[0];
      groundPool.RemoveAt(0);

      // Move chunk to front
      oldChunk.transform.position = new Vector3(0, 0, spawnZ);

      groundPool.Add(oldChunk);

      spawnZ += chunkLength;
    }
  }
}


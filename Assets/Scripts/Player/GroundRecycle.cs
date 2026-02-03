using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChunkQueue : MonoBehaviour
{
  public Transform player;
  public float chunkLength = 20f;

  // Drag your 5 chunks here in Inspector (0,1,2,3,4)
  public List<Transform> chunks = new List<Transform>();

  private Queue<Transform> chunkQueue = new Queue<Transform>();

  private float nextSpawnZ;

  void Start()
  {
    // Put chunks into queue in correct order
    foreach (Transform chunk in chunks)
    {
      chunkQueue.Enqueue(chunk);
    }

    // Set nextSpawnZ after last chunk
    nextSpawnZ = chunks[chunks.Count - 1].position.z + chunkLength;
  }

  void Update()
  {
    RecycleChunks();
  }

  void RecycleChunks()
  {
    Transform firstChunk = chunkQueue.Peek();

    // If player passed the first chunk completely
    if (player.position.z > firstChunk.position.z + chunkLength)
    {
      // Remove first chunk from queue
      Transform oldChunk = chunkQueue.Dequeue();

      // Move it to the end
      oldChunk.position = new Vector3(
          oldChunk.position.x,
          oldChunk.position.y,
          nextSpawnZ
      );

      // Update next spawn position
      nextSpawnZ += chunkLength;

      // Add chunk back to queue end
      chunkQueue.Enqueue(oldChunk);
    }
  }
}



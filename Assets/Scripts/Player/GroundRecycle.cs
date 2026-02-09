using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRecycle : MonoBehaviour
{

  public Transform player;
  public List<Transform> chunks;
  public float chunkLength = 10f;

  public Vector3[] initialChunkPositions;

  private Queue<Transform> chunkQueue;

  void Start()
  {

    chunkQueue = new Queue<Transform>();

    foreach (Transform chunk in chunks)
    {
      chunkQueue.Enqueue(chunk);
    }
  }

  void Update()
  {
    Transform firstChunk = chunkQueue.Peek();
    if (player.position.z > firstChunk.position.z + chunkLength)
    {
      RecycleChunk();
    }
  }

  void RecycleChunk()
  {
    Transform oldChunk = chunkQueue.Dequeue();

    Transform lastChunk = null;
    foreach (Transform chunk in chunkQueue)
    {
      lastChunk = chunk;
    }


    oldChunk.position = new Vector3(
        oldChunk.position.x,
        oldChunk.position.y,
        lastChunk.position.z + chunkLength
    );

    chunkQueue.Enqueue(oldChunk);
  }

  public void ResetGround()
    {
        chunkQueue.Clear();

        for (int i = 0; i < chunks.Count; i++)
        {
            chunks[i].position = initialChunkPositions[i];
            chunkQueue.Enqueue(chunks[i]);
        }
    }
}




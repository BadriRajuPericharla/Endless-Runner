using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinMagnet : MonoBehaviour
{
    public float speed = 10f;
    public float collectDistance=0.2f;
    Transform Cube;
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MagnetArea"))
        {
            Cube = other.transform.parent;
            transform.position = Vector3.MoveTowards(transform.position,Cube.position,speed * Time.deltaTime);
            if (Vector3.Distance(transform.position,Cube.position) < collectDistance)
            {
                Destroy(gameObject);
            }
        }
        
    }
}

  
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSpawner : MonoBehaviour
{
   public GameObject SuperRun;
   public GameObject Magnet;
   public Transform player;
   public float SpawnInterval=15f;
   float timer;
   bool Power=true;
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer> SpawnInterval)
        {
            SuperPowerInterval();
            timer=0f;
        }
    
    }
    void SuperPowerInterval()
    {
        Vector3 spawnpos=player.position +new Vector3(0,0,30f);
        if (Power)
        {
            Instantiate(SuperRun,spawnpos,Quaternion.identity);
            Power=false;
        }
        else
        {
            Instantiate(Magnet,spawnpos,Quaternion.identity);
            Power=true;
        }
    }
}

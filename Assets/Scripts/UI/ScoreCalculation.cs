using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreCalculation : MonoBehaviour
{
     public TextMeshProUGUI Coins;
     public TextMeshProUGUI Score;
     int coinsCollected=0;
    float timer=0;
    int timeUpdated;
    void Start()
    {
       
    }

    
    void Update()
    {
         timer+=Time.deltaTime;
         timeUpdated=(int)timer;
         Score.text=timeUpdated.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coinsCollected++;
            Coins.text=coinsCollected.ToString();
    
        }
    }

}

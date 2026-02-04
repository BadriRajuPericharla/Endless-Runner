using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    [SerializeField]GameObject LevelsPannel;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void Beginner()
    {
        PlayerPrefs.SetInt("Level",0);
        LevelsPannel.SetActive(false);
    }
    public void Intermediate()
    {
        PlayerPrefs.SetInt("Level",1);
        LevelsPannel.SetActive(false);
    }
    public void Difficult()
    {
        PlayerPrefs.SetInt("Level",2);
        LevelsPannel.SetActive(false);
    }
}

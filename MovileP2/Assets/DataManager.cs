using Assets.scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviourSingleton<DataManager>
{
    private int gold;

    private int maxTime;

    private bool[] unlocked = new bool[6];

    [SerializeField]private Material material;




    public int MaxTime
    {
        get => maxTime; set
        {
            if (value>maxTime)
            {
            maxTime = value; }  
        }
    } 
    public bool[] Unlocked { get => unlocked; set => unlocked = value; }
    public Material Material { get => material; set => material = value; }

    public int Gold { get => gold; set { gold = value; } }  


    private void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        if (PlayerPrefs.GetInt("maxTime") <= maxTime)
            PlayerPrefs.SetInt("maxTime", maxTime);
        PlayerPrefs.SetInt("gold", gold);
        for (int i = 0; i < unlocked.Length; i++)
        {
            bool v = unlocked[i];
            if (v==true)
            
                PlayerPrefs.SetInt("Unlocked" + i, 1);
            
            else
            
                PlayerPrefs.SetInt("Unlocked" + i, 0);
            
            
        }
        
    }
    public void LoadData()
    {
        gold = PlayerPrefs.GetInt("gold");
        maxTime = PlayerPrefs.GetInt("maxTime", maxTime);
        for (int i = 0; i < unlocked.Length; i++)
        {
            bool v = unlocked[i];
            if (v == true)
            
                PlayerPrefs.GetInt("Unlocked" + i, 1);
            
            else
            
                PlayerPrefs.GetInt("Unlocked" + i, 0);
            

        }
    }
}

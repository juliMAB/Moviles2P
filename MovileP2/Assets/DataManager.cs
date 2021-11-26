using Assets.scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviourSingleton<DataManager>
{
    private int gold;

    private float maxTime;

    private bool[] unlocked = new bool[6];

    [SerializeField]private Material material;




    public float MaxTime
    {
        get => maxTime; set
        {
            if (value>maxTime)
            {
            maxTime = value; OnMaxTimeChange.Invoke(); }  
        }
    } 
    public bool[] Unlocked { get => unlocked; set => unlocked = value; }
    public Material Material { get => material; set => material = value; }

    public Action<int> OnGoldChange;
    public Action OnMaxTimeChange;
    public int Gold { get => gold; set { gold = value; OnGoldChange.Invoke(value); } }  


    private void Start()
    {
        LoadData();
    }

    void SaveData()
    {
        if (PlayerPrefs.GetFloat("maxTime") <= maxTime)
            PlayerPrefs.SetFloat("maxTime", maxTime);
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
    void LoadData()
    {
        PlayerPrefs.GetInt("gold", gold);
        PlayerPrefs.GetFloat("maxTime", maxTime);
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

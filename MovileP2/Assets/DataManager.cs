using Assets.scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviourSingleton<DataManager>
{
    private int gold;

    private float maxTime;

    public int Gold { get => gold; set { gold = value; OnGoldChange.Invoke(); } }
    public float MaxTime { get => maxTime; set => maxTime = value;  }
    
    public Action OnGoldChange;

    private void Start()
    {
        LoadData();
    }

    void SaveData()
    {
        if (PlayerPrefs.GetFloat("maxTime") <= maxTime)
            PlayerPrefs.SetFloat("maxTime", maxTime);
        PlayerPrefs.SetInt("gold", gold);
    }
    void LoadData()
    {
        PlayerPrefs.GetInt("gold", gold);
        PlayerPrefs.GetFloat("maxTime", maxTime);
    }
}

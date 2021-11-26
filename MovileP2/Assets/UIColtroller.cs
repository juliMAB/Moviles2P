using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIColtroller : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gold;
    [SerializeField] TextMeshProUGUI maxTime;
    private void Start()
    {
        UpdateGold(DataManager.Get().Gold);
        if (maxTime!=null)
        {
        UpdateMaxTime(DataManager.Get().MaxTime);

        }
    }
    public void UpdateGold(int a)
    {
        gold.text = a.ToString();
    }
    public void UpdateMaxTime(int b)
    {
        maxTime.text = b.ToString();
    }
}

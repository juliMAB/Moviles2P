using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class timerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI t_Time;

    float t_TimeColor = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameplayManager.Get().GameTime>0)
        {
            float b = GameplayManager.Get().GameTime;
            int a = (int)b;
            t_Time.text = a.ToString();
            t_Time.text += ":";
            b = ((b - a) * 100);
            a = (int)b;
            if (a < 10)
            {
                t_Time.text += "0";
            }
            t_Time.text += a.ToString() + ":";
            b = ((b - a) * 100);
            a = (int)b;
            if (a < 10)
            {
                t_Time.text += "0";
            }
            t_Time.text += a.ToString();
            if (GameplayManager.Get().GameTime<10)
            {
                changeColor();
            }
        }
    }
    void changeColor()
    {
        t_TimeColor -= t_TimeColor;
        if (t_TimeColor > 0)
            return;
        if (t_Time.color == Color.red)
        {
            t_Time.color = Color.black;
        }
        else
        {
            t_Time.color = Color.red;
        }
        t_TimeColor = 1;
    }
}

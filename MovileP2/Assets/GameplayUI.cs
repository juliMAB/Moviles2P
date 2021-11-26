using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimerUi;

    public void UpdateTimer(int Time)
    {
        TimerUi.text = "Time"+ BuildTime(Time);
    }
    string BuildTime(int Time)
    {
        if (Time < 60)
            return Time.ToString();
        else
        {
            int minutes=0;
            while (Time>60)
            {
                Time -= 60;
                minutes++;
            }
            return minutes.ToString() + " : " + Time.ToString();
        }
    }
}

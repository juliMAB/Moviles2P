using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private Gyroscope gyro;
    private Gyro gyro2;
    private Quaternion rotation;
    private bool gyroActive;

    public void TestGiro()
    {

        Text eso = GetComponent<Text>();
        Debug.Log(SystemInfo.supportsGyroscope);
        eso.text = SystemInfo.supportsGyroscope.ToString();
        if (SystemInfo.supportsGyroscope)
        {
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }
}

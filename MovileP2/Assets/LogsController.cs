using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LogsController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI logs;

    private void Start()
    {
        logs.text = JLogger.ReadFile();
    }
}

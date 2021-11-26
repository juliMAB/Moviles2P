using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UI_Asistans : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI messageText;
    [SerializeField] float speed;
    [SerializeField] string[] message;
    private textWriterSingle textWriterSingle;
    public Action<int> OnIndexChange;
    public int MaxMessage;
    private int index;

    private void Awake()
    {
        OnIndexChange += OnButton;
        MaxMessage = message.Length;
    }

    public void OnButton(int index)
    {
        if (textWriterSingle != null && textWriterSingle.IsActive())
        {
            textWriterSingle.WriteAllAndDestroy();
        }
        else
        {
            if (index < message.Length)
            {
                string mesage = message[index];
                textWriterSingle = textWriter.AddWriter_Static(messageText, mesage, speed, true, true, xd);
            }
        }
    }

    private void xd()
    {
    
    }

}

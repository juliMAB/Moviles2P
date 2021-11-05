using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Asistans : MonoBehaviour
{
    [SerializeField] Text messageText;
    [SerializeField] float speed;
    [SerializeField] string[] message;
    private textWriterSingle textWriterSingle;
    [SerializeField] CodeMonkey.Utils.Button_UI button_UI;
    public Action<int> onIndexChange;

    private int index;

    private void Start()
    {
        button_UI.ClickFunc = () =>
        {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                index++;
                if (index<message.Length)
                {
                    string mesage = message[index];
                    textWriterSingle = textWriter.AddWriter_Static(messageText, mesage, speed, true, true, xd);
                }
            }
        };
    }

    private void xd()
    {
        onIndexChange(index);
    }

}

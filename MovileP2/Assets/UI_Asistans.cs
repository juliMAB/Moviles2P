using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Asistans : textWriter
{
    //[SerializeField] textWriter textWriter;
    [SerializeField] Text messageText;

    private void Start()
    {
        //messageText.text = "Hello World!";
        AddWriter(messageText, "Hello World!", 1f, true);
    }
}

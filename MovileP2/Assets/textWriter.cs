using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class textWriter : MonoBehaviour
{
    private textWriterSingle textWriterSingle;
    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        textWriterSingle = new textWriterSingle(uiText,textToWrite,timePerCharacter,invisibleCharacters);
    }
    private void Update()
    {
        if (textWriterSingle != null)
        {
            textWriterSingle.update();
        }
    }
}
public class textWriterSingle
{
    private Text uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    private bool invisibleCharacters;

    public textWriterSingle(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }
    public void AddWriter(Text uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }
    public void update()
    {
        if (uiText != null)
        {
            timer -= Time.deltaTime;
            while (timer<=0f)
            {
                timer = timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
                }
                uiText.text = text;
                if (characterIndex >= textToWrite.Length)
                {
                    uiText = null;
                    return;
                }
            }
        }
    }
}

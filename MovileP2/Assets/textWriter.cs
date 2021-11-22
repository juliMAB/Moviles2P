using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class textWriter : MonoBehaviour
{
    private static textWriter instance;

    private List<textWriterSingle> textWriterSingleList;

    private void Awake()
    {
        instance = this;
        textWriterSingleList = new List<textWriterSingle>();
    }
    public static textWriterSingle AddWriter_Static(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters,bool removeBeforeAdder,Action onComplete){
        if (removeBeforeAdder)
            instance.RemoveWriter(uiText);
        return instance.AddWriter(uiText, textToWrite, timePerCharacter, invisibleCharacters,onComplete);
    }
    private textWriterSingle AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters,Action onComplete){
        textWriterSingle textWriterSingle = new textWriterSingle(uiText, textToWrite, timePerCharacter, invisibleCharacters,onComplete);
        textWriterSingleList.Add(textWriterSingle);
        return textWriterSingle;
    }

    public static void RemoveWriter_Static(TextMeshProUGUI uiText)
    {
        instance.RemoveWriter(uiText);
    }
    private void RemoveWriter(TextMeshProUGUI uiText)
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            if (textWriterSingleList[i].GetUiText() == uiText)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }
    private void Update()
    {
        for (int i = 0; i < textWriterSingleList.Count; i++)
        {
            bool destroyInstance = textWriterSingleList[i].update();
            if (destroyInstance)
            {
                textWriterSingleList.RemoveAt(i);
                i--;
            }
        }
    }
}
public class textWriterSingle
{
    private TextMeshProUGUI uiText;
    private string textToWrite;
    private int characterIndex;
    private float timePerCharacter;
    private float timer;
    private bool invisibleCharacters;
    private Action onComplete;

    public textWriterSingle(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters,Action onComplete)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        this.onComplete = onComplete;
        characterIndex = 0;
    }
    public void AddWriter(TextMeshProUGUI uiText, string textToWrite, float timePerCharacter, bool invisibleCharacters)
    {
        this.uiText = uiText;
        this.textToWrite = textToWrite;
        this.timePerCharacter = timePerCharacter;
        this.invisibleCharacters = invisibleCharacters;
        characterIndex = 0;
    }
    public bool update()
    {
        timer -= Time.deltaTime;
        while (timer <= 0f)
        {
            timer += timePerCharacter;
            characterIndex++;
            string text = textToWrite.Substring(0, characterIndex);
            if (invisibleCharacters)
            {
                text += "<color=#00000000>" + textToWrite.Substring(characterIndex) + "</color>";
            }
            uiText.text = text;
            if (characterIndex >= textToWrite.Length)
            {
                if (onComplete != null) onComplete();
                return true;
            }
        }
        return false;
    }
    public TextMeshProUGUI GetUiText()
    {
        return uiText;
    }
    public bool IsActive()
    {
        return characterIndex < textToWrite.Length;
    }
    public void WriteAllAndDestroy()
    {
        uiText.text = textToWrite;
        characterIndex = textToWrite.Length;
        if (onComplete != null) onComplete();
        textWriter.RemoveWriter_Static(uiText);
    }
}

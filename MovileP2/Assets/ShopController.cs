using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] Material showMaterial;
    [SerializeField] Color[] color = new Color[6];
    [SerializeField] int[] price = new int[6];
    [SerializeField] GameObject Alert;
    [SerializeField] TextMeshProUGUI BuyButton;
    [SerializeField] TextMeshProUGUI priceText;
    //Price: 10;
    int index =0;

    public void Next()
    {
        index++;
        if (index >= color.Length)
            index = 0;
        showMaterial.color = color[index];
        priceText.text = "Price: " + price[index];
        UpdateLetter();
    }
    public void Previous()
    {
        index--;
        if (index<0)
            index = price.Length-1;
        showMaterial.color = color[index];
        priceText.text = "Price: " + price[index];
        UpdateLetter();
    }
    public void Buy()
    {
        Alert.SetActive(true);
        if (DataManager.Get().Unlocked[index] == true)
        {
            Alert.GetComponent<TextMeshProUGUI>().text = "Equiped";
            DataManager.Get().Material = showMaterial;
            JLogger.SendLog("equipaste el color: " + showMaterial.color.ToString());

        }
        else if (DataManager.Get().Gold>=price[index])
        {
            DataManager.Get().Gold -= price[index];
            DataManager.Get().Unlocked[index]=true;
            Alert.GetComponent<TextMeshProUGUI>().text = "Buy!!";
            JLogger.SendLog("realizaste una compra");
        }
        else
        {
            Alert.GetComponent<TextMeshProUGUI>().text = "No Money!!";
            JLogger.SendLog("no tienes dinero para esta compra");
        }
        Alert.GetComponent<Animator>().Play("a");
        Invoke(nameof(AlertDisabled), 2);
        UpdateLetter();
    }
    void AlertDisabled()
    {
        Alert.SetActive(false);
    }
    void UpdateLetter()
    {
        if (DataManager.Get().Unlocked[index] == true)
        {
            BuyButton.text = "E";
            priceText.text = " ";
        }
        else
        {
            BuyButton.text = "B";
        }
        
    }
}

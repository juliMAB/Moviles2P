using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public static System.Action OnEndGame;



    public void ReloadScene()
    {
        SceneController.goToGame();
    }
    public void GoToMenu()
    {
        SceneController.goToMenu();
    }
}

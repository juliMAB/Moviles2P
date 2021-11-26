using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndManager : MonoBehaviour
{
    public static System.Action OnEndGame;

    [SerializeField] SceneController sc;


    public void ReloadScene()
    {
        sc.goToGame();
    }
    public void GoToMenu()
    {
        sc.goToMenu();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static void goToGame() { SceneManager.LoadScene("Game"); }

    public static void goToMenu() { SceneManager.LoadScene("Menu"); }
}

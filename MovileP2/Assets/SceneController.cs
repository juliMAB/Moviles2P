using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void goToGame() { SceneManager.LoadScene("Game"); }

    public void goToMenu() { SceneManager.LoadScene("Menu"); }
}

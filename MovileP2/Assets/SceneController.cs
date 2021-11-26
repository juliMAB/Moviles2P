using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void goToGame() { JLogger.SendLog("Cambiar a escena game"); SceneManager.LoadScene("Game"); }

    public void goToMenu() { JLogger.SendLog("Cambiar a escena Menu"); SceneManager.LoadScene("MainScene"); }
}

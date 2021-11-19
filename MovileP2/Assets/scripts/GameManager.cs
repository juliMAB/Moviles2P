using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    bool tutorial = true;
    public bool Tutorial { get => tutorial; set => tutorial = value; }

}

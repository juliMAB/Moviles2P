using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToDestroy : MonoBehaviour
{
    [SerializeField] GameObject ball;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            EndManager.OnEndGame.Invoke();
        }
    }
}

using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    [SerializeField] GameObject target;

    public System.Action OnGetMoney;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entre" + other.gameObject);
        if (target == other.gameObject)
        {
            GameplayManager.oro++;
            OnGetMoney?.Invoke();
        }
    }
}

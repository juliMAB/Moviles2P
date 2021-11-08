using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDesactive : MonoBehaviour
{
    [SerializeField] float initial_time= 5f;

    float time = 0f;

    private void Start()
    {
        time = initial_time;
    }

    private void Update()
    {
        time -= Time.deltaTime;
        if (time<0)
        {
            time = initial_time;
            gameObject.SetActive(false);
        }
    }
}

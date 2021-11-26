using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowestToEnd : MonoBehaviour
{
    [SerializeField] GameObject target;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.magnitude > 4 && target.transform.position.y>gameObject.transform.position.y)
        {
            EndManager.OnEndGame.Invoke();
        }
    }
}

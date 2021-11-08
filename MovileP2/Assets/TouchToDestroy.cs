using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToDestroy : MonoBehaviour
{
    LayerMask layersToDesty;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == layersToDesty)
        {
            collision.gameObject.SetActive(false);
        }
    }
}

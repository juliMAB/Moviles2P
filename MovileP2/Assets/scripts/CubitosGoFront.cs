using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubitosGoFront : MonoBehaviour
{

    [SerializeField] List<Rigidbody> cubitos= null;
    [SerializeField] float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in cubitos)
        {
            item.AddForce(Vector3.left* speed, ForceMode.Impulse);
        }
    }
}

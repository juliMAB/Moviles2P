using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    [SerializeField] float speedRot;

    [SerializeField]
    private float smoothInputSpeed = .2f;

    private Vector3 currentInputVector;

    private Vector3 smoothInputVelocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 input = -Input.acceleration;
        currentInputVector = Vector3.SmoothDamp(currentInputVector, input, ref smoothInputVelocity, smoothInputSpeed);
        Vector3 move = new Vector3(currentInputVector.x, 0, 0);
        transform.rotation = Quaternion.Euler(move * Time.deltaTime * speedRot);
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    public bool isFlat = true;
    private Rigidbody rb;
    public bool test;
    public Vector3 v3;
    [SerializeField]
    private float smoothInputSpeed = .2f;
    private Vector3 currentInput;
    private Vector3 smoothInputVel;
    public enum CHANGER
    {
        MOVE,
        ROTE
    }
    public CHANGER changer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 tilt = Input.acceleration;
        Debug.DrawRay(transform.position, transform.up, Color.cyan);
        switch (changer)
        {
            case CHANGER.MOVE:
                if (isFlat)
                    tilt = Quaternion.Euler(90, 0, 90) * tilt;

                rb.AddForce(-tilt.x, tilt.y, tilt.z);
                Debug.Log("aceleration: " + tilt);
                break;
            case CHANGER.ROTE:
                tilt *= 45;
                currentInput = Vector3.SmoothDamp(currentInput, tilt, ref smoothInputVel, smoothInputSpeed); 
                //if (isFlat)
                    //tilt = Vector3.forward*90 + tilt;
                
                
                Debug.Log("input: " + Input.acceleration);
                if (test)
                {
                    transform.rotation = Quaternion.Euler(v3);
                }
                else
                {
                    rb.rotation = Quaternion.Lerp(Quaternion.Euler(-currentInput.x, 0, 0), transform.rotation, 0.1f);
                    //rb.AddTorque(new Vector3(-tilt.x, 0, 0), ForceMode.Force);
                    //transform.rotation = Quaternion.Lerp(Quaternion.Euler(-tilt.x, 0, 0), transform.rotation, 0.1f);
                    Debug.DrawRay(transform.position + Vector3.up, tilt, Color.cyan);
                }
                break;
            default:
                break;
        }
        
    }
    
}

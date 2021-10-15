using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    Rigidbody2D rg2d;
    [SerializeField] float m_speed;
    private void Start()
    {
        rg2d = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        rg2d.AddForce(Vector2.up);
    }
}

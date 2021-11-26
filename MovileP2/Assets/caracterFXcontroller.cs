using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracterFXcontroller : MonoBehaviour
{
    [SerializeField] GameObject LRspawnPoint = null;

    [SerializeField] GameObject RRspawnPoint = null;

    [SerializeField] GameObject cubitosConteiner;
    [SerializeField] GameObject meteoritosConteiner;
    [SerializeField] float speed = 1f;
    [SerializeField] private Animator animator;
    private Rigidbody[] rb_Cubitos;
    private Rigidbody[] rb_Meteoritos;

    const int hitAmount = 3;
    private void Awake()
    {
        rb_Cubitos = cubitosConteiner.GetComponentsInChildren<Rigidbody>();
        rb_Meteoritos = meteoritosConteiner.GetComponentsInChildren<Rigidbody>();
        animator = GetComponent<Animator>();
        Debug.Log(rb_Cubitos.Length);
        for (int i = 0; i < rb_Cubitos.Length; i++)
        {
            rb_Cubitos[i].gameObject.SetActive(false);
        }
    }

    void Spawn_AtackL()
    {
        int errorCounter=0;
        GameObject go = null;
        while (go == null)
        {
            int index = Random.Range(0, rb_Cubitos.Length);
            go = rb_Cubitos[index].gameObject;
            if (go.activeSelf)
            {
                go = null;
            }
            else
            {
                go.SetActive(true);
                go.transform.position = LRspawnPoint.transform.position;
                rb_Cubitos[index].velocity = Vector3.zero;
                rb_Cubitos[index].AddForce(Vector3.left * speed, ForceMode.Impulse);
                return;
            }
                errorCounter++;
            if (errorCounter> rb_Cubitos.Length)
            {
                Debug.Log("no hay cubitos para tirar.");
                return;
            }
        }
    }
    void Spawn_AtackR()
    {
        int errorCounter = 0;
        GameObject go = null;  
        while (go==null)
        {
            int index = Random.Range(0, rb_Cubitos.Length-1);
            
            go = rb_Cubitos[index].gameObject;
            if (go.activeSelf)
            {
                go = null;
            }
            else
            {
                go.SetActive(true);
                go.transform.position = RRspawnPoint.transform.position;
                rb_Cubitos[index].velocity = Vector3.zero;
                rb_Cubitos[index].AddForce(Vector3.left * speed, ForceMode.Impulse);
                return;
            }
            if (errorCounter > rb_Cubitos.Length)
            {
                Debug.Log("no hay cubitos para tirar.");
                return;
            }
        }
    }
    void Spawn_Meteorito()
    {
        GameObject go = null;
        while (go == null)
        {
            int index = Random.Range(0, rb_Meteoritos.Length-1);
            go = rb_Meteoritos[index].gameObject;
            if (go.activeSelf)
            {
                go = null;
            }
            else
            {
                go.SetActive(true);
                go.transform.position = go.transform.parent.transform.position;
                return;
            }
        }
    }
    public void RhitAtack()
    {
        animator.Play("RightHit");
    }
    public void LhitAtack()
    {
        animator.Play("LeftHit");
    }
    public void RandomHit()
    {
        int a = Random.Range(0, hitAmount);
        switch (a)
        {
            case 0:
                animator.Play("RightHit");
                break;
            case 1:
                animator.Play("LeftHit");
                break;
            case 2:
                animator.Play("MiddleDownHit");
                break;
            default:
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caracterFXcontroller : MonoBehaviour
{
    [SerializeField] GameObject LRspawnPoint;

    [SerializeField] GameObject RRspawnPoint;

    [SerializeField] List<GameObject> pool= new List<GameObject>();

    [SerializeField] List<Rigidbody> rigidbodies = new List<Rigidbody>();

    [SerializeField] float speed = 1f;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        for (int i = 0; i < pool.Count; i++)
        {
            rigidbodies.Add(pool[i].GetComponent<Rigidbody>());
        }
    }

    void Spawn_AtackL()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeSelf)
            {
                pool[i].SetActive(true);
                pool[i].transform.position = LRspawnPoint.transform.position;
                rigidbodies[i].AddForce(Vector3.left * speed, ForceMode.Impulse);
                return;
            }
        }
    }
    public void Rhit()
    {
        animator.Play("RightHit");
    }
}

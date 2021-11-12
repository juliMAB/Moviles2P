using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteroid : MonoBehaviour
{

    [SerializeField] LayerMask colLayer;
    [SerializeField] GameObject myGiz;

    [SerializeField] GameObject target;

    Rigidbody rg;
    Ray ray1;

    private void Awake()
    {
        rg = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        ray1 = new Ray(transform.position, target.transform.position-transform.position);
        rg.AddForce(target.transform.position - transform.position, ForceMode.Impulse);

    }
    private void Update()
    {
        RaycastHit raycastHit;
        Physics.Raycast(ray1,out raycastHit,1000,colLayer);
        myGiz.transform.position = raycastHit.point;
    }

}

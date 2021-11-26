using Assets.scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteroid : MonoBehaviour
{

    [SerializeField] LayerMask colLayer;

    [SerializeField] GameObject myGiz;

    [SerializeField] GameObject target;

    [SerializeField] float shootPower;

    [SerializeField] float power;

    [SerializeField] float radius;

    Vector3 v3;
    Ray ray1;



    public void CallStart()
    {
        ray1 = new Ray(transform.position, target.transform.position - transform.position);
        myGiz.GetComponent<MeshRenderer>().enabled = true;
        RaycastHit raycastHit;
        Physics.Raycast(ray1, out raycastHit, 1000, colLayer);
        myGiz.transform.position = raycastHit.point;
       // v3 = transform.position - (transform.position - myGiz.transform.position);
    }

    private void Update()
    {
        RaycastHit raycastHit;
        Physics.Raycast(ray1,out raycastHit,1000,colLayer);
        myGiz.transform.position = raycastHit.point;
        transform.position = transform.position - (transform.position - myGiz.transform.position) * Time.deltaTime * shootPower;
        if (Vector3.Distance (transform.position, myGiz.transform.position)<3)
        {
            Collider[] colliders = Physics.OverlapSphere(myGiz.transform.position, radius);
            foreach (Collider item in colliders)
            {
                if (item.gameObject == target)
                {
                    item.GetComponent<Rigidbody>().AddExplosionForce(power, myGiz.transform.position, radius);
                }
            }
            myGiz.GetComponent<MeshRenderer>().enabled = false;
            gameObject.SetActive(false);
        }
    }

}

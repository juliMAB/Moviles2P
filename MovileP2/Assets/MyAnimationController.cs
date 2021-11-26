using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimationController : MonoBehaviour
{
    public void callAnimation(string a, bool b)
    {
        GetComponent<Animator>().Play(a);
    }
    public void callAnimation(string a)
    {
        GetComponent<Animator>().Play(a);
    }
}

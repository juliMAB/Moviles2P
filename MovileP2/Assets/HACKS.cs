using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HACKS : MonoBehaviour
{
    public void AddExtraMoney()
    {
        DataManager.Get().Gold += int.MaxValue;
    }
}

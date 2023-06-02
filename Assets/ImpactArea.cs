using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactArea : MonoBehaviour
{
    private bool makesDamage;
    private bool isDetecting;

    public void GetMakesDamage()
    {
        return makesDamage;
    }

    public void SetMakesDamage(bool newmakesDamage)
    {
        makesDamage = newmakesDamage;
    }
}

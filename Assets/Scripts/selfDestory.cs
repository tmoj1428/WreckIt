using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestory : MonoBehaviour
{
    public void onAnimEnd()
    {
        Destroy(gameObject);
    }
}

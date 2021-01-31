using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomperDamage : MonoBehaviour
{

    public GameObject Parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(Parent);
    }
}

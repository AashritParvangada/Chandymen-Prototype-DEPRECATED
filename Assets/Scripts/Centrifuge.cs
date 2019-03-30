using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Centrifuge : MonoBehaviour
{
public int chargeNeeded;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlasmaBullet>().bulletCharge >=chargeNeeded)
        {

			transform.localScale=transform.localScale*10;
        }
    }
}

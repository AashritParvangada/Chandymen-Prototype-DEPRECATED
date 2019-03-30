using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflector : MonoBehaviour {

private void OnTriggerEnter(Collider other) {
	if(other.gameObject.GetComponent<PlasmaBullet>())
	{
		other.gameObject.GetComponent<PlasmaBullet>().bulletCharge++;
		Debug.Log(other.gameObject.GetComponent<PlasmaBullet>().bulletCharge);
	}
}

}

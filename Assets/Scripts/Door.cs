using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton1)) //Was 1 PS4 Windows
            {
				Debug.Log("Trying to load scene");
				SceneManager.LoadScene(1);
            }
        }
    }

}

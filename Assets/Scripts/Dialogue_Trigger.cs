using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_Trigger : MonoBehaviour {

public DialogueGroup dialogue;
bool triggered = false;
public void TriggerDialogue()
{
	if(!triggered)
	FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

	else
	{
		FindObjectOfType<DialogueManager>().DisplayNextSentence();
	}
}

	private void OnTriggerStay(Collider other) {
		if(other.gameObject.tag=="Player")
		{
			if(Input.GetKeyDown(KeyCode.JoystickButton1)) //Was 1
			{
				TriggerDialogue();
				triggered=true;
			}
		}
	}

}

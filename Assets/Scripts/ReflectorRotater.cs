using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectorRotater : MonoBehaviour
{

    Transform reflectorTransform;
    bool openToRotate = true;
    [SerializeField] bool isHorizontal;
    [SerializeField] float f_Time;
    private void Start()
    {
        reflectorTransform = GetComponentInParent<Reflector>().transform;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton1)) //Was 1
            {
                RotateReflector();
            }
        }
    }

    void RotateReflector()
    {
        if (openToRotate)
        {
            MakeHorizontalOrVertical();
            StartCoroutine(CloseToRotateForTime(f_Time));
        }
    }

    void MakeHorizontalOrVertical()
    {
        if (isHorizontal)
        {
            Vector3 verticalTransform = new Vector3(0, 0, 0);
            reflectorTransform.eulerAngles = verticalTransform;
            isHorizontal = false;
        }

        else if (!isHorizontal)
        {
            Vector3 horizontalTransform = new Vector3(0, 90, 0);
            reflectorTransform.eulerAngles = Vector3.Lerp(reflectorTransform.eulerAngles, horizontalTransform, f_Time);
            isHorizontal = true;
        }
    }

    IEnumerator CloseToRotateForTime(float time)
    {
        openToRotate = false;
        yield return new WaitForSeconds(time);
        openToRotate = true;
    }
}

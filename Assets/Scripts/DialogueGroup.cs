using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueGroup
{
    public string name;

    [TextArea(1, 3)]
    public string[] sentences;

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VirtualKeyboard : MonoBehaviour
{
      public Text virtualKeyboardText;
   // public TextMeshPro virtualKeyboardText;

    private string virtualKeyboardInput;

      
    void Update()
    {
        virtualKeyboardText.text = virtualKeyboardInput;
    }

    public void alphabetPressed(string s)
    {
        Debug.Log("Button Pressed");
        virtualKeyboardInput += s;
        Debug.Log(s);
    }
}

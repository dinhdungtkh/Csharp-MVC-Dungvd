using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update

   
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI buttonText;
    void Start()
    {
        textMeshProUGUI.text = "Hello I am a Intern Dev";
    }

    // Update is called once per frame
   public void buttonPress(){
    buttonText.text = "Button Pressed";
    Debug.Log("Button Pressed");
   }
}

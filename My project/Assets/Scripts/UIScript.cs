using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
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
    public void buttonPress()
    {
        buttonText.text = "Button Pressed";
        Debug.Log("Button Pressed");
    }

    public void buttonPress2(Button button)
    {
        buttonText.text = button.name;
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        Debug.Log("====================");
        Debug.Log(button.name);
    }

    public void buttonPress3(Button button)
    {
        Application.OpenURL("https://www.google.com");
    }
}

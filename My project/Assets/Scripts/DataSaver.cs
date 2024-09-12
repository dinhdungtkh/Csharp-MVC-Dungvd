using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("Name", "MOJOJOJOJOJOJOMOMOMO");
        PlayerPrefs.SetString("ID", "001");
        PlayerPrefs.SetInt("Level", 10);
        PlayerPrefs.SetFloat("Volume", 0.5f);
        Debug.Log("Data saved");
    }


}

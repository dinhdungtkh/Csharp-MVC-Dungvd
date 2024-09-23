using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    private Object gameController;
    [SerializeField]
    private GameObject Star;
    public Sprite GoldStar;

    void Start()
    {
        gameController = FindAnyObjectByType<GameControllerClone>();
        AudioManager.PlaySound(Soundnames.VICTORY);
        StartCoroutine("ShowStar");
    }
  
  
   
    IEnumerator ShowStar()
    {
        
        yield return new WaitForSeconds(2f);
        foreach (Transform child in Star.transform)
        {
                Image image = child.GetComponent<Image>(); 
                if (image != null)
                {
                    image.sprite = GoldStar;
                }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level01");
    }


}

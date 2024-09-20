using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CylinderController : MonoBehaviour
{
  public float numberOfGift = 8;
    public float timeRotate;
    public float numberCircleRotate;

    private const float CIRCLE = 360f;
    private float angleOfOneGift;


    public Transform parrent;
    private float currentTime;

    public AnimationCurve curve;

    public GameObject m_RewardPanel;

    public TMP_Text m_RewardFinalText;
    private void Start()
    {
        angleOfOneGift = CIRCLE / numberOfGift;

        SetPositionData();
    }
    private void SetPositionData()
    {
        for (int i = 0; i < parrent.childCount; i++)
        {
            parrent.GetChild(i).eulerAngles = new Vector3(0,-CIRCLE / numberOfGift * i,0);
            parrent.GetChild(i).GetChild(0).GetComponent<TextMeshPro>().text = (i + 1).ToString();
        }
    }

    IEnumerator RotateWheel(){
        float startAngle = transform.eulerAngles.z;
        currentTime = 0;
        int IndexGiftRandom = (int)Random.Range(0, numberOfGift);
       //Debug.Log("" + IndexGiftRandom);
        //UIManager.Instance.textMeshProUGUI.text = " Current Random Index " +  IndexGiftRandom.ToString();
        m_RewardFinalText.text = "Number" + IndexGiftRandom.ToString();
        float angleWant = (numberCircleRotate * CIRCLE) + angleOfOneGift * IndexGiftRandom - startAngle;
        while (currentTime < timeRotate) {
          yield return new WaitForEndOfFrame();
          currentTime += Time.deltaTime;
          float angleCurrent = angleWant * curve.Evaluate(currentTime/timeRotate);
          this.transform.eulerAngles = new Vector3(0, angleCurrent + startAngle,0);
        }
        StartCoroutine(ShowRewardMenu(1));
    }

    IEnumerator ShowRewardMenu(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (true)
        {
            m_RewardPanel.gameObject.SetActive(true);
           // m_RewardFinalText.text = UIManager.Instance.textMeshProUGUI.text;
            yield return new WaitForSeconds(2);
        }

        yield return new WaitForSeconds(.1f);
        Reset();
    }

    public void Reset()
    {
        m_RewardPanel.gameObject.SetActive(false);
    }

    [ContextMenu("Rotate")]
    public void RotateMenu(){
        StartCoroutine(RotateWheel());
    }
    
}

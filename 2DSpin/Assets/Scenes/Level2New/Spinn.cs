using System.Collections;
using TMPro;
using UnityEngine;


public class Spinn : MonoBehaviour
{
    public float numberOfGift = 11;
    public float timeRotate;
    public float numberCircleRotate;

    private const float CIRCLE = 360f;
    private float angleOfOneGift;


    public Transform parrent;
    private float currentTime;

    public AnimationCurve curve;

    //public GameObject m_RewardPanel;

  //  public TextMeshProUGUI m_RewardFinalText;

    [Range(0,1000)]
    public float rotationSpeed = 200f;
    private void Start()
    {
        angleOfOneGift = CIRCLE / numberOfGift;

        SetPositionData();
    }
    private void SetPositionData()
    {
        for (int i = 0; i < parrent.childCount; i++)
        {
            parrent.GetChild(i).eulerAngles = new Vector3(0, 0, -CIRCLE / numberOfGift * i);
        }
    }

    IEnumerator RotateWheel()
    {
        float startAngle = transform.eulerAngles.z;
        currentTime = 0;
        int IndexGiftRandom = (int)Random.Range(0, numberOfGift);
        ///UIManager.Instance.textMeshProUGUI.text = " Current Random Index " + IndexGiftRandom.ToString();
        //m_RewardFinalText.text = "Number " + IndexGiftRandom.ToString();
        float angleWant = (numberCircleRotate * CIRCLE) + angleOfOneGift * IndexGiftRandom - startAngle;


        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;
            float t = currentTime / timeRotate;
            float angleCurrent = angleWant * curve.Evaluate(t);
            float currentRotation = Mathf.Lerp(0, angleCurrent, t * rotationSpeed);
            this.transform.eulerAngles = new Vector3(0, 0, currentRotation + startAngle);
        }
        this.transform.eulerAngles = new Vector3(0, 0, angleWant + startAngle);
       // StartCoroutine(ShowRewardMenu(1));
    }

    IEnumerator ShowRewardMenu(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (true)
        {
          //  m_RewardPanel.gameObject.SetActive(true);
           // m_RewardFinalText.text = UIManager.Instance.textMeshProUGUI.text;
            yield return new WaitForSeconds(2);
        }

        yield return new WaitForSeconds(.1f);
        Reset();
    }

    public void Reset()
    {
       // m_RewardPanel.gameObject.SetActive(false);
    }

    [ContextMenu("Rotate")]
    public void RotateMenu(){
        StartCoroutine(RotateWheel());
    }
    
}

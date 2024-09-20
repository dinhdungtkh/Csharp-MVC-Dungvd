using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinWheel : MonoBehaviour
{
    public Transform m_Spin;
    public Button spinButton;
    public float minSpinTime = 4f;
    public float maxSpinTime = 6f;

    public float initialSpinSpeed = 1000f;

    private bool isSpinning = false;
    private int targetIndex;
    private float anglePerPrize;
   
    [SerializeField]
    private float currentAngle; 


    public AudioSource m_audioSource;
    public AudioClip yaysfx;

    public enum Prize
    {
        TwentyK = 1,
        TenK,
        FiveK,
        FiveHundredK,
        Halve,
        TwoHundredK,
        Double,
        HundredK,
        ThirtyK,
        FiftyK,
        GoBack
    }

    private Prize[] prizes;

    private void Start()
    {
        prizes = (Prize[])System.Enum.GetValues(typeof(Prize));
        anglePerPrize = 360f / prizes.Length;
    }

  
    [ContextMenu("Spin2")]
    public void SpinWheelTestTwo()
    {
        if (!isSpinning)
        {
            float spinTime = Random.Range(minSpinTime, maxSpinTime);
            StartCoroutine(SpinTestTwo(spinTime));
        }
      
    }


    private float EaseOutCubic(float t)
    {
        t--;
        return t * t * t + 1;
    }


    private IEnumerator SpinTestTwo(float spinTime)
    {
        
        float elapsedTime = 0f;
        currentAngle = m_Spin.eulerAngles.z;
        while (elapsedTime < spinTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinTime;
            float easedT = EaseOutCubic(t);

            float currentSpeed = Mathf.Lerp(initialSpinSpeed, 0f, easedT);
            currentAngle += currentSpeed * Time.deltaTime;
            currentAngle %= 360;
            m_Spin.rotation = Quaternion.Euler(0f, 0f, currentAngle);
            CalculateCurrentIndex(currentAngle);
            yield return null;
        }
        m_audioSource.PlayOneShot(yaysfx, 1);
        Debug.Log("Giải thưởng: " + prizes[CalculateCurrentIndex(currentAngle)]);
    }

    private int CalculateCurrentIndex(float currentAngle)
    {
        currentAngle = currentAngle % 360;
        int index = Mathf.FloorToInt(currentAngle / anglePerPrize);
        index = index % prizes.Length;
        return index;
    }

}
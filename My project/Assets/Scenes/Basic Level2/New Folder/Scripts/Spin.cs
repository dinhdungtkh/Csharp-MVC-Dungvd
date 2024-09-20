using JSG.FortuneSpinWheel;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{

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
     
     
        public enum Prize3D
    {
        TenK = 1,
        TwentyK,
        GoBack,
        TwoHundredK,
        FiveHundredK,
        Halve,
        Double,
        HundredK,
        FiftyK,
        ThirtyK,
        FiveK
    }
    
    public Transform m_Spin;
    public Button spinButton;
    public float minSpinTime = 4f;
    public float maxSpinTime = 6f;

    private bool isSpinning = false;
    
     public float numberCircleRotate;

    public Prize3D wishedIndex;
    
    [SerializeField]
    private int targetIndex;
    private float anglePerPrize ;

    [SerializeField]
    private float currentAngle;

    public float initialSpinSpeed;

    public AudioSource m_audioSource;
    public AudioClip yaysfx;



    private Prize3D[] prizes;

    private void Start()
    {
        prizes = (Prize3D[])System.Enum.GetValues(typeof(Prize));
        anglePerPrize = 360f / prizes.Length;
     
    }


    [ContextMenu("Spin3")]
    public void SpinWheelTestThree()
    {
        if (!isSpinning)
        {
             float spinTimeRandom = Random.Range(minSpinTime, maxSpinTime);
            
            StartCoroutine(SpinTestThree(maxSpinTime));
        }

    }

    IEnumerator SpinTestThree(float spinTime)
    {
        isSpinning = true;
        float startAngle = m_Spin.eulerAngles.z;
        float elapsedTime = 0f;
        float totalRotation = numberCircleRotate * 360f;
        targetIndex = (int)wishedIndex; 
        float targetAngle = anglePerPrize * targetIndex;
        float finalAngle = totalRotation + targetAngle - anglePerPrize / 2 ;

        while (elapsedTime < spinTime)
        {
            yield return new WaitForEndOfFrame();

            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinTime;

            float easedT = EaseOutQuint(t); 
            currentAngle = Mathf.Lerp(0, finalAngle, easedT);
            currentAngle %= 360;
            m_Spin.eulerAngles = new Vector3(0, 0, startAngle + currentAngle);
        }
        m_Spin.eulerAngles = new Vector3(0, 0, startAngle + finalAngle);
        Debug.Log(startAngle + finalAngle);
        m_audioSource.PlayOneShot(yaysfx, 1);
        Debug.Log("Giải thưởng: " + prizes[CalculateCurrentIndex(startAngle + finalAngle)]);
        isSpinning = false;
    }
    private int CalculateCurrentIndex(float currentAngle)
    {
        currentAngle = currentAngle % 360;
        int index = Mathf.FloorToInt(currentAngle / anglePerPrize);
        index = index % prizes.Length;
        return index;
    }

        private float EaseOutQuint(float t)
    {
        return 1 - Mathf.Pow(1 - t, 5);
    }
     
}
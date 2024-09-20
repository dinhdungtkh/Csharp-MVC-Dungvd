using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class WheelController : MonoBehaviour
{
    public RectTransform wheel;
    public float spinDuration = 5f;
    public AnimationCurve spinCurve;
    public int segmentCount = 8;
    public TextMeshProUGUI resultText; 

    private bool isSpinning = false;
    [SerializeField]
    private int selectedSegment;

   public void Start()
    {
        resultText.gameObject.SetActive(false);
    }

   public void StartSpin()
    {
        if (!isSpinning)
        {
            selectedSegment = Random.Range(0, segmentCount);
            StartCoroutine(SpinWheel());
        }
    }

    IEnumerator SpinWheel()
    {
        isSpinning = true;
        resultText.gameObject.SetActive(false);
        
        float spinDuration = Random.Range(4f, 6f);
        float elapsedTime = 0f;
        float startRotation = wheel.rotation.eulerAngles.z;
        float targetRotation = -(selectedSegment * (360f / segmentCount));
        float totalRotation = startRotation - (360f * (Random.Range(2, 5) + Random.value)) + targetRotation;

        while (elapsedTime < spinDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinDuration;
            float curveValue = spinCurve.Evaluate(t);
            float currentRotation = Mathf.Lerp(startRotation, totalRotation, curveValue);
            wheel.rotation = Quaternion.Euler(0f, 0f, currentRotation);
            yield return null;
        }

        wheel.rotation = Quaternion.Euler(0f, 0f, totalRotation);
        isSpinning = false;

        ShowResult();
    }

    void ShowResult()
    {
        resultText.text = "Kết quả: Phần thưởng " + (selectedSegment + 1);
        resultText.gameObject.SetActive(true);
        Debug.Log(resultText.text);
    }
}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WheelController : MonoBehaviour
{
    public Button spinButton;
    public RectTransform wheel;
    public float spinDuration = 5f;
    public AnimationCurve spinCurve;
    public int segmentCount = 8;

    private bool isSpinning = false;

    void Start()
    {
        spinButton.onClick.AddListener(StartSpin);
    }

    void StartSpin()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinWheel());
        }
    }

    IEnumerator SpinWheel()
    {
        isSpinning = true;
        float elapsedTime = 0f;
        float startRotation = wheel.rotation.eulerAngles.z;
        float endRotation = startRotation - (360f * (Random.Range(2, 5) + Random.value));
        float targetRotation = endRotation - (endRotation % (360f / segmentCount));

        while (elapsedTime < spinDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinDuration;
            float curveValue = spinCurve.Evaluate(t);
            float currentRotation = Mathf.Lerp(startRotation, targetRotation, curveValue);
            wheel.rotation = Quaternion.Euler(0f, 0f, currentRotation);
            yield return null;
        }

        wheel.rotation = Quaternion.Euler(0f, 0f, targetRotation);
        isSpinning = false;

        int selectedSegment = Mathf.RoundToInt((-targetRotation % 360f) / (360f / segmentCount));
        Debug.Log("Kết quả: Phần thưởng " + (selectedSegment + 1));
    }
}
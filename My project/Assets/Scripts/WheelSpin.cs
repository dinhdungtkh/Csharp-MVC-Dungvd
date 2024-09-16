using UnityEngine;
using System.Collections;

public class WheelSpin : MonoBehaviour
{
    public float minSpinTime = 4f;
    public float maxSpinTime = 6f;
    public float maxSpinSpeed = 1000f;
    public AnimationCurve spinCurve;
    public string[] prizes;

    private bool isSpinning = false;
    private float spinTime;
    private float currentAngle = 0f;
    private int selectedPrizeIndex;

    public void StartSpin()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            spinTime = Random.Range(minSpinTime, maxSpinTime);
            selectedPrizeIndex = Random.Range(0, prizes.Length);
            StartCoroutine(SpinWheel());
        }
    }

    private IEnumerator SpinWheel()
    {
        float elapsedTime = 0f;
        float targetAngle = 360f * (spinTime / 60f) + (360f / prizes.Length) * selectedPrizeIndex;

        while (elapsedTime < spinTime)
        {
            float t = elapsedTime / spinTime;
            float currentSpeed = spinCurve.Evaluate(t) * maxSpinSpeed;
            currentAngle += currentSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        float finalAngle = 360f - (360f / prizes.Length) * selectedPrizeIndex;
        transform.rotation = Quaternion.Euler(0f, 0f, finalAngle);

        isSpinning = false;
        ShowResult();
    }

    private void ShowResult()
    {
        Debug.Log("Kết quả: " + prizes[selectedPrizeIndex]);
    }
}
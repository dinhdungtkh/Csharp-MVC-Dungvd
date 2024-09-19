using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

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

    public void SpinWheelTest()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            float spinTime = Random.Range(minSpinTime, maxSpinTime);
            Debug.Log("" + spinTime);
            targetIndex = Random.Range(0, prizes.Length);
            Debug.Log(targetIndex);
            StartCoroutine(Spin(spinTime));
        }
    }

    private IEnumerator Spin(float spinTime)
    {
        float elapsedTime = 0f;
        float currentAngle = m_Spin.eulerAngles.z;
        float targetAngle = (360f * Random.Range(2, 5)) + (anglePerPrize * targetIndex);

        Debug.Log("Góc khởi đầu: " + currentAngle);
        Debug.Log("Góc mục tiêu: " + targetAngle);

        while (elapsedTime < spinTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinTime;
            float currentSpeed = Mathf.Lerp(initialSpinSpeed, 0f, t);

            currentAngle += currentSpeed * Time.deltaTime;
            currentAngle %= 360;
            m_Spin.rotation = Quaternion.Euler(0f, 0f, currentAngle);

            if (elapsedTime % (spinTime / 10) < Time.deltaTime)
            {
                Debug.Log("Trục Z hiện tại: " + m_Spin.eulerAngles.z);
            }

            yield return null;
        }

        targetAngle %= 360;
        float finalAngle = m_Spin.eulerAngles.z;
        Debug.Log("Trục Z hiện tại trước khi đặt lại: " + finalAngle);

        if (Mathf.Abs(finalAngle - targetAngle) > 1f)
        {
            Debug.Log("Điều chỉnh góc cuối cùng từ " + finalAngle + " đến " + targetAngle);
            m_Spin.rotation = Quaternion.Euler(0f, 0f, targetAngle);
        }

        isSpinning = false;
        Debug.Log("Trục Z hiện tại sau khi đặt lại: " + m_Spin.eulerAngles.z);

        int currentIndex = CalculateCurrentIndex(m_Spin.eulerAngles.z);
        Debug.Log("Chỉ số hiện tại: " + currentIndex);

        ShowResult();
    }

    private int CalculateCurrentIndex(float currentAngle)
    {
        currentAngle = currentAngle % 360;
        int index = Mathf.FloorToInt(currentAngle / anglePerPrize);
        index = index % prizes.Length;
        return index;
    }

    private void ShowResult()
    {
        Debug.Log("Giải thưởng: " + prizes[targetIndex]);
    }
}
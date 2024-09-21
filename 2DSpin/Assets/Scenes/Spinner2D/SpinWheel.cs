using System.Collections;
using TMPro;
using UnityEngine;

public class SpinWheel : MonoBehaviour
{
    public Transform m_Spin;
    public float minSpinTime = 4f;
    public float maxSpinTime = 6f;

    public float initialSpinSpeed = 1000f;

    private bool isSpinning = false;
    private float anglePerPrize;

    [SerializeField]
    private float currentAngle;

    public AudioSource m_audioSource;
    public AudioClip yaysfx;

    public GameObject m_RewardPanel;
    public TMP_Text m_RewardText;

    public enum Prize
    {
        TwentyK = 1,
        TenK,
        FiveK,
        FiveHundredK,
        CHIADOI,
        TwoHundredK,
        NHANDOI,
        HundredK,
        ThirtyK,
        FiftyK,
        QUAYLAI
    }

    private Prize[] prizes;
    private string[] prizeNames = {
        "20K", "10K", "5K", "500K", "Chia đôi", "200K", "Nhân đôi", "100K", "30K", "50K", "Quay lại"
    };

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
            m_RewardPanel.SetActive(false);
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
        isSpinning = true;
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

        isSpinning = false;
        m_audioSource.PlayOneShot(yaysfx, 1);
        ShowReward(currentAngle);
        yield return new WaitForSeconds(1.5f);
        m_RewardPanel.SetActive(false);
    }

    private int CalculateCurrentIndex(float angle)
    {
        angle = angle % 360;
        return Mathf.FloorToInt(angle / anglePerPrize) % prizes.Length;
    }

    private void ShowReward(float angle)
    {
        int prizeIndex = CalculateCurrentIndex(angle);
        string wonPrizeName = prizeNames[prizeIndex];
        m_RewardText.text = "Giải thưởng: " + wonPrizeName;
        m_RewardPanel.SetActive(true);
        Debug.Log(wonPrizeName);
    }
}
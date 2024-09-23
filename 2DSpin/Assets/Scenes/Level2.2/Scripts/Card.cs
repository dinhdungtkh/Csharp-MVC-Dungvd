using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public enum CardType
    {
        Mom,
        Dad,
        Baby
    }


    [SerializeField] private CardType cardType;
    [SerializeField] private GameObject cardFront;
    [SerializeField] private GameObject cardBack;
    [SerializeField] private Image frontImage;
    private RectTransform m_rectTransform;


    public CardType Type => cardType;
    public bool IsTextCard { get; private set; }

    public void SetupCard(CardType type, Sprite sprite, bool isTextCard)
    {
        cardType = type;
        gameObject.tag = type.ToString();
        SetFrontSprite(sprite);
        IsTextCard = isTextCard;
    }

    public void SetFrontSprite(Sprite sprite)
    {
        if (frontImage != null && sprite != null)
        {
            frontImage.sprite = sprite;
        }
    }

    public void Flip(bool showFront)
    {
        cardFront.SetActive(showFront);
        cardBack.SetActive(!showFront);
    }

    public void CastFlipUp()
    {
        StartCoroutine(FlipUpCoroutine());
    }

    private IEnumerator FlipUpCoroutine()
    {
        for (float i = 0; i <= 180; i += 10f)
        {
            m_rectTransform.rotation = Quaternion.Euler(0, i, 0);
            if (i == 90)
            {

                cardBack.SetActive(false);
                cardFront.SetActive(true);
            }
        }
        yield return new WaitForSeconds(0.5f);
    }

    public void CastViberation()
    {
        StartCoroutine(VibrateCoroutine());
    }

    private IEnumerator VibrateCoroutine()
    {
        Vector2 originalPosition = m_rectTransform.anchoredPosition;
        float elapsedTime = 0f;
        float vibrationDuration = 0.5f;
        float vibrationMagnitude = 10f;

        while (elapsedTime < vibrationDuration)
        {
            m_rectTransform.anchoredPosition = originalPosition + Random.insideUnitCircle * vibrationMagnitude;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        m_rectTransform.anchoredPosition = originalPosition;
    }

    private GameControllerClone gameController;

    private void Start()
    {
        m_rectTransform = GetComponent<RectTransform>();
        gameController = FindObjectOfType<GameControllerClone>();
    }

    public void OnButtonClick()
    {
        if (gameController != null)
        {
            gameController.OnCardClicked(this);
            gameController.OnCardInteraction();
        }
    }


}
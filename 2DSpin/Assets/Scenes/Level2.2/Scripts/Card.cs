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

    private GameControllerClone gameController;

    private void Start()
    {
        
        gameController = FindObjectOfType<GameControllerClone>();
        if (gameController == null)
        {
            Debug.LogError("Không tìm thấy GameControllerClone trong scene!");
        }

    
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
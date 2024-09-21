using UnityEngine;

public class CardRuleNew : MonoBehaviour
{
    [SerializeField] private float checkDelay = 1f;
    private const int MAX_WRONG_ATTEMPTS = 3;

    private int wrongAttempts = 0;

    public bool AreCardsMatching(Card firstCard, Card secondCard)
    {
        return firstCard.Type == secondCard.Type &&
               (firstCard.Type == Card.CardType.Baby || 
                firstCard.Type == Card.CardType.Mom || 
                firstCard.Type == Card.CardType.Dad);
    }

    public bool ShouldDisableCards(Card firstCard, Card secondCard)
    {
        return AreCardsMatching(firstCard, secondCard);
    }

    public void HandleMatchedCards()
    {
        AudioManager.PlaySound(Soundnames.TING);
    }

    public bool HandleMismatchedCards()
    {
        AudioManager.PlayRandomErrorSound();
        wrongAttempts++;
        return wrongAttempts >= MAX_WRONG_ATTEMPTS;
    }

    public void ResetWrongAttempts()
    {
        wrongAttempts = 0;
    }

    public float GetCheckDelay()
    {
        return checkDelay;
    }
}

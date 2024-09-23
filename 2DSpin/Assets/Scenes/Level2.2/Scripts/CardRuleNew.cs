using System.Collections;
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

    public void PlayCardSound(Card card)
    {
        switch (card.Type)
        {
            case Card.CardType.Baby:
                AudioManager.PlaySound(Soundnames.BABY);
                break;
            case Card.CardType.Mom:
                AudioManager.PlaySound(Soundnames.MOM);
                break;
            case Card.CardType.Dad:
                AudioManager.PlaySound(Soundnames.DAD);
                break;
        }
    }

    public void HandleMatchedCards(Card firstCard, Card secondCard)
    {
        AudioManager.PlaySound(Soundnames.TING);
        StartCoroutine(PlayFirstCardSound(firstCard));
    }

    private IEnumerator PlayFirstCardSound(Card card)
    {
        yield return new WaitForSeconds(1f);
        PlayCardSound(card);
    }

    public bool HandleMismatchedCards(Card firstCard, Card secondCard)
    {
        firstCard.CastViberation();
        secondCard.CastViberation();
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

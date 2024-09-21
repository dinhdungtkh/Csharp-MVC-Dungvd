using System.Collections.Generic;
using UnityEngine;

public class RuleNoRaycast : MonoBehaviour
{
    private Stack<GameObject> flippedCards = new Stack<GameObject>();
    [SerializeField]
    private int maxFlippedCards = 2;
    private GameController gameController;

    private int wrongAttempts = 0;
    private const int MAX_WRONG_ATTEMPTS = 3;


    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void OnCardBackClick(GameObject cardBack)
    {
        if (cardBack.CompareTag("CardBack"))
        {
            FlipCard(cardBack);
          //  gameController.OnCardInteraction();
        }
    }

    void FlipCard(GameObject cardBack)
    {
        if (flippedCards.Count >= maxFlippedCards)
            return;

        cardBack.SetActive(false);
        GameObject card = cardBack.transform.parent.gameObject;
        flippedCards.Push(card);

        if (flippedCards.Count == maxFlippedCards)
        {
            Invoke("CheckCards", 1f);
        }
    }

    public void OnButtonClick()
    {
        CheckCards();
       // gameController.OnCardInteraction();
    }

    void CheckCards()
    {
        if (flippedCards.Count == 2)
        {
            GameObject card1 = flippedCards.Pop();
            GameObject card2 = flippedCards.Pop();

            if (card1.CompareTag(card2.tag))
            {
                if (card1.CompareTag("baby") || card1.CompareTag("mom") || card1.CompareTag("dad"))
                {
                    DisableCard(card1);
                    DisableCard(card2);
                    AudioManager.PlaySound(Soundnames.TING);
                }
            }
            else
            {
                AudioManager.PlayRandomErrorSound();
                FlipCardBack(card1);
                FlipCardBack(card2);
                wrongAttempts++;
                if (wrongAttempts >= MAX_WRONG_ATTEMPTS)
                {
                    gameController.GameOver("Sai quá nhiều lần");
                    return;
                }
            }
        }

        if (gameController.GetAllCardsCount() == 0)
        {
            Debug.Log("Hết thẻ");
            gameController.StartNewTurn();
        }
    }

    void DisableCard(GameObject card)
    {
        card.SetActive(false);
        gameController.RemoveCard(card);
    }

    void FlipCardBack(GameObject card)
    {
        card.transform.Find("CardBack").gameObject.SetActive(true);
    }
}
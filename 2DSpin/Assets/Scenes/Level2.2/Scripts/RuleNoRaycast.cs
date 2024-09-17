using UnityEngine;
using System.Collections.Generic;

public class RuleNoRaycast : MonoBehaviour
{
    [SerializeField] private List<GameObject> allCards = new List<GameObject>();
    private Stack<GameObject> flippedCards = new Stack<GameObject>();
    [SerializeField]
    private int maxFlippedCards = 2;
    
    void Update()
    {
        // Không cần kiểm tra click trong Update nữa
    }

    public void OnCardBackClick(GameObject cardBack)
    {
        if (cardBack.CompareTag("CardBack"))
        {
            FlipCard(cardBack);
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
    }

    void CheckCards()
    {
        if (flippedCards.Count == 2)
        {
            GameObject card1 = flippedCards.Pop();
            GameObject card2 = flippedCards.Pop();

            if (card1.CompareTag(card2.tag))
            {
                if (card1.CompareTag("baby") || card1.CompareTag("mom"))
                {
                    DisableCard(card1);
                    DisableCard(card2);
                    Debug.Log("Thẻ đúng!");
                }
            }
            else
            {
                FlipCardBack(card1);
                FlipCardBack(card2);
            }
        }
    }

    void DisableCard(GameObject card)
    {
        card.SetActive(false);
        allCards.Remove(card);
    }

    void FlipCardBack(GameObject card)
    {
        card.transform.Find("CardBack").gameObject.SetActive(true);
    }
}
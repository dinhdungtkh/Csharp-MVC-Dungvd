using UnityEngine;
using System.Collections.Generic;

public class Rule : MonoBehaviour
{
    [SerializeField] private List<GameObject> allCards = new List<GameObject>();
    private Stack<GameObject> flippedCards = new Stack<GameObject>();
    [SerializeField]
    private int maxFlippedCards = 2;
    private Vector2 lastMousePosition;
    private float raycastThreshold = 0.1f;
    

    void Update()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(currentMousePosition);
        
        if (Vector2.Distance(currentMousePosition, lastMousePosition) > raycastThreshold)
        {
            lastMousePosition = currentMousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                Collider2D hit = Physics2D.OverlapPoint(currentMousePosition);

                if (hit != null && hit.CompareTag("CardBack"))
                {
                    FlipCard(hit.gameObject);
                }
            }
        }
    }

    void FixedUpdate(){
        
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
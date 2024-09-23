using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private List<GameObject> allCards = new List<GameObject>();
    [SerializeField] private TMP_Text currentTurnTxt;
    private Animator cursorAnimator;
    private Animator shuffleCardAnimator;

    private float idleTime = 3f;
    private float lastInteractionTime;
    private int currentTurn = 0;
    private bool isIdle = false;
    [SerializeField] private GameObject gameoverPanel;
    private bool isGameOver = false;

    private void Start()
    {

        if (cursorAnimator == null || shuffleCardAnimator == null)
        {
            Debug.LogError("Animator không được gán.");
            return;
        }

        cursorAnimator.gameObject.SetActive(false);
        shuffleCardAnimator.gameObject.SetActive(false);

        StartNewTurn();
    }

    private void Update()
    {
        if (cursorAnimator == null || shuffleCardAnimator == null)
        {
            // Debug.LogError("Animator không được gán.");
            return;
        }

        if (Time.time - lastInteractionTime > idleTime)
        {
            if (!isIdle)
            {
                cursorAnimator.gameObject.SetActive(true);
                cursorAnimator.SetBool("IsIdle", true);
                isIdle = true;
            }
        }
        else
        {
            if (isIdle)
            {
                cursorAnimator.SetBool("IsIdle", false);
                cursorAnimator.gameObject.SetActive(false);
                isIdle = false;
            }
        }
    }

    public void OnCardInteraction()
    {
        lastInteractionTime = Time.time;
    }

    public void StartNewTurn()
    {
        currentTurn++;
        currentTurnTxt.text = "Turn: " + currentTurn.ToString();
        if (currentTurn > 4)
        {
            GameOver("Đã hết lượt chơi");
            return;
        }

        StartCoroutine(ShuffleCardAnimation());
    }

    public void GameOver(string reason)
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log("Game Over: " + reason);
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        gameoverPanel.SetActive(true);
    }

    private IEnumerator ShuffleCardAnimation()
    {
        if (shuffleCardAnimator != null)
        {
            shuffleCardAnimator.gameObject.SetActive(true);
            shuffleCardAnimator.SetBool("IsShuffled", true);
            foreach (GameObject card in allCards)
            {
                card.SetActive(false);
            }

            yield return new WaitForSeconds(1f);
            
            foreach (GameObject card in allCards)
            {
                card.SetActive(true);
            }

            lastInteractionTime = Time.time;
            OnShuffleAnimationEnd();
        }
    }

    public void OnShuffleAnimationEnd()
    {
        if (shuffleCardAnimator != null)
        {
            shuffleCardAnimator.SetBool("IsShuffled", false);
            shuffleCardAnimator.gameObject.SetActive(false);
        }
    }

    public int GetAllCardsCount()
    {
        return allCards.Count;
    }

    public void RemoveCard(GameObject card)
    {
        allCards.Remove(card);
    }

    public void ResetCurrentLevel()
    {
        isGameOver = false;
        currentTurn = 0;
        gameoverPanel.SetActive(false);
        foreach (GameObject card in allCards)
        {
            card.SetActive(true);
        }
        StartNewTurn();
    }

}
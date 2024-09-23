using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerClone : MonoBehaviour
{
    [SerializeField] private List<Card> allCards = new List<Card>();
    [SerializeField] private int currentTurn = 0;
    [SerializeField] private int maxTurns = 4;

    [Header("Card Sprites")]
    [SerializeField] private Sprite momSprite;
    [SerializeField] private Sprite dadSprite;
    [SerializeField] private Sprite babySprite;
    [SerializeField] private Sprite momTextSprite;
    [SerializeField] private Sprite dadTextSprite;
    [SerializeField] private Sprite babyTextSprite;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI currentTurnTxt;
    [SerializeField] private GameObject gameoverPanel;

    [Header("Animation Settings")]
    [SerializeField] private float idleTime = 5f;
    [SerializeField] private float shuffleAnimationDuration = 2f;

    private bool markLevelComplete = false;

    [Header("Animators")]
    [SerializeField] private Animator cursorAnimator;
    [SerializeField] private Animator shuffleCardAnimator;

    private float lastInteractionTime;
    private bool isIdle = false;
    private bool isGameOver = false;

    [SerializeField] private CardRuleNew cardRule;
    private Card firstFlippedCard;
    private Card secondFlippedCard;
    private List<Card> disabledCards = new List<Card>();

    private void Start()
    {
        InitializeAnimators();

        StartNewTurn();
    }

    private void Update()
    {
        HandleIdleAnimation();
    }

    private void InitializeAnimators()
    {
        if (cursorAnimator == null || shuffleCardAnimator == null)
        {
            Debug.LogError("Animator không được gán.");
            return;
        }

        cursorAnimator.gameObject.SetActive(false);
        shuffleCardAnimator.gameObject.SetActive(false);
    }

    private void HandleIdleAnimation()
    {
        if (cursorAnimator == null) return;

        bool shouldBeIdle = Time.time - lastInteractionTime > idleTime;

        if (shouldBeIdle && !isIdle)
        {
            isIdle = true;
            cursorAnimator.gameObject.SetActive(true);
            cursorAnimator.SetBool("IsIdle", true);
        }
        else if (!shouldBeIdle && isIdle)
        {
            isIdle = false;
            cursorAnimator.gameObject.SetActive(false);
            cursorAnimator.SetBool("IsIdle", false);
        }
    }

    public void OnCardInteraction()
    {
        lastInteractionTime = Time.time;
    }

    public void OnCardClicked(Card card)
    {   
        OnCardInteraction();
        if (firstFlippedCard == null)
        {
            firstFlippedCard = card;
            cardRule.PlayCardSound(card);
           // firstFlippedCard.CastFlipUp();
           card.Flip(true);
        }
        else if (secondFlippedCard == null)
        {
            secondFlippedCard = card;
            cardRule.PlayCardSound(card);
           // secondFlippedCard.CastFlipUp();
            card.Flip(true);
            StartCoroutine(CheckCardsAfterDelay());
        }
    }

    private IEnumerator CheckCardsAfterDelay()
    {
        yield return new WaitForSeconds(cardRule.GetCheckDelay());
        CheckCards();
    }

    private void CheckCards()
    {
        if (cardRule.AreCardsMatching(firstFlippedCard, secondFlippedCard))
        {
            if (cardRule.ShouldDisableCards(firstFlippedCard, secondFlippedCard))
            {
                DisableCard(firstFlippedCard);
                DisableCard(secondFlippedCard);
                cardRule.HandleMatchedCards(firstFlippedCard, secondFlippedCard);
            }
        }
        else
        {
            FlipCardBack(firstFlippedCard);
            FlipCardBack(secondFlippedCard);
            if (cardRule.HandleMismatchedCards(firstFlippedCard, secondFlippedCard))
            {
                GameOver("Sai quá nhiều lần");
                return;
            }
        }

        firstFlippedCard = null;
        secondFlippedCard = null;

        if (GetActiveCardsCount() == 0)
        {
            Debug.Log("Không còn thẻ nào hoạt động");
            markLevelComplete = true;
            MoveToNextLevel();
            return;
        }
    }

    private void DisableCard(Card card)
    {
        card.gameObject.SetActive(false);
        disabledCards.Add(card);
    }

    private void FlipCardBack(Card card)
    {
        card.Flip(false);
    }

    public void StartNewTurn()
    {
        currentTurn++;
        UpdateTurnDisplay();

        if (currentTurn > maxTurns)
        {
            GameOver("Đã hết lượt chơi");
        }
        else
        {
            StartCoroutine(ShuffleCardAnimation());
        }
    }

    private void UpdateTurnDisplay()
    {
        if (currentTurnTxt != null)
        {
            currentTurnTxt.text = $"Turn: {currentTurn}";
        }
    }

    public void GameOver(string reason)
    {
        if (!isGameOver)
        {
            isGameOver = true;
            Debug.Log($"Game Over: {reason}");
            ShowGameOver();
        }
    }

    private void ShowGameOver()
    {
        if (gameoverPanel != null)
        {
            gameoverPanel.SetActive(true);
        }
    }

    private IEnumerator ShuffleCardAnimation()
    {
        foreach (Card card in allCards)
        {
            card.gameObject.SetActive(true);
            card.Flip(true);

        }

        yield return new WaitForSeconds(2f);

        foreach (Card card in allCards)
        {
            card.gameObject.SetActive(false);
            card.Flip(false);
        }

        if (shuffleCardAnimator != null)
        {
            shuffleCardAnimator.gameObject.SetActive(true);
            shuffleCardAnimator.SetBool("IsShuffled", true);

            yield return new WaitForSeconds(shuffleAnimationDuration);
            foreach (Card card in allCards)
            {
                card.gameObject.SetActive(true);
            }

            shuffleCardAnimator.SetBool("IsShuffled", false);
            shuffleCardAnimator.gameObject.SetActive(false);
        }

        lastInteractionTime = Time.time;
        OnShuffleAnimationEnd();
    }


    public void OnShuffleAnimationEnd()
    {
        if (shuffleCardAnimator != null)
        {
            shuffleCardAnimator.SetBool("IsShuffled", false);
            shuffleCardAnimator.gameObject.SetActive(false);
        }
    }

    public int GetActiveCardsCount() => allCards.Count - disabledCards.Count;

    public void RemoveCard(Card card)
    {
        //allCards.Remove(card);
    }

    public void ResetCurrentLevel()
    {
        isGameOver = false;
        currentTurn = 0;
        if (gameoverPanel != null) gameoverPanel.SetActive(false);
        foreach (Card card in allCards)
        {
            card.gameObject.SetActive(true);
            card.Flip(false);
        }
        disabledCards.Clear();
        StartNewTurn();
    }



    public void MoveToNextLevel()
    {
        if (markLevelComplete)
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.Log("Đã hoàn thành tất cả các cấp độ!");
                // Xử lý khi đã hoàn thành tất cả các cấp độ
                SceneManager.LoadScene("MainMenu");

            }
        }
    }
}



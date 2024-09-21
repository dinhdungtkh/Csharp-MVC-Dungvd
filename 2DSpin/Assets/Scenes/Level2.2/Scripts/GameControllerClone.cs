using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerClone : MonoBehaviour
{
	[SerializeField] private List<Card> allCards = new List<Card>();
	[SerializeField] private int currentLevel = 1;
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

	private Animator cursorAnimator;
	private Animator shuffleCardAnimator;
	private float lastInteractionTime;
	private bool isIdle = false;
	private bool isGameOver = false;

	[SerializeField] private CardRuleNew cardRule;
	private Card firstFlippedCard;
	private Card secondFlippedCard;

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
		cursorAnimator = EssentialLoader.Instance.GetCursorAnimator();
		shuffleCardAnimator = EssentialLoader.Instance.GetShuffleCardAnimator();

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

		if (shouldBeIdle != isIdle)
		{
			isIdle = shouldBeIdle;
			cursorAnimator.gameObject.SetActive(isIdle);
			cursorAnimator.SetBool("IsIdle", isIdle);
		}
	}

	public void OnCardInteraction()
	{
		lastInteractionTime = Time.time;
	}

	public void OnCardClicked(Card card)
	{
		if (firstFlippedCard == null)
		{
			firstFlippedCard = card;
			card.Flip(true);
		}
		else if (secondFlippedCard == null)
		{
			secondFlippedCard = card;
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
				cardRule.HandleMatchedCards();
			}
		}
		else
		{
			FlipCardBack(firstFlippedCard);
			FlipCardBack(secondFlippedCard);
			if (cardRule.HandleMismatchedCards())
			{
				GameOver("Sai quá nhiều lần");
				return;
			}
		}

		firstFlippedCard = null;
		secondFlippedCard = null;

		if (GetAllCardsCount() == 0)
		{
			Debug.Log("Không còn thẻ nào");
            markLevelComplete = true;
			StartNewTurn();
		}
	}

	private void DisableCard(Card card)
	{
		card.gameObject.SetActive(false);
		RemoveCard(card);
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

	public int GetAllCardsCount() => allCards.Count;

	public void RemoveCard(Card card)
	{
		allCards.Remove(card);
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
		StartNewTurn();
	}


    
	public void MoveToNextLevel()
	{
		
	}


}



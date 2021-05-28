using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseCollider : MonoBehaviour
{
	// cached references
	GameStatus gameStatus;

	private void Start()
	{
		gameStatus = FindObjectOfType<GameStatus>();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (gameStatus.NumberOfLives() == 1)
        {
			gameStatus.Lives();
			SceneManager.LoadScene("Game Over");
        }
		else
			gameStatus.Lives();
	}
}

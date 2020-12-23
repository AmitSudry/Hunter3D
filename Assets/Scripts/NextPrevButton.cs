﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextPrevButton : MonoBehaviour
{
	public Button prev;
	public Button next;

	public Image jungle;
	public Image desert;

	public TextMeshProUGUI difficultyText;

	private int numOfEnv = 2;
	private int currEnv = 0;

	private int numOfDifficulties = 3;
	private int currDifficulty = 0;

	void Start()
	{
		Button btn1 = prev.GetComponent<Button>();
		Button btn2 = next.GetComponent<Button>();
		btn1.onClick.AddListener(TaskOnClick1);
		btn2.onClick.AddListener(TaskOnClick2);
	}

	void TaskOnClick1()
	{
		if (currEnv == 0)
			currEnv = numOfEnv - 1;
		else
			currEnv--;

		HandleChange();
	}

	void TaskOnClick2()
	{
		currEnv = (currEnv + 1) % numOfEnv;
		HandleChange();
	}

	void HandleChange()
	{
		if (currEnv == 0)
		{
			PlayerPrefs.SetString("CurrentScene", "Game");
			jungle.enabled = true;
			desert.enabled = false;
		}
		else if (currEnv == 1)
		{
			PlayerPrefs.SetString("CurrentScene", "GAME_TESTING");
			jungle.enabled = false;
			desert.enabled = true;
		}
	}

	public void HigherDifficulty()
	{
		currDifficulty = (currDifficulty + 1) % numOfDifficulties;
		HandleDifficulty();
	}

	public void LowerDifficulty()
	{
		if (currDifficulty == 0)
			currDifficulty = numOfDifficulties - 1;
		else
			currDifficulty--;
		HandleDifficulty();
	}

	void HandleDifficulty()
	{
		if (currDifficulty == 0)
			difficultyText.SetText("EASY");
		else if (currDifficulty == 1)
			difficultyText.SetText("MEDIUM");
		else if (currDifficulty == 2)
			difficultyText.SetText("HARD");

		PlayerPrefs.SetInt("CurrentDifficulty", currDifficulty);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject[] dots;
	public GameObject[] Shape;
	public GameObject Spawn;
	public GameObject InventoryBar;
	public static GameState checkState;
	public static GameState preState;
	public GameObject Tile;
	public GameObject StirMold;
	Board board;
	FindMatch FindMatch;
	bool InCookTime = false;
	private void Start()
	{
		board = FindObjectOfType<Board>();
		FindMatch = FindObjectOfType<FindMatch>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!InCookTime)
			{
				checkState = GameState.CookTime;
				board.Reset();
				board.Draw();
				InCookTime = true;
			}
			else if (!Spawn.activeSelf)
			{
				checkState = GameState.CookingInventory;
				InCookTime = false;
			}
		}
		switch (checkState)
		{
			case (GameState.CookingInventory):
				OpenInventory();
				break;
			case (GameState.PrefTime):
				AddToBoard();
				break;
			case (GameState.CookTime):
				CloseInventory();
				break;
		}
	}
	void CloseInventory()
	{
		Spawn.SetActive(false);
		Spawn.GetComponent<Spawn>().DestroyChild();
		switch (Board.height)
		{
			case (8):
				InventoryBar.transform.GetChild(0).gameObject.SetActive(false);
				break;
			case (6):
				InventoryBar.transform.GetChild(1).gameObject.SetActive(false);
				break;
			case (4):
				InventoryBar.transform.GetChild(2).gameObject.SetActive(false);
				break;
		}
		StirMold.SetActive(true);
		FindMatch.FindMatches();
		board.DestroyMatches();
	}
	void OpenInventory()
	{
		StirMold.SetActive(false);
		Spawn.SetActive(false);
		if (Spawn.transform.childCount != 0)
		{ 
			Spawn.GetComponent<Spawn>().DestroyChild();
		}
		switch (Board.height) 
		{
			case (8):
				InventoryBar.transform.GetChild(0).gameObject.SetActive(true);
				break;
			case (6):
				InventoryBar.transform.GetChild(1).gameObject.SetActive(true);
				break;
			case (4):
				InventoryBar.transform.GetChild(2).gameObject.SetActive(true);
				break;
		}
	}
	void AddToBoard()
	{
		Spawn.SetActive(true);
		StirMold.SetActive(false);
		switch (Board.height)
		{
			case (8):
				InventoryBar.transform.GetChild(0).gameObject.SetActive(true);
				break;
			case (6):
				InventoryBar.transform.GetChild(1).gameObject.SetActive(true);
				break;
			case (4):
				InventoryBar.transform.GetChild(2).gameObject.SetActive(true);
				break;
		}
	}
}

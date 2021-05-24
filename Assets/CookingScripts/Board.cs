using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public static int height = 8;
    public GameObject BoardTile;
    public bool[,] Occupied = new bool[8, 8];
	public GameObject[,] AllTile = new GameObject[8, 8];
	public GameObject[,] AllOrb = new GameObject[8, 8];
	GameManager gameManager;
	public static bool CanMove = true;
	bool isMoving = false;
	private void Start()
	{
		gameManager = FindObjectOfType<GameManager>();
		Setup();
	}
	public void Draw()
	{
		switch (height)
		{
			case 8:
				for (int x = 0; x < height; x++)
				{
					for (int y = 0; y < height; y++)
					{

						GameObject dotsNum = AllTile[x, y];
						if (dotsNum.GetComponent<Tile>().TileID != 0)
						{
							Vector2 temPos = new Vector2(x, y);
							int id = dotsNum.GetComponent<Tile>().TileID;
							Destroy(dotsNum);
							GameObject tmp = FindObjectOfType<GameManager>().Tile;
							tmp.GetComponent<Tile>().TileID = id;
							tmp.GetComponent<Tile>().scaleChange = new Vector3(1, 1, 1);
							GameObject boardTile = Instantiate(tmp, temPos, Quaternion.identity);
							boardTile.transform.parent = this.transform;
							boardTile.name = "(" + x + "," + y + ")";
							AllTile[x, y] = boardTile;
						}
					}
				}
				break;
			case 6:
				for (int x = 1; x <= height; x++)
				{
					for (int y = 1; y <= height; y++)
					{
						GameObject dotsNum = AllTile[x, y];
						if (dotsNum.GetComponent<Tile>().TileID != 0)
						{
							Vector2 temPos = new Vector2(x, y);
							int id = dotsNum.GetComponent<Tile>().TileID;
							Destroy(dotsNum);
							GameObject tmp = FindObjectOfType<GameManager>().Tile;
							tmp.GetComponent<Tile>().TileID = id;
							tmp.GetComponent<Tile>().scaleChange = new Vector3(1, 1, 1);
							GameObject boardTile = Instantiate(tmp, temPos, Quaternion.identity);
							boardTile.transform.parent = this.transform;
							boardTile.name = "(" + x + "," + y + ")";
							AllTile[x, y] = boardTile;
						}
					}
				}
				break;
			case 4:
				for (int x = 2; x <= height + 1; x++)
				{
					for (int y = 2; y <= height + 1; y++)
					{
						GameObject dotsNum = AllTile[x, y];
						if (dotsNum.GetComponent<Tile>().TileID != 0)
						{
							Vector2 temPos = new Vector2(x, y);
							int id = dotsNum.GetComponent<Tile>().TileID;
							Destroy(dotsNum);
							GameObject tmp = FindObjectOfType<GameManager>().Tile;
							tmp.GetComponent<Tile>().TileID = id;
							tmp.GetComponent<Tile>().scaleChange = new Vector3(1, 1, 1);
							GameObject boardTile = Instantiate(tmp, temPos, Quaternion.identity);
							boardTile.transform.parent = this.transform;
							boardTile.name = "(" + x + "," + y + ")";
							AllTile[x, y] = boardTile;
						}
					}
				}
				break;
			default:
				break;
		}
	}
	private void Setup()
	{
		switch (height)
		{
			case 6:
				for (int i = 1; i <= height; i++)
				{
					for (int j = 1; j <= height; j++)
					{
						Vector2 temPos = new Vector2(i, j);
						GameObject tmp = FindObjectOfType<GameManager>().Tile;
						tmp.GetComponent<Tile>().TileID = 0;
						GameObject boardTile = Instantiate(tmp, temPos, Quaternion.identity);
						boardTile.transform.parent = this.transform;
						boardTile.name = "(" + i + "," + j + ")";
						AllTile[i, j] = boardTile;
						Occupied[i, j] = false;
					}
				}
				break;
			case 4:
				for (int i = 2; i <= height + 1; i++)
				{
					for (int j = 2; j <= height + 1; j++)
					{
						Vector2 temPos = new Vector2(i, j);
						GameObject tmp = FindObjectOfType<GameManager>().Tile;
						tmp.GetComponent<Tile>().TileID = 0;
						GameObject boardTile = Instantiate(tmp, temPos, Quaternion.identity);
						boardTile.transform.parent = this.transform;
						boardTile.name = "(" + i + "," + j + ")";
						AllTile[i, j] = boardTile;
						Occupied[i, j] = false;
					}
				}
				break;
			case 8:
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < height; j++)
					{
						Vector2 temPos = new Vector2(i, j);
						GameObject tmp = FindObjectOfType<GameManager>().Tile;
						tmp.GetComponent<Tile>().TileID = 0;
						GameObject boardTile = Instantiate(tmp, temPos, Quaternion.identity);
						boardTile.transform.parent = this.transform;
						boardTile.name = "(" + i + "," + j + ")";
						AllTile[i, j] = boardTile;
						Occupied[i, j] = false;
					}
				}
				break;
			default:
				break;
		}
	}
	public void Hover(int x, int TileID) 
	{
		switch (height)
		{
			case 6:
				for (int y = 1; y <= height; y++)
				{
					GameObject tmpTile = AllTile[x, y];
					if (!Occupied[x, y] && tmpTile.GetComponent<Tile>().TileID == 0)
					{
						
						//tmpTile.GetComponent<Tile>().AlphaLvl = 155;
						tmpTile.GetComponent<Tile>().TileID = TileID;
						break;
					}
				}
				break;
			case 4:
				for (int y = 2; y <= height + 1; y++)
				{
					GameObject tmpTile = AllTile[x, y];
					if (!Occupied[x, y] && tmpTile.GetComponent<Tile>().TileID == 0)
					{
						//tmpTile.GetComponent<Tile>().AlphaLvl = 155;
						tmpTile.GetComponent<Tile>().TileID = TileID;
						break;
					}
				}
				break;
			case 8:
				for (int y = 0; y < height; y++)
				{
					GameObject tmpTile = AllTile[x, y];
					if (!Occupied[x, y] && tmpTile.GetComponent<Tile>().TileID == 0)
					{
						//tmpTile.GetComponent<Tile>().AlphaLvl = 0.5f;
						tmpTile.GetComponent<Tile>().TileID = TileID;
						break;
					}
				}
				break;
			default:
				break;
		}
		
	}
	public void Reset()
	{
		switch (height)
		{
			case 6:
				for (int i = 1; i <= height; i++)
				{
					for (int j = 1; j <= height; j++)
					{
						GameObject tmpTile = AllTile[i, j];
						if (tmpTile.GetComponent<Tile>().TileID != 0 && !Occupied[i, j])
						{
							tmpTile.GetComponent<Tile>().TileID = 0;
						}
					}
				}
				break;
			case 4:
				for (int i = 2; i <= height + 1; i++)
				{
					for (int j = 2; j <= height + 1; j++)
					{
						GameObject tmpTile = AllTile[i, j];
						if (tmpTile.GetComponent<Tile>().TileID != 0 && !Occupied[i, j])
						{
							tmpTile.GetComponent<Tile>().TileID = 0;
						}
					}
				}
				break;
			case 8:
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < height; j++)
					{
						GameObject tmpTile = AllTile[i, j];
						if (tmpTile.GetComponent<Tile>().TileID != 0 && !Occupied[i, j])
						{
							tmpTile.GetComponent<Tile>().TileID = 0;
						}
					}
				}
				break;
			default:
				break;
		}
	}
	public bool CanYouPressS(int x) 
	{
		switch (height)
		{
			case 6:
				for (int y = 1; y <= height; y++)
				{
					if (!Occupied[x, y])
					{
						return true;
					}
				}
				break;
			case 4:
				for (int y = 2; y <= height + 1; y++)
				{
					if (!Occupied[x, y])
					{
						return true;
					}
				}
				break;
			case 8:
				for (int y = 0; y < height; y++)
				{
					if (!Occupied[x, y])
					{
						return true;
					}
				}
				break;
			default:
				break;
		}
		return false;
	}
	public void S_Was_Pressed() 
	{
		switch (height)
		{
			case 8:
				for (int x = 0; x < height; x++)
				{
					for (int y = 0; y < height; y++)
					{

						GameObject dotsNum = AllTile[x, y];
						if (dotsNum.GetComponent<Tile>().TileID != 0)
						{
							Occupied[x, y] = true;
							Vector3 OrbPos = new Vector3(x, y, 0);
							GameObject _orb = Instantiate(gameManager.dots[dotsNum.GetComponent<Tile>().TileID], OrbPos, Quaternion.identity);
							_orb.transform.parent = this.transform;
							dotsNum.GetComponent<Tile>().TileID = 0;
							AllOrb[x, y] = _orb;
						}
					}
				}
				break;
			case 6:
				for (int x = 1; x <= height; x++)
				{
					for (int y = 1; y <= height; y++)
					{
						GameObject dotsNum = AllTile[x, y];
						if (dotsNum.GetComponent<Tile>().TileID != 0)
						{
							Occupied[x, y] = true;
							Vector3 OrbPos = new Vector3(x, y, 0);
							GameObject _orb = Instantiate(gameManager.dots[dotsNum.GetComponent<Tile>().TileID], OrbPos, Quaternion.identity);
							_orb.transform.parent = this.transform;
							dotsNum.GetComponent<Tile>().TileID = 0;
							AllOrb[x, y] = _orb;
						}
					}
				}
				break;
			case 4:
				for (int x = 2; x <= height + 1; x++)
				{
					for (int y = 2; y <= height + 1; y++)
					{
						GameObject dotsNum = AllTile[x, y];
						if (dotsNum.GetComponent<Tile>().TileID != 0)
						{
							Occupied[x, y] = true;
							Vector3 OrbPos = new Vector3(x, y, 0);
							GameObject _orb = Instantiate(gameManager.dots[dotsNum.GetComponent<Tile>().TileID], OrbPos, Quaternion.identity);
							_orb.transform.parent = this.transform;
							dotsNum.GetComponent<Tile>().TileID = 0;
							AllOrb[x, y] = _orb;
						}
					}
				}
				break;
			default:
				break;
		}
	}
	public void Q_Was_Pressed(int x, int y)
	{
		StartCoroutine(Q(x, y));
	}
	IEnumerator Q(int x, int y) 
	{
		CanMove = false;
		yield return new WaitForSeconds(.1f);
		isMoving = true;
		changenum(x, y, 3);
		changenum(x, y - 1, 4);
		changenum(x + 1, y - 1, 1);
		changenum(x + 1, y, 2);
		yield return new WaitForSeconds(.1f);
		isMoving = false;
		Seeking();
		yield return new WaitForSeconds(.1f);
		CanMove = true;
	}
	public void E_Was_Pressed(int x, int y)
	{
		StartCoroutine(E(x, y));
	}
	IEnumerator E(int x, int y)
	{
		CanMove = false;
		yield return new WaitForSeconds(.1f);
		isMoving = true;
		changenum(x, y, 4);
		changenum(x, y - 1, 1);
		changenum(x + 1, y - 1, 2);
		changenum(x + 1, y, 3);
		yield return new WaitForSeconds(.1f);
		isMoving = false;
		Seeking();
		yield return new WaitForSeconds(.1f);
		CanMove = true;
	}
	void changenum(int x, int y, int num)
	{
		if (AllOrb[x, y] != null) 
		{
			GameObject orb = AllOrb[x, y];
			orb.GetComponent<Orbs>().PosNum = num;
			orb.GetComponent<Orbs>().MoveOrb();
			AllOrb[x, y] = null;
		}
	}
	void DestroyMatch(int x, int y)
	{
		if (AllOrb[x, y].GetComponent<Orbs>().isMatch)
		{
			Destroy(AllOrb[x, y]);
			AllOrb[x, y] = null;
		}
	}
	IEnumerator Seek_And_Destroy() 
	{
		yield return new WaitForSeconds(.1f);
		DestroyMatches();		
	}
	public void Seeking() 
	{
		StartCoroutine(Seek_And_Destroy());
	}
	public void DestroyMatches()
	{
		StartCoroutine(Move_Down());
		switch (height)
		{
			case 4:
				for (int x = 2; x < height + 2; x++)
				{
					for (int y = 2; y < height + 2; y++)
					{
						if (AllOrb[x, y] != null)
						{
							DestroyMatch(x, y);
						}
					}
				}
				StartCoroutine(Move_Down());
				break;
			case 6:
				for (int x = 1; x < height + 1; x++)
				{
					for (int y = 1; y < height + 1; y++)
					{
						if (AllOrb[x, y] != null)
						{
							DestroyMatch(x, y);
						}
					}
				}
				StartCoroutine(Move_Down());
				break;
			case 8:
				for (int x = 0; x < height; x++)
				{
					for (int y = 0; y < height; y++)
					{
						if (AllOrb[x, y] != null)
						{
							DestroyMatch(x, y);
						}
					}
				}
				StartCoroutine(Move_Down());
				break;
		}
	}
	IEnumerator Move_Down()
	{
		int Count = 0;
		switch (height)
		{
			case 4:
				for (int x = 2; x < height + 2; x++)
				{
					for (int y = 2; y < height + 2; y++)
					{
						if (AllOrb[x, y] == null && !isMoving)
						{
							Count++;
						}
						else if (Count > 0)
						{
							AllOrb[x, y].GetComponent<Orbs>().row -= Count;
							AllOrb[x, y] = null;
						}
					}
					Count = 0;
				}
				break;
			case 6:
				for (int x = 1; x < height + 1; x++)
				{
					for (int y = 1; y < height + 1; y++)
					{
						if (AllOrb[x, y] == null && !isMoving)
						{
							Count++;
						}
						else if (Count > 0)
						{
							AllOrb[x, y].GetComponent<Orbs>().row -= Count;
							AllOrb[x, y] = null;
						}
					}
					Count = 0;
				}
				break;
			case 8:
				for (int x = 0; x < height; x++)
				{
					for (int y = 0; y < height; y++)
					{
						if (AllOrb[x, y] == null && !isMoving)
						{
							Count++;
						}
						else if (Count > 0) 
						{
							AllOrb[x, y].GetComponent<Orbs>().row -= Count;
							AllOrb[x, y] = null;
						}
					}
					Count = 0;
				}
				break;
		}
		yield return new WaitForSeconds(.4f);
		StartCoroutine(Matching());
	}
	IEnumerator Matching()
	{
		while (Match_on_board())
		{
			yield return new WaitForSeconds(.1f);
			DestroyMatches();
		}
	}
	bool Match_on_board()
	{
		switch (height)
		{
			case 4:
				for (int x = 2; x < height + 2; x++)
				{
					for (int y = 2; y < height + 2; y++)
					{
						if (AllOrb[x, y] != null)
						{
							if (AllOrb[x, y].GetComponent<Orbs>().isMatch)
							{
								return true;
							}
						}
					}
				}
				break;
			case 6:
				for (int x = 1; x < height + 1; x++)
				{
					for (int y = 1; y < height + 1; y++)
					{
						if (AllOrb[x, y] != null)
						{
							if (AllOrb[x, y].GetComponent<Orbs>().isMatch)
							{
								return true;
							}
						}
					}
				}
				break;
			case 8:
				for (int x = 0; x < height; x++)
				{
					for (int y = 0; y < height; y++)
					{
						if (AllOrb[x, y] != null)
						{
							if (AllOrb[x, y].GetComponent<Orbs>().isMatch)
							{
								return true;
							}
						}
					}

				}
				break;
		}
		return false;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static string IngredientID = null;
    public static int ChildCount;
    int shape;
    public List<int> Orbcolor = new List<int>();
    char[] FindShape = { '-', ' '};
    char[] FindColor = { ',', ' ' };
    Int32 count = 2;
    private Vector3 scaleChange = new Vector3(1, 1, 0);
    string Orb;
    GameObject MyChild;
    Board board;
    Vector3 MyPOS;
    bool spawned;
	// Start is called before the first frame update
	private void Start()
	{
        board = FindObjectOfType<Board>();
        MyPOS = this.transform.position;
        Debug.Log(MyPOS);
    }
	void OnEnable()
    {
        Respawn();
	}
    // Update is called once per frame
    void Update()
    {
        if (spawned) 
        {
            Shadowing();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!ValidMoveHorizontal())
                transform.position -= new Vector3(-1, 0, 0);           
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!ValidMoveHorizontal())
                transform.position -= new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            board.S_Was_Pressed();
            GameManager.checkState = GameState.CookingInventory;
        }
    }
    void shapenume() 
    {
        string[] strlist = IngredientID.Split(FindShape, count, StringSplitOptions.None);
        shape = int.Parse(strlist[0]);
        Orb = strlist[1];
        AddColor();
		GameObject tmp = FindObjectOfType<GameManager>().Shape[shape];
		tmp.transform.localScale = scaleChange;
		tmp.GetComponent<Shape>().SpawnOrbcolor(Orbcolor);
        GameObject dot = Instantiate(tmp, transform.position, Quaternion.identity);
        dot.transform.parent = this.transform;
        MyChild = dot;
        spawned = true;
    }
    void AddColor() 
    {
        for (int i = 0; i < ChildCount; i++) 
        {
            string[] strlist = Orb.Split(FindColor, count, StringSplitOptions.None);
            int tmpint = int.Parse(strlist[0]);
			Orbcolor.Add(tmpint);
            Orb = strlist[1];
        }
    }
    public void DestroyChild() 
    {
        var child = new List<GameObject>();
        foreach (Transform children in transform) 
        {
            child.Add(children.gameObject);
        }
        child.ForEach(children => Destroy(children));
        spawned = false;
    }
    public void Respawn() 
    {
        Vector3 check = new Vector3(0, 0, 0);
        Orbcolor.Clear();
        shapenume();
        if (transform.position != MyPOS && MyPOS != check) 
        {
            transform.position = MyPOS;
        }
    }
    bool ValidMoveHorizontal()
    {
        foreach (Transform child in transform.GetChild(0)) 
        {
            int X = Mathf.RoundToInt(child.transform.position.x);
            switch (Board.height)
            {
                case 6:
                    if (X < 1 || X > Board.height)
                    {
                        return false;
                    }
                    break;
                case 4:
                    if (X < 2 || X > Board.height + 1)
                    {
                        return false;
                    }
                    break;
                case 8:
                    if (X < 0 || X >= Board.height)
                    {
                        return false;
                    }
                    break;
                default:
                    break;
            }
        }            
        return true;
    }
    bool PressS()
    {
        foreach (Transform child in transform.GetChild(0)) 
        {
            int x = (int)child.position.x;
            if (!board.CanYouPressS(x))
            {
                return false;
            }
        }
            
        return true;
    }
    void Shadowing()
    {
        board.Reset();
        if (PressS())
        {
            foreach (Transform child in transform.GetChild(0))
            {
                int x = (int)child.transform.position.x;
                int ID = child.GetComponent<Tile>().TileID;
                board.Hover(x, ID);
            }
            board.Draw();
        }
    }
}

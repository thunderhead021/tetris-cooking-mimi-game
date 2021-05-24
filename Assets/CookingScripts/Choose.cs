using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose : MonoBehaviour
{
    Board board;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Board.CanMove) 
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                transform.position += new Vector3(-1, 0, 0);
                if (!ValidMove())
                    transform.position -= new Vector3(-1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position += new Vector3(1, 0, 0);
                if (!ValidMove())
                    transform.position -= new Vector3(1, 0, 0);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                transform.position += new Vector3(0, 1, 0);
                if (!ValidMove())
                    transform.position -= new Vector3(0, 1, 0);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                transform.position += new Vector3(0, -1, 0);
                if (!ValidMove())
                    transform.position -= new Vector3(0, -1, 0);
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;
                board.Q_Was_Pressed(x, y);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                int x = (int)transform.position.x;
                int y = (int)transform.position.y;
                board.E_Was_Pressed(x, y);
            }
        }
    }
    bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            int X = Mathf.RoundToInt(child.transform.position.x);
            int Y = Mathf.RoundToInt(child.transform.position.y);
            switch (Board.height)
            {
                case 6:
                    if (X < 1 || X > Board.height || Y < 1 || Y > Board.height)
                    {
                        return false;
                    }
                    break;
                case 4:
                    if (X < 2 || X > Board.height + 1 || Y < 2 || Y > Board.height + 1)
                    {
                        return false;
                    }
                    break;
                case 8:
                    if (X < 0 || X >= Board.height || Y < 0 || Y >= Board.height)
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
}

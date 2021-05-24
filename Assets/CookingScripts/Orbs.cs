using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    FindMatch FindMatch;
    public int PosNum = 0;
    public int columm;
    public int row;
    public int targetX;
    public int targetY;
    public int Level = 0;
    public bool isMatch = false;
    Vector2 tmpPos;
    Board board;
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
        FindMatch = FindObjectOfType<FindMatch>();
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        row = targetY;
        columm = targetX;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.checkState == GameState.CookTime) 
        {
            targetX = columm;
            targetY = row;
            if (Mathf.Abs(targetX - transform.position.x) > .1)
            {
                tmpPos = new Vector2(targetX, transform.position.y);
                transform.position = Vector2.Lerp(transform.position, tmpPos, .6f);
                PosNum = 0;
                if (board.AllOrb[columm, row] != gameObject) 
                {
                    board.AllOrb[columm, row] = gameObject;
                }
                FindMatch.FindMatches();
            }
            else
            {
                tmpPos = new Vector2(targetX, transform.position.y);
                transform.position = tmpPos;
            }
            if (Mathf.Abs(targetY - transform.position.y) > .1)
            {
                tmpPos = new Vector2(transform.position.x, targetY);
                transform.position = Vector2.Lerp(transform.position, tmpPos, .4f);
                PosNum = 0;
                if (board.AllOrb[columm, row] != gameObject)
                {
                    board.AllOrb[columm, row] = gameObject;
                }
                FindMatch.FindMatches();
            }
            else
            {
                tmpPos = new Vector2(transform.position.x, targetY);
                transform.position = tmpPos;     
            }
		}
    }
    public void MoveOrb() 
    {   
        if (PosNum == 1) 
        {   //up
            row += 1;
        }
        else if (PosNum == 2)
        {   //left
            columm -= 1;
        }
        else if (PosNum == 3)
        {   //down
            row -= 1;
        }
        else if (PosNum == 4)
        {   //right
            columm += 1;
        }
        StartCoroutine(Checkmove());
    }
    IEnumerator Checkmove() 
    {
        yield return new WaitForSeconds(.2f);
        board.DestroyMatches();
    }
}

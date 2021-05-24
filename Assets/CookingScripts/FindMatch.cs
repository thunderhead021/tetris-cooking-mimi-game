using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMatch : MonoBehaviour
{
    Board board;
    public List<GameObject> Matches = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        board = FindObjectOfType<Board>();
    }
    IEnumerator FindALlMatches() 
    {
        yield return new WaitForSeconds(.2f);
        switch (Board.height) 
        {
            case 8:
                for (int x = 0; x < Board.height; x++) 
                {
                    for (int y = 0; y < Board.height; y++) 
                    {
                        GameObject curOrb = board.AllOrb[x, y];
                        if (curOrb != null 
                            && curOrb.GetComponent<Orbs>().Level < 2)
                        {
                            if (x > 0 && x < Board.height - 1)
                            {
                                GameObject LeftOrb = board.AllOrb[x - 1, y];
                                GameObject RightOrb = board.AllOrb[x + 1, y];
                                if (LeftOrb != null && RightOrb != null) 
                                {
                                    if (LeftOrb.tag == curOrb.tag && RightOrb.tag == curOrb.tag 
                                        && curOrb.GetComponent<Orbs>().Level == LeftOrb.GetComponent<Orbs>().Level 
                                        && curOrb.GetComponent<Orbs>().Level == RightOrb.GetComponent<Orbs>().Level) 
                                    {
                                        LeftOrb.GetComponent<Orbs>().isMatch = true;
                                        RightOrb.GetComponent<Orbs>().isMatch = true;
                                        curOrb.GetComponent<Orbs>().Level += 1;
                                    }
                                }
                            }
                            if (y > 0 && y < Board.height - 1)
                            {
                                GameObject DownOrb = board.AllOrb[x, y - 1];
                                GameObject UpOrb = board.AllOrb[x, y + 1];
                                if (DownOrb != null && UpOrb != null)
                                {
                                    if (DownOrb.tag == curOrb.tag && UpOrb.tag == curOrb.tag
                                        && curOrb.GetComponent<Orbs>().Level == DownOrb.GetComponent<Orbs>().Level
                                        && curOrb.GetComponent<Orbs>().Level == UpOrb.GetComponent<Orbs>().Level)
                                    {
                                        DownOrb.GetComponent<Orbs>().isMatch = true;
                                        UpOrb.GetComponent<Orbs>().isMatch = true;
                                        curOrb.GetComponent<Orbs>().Level += 1;
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            case 6:
                for (int x = 1; x < Board.height + 1; x++)
                {
                    for (int y = 1; y < Board.height + 1; y++)
                    {
                        GameObject curOrb = board.AllOrb[x, y];
                        if (curOrb != null
                            && curOrb.GetComponent<Orbs>().Level < 2)
                        {
                            if (x > 1 && x < Board.height)
                            {
                                GameObject LeftOrb = board.AllOrb[x - 1, y];
                                GameObject RightOrb = board.AllOrb[x + 1, y];
                                if (LeftOrb != null && RightOrb != null)
                                {
                                    if (LeftOrb.tag == curOrb.tag && RightOrb.tag == curOrb.tag
                                        && curOrb.GetComponent<Orbs>().Level == LeftOrb.GetComponent<Orbs>().Level
                                        && curOrb.GetComponent<Orbs>().Level == RightOrb.GetComponent<Orbs>().Level)
                                    {
                                        LeftOrb.GetComponent<Orbs>().isMatch = true;
                                        RightOrb.GetComponent<Orbs>().isMatch = true;
                                        curOrb.GetComponent<Orbs>().Level += 1;
                                    }
                                }
                            }
                            if (y > 1 && y < Board.height)
                            {
                                GameObject DownOrb = board.AllOrb[x, y - 1];
                                GameObject UpOrb = board.AllOrb[x, y + 1];
                                if (DownOrb != null && UpOrb != null)
                                {
                                    if (DownOrb.tag == curOrb.tag && UpOrb.tag == curOrb.tag
                                        && curOrb.GetComponent<Orbs>().Level == DownOrb.GetComponent<Orbs>().Level
                                        && curOrb.GetComponent<Orbs>().Level == UpOrb.GetComponent<Orbs>().Level)
                                    {
                                        DownOrb.GetComponent<Orbs>().isMatch = true;
                                        UpOrb.GetComponent<Orbs>().isMatch = true;
                                        curOrb.GetComponent<Orbs>().Level += 1;
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            case 4:
                for (int x = 2; x < Board.height + 2; x++)
                {
                    for (int y = 2; y < Board.height + 2; y++)
                    {
                        GameObject curOrb = board.AllOrb[x, y];
                        if (curOrb != null
                            && curOrb.GetComponent<Orbs>().Level < 2)
                        {
                            if (x > 2 && x < Board.height + 1)
                            {
                                GameObject LeftOrb = board.AllOrb[x - 1, y];
                                GameObject RightOrb = board.AllOrb[x + 1, y];
                                if (LeftOrb != null && RightOrb != null)
                                {
                                    if (LeftOrb.tag == curOrb.tag && RightOrb.tag == curOrb.tag
                                        && curOrb.GetComponent<Orbs>().Level == LeftOrb.GetComponent<Orbs>().Level
                                        && curOrb.GetComponent<Orbs>().Level == RightOrb.GetComponent<Orbs>().Level)
                                    {
                                        LeftOrb.GetComponent<Orbs>().isMatch = true;
                                        RightOrb.GetComponent<Orbs>().isMatch = true;
                                        curOrb.GetComponent<Orbs>().Level += 1;
                                    }
                                }
                            }
                            if (y > 2 && y < Board.height + 1)
                            {
                                GameObject DownOrb = board.AllOrb[x, y - 1];
                                GameObject UpOrb = board.AllOrb[x, y + 1];
                                if (DownOrb != null && UpOrb != null)
                                {
                                    if (DownOrb.tag == curOrb.tag && UpOrb.tag == curOrb.tag
                                        && curOrb.GetComponent<Orbs>().Level == DownOrb.GetComponent<Orbs>().Level
                                        && curOrb.GetComponent<Orbs>().Level == UpOrb.GetComponent<Orbs>().Level)
                                    {
                                        DownOrb.GetComponent<Orbs>().isMatch = true;
                                        UpOrb.GetComponent<Orbs>().isMatch = true;
                                        curOrb.GetComponent<Orbs>().Level += 1;
                                    }
                                }
                            }
                        }
                    }
                }
                break;

        }
    }
    public void FindMatches() 
    {
        StartCoroutine(FindALlMatches());
    }
}

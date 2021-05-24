using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public GameObject[] Shape;
    public GameObject[] Orb;
    List<int> Orbcolor = new List<int>();
	GameManager gameManager;
    public string tmpID = null;
    private string IngredientsID;
    private Vector3 scaleChange = new Vector3(50, 50, 0);
    int tmpShapenum;
    public int childCount;
    // Start is called before the first frame update
    void Awake()
    {
		gameManager = FindObjectOfType<GameManager>();
        Init();
        IngredientsID = tmpID;
        Debug.Log(IngredientsID);
        Debug.Log(childCount);
    }
	private void OnMouseEnter()
	{
        this.transform.GetChild(0).gameObject.SetActive(true);
	}
    private void OnMouseExit()
	{
        this.transform.GetChild(0).gameObject.SetActive(false);
    }
    void Init() 
    {
        for (int m = 0; m < Orb.Length; m++)
        {
            for (int n = 0; n < gameManager.dots.Length; n++)
            {
                if (Orb[m] == gameManager.dots[n])
                {
                    Orbcolor.Add(n);
                }
            }
        }
        int Shapenum = Random.Range(0, Shape.Length);
		IngredientID(Shapenum);
        Shape[Shapenum].GetComponent<Shape>().Orbcolor(Orbcolor, this.gameObject);
        Shape[Shapenum].transform.localScale = scaleChange;
		Vector3 tmppos = new Vector3(transform.position.x + 20, transform.position.y - 80, transform.position.z);
        GameObject dot = Instantiate(Shape[Shapenum], tmppos, Quaternion.identity);
        dot.transform.parent = this.transform;
        childCount = Shape[Shapenum].gameObject.transform.childCount;
    }
	void IngredientID(int Shapenum) 
	{
		for (int i = 0; i < gameManager.Shape.Length; i++)
		{
			if (gameManager.Shape[i] == Shape[Shapenum])
			{
				tmpShapenum = i;
			}
		}
        tmpID = (tmpShapenum.ToString() + "-");
	}

}

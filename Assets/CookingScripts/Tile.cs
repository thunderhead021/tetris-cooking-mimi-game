using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameObject[] dots;
    public int TileID = 0;
    private int tmpID = 0;
    public Vector3 scaleChange;
    //public float AlphaLvl = 0;
    void Start()
    {
        Init(TileID);
        tmpID = TileID;
    }

    // Update is called once per frame
    void Update()
    {
        if (TileID != tmpID)
        {
            Init(TileID);
            tmpID = TileID;
        }
	}
    void Init(int ID)
    {
        DestroyChild();
        dots[ID].transform.localScale = scaleChange;
        GameObject dot = Instantiate(dots[ID], transform.position, Quaternion.identity);
		//if (AlphaLvl != 0)
		//{
  //          dot.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, AlphaLvl);
		//}
		dot.transform.parent = this.transform;
    }
    void DestroyChild()
    {
        var child = new List<GameObject>();
        foreach (Transform children in transform)
        {
            child.Add(children.gameObject);
        }
        child.ForEach(children => Destroy(children));
    }
}

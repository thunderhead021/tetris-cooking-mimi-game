using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    // Start is called before the first frame update
	public void Orbcolor(List<int> Orbnum, GameObject gameObject) 
    {
        foreach (Transform child in transform)
        {
            int pickOrb = Random.Range(0, Orbnum.Count);
            int Orb = Orbnum[pickOrb];
			child.GetComponent<Tile>().TileID = Orb;
            child.GetComponent<Tile>().scaleChange = new Vector3(50, 50, 0);
            string tmp = Orb.ToString() + ",";
            gameObject.GetComponent<Ingredients>().tmpID += tmp;            
		}
    }
    public void SpawnOrbcolor(List<int> Orbnum)
    {
        int num = 0;
		foreach (Transform child in transform)
		{
			int Orb = Orbnum[num];
            child.GetComponent<Tile>().TileID = Orb;
            child.GetComponent<Tile>().scaleChange = new Vector3(1, 1, 0);
            num++;
		}
	}

}

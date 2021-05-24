using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public GameObject[] Ingredients;
    string SlotID;
    string TmpID;
    int TmpCount;
    int ID;
    GameManager gameManager;
    static int num = 1;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ID = num;
		NewIngredients();
        num += 1;
    }
    public void NewIngredients()
    {
        int i = Random.Range(0, Ingredients.Length);
        GameObject dot = Instantiate(Ingredients[i], transform.position, Quaternion.identity); 
        dot.transform.parent = this.transform;
        TmpID = dot.GetComponent<Ingredients>().tmpID;
        TmpCount = dot.GetComponent<Ingredients>().childCount;
        SlotID = i.ToString() + "|" + TmpID;
    }
    public void OnItemClicked() 
    {
		Spawn.IngredientID = this.TmpID;
		Spawn.ChildCount = this.TmpCount;
        if (GameManager.checkState != GameState.PrefTime)
            GameManager.checkState = GameState.PrefTime;
        else 
        {
            gameManager.Spawn.GetComponent<Spawn>().DestroyChild();
            gameManager.Spawn.GetComponent<Spawn>().Respawn();
        }
    }
}

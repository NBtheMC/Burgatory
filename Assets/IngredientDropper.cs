using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredientDropper : MonoBehaviour
{
    public List<string> ingredientsToDrop;
    private float speed;
    private float timer;
    private float range;

    [SerializeField] private GameObject lettuce;
    [SerializeField] private GameObject tomato;
    [SerializeField] private GameObject bun;
    [SerializeField] private GameObject cheese;

    void Awake(){
        //ingredientsToDrop = new List<string>() 
    }

    // Start is called before the first frame update
    void Start()
    {
        //Testing numbers
        timer = 0;
        speed = 2; //will change later
        range = 2;
        //Test list
        // ingredientsToDrop = new List<string>();
        // ingredientsToDrop.Add("bun");
        // ingredientsToDrop.Add("cheese");
        // ingredientsToDrop.Add("cheese");
        // ingredientsToDrop.Add("bun");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= speed){
            if(ingredientsToDrop.Count == 0){
                EndDrop();
            }
            DropIngredient();
            ingredientsToDrop.RemoveAt(0);
            timer = 0;
        }
    }

    //Used by some other script to set up order of ingredients to drop
    public void GiveIngredientsToDrop(List<string> ingredients){
        ingredientsToDrop = ingredients;
        return;
    }


    //Get next ingredient in drop list and drop it
    void DropIngredient(){
        Vector3 positionToDrop = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(Random.Range(-range, range), 0, 0);
        string nextIngredientToDrop = ingredientsToDrop[0];
        switch(nextIngredientToDrop){
            case "lettuce":
                Instantiate(lettuce, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case "tomato":
                Instantiate(tomato, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case "bun":
                Instantiate(bun, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                break;
            case "cheese":
                Instantiate(cheese, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                break;
        }
    }

    //ends the burgermaking phase and gives data back to customer service
    void EndDrop(){
        Debug.Log("Switched Scene");
    }
}

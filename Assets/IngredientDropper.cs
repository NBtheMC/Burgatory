using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngredientDropper : MonoBehaviour
{
    public List<string> ingredientsToDrop;
    private float speed;
    private float timer;
    private float range;

    //PREFABS
    [SerializeField] private GameObject lettuce;
    [SerializeField] private GameObject tomato;
    [SerializeField] private GameObject cheese;
    [SerializeField] private GameObject bun;

    //SPAWNING BUTTONS
    [SerializeField] private Button lettuceButton;
    [SerializeField] private Button tomatoButton;
    [SerializeField] private Button cheeseButton;
    [SerializeField] private Button bunButton;

    //TIMER LOGIC
    private bool lettuceCanSpawn;
    private bool tomatoCanSpawn;
    private bool cheeseCanSpawn;
    private bool bunCanSpawn;

    private float lettuceTimer;
    private float tomatoTimer;
    private float cheeseTimer;
    private float bunTimer;

    void Awake(){
        //ingredientsToDrop = new List<string>() 
        lettuceCanSpawn = true;
        tomatoCanSpawn = true;
        cheeseCanSpawn = true;
        bunCanSpawn = true;
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
        // One at a time dropping based on list
        // timer += Time.deltaTime;
        // if(timer >= speed){
        //     if(ingredientsToDrop.Count == 0){
        //         EndDrop();
        //     }
        //     DropIngredient();
        //     ingredientsToDrop.RemoveAt(0);
        //     timer = 0;
        // }
        // Timer updating
        lettuceTimer -= Time.deltaTime;
        tomatoTimer -= Time.deltaTime;
        cheeseTimer -= Time.deltaTime;
        bunTimer -= Time.deltaTime;
    }

    //Used by some other script to set up order of ingredients to drop
    public void GiveIngredientsToDrop(List<string> ingredients){
        ingredientsToDrop = ingredients;
        return;
    }


    //Get next ingredient in drop list and drop it
    public void DropIngredient(string ingredient){
        Vector3 positionToDrop = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(Random.Range(-range, range), 0, 0);
        //string nextIngredientToDrop = ingredientsToDrop[0];
        switch(ingredient){
            case "lettuce":
                if(lettuceTimer <= 0){
                    Instantiate(lettuce, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                    lettuceTimer = timer;
                }
                break;
            case "tomato":
                if(tomatoTimer <= 0){
                    Instantiate(tomato, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                    tomatoTimer = timer;
                }                
                break;
            case "cheese":
                if(cheeseTimer <= 0){
                    Instantiate(cheese, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                    cheeseTimer = timer;
                }
                break;
            case "bun":
                if(bunTimer <= 0){
                    Instantiate(bun, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                    bunTimer = timer;
                }
                break;
        }
    }

    //ends the burgermaking phase and gives data back to customer service
    void EndDrop(){
        Debug.Log("Switched Scene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngredientDropper : MonoBehaviour
{
    public List<string> burgerToMake;
    public List<string> currentBurger;
    private List<GameObject> currentPrefabs;
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
    private float lettuceTimer;
    private float tomatoTimer;
    private float cheeseTimer;
    private float bunTimer;

    void Awake(){
        burgerToMake = new List<string>();
        currentBurger = new List<string>();
        currentPrefabs = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //Testing numbers
        timer = 2;
        speed = 2; //will change later
        range = 2;
        lettuceTimer = timer;
        tomatoTimer = timer;
        cheeseTimer = timer;
        bunTimer = timer;
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
        if(lettuceTimer <= 0){
            lettuceButton.interactable = true;
        }
        tomatoTimer -= Time.deltaTime;
        if(tomatoTimer <= 0){
            tomatoButton.interactable = true;
        }
        cheeseTimer -= Time.deltaTime;
        if(cheeseTimer <= 0){
            cheeseButton.interactable = true;
        }
        bunTimer -= Time.deltaTime;
        if(bunTimer <= 0){
            bunButton.interactable = true;
        }
    }



    //Get next ingredient in drop list and drop it
    public void DropIngredient(string ingredient){
        Vector3 positionToDrop = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z) + new Vector3(Random.Range(-range, range), 0, 0);
        //string nextIngredientToDrop = ingredientsToDrop[0];
        switch(ingredient){
            case "lettuce":
                // if(lettuceTimer <= 0){
                    GameObject newLettuce = Instantiate(lettuce, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                    currentPrefabs.Add(newLettuce);
                    lettuceTimer = timer;
                    lettuceButton.interactable = false;
                // }
                break;
            case "tomato":
                // if(tomatoTimer <= 0){
                    GameObject newTomato = Instantiate(tomato, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                    currentPrefabs.Add(newTomato);
                    tomatoTimer = timer;
                    tomatoButton.interactable = false;
                // }                
                break;
            case "cheese":
                // if(cheeseTimer <= 0){
                    GameObject newCheese = Instantiate(cheese, positionToDrop, new Quaternion(0f, 0f, 0f, 0f)) as GameObject;
                    currentPrefabs.Add(newCheese);
                    cheeseTimer = timer;
                    cheeseButton.interactable = false;
                // }
                break;
            case "bun":
                // if(bunTimer <= 0){
                    GameObject newBun = Instantiate(bun, positionToDrop, new Quaternion(0f, 0f, 0f, 0f));
                    currentPrefabs.Add(newBun);
                    bunTimer = timer;
                    bunButton.interactable = false;
                // }
                break;
        }
    }

    //Used by some other script to set up order of ingredients to drop
    public void GiveIngredientsToDrop(List<string> ingredients){
        burgerToMake = ingredients;
        return;
    }

    //ends the burgermaking phase and gives data back to customer service
    void FinishedBurger(){
        Debug.Log("Switched Scene");
    }

    public void DumpBurger(){
        foreach(GameObject i in currentPrefabs){
            Destroy(i);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    List<string> ingredients = new List<string>();
    List<string> burger = new List<string>();
    
    // Start is called before the first frame update
    void Start()
    {
        ingredients.Add("bun");
        ingredients.Add("lettuce");
        ingredients.Add("tomato");
        ingredients.Add("cheese");
        ingredients.Add("patty");
    }

    void generateBurger(int size)
    {
        burger.Add(ingredients[0]);
        for(int i = 0; i < size; i++)
        {
            burger.Add(ingredients[UnityEngine.Random.Range(1, 5)]);
        }
        burger.Add(ingredients[0]);
        for(int j = 0; j < burger.Count; j++)
        {
            UnityEngine.Debug.Log(burger[j]);
        }
        //UnityEngine.Debug.Log(burger.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            generateBurger(3);
        }
    }
}

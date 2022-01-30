using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;

public class burgerChecker : MonoBehaviour
{
    private GameObject[] ingredientsInField;
    private List<string> burgerMade = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void checkBurger()
    {
        
        ingredientsInField = GameObject.FindGameObjectsWithTag("Ingredient");
        if (ingredientsInField.Length > 0)
        {
            for (int i = 0; i < ingredientsInField.Length; i++)
            {
                //UnityEngine.Debug.Log(ingredientsInField[i].name);
                if (ingredientsInField[i].name.IndexOf("lettuce", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    burgerMade.Add("lettuce");
                }
                else if (ingredientsInField[i].name.IndexOf("bun", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    burgerMade.Add("bun");
                }
                else if (ingredientsInField[i].name.IndexOf("cheese", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    burgerMade.Add("cheese");
                }
                else if (ingredientsInField[i].name.IndexOf("patty", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    burgerMade.Add("patty");
                }
                else if (ingredientsInField[i].name.IndexOf("tomato", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    burgerMade.Add("tomato");
                }
            }
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            checkBurger();
        }
    }
}

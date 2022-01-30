using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerChecker : MonoBehaviour
{
    private GameObject[] ingredientsInField;
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
                UnityEngine.Debug.Log(ingredientsInField[i].name);
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

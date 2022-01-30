using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    List<string> ingredients = new List<string>();
    List<string> burger = new List<string>();
    float maxTimer = 60f;
    float currentTimer;
    public Image timerImage;
    bool waitingForOrder;
    public Text orderTextBox;
    private string orderText;

    // Start is called before the first frame update
    void Start()
    {
        waitingForOrder = false;
        currentTimer = maxTimer;
        ingredients.Add("bun");
        ingredients.Add("lettuce");
        ingredients.Add("tomato");
        ingredients.Add("cheese");
        ingredients.Add("patty");
    }

    void generateBurger(int size)
    {
        burger.Clear();
        orderText = string.Empty;
        burger.Add(ingredients[0]);
        for(int i = 0; i < size; i++)
        {
            burger.Add(ingredients[UnityEngine.Random.Range(1, 5)]);
        }
        burger.Add(ingredients[0]);
        for(int j = 0; j < burger.Count; j++)
        {
            orderText = orderText + burger[j] + "\n";
            UnityEngine.Debug.Log(burger[j]);
        }
        orderTextBox.text = orderText;
        waitingForOrder = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        timerImage.fillAmount = currentTimer / maxTimer;
        if (waitingForOrder)
        {
            currentTimer -= Time.deltaTime;
        }

        if (Input.GetKeyDown("space"))
        {
            generateBurger(3);
        }
    }
}

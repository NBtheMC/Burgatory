using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    List<string> ingredients = new List<string>();
    List<string> burger = new List<string>();
    float maxTimer = 15f;
    float currentTimer;
    public Image timerImage;
    bool waitingForOrder;
    public Text orderTextBox;
    private string orderText;
    public GameObject biasChecker;
    string side;

    // Start is called before the first frame update
    void Awake()
    {
        biasChecker = GameObject.Find("BalanceCheckerObj");
        waitingForOrder = false;
        currentTimer = maxTimer;
        ingredients.Add("bun");
        ingredients.Add("lettuce");
        ingredients.Add("tomato");
        ingredients.Add("cheese");
        ingredients.Add("patty");
    }

    public void generateBurger(int size)
    {
        burger.Clear();
        orderText = string.Empty;
        
        burger.Add(ingredients[0]);
        UnityEngine.Debug.Log("Reached here");
        for (int i = 0; i < size; i++)
        {
            burger.Add(ingredients[UnityEngine.Random.Range(1, 5)]);
        }
        burger.Add(ingredients[0]);
        for(int j = 0; j < burger.Count; j++)
        {
            orderText = orderText + burger[j] + "\n";
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
            generateBurger(UnityEngine.Random.Range(3, 6));
        }
        if (waitingForOrder && currentTimer <= 0f)
        {
            leaveAngry();
        }
    }
    void leaveAngry()
    {
        UnityEngine.Debug.Log("Well, I never!");
        switch (side)
        {
            case "left":
                biasChecker.GetComponent<BalanceChecker>().increaseNumber(-30);
                break;
            case "right":
                biasChecker.GetComponent<BalanceChecker>().increaseNumber(30);
                break;
        }
        
        Destroy(gameObject);
    }
    void leaveHappy()
    {
        switch (side)
        {
            case "left":
                biasChecker.GetComponent<BalanceChecker>().increaseNumber(10);
                break;
            case "right":
                biasChecker.GetComponent<BalanceChecker>().increaseNumber(-10);
                break;
        }
    }
    public void pickSide(string chosenSide)
    {
        side = chosenSide;
    }
}

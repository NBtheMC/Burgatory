using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceChecker : MonoBehaviour
{

    public GameObject arrow;
    public GameObject leftSide;
    public GameObject rightSide; 
    public Sprite[] leftSprites; //side A
    public Sprite[] rightSprites; //side B
    private float balanceNum;
    private float currentRotation;
    int failedOrders;
    int allowedFails;
    private float lossTimer;
    bool losing;
    // Start is called before the first frame update
    void Start()
    {
        losing = false;
        lossTimer = 10f;
        failedOrders = 0;
        allowedFails = 3;
        balanceNum = 0f;
        currentRotation = 0f;
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentRotation);
        updateSides();
    }

    // Update is called once per frame
    void Update()
    {
        if(losing && lossTimer > 0)
        {
            lossTimer -= Time.deltaTime;
            UnityEngine.Debug.Log("You are losing!");
        }
        else if (losing && lossTimer <= 0)
        {
            loseGame();
        }
        if (Input.GetKeyDown("q"))
        {
            increaseNumber(10);
        }
        if (Input.GetKeyDown("e"))
        {
            increaseNumber(-10);
        }
    }

    public void increaseNumber(int num)
    {
        //currentRotation += num;
        if(balanceNum + num > 90)
        {
            balanceNum = 90;
        }
        else if (balanceNum + num < -90)
        {
            balanceNum = -90;
        }
        else
        {
            balanceNum += num;
        }
        rotateArrow();
        updateSides();
    }

    void updateSides()
    {
        switch (balanceNum)
        {
            //Perfect balance
            case float n when balanceNum == 0f:
                UnityEngine.Debug.Log("Perfectly balanced");
                //sideA.GetComponent<Image>().color = Color.white;
                leftSide.GetComponent<Image>().sprite = leftSprites[0];
                rightSide.GetComponent<Image>().sprite = rightSprites[0];
                //sideB.GetComponent<Image>().color = Color.white;
                break;
            //slight A
            case float n when (balanceNum >= 30f && balanceNum < 60):
                //sideA.GetComponent<Image>().color = new Color32(86, 255, 0, 255);
                leftSide.GetComponent<Image>().sprite = leftSprites[1];
                rightSide.GetComponent<Image>().sprite = rightSprites[4];
                //sideB.GetComponent<Image>().color = new Color32(221, 161, 47, 255);
                UnityEngine.Debug.Log("Slight advantage towards A");
                break;
            //heavy A
            case float n when (balanceNum >= 60 && balanceNum < 90):
                //sideA.GetComponent<Image>().color = new Color32(12, 184, 202, 255);
                leftSide.GetComponent<Image>().sprite = leftSprites[3];
                rightSide.GetComponent<Image>().sprite = rightSprites[2];
                //sideB.GetComponent<Image>().color = new Color32(241, 79, 28, 255);
                UnityEngine.Debug.Log("Heavy advantage towards A");
                resetLosing();
                break;
            //complete A
            case float n when balanceNum >= 90f:
                leftSide.GetComponent<Image>().sprite = leftSprites[3];
                rightSide.GetComponent<Image>().sprite = rightSprites[2];
                //UnityEngine.Debug.Log("Complete bias towards A");
                losing = true;
                break;
            //slight B
            case float n when (balanceNum <= -30f && balanceNum > -60):
                leftSide.GetComponent<Image>().sprite = leftSprites[4];
                rightSide.GetComponent<Image>().sprite = rightSprites[1];
                UnityEngine.Debug.Log("Slight advantage towards B");
                break;
            //heavy B
            case float n when (balanceNum <= -60 && balanceNum > -90):
                leftSide.GetComponent<Image>().sprite = leftSprites[2];
                rightSide.GetComponent<Image>().sprite = rightSprites[3];
                UnityEngine.Debug.Log("Heavy advantage towards B");
                resetLosing();
                break;
            //complete B
            case float n when balanceNum == -90f:
                leftSide.GetComponent<Image>().sprite = leftSprites[2];
                rightSide.GetComponent<Image>().sprite = rightSprites[3];
                UnityEngine.Debug.Log("Complete bias towards B");
                losing = true;
                break;
        }
    }
    public float getBalanceNum()
    {
        return balanceNum;
    }
    void rotateArrow()
    {
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, balanceNum);
    }
    void resetLosing()
    {
        losing = false;
        lossTimer = 10f;
        UnityEngine.Debug.Log("Timer reset");
    }
    void loseGame()
    {
        UnityEngine.Debug.Log("Lost Game");
    }
}

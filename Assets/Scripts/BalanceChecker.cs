using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceChecker : MonoBehaviour
{

    public GameObject arrow;
    public GameObject sideA;
    public GameObject sideB;
    private float balanceNum;
    private float currentRotation;
    // Start is called before the first frame update
    void Start()
    {
        balanceNum = 0f;
        currentRotation = 0f;
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentRotation);
        updateSides();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            increaseNumber(10);
        }
        if (Input.GetKeyDown("e"))
        {
            increaseNumber(-10);
        }
    }

    void increaseNumber(int num)
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
                sideA.GetComponent<Image>().color = Color.white;
                sideB.GetComponent<Image>().color = Color.white;
                break;
            //slight A
            case float n when (balanceNum >= 30f && balanceNum < 60):
                sideA.GetComponent<Image>().color = new Color32(86, 255, 0, 255);
                sideB.GetComponent<Image>().color = new Color32(221, 161, 47, 255);
                UnityEngine.Debug.Log("Slight advantage towards A");
                break;
            //heavy A
            case float n when (balanceNum >= 60 && balanceNum < 90):
                UnityEngine.Debug.Log("Heavy advantage towards A");
                break;
            //complete A
            case float n when balanceNum == 90f:
                UnityEngine.Debug.Log("Complete bias towards A");
                break;
            //slight B
            case float n when (balanceNum <= -30f && balanceNum > -60):
                UnityEngine.Debug.Log("Slight advantage towards B");
                break;
            //heavy B
            case float n when (balanceNum <= -60 && balanceNum > -90):
                UnityEngine.Debug.Log("Heavy advantage towards B");
                break;
            //complete B
            case float n when balanceNum == -90f:
                UnityEngine.Debug.Log("Complete bias towards B");
                break;
        }
        /*if(balanceNum == 0)
        {
            sideA.GetComponent<Image>().color = Color.white;
            sideB.GetComponent<Image>().color = Color.white;

        }
        if (balanceNum > 30)
        {
            sideA.GetComponent<Image>().color = Color.green;
            sideB.GetComponent<Image>().color = new Color32(221, 161, 47, 255);
        }*/
    }

    void rotateArrow()
    {
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, balanceNum);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceChecker : MonoBehaviour
{

    public GameObject arrow;
    private float balanceNum;
    private float currentRotation;
    // Start is called before the first frame update
    void Start()
    {
        balanceNum = 0f;
        currentRotation = 0f;
        arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentRotation);
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.Debug.Log(currentRotation);
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
        balanceNum += num;
        rotateArrow(num);
    }

    void rotateArrow(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            currentRotation++;
            arrow.transform.rotation = Quaternion.Euler(0.0f, 0.0f, currentRotation);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerGenerator : MonoBehaviour
{
    //Game objects and locations
    public GameObject customer;
    public Transform leftCustomerLocation;
    public Transform rightCustomerLocation;
    //Timer that will count down
    float currentSpawnTimerLeft;
    float currentSpawnTimerRight;
    //Timer value
    float maxTimeLeft = 10f;
    float maxTimeRight = 10f;
    //Check waiting
    bool waitingForLeft = false;
    bool waitingForRight = false;
    //
    float checkTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawnTimerLeft = maxTimeLeft;
        currentSpawnTimerRight = maxTimeRight;
    }

    // Update is called once per frame
    void Update()
    {
        if (!waitingForLeft)
        {
            currentSpawnTimerLeft -= Time.deltaTime;
        }
        if (!waitingForRight)
        {
            currentSpawnTimerRight -= Time.deltaTime;
        }
        if (!waitingForLeft && currentSpawnTimerLeft <= 0)
        {
            spawnCustomer("left");
        }
        if (!waitingForRight && currentSpawnTimerRight <= 0)
        {
            spawnCustomer("right");
        }
        if ((waitingForRight || waitingForLeft) && (checkTimer > 0))
        {
            checkTimer -= Time.deltaTime;
        }
        if ((waitingForLeft || waitingForRight) && (checkTimer <= 0))
        {
            checkForVacancy();
        }
        
        //spawn left customer

        if (Input.GetKeyDown("z"))
        {
            spawnCustomer("left");
        }
        if (Input.GetKeyDown("x"))
        {
            spawnCustomer("right");
        }
    }

    void spawnCustomer(string side)
    {
        switch (side)
        {
            case "left":
                GameObject leftCustomerCopy = Instantiate(customer, leftCustomerLocation.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
                leftCustomerCopy.GetComponent<Customer>().pickSide(side);
                leftCustomerCopy.GetComponent<Customer>().generateBurger(3);
                waitingForLeft = true;
                currentSpawnTimerLeft = maxTimeLeft;
                break;
            case "right":
                GameObject rightCustomerCopy = Instantiate(customer, rightCustomerLocation.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
                rightCustomerCopy.GetComponent<Customer>().pickSide(side);
                rightCustomerCopy.GetComponent<Customer>().generateBurger(3);
                currentSpawnTimerRight = maxTimeRight;
                waitingForRight = true;
                break;
        }
    }
    void checkForVacancy()
    {
        checkTimer = 5f;
    }
    public void provideVacancy(string side)
    {
        switch (side)
        {
            case "left":
                waitingForLeft = false;
                break;
            case "right":
                waitingForRight = false;
                break;
        }
    }
}

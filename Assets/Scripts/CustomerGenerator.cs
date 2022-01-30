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
                break;
            case "right":
                GameObject rightCustomerCopy = Instantiate(customer, rightCustomerLocation.position, Quaternion.identity, GameObject.FindGameObjectWithTag("Canvas").transform);
                rightCustomerCopy.GetComponent<Customer>().pickSide(side);
                rightCustomerCopy.GetComponent<Customer>().generateBurger(3);
                break;
        }
    }
}

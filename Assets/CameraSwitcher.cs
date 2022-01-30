using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform pointA; //Title
    [SerializeField] Transform pointB; //Serving
    [SerializeField] Transform pointC; //Burger
    private int currentPoint; //1 for A, 2 for B

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = 1;
        cam.transform.position = pointB.position;
    }

    public IEnumerator SwitchToBurger(){
        Gotoposition = pointC;
        float elapsedTime = 0;
        float waitTime = 3f;
        currentPos = transform.position;
 
        while (elapsedTime < waitTime){
            transform.position = Vector3.Lerp(currentPos, pointC, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
        }
        return null;
    }

    // public void SwitchToBurger(){
    //     if(currentPoint == 1){
    //         cam.transform.position = Vector3.Lerp(cam.transform.position, pointB.position, .5f);
    //         currentPoint = 2;

    //     }
    // }

    public void SwitchToServing(){
        if(currentPoint == 2){
            cam.transform.position = Vector3.Lerp(cam.transform.position, pointA.position, .5f);
            currentPoint = 1;
        }
    }
}

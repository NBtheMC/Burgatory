using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Transform pointA; //Title
    [SerializeField] Transform pointB; //Serving
    [SerializeField] Transform pointC; //Burger
    [SerializeField] Transform pointD; //Results
    private int currentPoint; //1 for A, 2 for B

    //public IEnumerator MoveDown;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = 1;
        //cam.transform.position = pointA.position;
    }

    public IEnumerator MoveDown(){
        Debug.Log("Moving down");
        float elapsedTime = 0;
        float waitTime = 1f;
        //currentPos = transform.position;
 
        while (elapsedTime < waitTime){
            cam.transform.position = Vector3.Lerp(cam.transform.position, pointC.position, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //return null;
    }

    public IEnumerator MoveUp(){
        Debug.Log("Moving up");
        float elapsedTime = 0;
        float waitTime = 1f;
        //currentPos = transform.position;
 
        while (elapsedTime < waitTime){
            cam.transform.position = Vector3.Lerp(cam.transform.position, pointB.position, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        //return null;
    }

    public void SwitchToBurger(){
        StartCoroutine(MoveDown());
    }

    public void SwitchToServing(){
        StartCoroutine(MoveUp());
    }

    public void StartGame(){
        SwitchToServing();
        
    }

    public void EndGame(){

    }
}

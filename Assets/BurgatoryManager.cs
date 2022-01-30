using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BurgatoryManager : MonoBehaviour
{
    public enum GameState{
        Title,
        Serving,
        GameOver,
        Results
    }
    [SerializeField] public CameraSwitcher cameraSwitcher;
    public GameState state;
    public int score; //number of customers served
    public Text scoreText;
    public float timer; //time spent in extremes of meter
    [SerializeField] private BalanceChecker meter; //Holds the meter number.. Need to update to the gameObject

    GameObject results;

    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        state = GameState.Title;
        results = Resources.Load<GameObject>("Results");
    }

    // Update is called once per frame
    void Update()
    {
        //Check if meter is too high or too low
        // if(meter > 80 || meter < -80){
        //     timer -= Time.deltaTime;
        // }
        // //refresh
        // else{
        //     timer += Time.deltaTime * 2;
        // }
        // if(timer >= 10){
        //     timer = 10;
        // }

        // if(timer <= 0){
        //     FailGame();
        // }
    }

    //called when 
    void FailGame(){
        //move to other screen or something

        //Create UI element that shows score
        GameObject resultsBox = Instantiate(results);
        resultsBox.transform.Find("Canvas").Find("OkButton").GetComponent<Button>().onClick.AddListener(delegate { DeleteResultsBox(resultsBox); });
        Text resultsBoxScore = resultsBox.transform.Find("Canvas").Find("Text").GetComponent<Text>();
        resultsBoxScore.text = score.ToString();
        score = 0;
    }

    void DeleteResultsBox(GameObject gameObject){
        Destroy(gameObject);
    }

    public void ChangeScore(int change){
        score += change;
        scoreText.text = score.ToString();
    }
}

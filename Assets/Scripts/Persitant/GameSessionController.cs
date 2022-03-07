using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameSessionController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI lives;


    [SerializeField] int playerLifes = 5;



    private void Awake()
    {
        
        int noOfGameSessionControllers = FindObjectsOfType<GameSessionController>().Length;
        // Debug.Log("No of lives on awake   " + playerLifes + "   noOfGameSessionControllers " + noOfGameSessionControllers);
        if(noOfGameSessionControllers > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }



    public void ProcessPlayerDeath(){
        if(playerLifes > 1){
            takeLife();
        }else{
            ResetGameSession();
        }
    }


    private void takeLife()
    {
        Debug.Log("No of lives on awake   " + playerLifes +"  before death");
        playerLifes -= 1;
        int currentHealth = playerLifes;
        Debug.Log("No of lives after death  (current health)  " + currentHealth);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);   
        lives.text = currentHealth.ToString();     
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    void Start()
    {
        lives.text = playerLifes.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // printLives();
    }


}

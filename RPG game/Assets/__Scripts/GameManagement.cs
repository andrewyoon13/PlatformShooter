using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    bool gameEnd = false; //check if game is ended, initialize to false
    public float delay = 3f; //delay time

    public void GameEnding(){
        //if game has not ended and this method is called, we want to end the game
        if(gameEnd == false){
            gameEnd = true; //game ending is now true, therefore game can only end once
            Invoke("Restart", delay); //invoke the restart method after delaying or "pausing the game" for 3 seconds
        }
    }
    //Restart game
    private void Restart(){
        //load the active scene after game is over
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class levelup : MonoBehaviour
{
    public Text points;
    public float pointsAmount = 5f;
    public GameObject Player;
    
    
    void Start(){
        Player.GetComponent<Movement>();
    }
    
    
    
    

    // Update is called once per frame
    void Update()
    {
        pointsAmount = Mathf.Clamp(pointsAmount, 0f, 5f);
        points.text = pointsAmount.ToString();
    }
    public void SubScore()
    {
        if(pointsAmount>0)
        pointsAmount--;
    }
    public void AddScore()
    {
        if (pointsAmount<5)
        pointsAmount++;
    }

    public void AddHealth(){
        if (pointsAmount>0){
        Player.GetComponent<Movement>().health += 20;
        } 
        
        Debug.Log("health is " + Player.GetComponent<Movement>().health);
        Debug.Log(pointsAmount);
    }
    public void SubHealth(){
        if(pointsAmount<6 && pointsAmount>0)
        Player.GetComponent<Movement>().health -= 20;

        Debug.Log("health is " + Player.GetComponent<Movement>().health);
        Debug.Log(pointsAmount);
    }
    public void AddDamage(){
        if (pointsAmount>0){
            Player.GetComponent<MeleeCombat>().attackDamage += 10;
            Player.GetComponent<Weapon>().damage += 10;
        }
        Debug.Log("damage is " + Player.GetComponent<MeleeCombat>().attackDamage + "and" + Player.GetComponent<Weapon>().damage);
        Debug.Log(pointsAmount);
    }
    public void SubDamage(){
        if(pointsAmount == 0){
            Debug.Log("cannot");
        }
        if(pointsAmount<6 && pointsAmount>0){
            Player.GetComponent<MeleeCombat>().attackDamage -= 10;
            Player.GetComponent<Weapon>().damage -= 10;
        }
        Debug.Log("damage is " + Player.GetComponent<MeleeCombat>().attackDamage + "and" + Player.GetComponent<Weapon>().damage);
        Debug.Log(pointsAmount);
    }
    public void AddSpeed(){
        if (pointsAmount>0){
            Player.GetComponent<Movement>().runSpeed += 5;
        }
        Debug.Log("speed is " + Player.GetComponent<Movement>().runSpeed);
        Debug.Log(pointsAmount);
    }
    public void SubSpeed(){
        if(pointsAmount<6 && pointsAmount>0){
            Player.GetComponent<Movement>().runSpeed -= 5;
        }
        Debug.Log("speed is " + Player.GetComponent<Movement>().runSpeed);
        Debug.Log(pointsAmount);
    }

    public void MoveOn(){
        Player.GetComponent<Movement>().Setter();
        if (Player.GetComponent<Movement>().isPlayer1){
                SceneManager.LoadScene(5);
        }
        else if (Player.GetComponent<Movement>().isPlayer2){
                SceneManager.LoadScene(6);
        }
    }
}
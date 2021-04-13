using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelup : MonoBehaviour
{
    public Text points;
    public float pointsAmount = 3f;
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
        if (pointsAmount<6)
        pointsAmount++;
    }

    public void AddHealth(){
        if (pointsAmount>0)
        Player.GetComponent<Movement>().health += 20;
        

        Debug.Log("health is " + Player.GetComponent<Movement>().health);
    }
    public void SubHealth(){
        if(pointsAmount<6 && pointsAmount>0)
        Player.GetComponent<Movement>().health -= 20;

        Debug.Log("health is " + Player.GetComponent<Movement>().health);
        
    }
    public void AddDamageMelee(){
        if (pointsAmount>0){
            Player.GetComponent<MeleeCombat>().attackDamage += 10;
        }
        Debug.Log("damage is " + Player.GetComponent<MeleeCombat>().attackDamage);

    }
    public void SubDamageMelee(){
        if(pointsAmount<6 && pointsAmount>0){
            Player.GetComponent<MeleeCombat>().attackDamage -= 10;
        }
        Debug.Log("damage is " + Player.GetComponent<MeleeCombat>().attackDamage);

    }
    public void AddDamageRanged(){
        if (pointsAmount<6){}

    }
    public void SubDamageRanged(){
        if(pointsAmount>0){}

    }
    public void AddSpeed(){
        if (pointsAmount>0){
            Player.GetComponent<Movement>().speed += 5;
        }
        Debug.Log("speed is " + Player.GetComponent<Movement>().speed);

    }
    public void SubSpeed(){
        if(pointsAmount<6 && pointsAmount>0){
            Player.GetComponent<Movement>().speed -= 5;
        }
        Debug.Log("speed is " + Player.GetComponent<Movement>().speed);

    }
}
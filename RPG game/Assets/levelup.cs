using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelup : MonoBehaviour
{
    public Text points;
    public float pointsAmount = 3f;
    

    // Update is called once per frame
    void Update()
    {
        pointsAmount = Mathf.Clamp(pointsAmount, 0f, 5f);
        points.text = pointsAmount.ToString();
    }
    public void SubScore()
    {
        pointsAmount--;
    }
    public void AddScore()
    {
        pointsAmount++;
    }
}
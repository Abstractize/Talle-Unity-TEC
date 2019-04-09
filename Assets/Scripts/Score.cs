using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        GetComponent<Text>().text = "Score: " + score;
    }
    public void AddScore()
    {
        score += 100;
    }
    public void ResetScore()
    {
        score = 0;
    }
}

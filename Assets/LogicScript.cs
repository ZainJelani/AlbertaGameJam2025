using UnityEngine;

public class LogicScript : MonoBehaviour
{
    public float health = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void adjustHealth(int amount)
    {
        health = health + amount;
        //healthText.text = health.ToString();
    }
}

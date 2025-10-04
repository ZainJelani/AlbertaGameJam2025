using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public float health = 3;
    public TMP_Text healthText;
    public int collectedLetters = 0;
    public TMP_Text wordText;

    // word is ZAP
    private int[] word = { 51, 26, 41 };
    private string builtWord = "Word:";

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
        string hearts = "Health: ";
        for (int i = 0; i < health; i++)
        {
            hearts += "<3 ";
        }
        healthText.text = hearts;
        if(health <= 0)
        {
            restartGame();
        }
    }

    public void adjustCollectedLetters(int letter)
    {
        if(letter == word[collectedLetters])
        {
            collectedLetters++;
            Debug.Log(message: "Spelt Word");
        }


        if (collectedLetters == 1)
        {
            builtWord = "Word: Z";
        }
        else if (collectedLetters == 2)
        {
            builtWord = "Word: ZA";
        }
        else if (collectedLetters == 3)
        {
            builtWord = "Word: ZAP";
        }

        if (collectedLetters >= 3)
        {
            collectedLetters = 0;
            Debug.Log(message: "Game time!");
            builtWord = "Word:";
        }

        wordText.text = builtWord;
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public int returnIndex()
    {
        int letterIndex = word[collectedLetters];
        return letterIndex;
    }
}

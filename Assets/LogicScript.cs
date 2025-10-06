using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public float health = 3;
    public TMP_Text healthText;
    public int collectedLetters = 0;
    public TMP_Text wordText;

    // Array of onomatopoeias to cycle through
    private string[] words = {"FLAP", "ZAP", "BOOM"};
    private int targetWordIndex = 0;
    private string word { get { return words[targetWordIndex]; } }
    private string builtWord = "Word:";

    public GameObject gameOverScreen;
    const int startingScene = 1;

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
            gameOver();
        }
    }

    public void adjustCollectedLetters(int letter)
    {
        if(letter == GetSpriteIndexFromString(collectedLetters))
        {
            collectedLetters++;
            Debug.Log(message: "Spelt Word");
        }

        // Build the word dynamically based on collected letters
        builtWord = "Word: ";
        for (int i = 0; i < collectedLetters; i++)
        {
            builtWord += word[i];
        }

        if (collectedLetters >= word.Length)
        {
            collectedLetters = 0;
            Debug.Log(message: "Game time!");
            builtWord = "Word:";
            
            // Cycle to the next word
            targetWordIndex = (targetWordIndex + 1) % words.Length;
        }

        wordText.text = builtWord;
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(startingScene);
    }

    public int returnIndex()
    {
        int letterIndex = GetSpriteIndexFromString(collectedLetters);
        return letterIndex;
    }

    private int GetSpriteIndexFromString(int position)
    {
        // Default to 'A' if position is out of bounds
        if (position < 0 || position >= word.Length) return 26;

        // Convert letter to sprite index starting at A=26
        char letter = char.ToUpper(word[position]);
        if (letter >= 'A' && letter <= 'Z') return 26 + (letter - 'A');
        return 26;
    }
}

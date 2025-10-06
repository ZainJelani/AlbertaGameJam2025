using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    public float bulletLife = 1f;  // Defines how long before the bullet is destroyed
    public float rotation = 0f;
    public float speed = 1f;
    public bool collectable = false;

    public LogicScript logic;
    private SpriteRenderer spriteRenderer;
    public Sprite[] frames;
    private BoxCollider2D boxCollider;

    private Vector2 spawnPoint;
    private float timer = 0f;

    int letterIndex = 0;
    private float deadzoneX = 9;
    private float deadzoneY = 6;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        spawnPoint = new Vector2(transform.position.x, transform.position.y);

        // Get the SpriteRenderer component on the same GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        
        // Pick a random frame at start
        letterIndex = logic.returnIndex();
        if (collectable)
        {
            spriteRenderer.sprite = frames[letterIndex];
        }
        else
        {
            // Pick from [0, 25), 25 options excluding letterIndex
            int randomIndex = UnityEngine.Random.Range(0, 25);
            if (randomIndex >= letterIndex) randomIndex++;
            spriteRenderer.sprite = frames[randomIndex];
        }

        UpdateColliderSize();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bulletLife) Destroy(this.gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
        if (Math.Abs(transform.position.x) >= deadzoneX || Math.Abs(transform.position.y) >= deadzoneY)
        {
            Destroy(this.gameObject);
        }
    }


    private Vector2 Movement(float timer)
    {
        // Moves right according to the bullet's rotation
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (collectable)
            {
                logic.adjustCollectedLetters(letterIndex);
                Destroy(this.gameObject);
            }
            else
            {
                logic.adjustHealth(-1);
                Debug.Log(message: "Collision");
                Destroy(this.gameObject);
            }
        }
    }

    public void UpdateColliderSize()
    {
        if (spriteRenderer.sprite != null)
        {
            // Set the collider size to match the sprite's bounds
            boxCollider.size = spriteRenderer.sprite.bounds.size;
            // Optionally, adjust the offset if needed
            boxCollider.offset = spriteRenderer.sprite.bounds.center;
        }
    }

}

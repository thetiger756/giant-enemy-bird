using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField]
    private int startingHealth = 100;  //Amount of health player starts with
    [HideInInspector] public int currentHealth;         //Current Player Health
    public Slider healthSlider;       //Ref UI's health bar
    public Image damageImage;         //Ref image to flash when hit
    public float flashSpeed = 5f;     //Speed damageImage will fade
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);  //color of damageImage


    //everything I'm about to say about player/playerMovement also applies to this
    GameObject gameControllerHolder;
    GameController gameController;


    //we need a reference to the gameobject
    GameObject player;
    //in order to reference the script that's attached to it
    PlayerMovement playerMovement;


    bool isDead;
    bool damaged;

    public AudioSource soundSource;
    public AudioClip hurtSound;


    void Awake()
    {
        //we assign the reference that we made to the actual GameObject that is tagged "Player"
        player = GameObject.FindGameObjectWithTag("Player");

        //now we can assign the reference to the Script that we want, so that we can access it easily.
        playerMovement = player.GetComponent<PlayerMovement>();

        //same applies here, except we find the gameobject by a specific name rather than a tag.
        gameControllerHolder = GameObject.Find("GameController Holder");
        gameController = gameControllerHolder.GetComponent<GameController>();

        currentHealth = startingHealth;
    }

    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
            soundSource.clip = hurtSound;
            soundSource.Play();
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        if(currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        //this is what we did all that work to do before.
        playerMovement.enabled = false;

        //it would have made sense to do all that work before, if we 
        //used the playerMovement script many times within this script.
        //However, since we only need it once, we could have simply used the following 
        //line of code, instead of making all of those references and assignments.

        //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;


        //everything that I said before is equally true here.
        //instead of all that work we did before in order to write this:
        gameController.GameOver();

        //we can just use this instead. 
        //we wouldn't have had to write lines 19, 20, 42, 43, or 90.

        //GameObject.Find("GameController Holder").GetComponent<GameController>().GameOver();

        //Again, that would have made sense if we were using the GameController script multiples times
        //within this script, but we are not.

        //The reason why your code wasn't working before was because you were referencing the GameController script,
        //but you weren't able to assign it, because you didn't have a reference to the object in the game that
        //held that script. You can't reference a script, unless it's actually IN the game (as opposed to in the assets folder).
        //This is because you can have the same script used on multiple gameobjects, so it needs to know specifically.

        //Please compare my code where I still used your method to your code which was having the errors, side-by-side.
    }
}

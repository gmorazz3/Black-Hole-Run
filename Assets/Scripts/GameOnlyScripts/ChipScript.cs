using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UIElements;
//script is in use*******
public class ChipScript : MonoBehaviour
{
    //assign variable that calls the GameOverScript (shows game over and play again button)
    public GameOverScript logic;

    //assign variable that calls TimerScript (Contains Timer functionality)
    public TimerScript timer;

    public MoveToLeft MTLScript;

    //assign variable that calls MoveToleft Script (for disabling asteroid colliders
    public MoveToLeft RoidScript;

    //assign variable to gameObject asteroid 1 (for disabling colliders)
    public GameObject RoidOne;
    //assign variable to gameObject asteroid 5 (for disabling colliders)
    public GameObject RoidFive;
    //assign variable to gameObject flaming asteroid (for disabling colliders)
    public GameObject FlamingRoid;

    //public Slider GhostBar;//reference to ghost slider component

    //flag to detect if player is alive
    public bool ChipIsAlive = true;

    //flag to see if player won
    public bool chipEscaped = false;

    //flag to check if the game is paused
    public bool gamePaused = false;

    //variables to assign the minimum and maximum x and y variables, key to create boundaries for the player
    private float xMin, xMax;
    private float yMin, yMax;

    // Start is called before the first frame update
    void Start()
    {
        //call logic script to control gameover screen
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<GameOverScript>();
    
        //boundary script
        var spriteSize = GetComponent<SpriteRenderer>().bounds.size.x * 0.5f; // get area for sprite
        var cam = Camera.main;// Camera component to get their size, if this change in runtime make sure to update values
        var camHeight = cam.orthographicSize;
        var camWidth = cam.orthographicSize * cam.aspect;
        yMin = -camHeight + spriteSize; // lower bound
        yMax = camHeight - spriteSize; // upper bound

        xMin = -camWidth + spriteSize; // left bound
        xMax = camWidth - spriteSize; // right bound 
    }

    // Update is called once per frame
    void Update()
    {

        //Create variable Chip for use later, Chip is the player
        Rigidbody2D Chip = GetComponent<Rigidbody2D>();

    //Assign variables that contain the valid area that the player should be able to move
    var xValidPosition = Mathf.Clamp(transform.position.x, xMin, xMax);
        var yValidPosition = Mathf.Clamp(transform.position.y, yMin, yMax);

        transform.position = new Vector3(xValidPosition, yValidPosition, 0f);

        //gravity pull to black hole
        if (chipEscaped == false && gamePaused == false)
        {
            Chip.AddForce(Vector2.left * 0.2f);
        }
        //movement, alive validation, and movement restricted to boundaries
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && ChipIsAlive && transform.position == new Vector3(xValidPosition, yValidPosition, 0f) && gamePaused == false)
        {
            Chip.AddForce(Vector3.left * 2);
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && ChipIsAlive && transform.position == new Vector3(xValidPosition, yValidPosition, 0f) && gamePaused == false)
        {
            Chip.AddForce(Vector3.right * 3);
        }
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && ChipIsAlive && transform.position == new Vector3(xValidPosition, yValidPosition, 0f) && gamePaused == false)
        {
            Chip.AddForce(Vector3.up * 3);
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && ChipIsAlive && transform.position == new Vector3(xValidPosition, yValidPosition, 0f) && gamePaused == false)
        {
            Chip.AddForce(Vector3.down * 3);
        }

        //bounce off boundaries to not get stuck
        if (Chip.transform.position.x <= xMin)
        {
            Chip.velocity = Vector3.zero;
            Chip.AddForce(Vector3.right);
        }
        if (Chip.transform.position.x >= xMax)
        {
            Chip.velocity = Vector3.zero;
            Chip.AddForce(Vector3.left);
        }
        if (Chip.transform.position.y <= yMin)
        {
            Chip.velocity = Vector3.zero;
            Chip.AddForce(Vector3.up);
        }
        if (Chip.transform.position.y >= yMax)
        {
            Chip.velocity = Vector3.zero;
            Chip.AddForce(Vector3.down);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //when spaceship collides with something game over appears and Chip stops moving
        logic.gameOver();
        ChipIsAlive = false;
        if (ChipIsAlive == false)
        {
            Destroy(gameObject);
        }
        timer.PauseTimer();
    }

    public void GameIsPaused()
    {
        gamePaused = true;
    }
    public void GameResume()
    {
        gamePaused = false;
    }
}

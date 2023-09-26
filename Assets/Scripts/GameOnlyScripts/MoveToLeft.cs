using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;
//script is in use**************
public class MoveToLeft : MonoBehaviour
{
    public float moveSpeed = 10; //asteroid speed
    public float deadZone = -35; //position where asteroids get destroyed (x-axis)

    private Collider2D asteroidCollider; // Reference to the Collider2D component

    public Slider GhostBar;//reference to ghost bar

    public float rotationSpeed = 100; //asteroid roation speed

    public GameObject Asteroid; //reference to Asteroid as a gameobject
    private ChipScript chipScript; // Reference to the ChipScript component


    // Start is called before the first frame update
    void Start()
    {
        // Get the Collider2D component attached to the game object
        asteroidCollider = GetComponent<Collider2D>();

        //Get the Slider component from progress bar
        GhostBar = GameObject.Find("ProgressBar").GetComponent<Slider>();

        // Ensure the Collider2D component is not null
        if (asteroidCollider == null)
        {
            Debug.Log("Collider2D component not found on this GameObject.");
        }
        //look for game object
        GameObject chipObject = GameObject.Find("Chip");
        //if Chip exists
        if (chipObject != null)
        {
            //get his scripts component
            chipScript = chipObject.GetComponent<ChipScript>();
        }
        else
        {
            Debug.Log("Chip GameObject not found.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //gravity (move asteroids left)
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        //delete when they reach deadZone x-axis
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }

        // Check if the spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && GhostBar.value > 0.05f)
        {
            // Disable the Collider2D component
            asteroidCollider.enabled = false;
        }
        // Check if the spacebar is released
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Re-enable the Collider2D component
            asteroidCollider.enabled = true;
        }
        if (GhostBar.value == 0)
        {
            asteroidCollider.enabled = true;
        }

        //rotate asteroid
        Asteroid.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);

        //check if Chip is alive
        if (chipScript != null && chipScript.ChipIsAlive)
        {
            //make Chip transparent if spacebar is pressed and meter value is larger than zero
            if (Input.GetKeyDown(KeyCode.Space) && GhostBar.value > 0.05f)
            {
                GameObject.Find("Chip").GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.3f);
            }
            //make Chip solid if spacebar is released and meter value is larger than zero
            if (Input.GetKeyUp(KeyCode.Space) && GhostBar.value > 0f)
            {
                GameObject.Find("Chip").GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            //make Chip solid if meter is drained
            if (GhostBar.value == 0f)
            {
                GameObject.Find("Chip").GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
        }
    }
}

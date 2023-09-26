using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChipOnMenuScript : MonoBehaviour
{
    public float startX = 6.9f; // Starting x position
    public float endX = 14f; // Ending x position
    public float speed = 2f; // Movement speed

    private bool movingRight = true;

    //public TimerScript timer;

    private void Start()
    {
        moveChip();
    }
    private void Update()
    {
        moveChip();
    }

    private void moveChip()
    {
        // Calculate the new position of Chip
        float step = speed * Time.deltaTime;
        Vector3 targetPosition;

        if (movingRight)
        {
            targetPosition = new Vector3(endX, transform.position.y, transform.position.z);
        }
        else
        {
            targetPosition = new Vector3(startX, transform.position.y, transform.position.z);
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

        // Check if Chip has reached the target position and reverse direction
        if (Mathf.Approximately(transform.position.x, endX) && movingRight)
        {
            movingRight = false;
        }
        else if (Mathf.Approximately(transform.position.x, startX) && !movingRight)
        {
            movingRight = true;
        }
    }
}

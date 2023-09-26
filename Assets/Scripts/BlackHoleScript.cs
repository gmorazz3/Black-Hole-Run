using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//script is in use*******
public class BlackHoleScript : MonoBehaviour
{
    public float rotationSpeed = 100;

    public GameObject Hole;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rotate black hole
        Hole.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}

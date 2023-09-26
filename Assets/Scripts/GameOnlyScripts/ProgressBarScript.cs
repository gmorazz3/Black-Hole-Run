using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//script is in use*************
public class ProgressBarScript : MonoBehaviour
{
    private Slider Bar;
    private ParticleSystem ParticleSys;

    public float FillSpeed = 0.5f;
    private float targetProgress = 0;

    public float barDrainRate = -0.8f;
    public float barFillRate = 0.001f;

    public bool ChipEscaped = false;

    public GameObject youWinScreen;

    public GameObject Fill;

    public GameObject Chip;

    public GameObject txtHitSpace;

    public GameObject ProgressBar;

    public GameObject txtpercentBar;
    public TextMeshProUGUI textPercent;

    public GameObject AsteroidSpawner;

    public GameObject FlatroidSpawner;

    public GameObject FlamingroidSpawner;

    public GameObject Asteroid;
    public GameObject Flatroid;
    public GameObject Flamingroid;

    public TimerScript timer;


    private void Awake()
    {
        Bar = gameObject.GetComponent<Slider>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Asteroid.SetActive(true);
        Flamingroid.SetActive(true);
        Flatroid.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        //fill bar smoothly
        if (Bar.value < targetProgress)
        {
            Bar.value = Bar.value + (FillSpeed * 0.05f) * Time.deltaTime;
        }

        //drain bar smoothly
        if (Bar.value > targetProgress)
        {
            Bar.value = Bar.value - (FillSpeed * 0.25f) * Time.deltaTime;
        }

        //do the following if spacebar is pressed and phantom meter value is larger than zero
        if (Input.GetKey(KeyCode.Space) && Bar.value > 0.0f)
        {
            //drain ghost mode bar
            IncrementBar(barDrainRate);
        }
        else
        {
            //fill ghost mode bar
            IncrementBar(barFillRate);
        }
        if (Bar.value == 1f)
        {
            Fill.GetComponent<Image>().color = Random.ColorHSV();
            txtHitSpace.SetActive(true);
        }
        if (Bar.value == 1f && Input.GetKey(KeyCode.Space))
        {
            YouWin();
            ChipEscaped = true;
        }
        textPercent.text = (Bar.value * 100).ToString("n2") + "%";
    }
    //function to fill bar
    public void IncrementBar(float newProgress)
    {
        //increase bar value with newprogress variable/parameter
        targetProgress = Bar.value + newProgress;
    }
    public void YouWin()
    {
        youWinScreen.SetActive(true);
        Destroy(Chip);
        Fill.GetComponent<Image>().color = Color.magenta;
        txtHitSpace.SetActive(false);
        ProgressBar.SetActive(false);
        AsteroidSpawner.SetActive(false);
        FlatroidSpawner.SetActive(false);
        FlamingroidSpawner.SetActive(false);
        Asteroid.SetActive(false);
        Flamingroid.SetActive(false);
        Flatroid.SetActive(false);
        timer.PauseTimer();
    }
}

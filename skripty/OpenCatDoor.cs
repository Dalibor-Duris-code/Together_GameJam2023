using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OpenCatDoor : MonoBehaviour
{
    [Header("Object connected to the button")]
    [SerializeField] private GameObject CatFirst;
    [SerializeField] private GameObject CatSecond;
    [SerializeField] private GameObject CatThird;

    [SerializeField] private GameObject openedDoors;
    [SerializeField] private GameObject closedDoors;

    [SerializeField] private AudioSource openingSound;

    private bool catsLighted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LightCats();

        if (catsLighted)
        {
            PlaySound();
            openedDoors.SetActive(true);
            closedDoors.SetActive(false);
        }
    }

    public void LightCats()
    {
        if (CatFirst.GetComponentInChildren<Light2D>().intensity == 1f && CatSecond.GetComponentInChildren<Light2D>().intensity == 1f && CatThird.GetComponentInChildren<Light2D>().intensity == 1f)
        {
            catsLighted = true;
        }
    }

    public void PlaySound()
    {
        openingSound.Play();
    }

}

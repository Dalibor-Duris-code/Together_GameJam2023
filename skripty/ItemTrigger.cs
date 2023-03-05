using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ItemTrigger : MonoBehaviour
{

    [Header("Object connected to the button")]
    [SerializeField] private Light2D PictureLight;

    [SerializeField] private KeyCode useKey = KeyCode.E;

    [SerializeField] private AudioSource turningLightOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(useKey))
            {
                PictureLight.intensity = 1;
                turningLightOn.Play();
            }
        }
    }




}

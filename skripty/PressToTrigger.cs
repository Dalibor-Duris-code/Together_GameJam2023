using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.GraphicsBuffer;

public class PressToTrigger : MonoBehaviour
{
    [Header("Object connected to the button")]
    [SerializeField] private GameObject triggeredObject;
    [SerializeField] private GameObject Colliders;
    [SerializeField] private KeyCode useKey = KeyCode.E;

    [Header("Switchers")]
    [SerializeField] private GameObject switchOn;
    [SerializeField] private GameObject switchOff;

    [Header("Sounds")]
    [SerializeField] private AudioSource playSound;

    [Header("Other")]
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothTime = 1f;
    [SerializeField]
    private float yVelocity = 1f;

    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed) 
        {
            float newPosition = Mathf.SmoothDamp(triggeredObject.transform.position.y, target.position.y, ref yVelocity, smoothTime);
            triggeredObject.transform.position = new Vector3(triggeredObject.transform.position.x, newPosition, triggeredObject.transform.position.z);
            switchOn.SetActive(true);
            switchOff.SetActive(false);
        }


    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(useKey))
            {
                isPressed = true;
                triggeredObject.SetActive(true);
                Colliders.SetActive(false);
            }
        }
    }
}

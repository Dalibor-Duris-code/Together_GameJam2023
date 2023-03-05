using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigerReverse : MonoBehaviour
{
    [SerializeField] private GameObject triggeredObject;
    [SerializeField] private GameObject triggeredSwitch;
    
    [SerializeField] private bool HoldTrigger = false;

    public Vector3 pos;
    bool isPressed = false;
    
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothTime = 1f;
    [SerializeField]
    private float yVelocity = 1f;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            //triggeredObject.SetActive(true);
            float newPosition = Mathf.SmoothDamp(triggeredObject.transform.position.y, target.position.y, ref yVelocity, smoothTime);
            triggeredObject.transform.position = new Vector3(triggeredObject.transform.position.x, newPosition, triggeredObject.transform.position.z);

            triggeredSwitch.SetActive(true);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPressed = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && HoldTrigger)
        {
            isPressed = false;
        }
    }
}

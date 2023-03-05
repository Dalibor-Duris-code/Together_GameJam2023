using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    [Header("Object connected to the �button")]
    [SerializeField] private GameObject triggeredObject;

    public Vector3 pos;
    public Vector3 objectPos;
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
        triggeredObject.SetActive(true);
        objectPos = triggeredObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            transform.position = new Vector3(pos.x, pos.y - 0.1f, pos.z);
            float newPosition = Mathf.SmoothDamp(triggeredObject.transform.position.y, target.position.y, ref yVelocity, smoothTime);
            
            triggeredObject.transform.position = new Vector3(objectPos.x, newPosition, objectPos.z);
        }
        else
        {
            transform.position = pos;
            
            float newPosition = Mathf.SmoothDamp(triggeredObject.transform.position.y, objectPos.y, ref yVelocity, smoothTime);
            triggeredObject.transform.position = new Vector3(objectPos.x, newPosition, objectPos.z);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPressed = true;
            collision.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isPressed = false;
            collision.transform.parent = null;
        }
    }
}

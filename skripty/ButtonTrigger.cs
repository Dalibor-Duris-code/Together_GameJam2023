using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    [Header("Object connected to the button")]
    [SerializeField] private GameObject triggeredObject;

    [SerializeField] private bool HoldTrigger = false;

    public Vector3 pos;
    bool isPressed = false;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        triggeredObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            triggeredObject.SetActive(false);
        }
        else
        {
            triggeredObject.SetActive(true);
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

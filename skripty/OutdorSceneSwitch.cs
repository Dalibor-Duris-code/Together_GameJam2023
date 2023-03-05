using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutdorSceneSwitch : MonoBehaviour
{

    private bool CharacterLongInTrigger = false;
    private bool CharacterSmallInTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "Long")
        {
            Debug.Log("Player has entered the exit trigger");
            CharacterLongInTrigger = true;

        }

        if (collision.gameObject.name == "Small")
        {
            Debug.Log("Player has entered the exit trigger");
            CharacterSmallInTrigger = true;

        }

        if (CharacterLongInTrigger == true && CharacterSmallInTrigger == true)
        {
            Debug.Log("Load level");
            // Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Long")
        {
            Debug.Log("Player exit trigger");
            CharacterLongInTrigger = false;

        }

        if (collision.gameObject.name == "Small")
        {
            Debug.Log("Player exit trigger");
            CharacterSmallInTrigger = false;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;

    public GameObject player2;

    [SerializeField] public string level;
    // Start is called before the first frame update
    void Start()
    {
        string levelName = PlayerPrefs.GetString("LevelSaved");
        if (levelName.Equals(level))
        {
            Debug.Log("True, load saved scenes");
            float[] savedPos = new float[6];
            savedPos[0] = PlayerPrefs.GetFloat("Obj1PosX");
            savedPos[1] = PlayerPrefs.GetFloat("Obj1PosY");
            savedPos[2] = PlayerPrefs.GetFloat("Obj1PosZ");
            savedPos[3] = PlayerPrefs.GetFloat("Obj2PosX");
            savedPos[4] = PlayerPrefs.GetFloat("Obj2PosY");
            savedPos[5] = PlayerPrefs.GetFloat("Obj2PosZ");

            player1.transform.position = new Vector3(savedPos[0], savedPos[1], savedPos[2]);
            player2.transform.position = new Vector3(savedPos[3], savedPos[4], savedPos[5]);

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}

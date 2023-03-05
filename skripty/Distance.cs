using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Distance : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    
    [SerializeField]
    public float minDistance = 20.0f;
    public List<GameObject> objectsToCompare;
    [SerializeField]
    public float minIntensity;
    [SerializeField]
    public float changeSpeed = 1.0f;
    [SerializeField]
    private float maxIntensity = 1;
    
    private Light2D light2D;
    private Light2D lightPlayer2;
    void Start()
    {
        light2D = object1.GetComponent<Light2D>();
        lightPlayer2 = object2.GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        for (int i = 0; i < objectsToCompare.Count; i++)
        {
            for (int j = i + 1; j < objectsToCompare.Count; j++)
            {
                float distance = Vector3.Distance(objectsToCompare[i].transform.position, objectsToCompare[j].transform.position);
                Debug.Log("Distance between " + objectsToCompare[i].name + " and " + objectsToCompare[j].name + " is " + distance);

                if (distance > minDistance)
                {
                    float currentIntensity = light2D.intensity;
                    float newIntensity = Mathf.Lerp(currentIntensity, minIntensity, changeSpeed * Time.deltaTime);
                    light2D.intensity = newIntensity;
                    lightPlayer2.intensity = newIntensity;
                }

                if (light2D.intensity < 1 && lightPlayer2.intensity < 1 && distance < minDistance)
                {
                    float currentIntensity = light2D.intensity;
                    float targetIntensity = Mathf.Lerp(currentIntensity, maxIntensity, Mathf.PingPong(Time.time * changeSpeed, 1.0f));
                    float newIntensity = Mathf.Lerp(currentIntensity, targetIntensity, changeSpeed * Time.deltaTime);
                    light2D.intensity = newIntensity;
                    lightPlayer2.intensity = newIntensity;
                }
            }
        }
    }
}
    

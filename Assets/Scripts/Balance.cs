using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balance : MonoBehaviour
{
    public Button retry;
    float balancedTime = 0;
    float stressTime = 0;
    float startingTimer = 10f;
    float globalTime;

    public GameObject displayResultat;
    public Text displayStress;
    public Text displayBalance; 

    // Start is called before the first frame update
    void Start()
    {
        globalTime = -startingTimer;
    }

    // Update is called once per frame
    void Update()
    {
        NotBalanced();


    }

    void NotBalanced()
    {
        //Debug.Log(transform.eulerAngles.z + "\n");
        startingTimer -= Time.deltaTime;
        globalTime += Time.deltaTime;
        if (startingTimer < 0)
        {
            if ((transform.eulerAngles.z > 90 && transform.eulerAngles.z < 100) || (transform.eulerAngles.z < 270 && transform.eulerAngles.z > 260))
            {
                
                retry.gameObject.SetActive(true);
                Destroy(gameObject);

                displayStress.text = Mathf.Floor(stressTime * 100 / globalTime) + " %";
                displayBalance.text = Mathf.Ceil(balancedTime * 100 / globalTime) + " %";
                displayResultat.SetActive(true);
            }
            else
            {
                if ((transform.eulerAngles.z > 3.5 && transform.eulerAngles.z < 90) || (transform.eulerAngles.z < 357.5 && transform.eulerAngles.z > 270))
                {
                    stressTime += Time.deltaTime;
                }
                else
                {
                    balancedTime += Time.deltaTime;
                }
            }
        }

    }
}

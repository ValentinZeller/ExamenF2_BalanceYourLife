using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectManager : MonoBehaviour
{
    static int maxObject = 5;
    const int maxArrayObjects = 7;

    float spawnTimer = 5.0f;
    float enoughTimer = 3.0f;
    int nbObject = maxObject - 1;
    int score = 0;
    public GameObject normalObject;
    public GameObject heavyObject;
    GameObject[] objects;

    public Text displayNbObject;
    public Text destress;
    public Text displayScore;
    public Text displayBalanceTimer;

    // Start is called before the first frame update
    void Start()
    {
        objects = new GameObject[maxArrayObjects] { normalObject, normalObject, normalObject, normalObject , normalObject , heavyObject , normalObject };
        displayNbObject.text = nbObject.ToString();
        destress.canvasRenderer.SetAlpha(0f);
        displayBalanceTimer.canvasRenderer.SetAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplayText();

        if (nbObject > 0 && GameObject.Find("BalancePad"))
        {
            SpawnObject();
        }

        FallObject();

        if (HasEnoughObject())
        {
            score += maxObject;
            maxObject += (maxObject/2);
            nbObject = maxObject;

            GetComponent<AudioSource>().Play();
            destress.CrossFadeAlpha(1f, 4f, false);
        }
        if (destress.canvasRenderer.GetAlpha() >= 1f)
        {
            destress.CrossFadeAlpha(0f, 1f, false);
        }
    }

    public void SpawnObject()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            spawnTimer = 5.0f;
            var object_spawned = Instantiate(objects[Random.Range(0,maxArrayObjects)], new Vector3(Random.Range(-5, 5), 4, 0), Quaternion.identity);
            object_spawned.transform.SetParent(transform);
            object_spawned.name = "Object";

            nbObject -= 1;

        }
    }


    public int CountObject()
    {
        int count = 0;
        foreach(Transform child in transform)
        {
            if (!child.CompareTag("Drag")) {
                count++;
            }
        }

        return count;
    }

    public bool HasEnoughObject()
    {
        bool enoughObject = false;
        if (CountObject() == maxObject)
        {
            BalanceTimer(3);
            enoughTimer -= Time.deltaTime;
            BalanceTimer(2);
            BalanceTimer(1);

            

            if (enoughTimer < 0)
            {
                displayBalanceTimer.CrossFadeAlpha(0f, 1f, false);
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                    enoughObject = true;
                    
                }
            }
        } else
        {
            if (displayBalanceTimer.canvasRenderer.GetAlpha() >= 1f)
            {
                displayBalanceTimer.CrossFadeAlpha(0f, 0.5f, false);
            }
            enoughTimer = 3.0f;
        }
        return enoughObject;
    }

    public void BalanceTimer(int value)
    {
        if (enoughTimer < value)
        {
            displayBalanceTimer.text = value.ToString();
            displayBalanceTimer.CrossFadeAlpha(1f, 0.5f, false);
        }

    }

    public void FallObject()
    {
        foreach(Transform child in transform)
        {
            if (child.position.y < -6)
            {
                Destroy(child.gameObject);
                nbObject += 1;
            }
        }
    }

    public void UpdateDisplayText()
    {
        displayScore.text = score.ToString();
        displayNbObject.text = nbObject.ToString();
    }

    public void ResetObject()
    {
        maxObject = 5;
    }
}

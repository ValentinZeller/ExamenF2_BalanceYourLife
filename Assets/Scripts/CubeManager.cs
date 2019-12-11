using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    static int maxObject = 5;
    const int maxArrayCubes = 7;

    float spawnTimer = 5.0f;
    float enoughTimer = 3.0f;
    int nbObject = maxObject - 1;
    int score = 0;
    public GameObject cube;
    public GameObject heavyCube;
    GameObject[] cubes;

    public Text displayNbObject;
    public Text destress;
    public Text displayScore;
    public Text displayBalanceTimer;

    // Start is called before the first frame update
    void Start()
    {
        cubes = new GameObject[maxArrayCubes] { cube, cube, cube, cube , cube , heavyCube , cube };
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
            SpawnCube();
        }

        FallCube();

        if (HasEnoughCube())
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

    public void SpawnCube()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            spawnTimer = 5.0f;
            var cube_spawned = Instantiate(cubes[Random.Range(0,maxArrayCubes)], new Vector3(Random.Range(-5, 5), 4, 0), Quaternion.identity);
            cube_spawned.transform.SetParent(transform);
            cube_spawned.name = "Cube";

            nbObject -= 1;

        }
    }


    public int CountCube()
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

    public bool HasEnoughCube()
    {
        bool enoughCube = false;
        if (CountCube() == maxObject)
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
                    enoughCube = true;
                    
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
        return enoughCube;
    }

    public void BalanceTimer(int value)
    {
        if (enoughTimer < value)
        {
            displayBalanceTimer.text = value.ToString();
            displayBalanceTimer.CrossFadeAlpha(1f, 0.5f, false);
        }

    }

    public void FallCube()
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

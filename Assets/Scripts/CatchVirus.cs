using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchVirus : MonoBehaviour
{
    private int point = 0;

    public AudioSource whacked;
    public AudioSource missed;

    private GameObject[] viruses;

    public GameObject GameOver;
    public Text pointText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Game Over!! pause game, if viruses are more than 20. 
        viruses = GameObject.FindGameObjectsWithTag("Virus");
        if (viruses.Length > 20)
        {
            Debug.Log("GameOver!");
            GameOver.SetActive(true);
            scoreText.text = "Score: " + point;
            Time.timeScale = 0;
        }

        //Catch Virus!! if game is not paused.
        if (Time.timeScale != 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Physics.Raycast(ray, out hit);
                if (hit.collider == null)
                {
                    missed.Play();
                    Debug.Log("Miss!");
                }
                else if (hit.collider.gameObject.CompareTag("Virus"))
                {
                    Destroy(hit.collider.gameObject);
                    whacked.Play();
                    point++;
                    Debug.Log("Point: " + point);

                    pointText.text = "Point: " + point;
                }

            }
        }
    }

}

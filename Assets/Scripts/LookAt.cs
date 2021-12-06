 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    private GameObject prefab1;
    private GameObject prefab2;
    
    // Start is called before the first frame update
    void Start()
    {
        prefab1 = GameObject.FindGameObjectWithTag("Prefab1");
        prefab2 = GameObject.FindGameObjectWithTag("Prefab2");
    }

    // Update is called once per frame
    void Update()
    {
        if (prefab1.activeInHierarchy == true && prefab2.activeInHierarchy == true)
        {
            prefab1.transform.LookAt(prefab2.transform);
            prefab2.transform.LookAt(prefab1.transform);
        }
        
    }
}

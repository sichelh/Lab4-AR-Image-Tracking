using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTracking : MonoBehaviour
{

    private ARTrackedImageManager trackedImgMgr;

    public GameObject prefab;

    private GameObject spawned;

    // Start is called before the first frame update
    void Awake()
    {
        trackedImgMgr = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        // subscribing to the trackedImageChanged event
        trackedImgMgr.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        // subscribing to the trackedImageChanged event
        trackedImgMgr.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {

        foreach (ARTrackedImage img in args.added)
        {
            if (img.referenceImage.name == "Virus")
            {
                StartCoroutine(Interval());
            }
        }

        foreach (ARTrackedImage img in args.updated)
        {
            UpdateImage(img);
        }

        foreach (ARTrackedImage img in args.removed)
        {
            spawned.SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage img)
    {
        if (img.trackingState == TrackingState.Tracking)
        {
            //spawned.transform.position = img.transform.position;
            //spawned.transform.rotation = img.transform.rotation;
            spawned.SetActive(true);
        }
        else if (img.trackingState == TrackingState.Limited || img.trackingState == TrackingState.None)
        {
            spawned.SetActive(false);
        }


    }
    IEnumerator Interval()
    {
        float intervalTime = 2;  // start with 2 seconds
        while(true)
        {
            yield return new WaitForSeconds(intervalTime);

            var position = new Vector3(UnityEngine.Random.Range(-0.5f, 0.5f), UnityEngine.Random.Range(-0.3f, 0.3f), UnityEngine.Random.Range(0.4f, 0.8f));
            spawned = Instantiate(prefab, position, Quaternion.identity);

            // change interval
            intervalTime -= intervalTime / 20;
        }
    }
}

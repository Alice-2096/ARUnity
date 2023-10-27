using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
public class ARObjectPlacement : MonoBehaviour
{
    // public GameObject objectToPlace; // The object you want to place

    private ARRaycastManager raycastManager;
    private ARPlaneManager planeManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();


    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        planeManager = GetComponent<ARPlaneManager>();
    }


    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown; //add the OnFingerUp method as a listener to the onFingerUp event
    }


    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;
        Debug.Log("Finger down");

        if (raycastManager.Raycast(finger.currentTouch.screenPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;

            if (GameManager.Instance.spawnMode)
            {
                Debug.Log("IN SPAWN MODE");
                string prefabName = GameManager.Instance.SelectedTree;
                GameObject prefab = Resources.Load<GameObject>(prefabName);
                Debug.Log("prefab is : " + prefabName);
                if (prefab == null)
                {
                    Debug.Log("prefab is null");
                }
                else
                {
                    Debug.Log("prefab is not null");
                    Instantiate(prefab, hitPose.position, hitPose.rotation);
                }

                GameManager.Instance.spawnMode = false;
                GameManager.Instance.SelectedTree = null;
            }
            else if (GameManager.Instance.DeleteTree)
            {
                Debug.Log("IN DELETE MODE");
                Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                RaycastHit hit;

                // find if there is a tree in the tapped location and delete it 
                if (Physics.Raycast(ray, out hit))
                {
                    // shoot a raycast at what we’re touching. If it hit something, destroy it.
                    GameObject hitObject = hit.transform.gameObject;
                    Debug.Log("hit object is : " + hitObject.name);

                    if (hitObject.CompareTag("tree"))
                    {
                        // Destroy the object.
                        Debug.Log("Destroy the object.");
                        Destroy(hitObject);
                        GameManager.Instance.DeleteTree = false;
                    }
                }

            }

        }
    }
    private void onDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }


}


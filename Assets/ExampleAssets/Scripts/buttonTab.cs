using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class buttonTab : MonoBehaviour
{
    public Button pine, palm, spruce, oak, maple, sakura;
    public Button delete, deleteAll;

    void Start()
    {
        delete.onClick.AddListener(() => DeleteClicked());
        deleteAll.onClick.AddListener(() => DeleteAllClicked());

        pine.onClick.AddListener(() => ButtonClicked("pine"));
        palm.onClick.AddListener(() => ButtonClicked("palm"));
        oak.onClick.AddListener(() => ButtonClicked("oak"));
        maple.onClick.AddListener(() => ButtonClicked("maple"));
        spruce.onClick.AddListener(() => ButtonClicked("spruce"));
        sakura.onClick.AddListener(() => ButtonClicked("sakura"));
    }
    void ButtonClicked(string treeName)
    {
        Debug.Log("TREE IS : " + treeName);
        //update global variable inside GameObject
        GameManager.Instance.SelectedTree = treeName;
        GameManager.Instance.spawnMode = true;
        GameManager.Instance.DeleteTree = false;
        Debug.Log("spawnMode is : " + GameManager.Instance.spawnMode);
    }

    void DeleteClicked()
    {
        GameManager.Instance.DeleteTree = true;
        Debug.Log("DeleteTree is : " + GameManager.Instance.DeleteTree);
    }

    void DeleteAllClicked()
    {
        //find all trees and delete them
        GameObject[] trees = GameObject.FindGameObjectsWithTag("tree");
        foreach (GameObject tree in trees)
        {
            Destroy(tree);
        }
        Debug.Log("Delete all trees");
    }
}

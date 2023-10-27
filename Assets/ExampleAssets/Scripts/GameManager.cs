using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// hold global information
public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public bool spawnMode { get; set; }
    public string SelectedTree { get; set; }
    public bool DeleteTree { get; set; }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(GameManager).Name;
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            // Initialize global variables 
            spawnMode = false;
            DeleteTree = false;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void update()
    {
        if (spawnMode)
        {
            Debug.Log("SPAWN MODE");
        }
        if (DeleteTree)
        {
            Debug.Log("DELETE MODE");
        }
        if (SelectedTree != null)
        {
            Debug.Log("SELECTED TREE IS : " + SelectedTree);
        }
    }
}

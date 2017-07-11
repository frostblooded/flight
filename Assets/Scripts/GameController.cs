using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float SecondsBetweenTrees = 1;
    public GameObject treePrefab;
    public Text displayedText;
    public bool gameHasEnded = false;

    private DateTime lastTreesCreatedAt = DateTime.Now;
    private Transform treeHolder;

    void CreateTree()
    {
        // If enought seconds have passed since the last tree was created,
        // create a new tree now
        if(lastTreesCreatedAt.AddSeconds(SecondsBetweenTrees) < DateTime.Now)
        {
            Vector3 newTreePosition = new Vector2(Tree.CreationX, 0);
            Instantiate(treePrefab, newTreePosition, Quaternion.identity, treeHolder);

            lastTreesCreatedAt = DateTime.Now;
        }
    }

    private void Start()
    {
        treeHolder = new GameObject("Trees").transform;
        displayedText = GameObject.Find("Displayed Text").GetComponent<Text>();
    }

    void Update () {
        CreateTree();

        if(gameHasEnded && Input.anyKey)
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}

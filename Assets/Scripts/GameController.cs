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
    [HideInInspector]
    public Text displayedText;
    [HideInInspector]
    public bool gameHasEnded = false;

    private DateTime? lastTreesCreatedAt;
    private Transform treeHolder;

    void CreateTree()
    {
        // If enought seconds have passed since the last tree was created,
        // create a new tree now.
        // The variable starts as null, so that it can be detected to start
        // creating trees immediately when the game starts.
        if(lastTreesCreatedAt == null
            || lastTreesCreatedAt.Value.AddSeconds(SecondsBetweenTrees) < DateTime.Now)
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

        if(gameHasEnded && Input.anyKeyDown)
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}

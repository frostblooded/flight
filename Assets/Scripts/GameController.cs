using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public float SecondsBetweenTrees = 1;
    public float TreesSpeed = 0.2f;

    public GameObject treePrefab;

    public float TreeCreationX = 20;
    public float TopTreeMinY = 3.0f;
    public float TopTreeMaxY = 7.0f;
    public float DistanceBetweenTreesY = 10.0f;
    public float DestroyTreesLeftOfX = -20.0f;

    private DateTime lastTreesCreatedAt = DateTime.Now;
    private Transform treeHolder;

    void CreateTreeAt(float x)
    {
        // Get a random position for the top tree and spawn
        // the rest of the tree parts based on that
        float topTreeY = UnityEngine.Random.Range(TopTreeMinY, TopTreeMaxY);
        float bottomTreeY = topTreeY - DistanceBetweenTreesY;

        Vector3 topTreePosition = new Vector3(x, topTreeY);
        Vector3 bottomTreePosition = new Vector3(x, bottomTreeY);

        Instantiate(treePrefab, topTreePosition, Quaternion.identity, treeHolder);
        Instantiate(treePrefab, bottomTreePosition, Quaternion.identity, treeHolder);
    }

    void CreateTrees()
    {
        // If enought seconds have passed since the last tree was created,
        // create a new tree now
        if(lastTreesCreatedAt.AddSeconds(SecondsBetweenTrees) < DateTime.Now)
        {
            CreateTreeAt(TreeCreationX);
            lastTreesCreatedAt = DateTime.Now;
        }
    }

    void MoveTrees()
    {
        // Move all trees to the right
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

        foreach(GameObject tree in trees)
        {
            tree.transform.position -= Vector3.right * TreesSpeed;

            // Destroy tree if it went off the screen
            if (tree.transform.position.x < DestroyTreesLeftOfX)
            {
                Destroy(tree.gameObject);
            }
        }
    }

    private void Start()
    {
        treeHolder = new GameObject("Trees").transform;
    }

    void Update () {
        CreateTrees();
        MoveTrees();
	}
}

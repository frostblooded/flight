using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public float SECONDS_BETWEEN_TREES = 1;
    public float TREES_SPEED = 0.2f;

    public GameObject treePrefab;

    private float TREE_CREATION_X = 20;
    private float TOP_TREE_Y = 3.5f;
    private float BOTTOM_TREE_Y = -3.5f;

    private DateTime lastTreesCreatedAt = DateTime.Now;

    void CreateTrees()
    {
        // If enought seconds have passed since the last tree was created,
        // create a new tree now
        if(lastTreesCreatedAt.AddSeconds(SECONDS_BETWEEN_TREES) < DateTime.Now)
        {
            Vector3 topTreePosition = new Vector3(TREE_CREATION_X, TOP_TREE_Y);
            Vector3 bottomTreePosition = new Vector3(TREE_CREATION_X, BOTTOM_TREE_Y);

            Instantiate(treePrefab, topTreePosition, Quaternion.identity);
            Instantiate(treePrefab, bottomTreePosition, Quaternion.identity);

            lastTreesCreatedAt = DateTime.Now;
        }
    }

    void MoveTrees()
    {
        // Move all trees to the right
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

        foreach(GameObject tree in trees)
        {
            tree.transform.position -= Vector3.right * TREES_SPEED;
        }
    }

	void Update () {
        CreateTrees();
        MoveTrees();
	}
}

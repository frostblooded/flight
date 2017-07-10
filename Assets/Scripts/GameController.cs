using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public float SECONDS_BETWEEN_TREES = 1;
    public float TREES_SPEED = 0.2f;

    public GameObject treePrefab;

    public float TREE_CREATION_X = 20;
    public float TOP_TREE_MIN_Y = 3.0f;
    public float TOP_TREE_MAX_Y = 7.0f;
    public float DISTANCE_BETWEEN_TREES_Y = 10.0f;

    private DateTime lastTreesCreatedAt = DateTime.Now;

    void CreateTrees()
    {
        // If enought seconds have passed since the last tree was created,
        // create a new tree now
        if(lastTreesCreatedAt.AddSeconds(SECONDS_BETWEEN_TREES) < DateTime.Now)
        {
            float topTreeY = UnityEngine.Random.Range(TOP_TREE_MIN_Y, TOP_TREE_MAX_Y);
            float bottomTreeY = topTreeY - DISTANCE_BETWEEN_TREES_Y;

            Vector3 topTreePosition = new Vector3(TREE_CREATION_X, topTreeY);
            Vector3 bottomTreePosition = new Vector3(TREE_CREATION_X, bottomTreeY);

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

    void DestroyTrees()
    {
        // Destroy trees that went off the screen to the left
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");

        foreach (GameObject tree in trees)
        {
            if(tree.transform.position.x < -20)
            {
                Destroy(tree.gameObject);
            }
        }
    }

	void Update () {
        CreateTrees();
        DestroyTrees();
        MoveTrees();
	}
}

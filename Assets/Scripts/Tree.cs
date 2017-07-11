using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public static float CreationX = 20;

    public float MoveSpeed = 0.2f;
    public float TopComponentMinY = 3.0f;
    public float TopComponentMaxY = 7.0f;
    public float DistanceBetweenComponentsY = 10.0f;
    public float DestroyTreesLeftOfX = -20.0f;

    public GameObject treeComponentPrefab;

    public void Move()
    {
        this.transform.position -= Vector3.right * MoveSpeed;

        // Destroy component if it went off the screen
        if (this.transform.position.x < DestroyTreesLeftOfX)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        float topTreeY = Random.Range(TopComponentMinY, TopComponentMaxY);
        float bottomTreeY = topTreeY - DistanceBetweenComponentsY;
        
        GameObject topTreeComponent = Instantiate(treeComponentPrefab, this.transform);
        GameObject bottomTreeComponent = Instantiate(treeComponentPrefab, this.transform);

        // Move the x of the components' relative position to zero, so
        // that they appear at the same x as their parent
        topTreeComponent.transform.localPosition = new Vector2(0, topTreeY);
        bottomTreeComponent.transform.localPosition = new Vector2(0, bottomTreeY);
    }

    private void FixedUpdate()
    {
        Move();
    }
}

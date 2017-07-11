using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public static float CreationX = 20;

    public float MoveSpeed = 0.2f;
    public float TopComponentMinY = 3.0f;
    public float TopComponentMaxY = 7.0f;
    public float DistanceBetweenComponentsY = 3.5f;
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
        Vector3 treeComponentSize = treeComponentPrefab.GetComponent<Renderer>().bounds.size;

        float topTreeY = Random.Range(TopComponentMinY, TopComponentMaxY);

        // To get what the Y of the bottom component should be, we first substract
        // the distance that we need between the components, but we also need to substract
        // half of the component's height which is taken into account because the Y
        // of the top component is actually its center. Then we substract half of the 
        // component's height again because the case is the same when it comes to
        // the bottom component. Ultimately we just substract the component's height once.
        float bottomTreeY = topTreeY - DistanceBetweenComponentsY - treeComponentSize.y;
        
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

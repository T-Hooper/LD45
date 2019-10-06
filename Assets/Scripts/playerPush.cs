using UnityEngine;
using System.Collections;

public class playerPush : MonoBehaviour
{

    public float distance = 1f;
    public LayerMask boxMask;
    public bool pushing = false;
    public Transform RaycastPoint;
    private float tempDis = 1f;

    private bool right = true;

    GameObject box;
    // Use this for initialization
    void Start()
    {
        tempDis = distance;
    }

    // Update is called once per frame
    void Update()
    {

        Physics2D.queriesStartInColliders = false;

        RaycastHit2D hit = Physics2D.Raycast(RaycastPoint.position, Vector2.right * RaycastPoint.localScale.x, distance, boxMask);


        if ((Input.GetKey("a") || Input.GetKey("left")) && !pushing)
        {
            right = false;
        }
        if ((Input.GetKey("d") || Input.GetKey("right")) && !pushing)
        {
            right = true;
        }

        if (right)
        {
            distance = tempDis;
        }
        else
        {
            distance = -tempDis;
        }




        if (hit.collider != null && hit.collider.gameObject.tag == "pushable" && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && pushing == false)
        {
            pushing = true;

            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().enabled = true;

        }
        else if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && pushing == true)
        {
            pushing = false;
            box.GetComponent<FixedJoint2D>().enabled = false;
        }

        if (transform.position == GetComponent<CharacterGamePlay>().tempPos)
        {
            pushing = false;
            box.GetComponent<FixedJoint2D>().enabled = false;
        }

    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;



        Gizmos.DrawLine(RaycastPoint.position, (Vector2)RaycastPoint.position + Vector2.right * RaycastPoint.localScale.x * distance);


    }
}
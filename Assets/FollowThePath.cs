using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;
    public int waypointIndex = 0;
    public bool moveAllowed = false;
    public bool moveReverseAllowed = false;

	// Use this for initialization
	private void Start () {
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	private void Update () {
        if (moveAllowed && !moveReverseAllowed)
        {
            Move();
        }

        if (!moveAllowed && moveReverseAllowed)
        {
            MoveReverse();
        }
        Debug.Log(waypointIndex + gameObject.name);
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
    }

    private void MoveReverse()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex - 2].transform.position, moveSpeed * Time.deltaTime);

        /*if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex-2].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex-2].transform.position)
            {
                waypointIndex -= 1;
            }
        }*/
    }
}

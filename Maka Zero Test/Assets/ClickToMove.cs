using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour
{
   public float speed;
    public  CharacterController controller;
    Vector3 position;

	// Use this for initialization
	void Start ()
    {
        position = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(0))
        {
            locatePosition();
        }
        moveToPosition();
    }
    void locatePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            Debug.Log(position);
        }
    }
    void moveToPosition()
    {
        if (Vector3.Distance(transform.position, position) > 0.8)
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position);

            newRotation.x = 0f;
            newRotation.z = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            controller.SimpleMove(transform.forward * speed);
        }
    }

}

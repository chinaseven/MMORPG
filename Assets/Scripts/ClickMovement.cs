using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animation anima;
    AnimationController animController;
	CharacterController charController;
	public Vector3 targetPosition;
	public bool canJump = true;
	public bool canMove = true;
	Vector3 m_DistanceFromCamera;
	public Terrain t;
	Plane m_Plane;
	public float m_DistanceZ;
	public Transform player;
	Quaternion bufferAndaRotation;
	void Start()
    {
		//m_DistanceFromCamera = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z - m_DistanceZ);
		m_Plane = new Plane(Vector3.zero + Vector3.up,1000.0f);
        targetPosition = transform.position;
        anima =GetComponentInChildren<Animation>();
        anima["anda"].speed = 1.2f;
        charController = GetComponent<CharacterController>();
        animController = GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetMouseButton (0) && canMove) {
			//RaycastHit hit;


			//Initialise the enter variable
			RaycastHit enter;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (t.GetComponent<Collider>().Raycast (ray,out enter,1000.0f)) {
				//Get the point that is clicked
				targetPosition = ray.GetPoint(enter.distance);

			}
		}


		if (GetComponent<AnimationController> ().stateOfAnimation != AnimationController.StateOfAnimation.atq) {
			if (Vector3.Distance (transform.position, targetPosition) > 0.5f) {
				animController.SetState (AnimationController.StateOfAnimation.anda);
				transform.position = Vector3.MoveTowards (transform.position, new Vector3 (targetPosition.x, 0, targetPosition.z), 20 * Time.deltaTime);
				transform.rotation = Quaternion.LookRotation (targetPosition - transform.position); 
				bufferAndaRotation = transform.rotation;
			} else {
				animController.SetState (AnimationController.StateOfAnimation.para);
				targetPosition = transform.position;
				transform.rotation = bufferAndaRotation;
			}
		}
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    // Start is called before the first frame update
    Animation a;
    void Start()
    {
		a =GetComponentInChildren<Animation>();
    }
    Vector3 targetPosition;
    Vector3 aux;
    public bool dash = false;
    public GameObject dashEffectParticle;
    public GameObject dashEffectParticleFinish;
	public Terrain t;
    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Q) && !dash)
        {
			RaycastHit enter;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (t.GetComponent<Collider>().Raycast (ray,out enter,1000.0f)) {
				//Get the point that is clicked
				aux = ray.GetPoint(enter.distance);

			}
			transform.rotation= Quaternion.LookRotation(new Vector3((aux - transform.position).x,0, (aux - transform.position).z));
			    
			targetPosition = transform.position + transform.forward * 15;
            //a["anda"].speed = 4;
			//Ray ray =Camera.main.ScreenPointToRay(Input.mousePosition);
			//if (t.GetComponent<Collider>().Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            //{
			//Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
			//	aux = ray.GetPoint(hit);
            //   
			dash = true;
//a["anda"].speed = 6;
            //}
        }
        if (dash)
        {
            if (Vector3.Distance(transform.position, targetPosition) > 0.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, 50 * Time.deltaTime);
            }
            else
            {
                dash = false;
                targetPosition = transform.position;
				GetComponent<ClickMovement> ().targetPosition = transform.position;
                //a["anda"].speed = 1.5f; 
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && !dash)
        {
            RaycastHit hit;

			RaycastHit enter;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (t.GetComponent<Collider>().Raycast (ray,out enter,1000.0f)) {
				//Get the point that is clicked
				aux = ray.GetPoint(enter.distance);
				transform.rotation = Quaternion.LookRotation(new Vector3((aux - transform.position).x, 0, (aux - transform.position).z));
				dash = true;
				targetPosition = transform.position + transform.forward * 6;
				Instantiate(dashEffectParticle, transform.position, Quaternion.identity) ;
			}
               
            
            transform.position = targetPosition;
            //Instantiate(dashEffectParticleFinish, transform.position, Quaternion.identity);
        }

    }
}

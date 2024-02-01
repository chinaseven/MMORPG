using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCamera : MonoBehaviour
{
    float h=0;
	float v=0;
    public Transform player;
    public Transform camBox;
	public Transform camBoxClose;
    // Start is called before the first frame update
    void Start()
    {
 
        
    }
    float min;
    float max;
    float camDist=120;
    bool closeUp = false;
    // Update is called once per frame
    void LateUpdate()
    {
        
        if (closeUp)
        {
			camBox.gameObject.SetActive (false);
			camBoxClose.gameObject.SetActive (true);
            //camDist += Input.GetAxis("Mouse ScrollWheel") * 2;
            //camBox.position = new Vector3 (camBox.position.x,camBox.position.y,camBox.transform.position.z + camDist);
            //camBox.position = player.transform.position + camBox.forward * -120;
        }
        else
        {
			camBox.gameObject.SetActive (true);
			camBoxClose.gameObject.SetActive (false);
            //camBox.position = player.transform.position + camBox.forward * -70;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (closeUp == false)
            {
                closeUp = true;
                //camBox.rotation = Quaternion.LookRotation(player.position);
            }

            else
            {
                closeUp = false;
                //camBox.rotation = Quaternion.LookRotation(player.position);

            }
        }

        if (Input.GetMouseButton(1))
        {
			h += Input.GetAxis("Mouse X")*5;
			v += Input.GetAxis("Mouse Y")*3;
            
        }
        transform.rotation = Quaternion.Euler(v, h, 0);
        //transform.position = Vector3.Lerp(transform.position, player.position, 25.5f*Time.deltaTime);
        transform.position = player.position;
    }
}

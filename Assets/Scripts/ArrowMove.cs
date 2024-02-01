using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        ac = GetComponent<AnimationController>();
    }
    float h;
    float v;
    float bh;
    float bv;
    CharacterController cc;
    AnimationController ac;
    float hv = 0;
    // Update is called once per frame
    void Update()
    {
		
        if (Input.GetMouseButton(1))
        {
			hv += Input.GetAxis("Mouse X") * 5;
			transform.rotation = Quaternion.Euler(0, hv, 0);
        }
        

        if (ac.stateOfAnimation != AnimationController.StateOfAnimation.atq )
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");
            //transform.rotation = Quaternion.Euler(0, hv, 0);
            if (h != 0)
            {

                cc.Move(transform.right * h *25 * Time.deltaTime);
                //transform.rotation = Quaternion.LookRotation(transform.position + transform.right*h);
            }
            if (v != 0)
            {
                cc.Move(transform.forward * v * 25 * Time.deltaTime);
                //transform.rotation = Quaternion.LookRotation(transform.position + transform.forward * v);
            }




            if (h == 0 && v == 0)
            {
                ac.SetState(AnimationController.StateOfAnimation.para);
                //transform.rotation = transform.rotation;
                /*if (GetComponent<Shot>().canAttack)
                {
                    if (v > 0)
                    {
                        transform.rotation = Quaternion.LookRotation(transform.forward * bv + transform.right*0.5f + transform.right * bh);
                    }
                    //transform.rotation = Quaternion.LookRotation(transform.forward * bv + transform.right * bh); 
                }
                else
                {
                    //transform.rotation = GetComponent<Shot>().attackRotationBuffer;
                }  */
            }
            else
            {
                //Rotação estilo WOW
                //transform.GetChild(0).rotation = Quaternion.LookRotation(transform.forward * v + transform.right * h);

                
                //if (v > 0)
                //{
					//transform.GetChild(0).rotation = Quaternion.LookRotation(transform.forward * v + transform.right * 0.35f + transform.right * h);
                //}
                //else
                //{
					transform.GetChild(0).rotation = Quaternion.LookRotation(transform.forward * v + transform.right * h);
                //}
                ac.SetState(AnimationController.StateOfAnimation.anda);
            }
                

        }

      /*
        if (v != 0)
        {
            transform.GetChild(0).rotation = Quaternion.LookRotation(transform.right * bh );
        }
        if (h != 0)
        {
            transform.GetChild(0).rotation = Quaternion.LookRotation(transform.right * h );
        }
        if (h != 0 )
        {
            //transform.GetChild(0).rotation = Quaternion.LookRotation(transform.right * bh + transform.right * h );
            bh = h;
            bv = v;
        }*/
    }
}
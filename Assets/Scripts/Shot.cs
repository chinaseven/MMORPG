using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shot : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource skillShotSound;
    public GameObject ShotParticle;
    GameObject shot;
    Collider[] cols;
    int defaultLayer =8;
    AnimationController animaC;
    public bool isAttacking = false;
    public bool canAttack = true;
    public bool canShotSkill = true;
    GameObject targetCreature;
    Animation anima;

	void Start()
	{
		anima = GetComponentInChildren<Animation>();
		animaC = GetComponent<AnimationController>();
		//skillShotSound = GetComponent<AudioSource>();
		anima["atq"].speed = 2.0f;
	}

    public void ShotSkill()
    {
		if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            //if (Physics.SphereCast(transform.position, 20.0f, transform.position + Vector3.up, out rh, 100.0f, defaultLayer))

			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500, LayerMask.GetMask("creature")))
            {

			//	if (hit.collider.tag == "enemy")
               // {
					Debug.Log ("FOI !");
					targetCreature = hit.collider.gameObject;
					
              //  }
                //else
               // {
                 //   targetCreature = null;
               // }


            }
            
        }
    }
    
    // Update is called once per frame
    void Update()
    {


        ShotSkill();

        if (targetCreature != null && canAttack)
        {

                canAttack = false;

                StartCoroutine(cooldownAttack());

                
            

        }


    }

	IEnumerator cooldownAttack()
	{
		//animaC.SetState(AnimationController.StateOfAnimation.atq);
		//transform.rotation = Quaternion.LookRotation(targetCreature.transform.position - transform.position);
		//skillShotSound.Play();
		isAttacking = true;
		shot = Instantiate(ShotParticle, transform.GetChild(0).position, Quaternion.identity);
		shot.GetComponent<ShotData>().target = targetCreature.gameObject;
		shot.transform.rotation = Quaternion.LookRotation(targetCreature.transform.position - transform.position);
		//Debug.Log(hit.collider.gameObject);
		yield return new WaitForSeconds(anima["atq"].length / 2.0f);
		//yield return new WaitForSeconds(0.5f);
		isAttacking = false;


		//Instantiate(ShotParticle, targetCreature.transform.position, Quaternion.identity);
		//targetCreature.GetComponent<CreatureData>().takeDamage(200);
		//animaC.SetState(AnimationController.StateOfAnimation.para);
		yield return new WaitForSeconds(0.3f);
		canAttack = true;
		//targetCreature = null;
	}
}

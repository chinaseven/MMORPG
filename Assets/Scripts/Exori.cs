using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exori : MonoBehaviour
{
    void Start()
    {
        anima = GetComponentInChildren<Animation>();
        animaC = GetComponent<AnimationController>();
        //anima["atq3"].speed = 2.0f;
        skillShotSound = GetComponent<AudioSource>();
    }
    public GameObject ShotParticle;
    public GameObject ShotParticle2;
    public GameObject ShotParticle3;
    GameObject shot;
    Collider[] cols;
    int defaultLayer =~7;
    RaycastHit hinfo;
    Animation anima;
    public bool isAttacking = false;
    public bool canAttack = true;
    public string atq= "atq3";
    AnimationController animaC;
    public AudioSource skillShotSound;
    int randomNumberRoll = 10;
    int randomBufferNumberRoll = 10;
    int randomCounterDamageNumberRoll = 10;
    int damageHit = 100;
    float hitSpeedComepensation = 2.0f;
    float aTtackSpeedDuration= 2.0f;
    bool attackSpeedOn = false;
    public AudioClip[] audioClips;

    public void attackSpeed(bool on)
    {
        if (attackSpeedOn)
        {
            hitSpeedComepensation = 2.0f;
        }
        else
        {
     
            hitSpeedComepensation = 1.0f;
        }

    }
    
	IEnumerator attackSpeedDuration()
	{
		attackSpeedOn = true;
		yield return new WaitForSeconds(aTtackSpeedDuration);
		attackSpeedOn = false;
	}

    public void BufferRoll()
    {
        randomBufferNumberRoll = Random.Range(1, 10);
        if (randomBufferNumberRoll <=3 && attackSpeedOn != true )
        {
         
            StartCoroutine(attackSpeedDuration());
        }
    }

    public void BufferCounterDamageRoll()
    {
        randomCounterDamageNumberRoll = Random.Range(1, 10);
    }

    public void counterAttack()
    {
        if (randomCounterDamageNumberRoll <= 3) { 
            cols = Physics.OverlapSphere(transform.position, 8.0f, defaultLayer);
            if (cols.Length > 0 && canAttack)
            {

                shot = Instantiate(ShotParticle3, transform.position, transform.rotation);
                randomCounterDamageNumberRoll = 10;
                skillShotSound.clip = audioClips[2];
                skillShotSound.Play();
                foreach (Collider c in cols)
                {
                    if (c.gameObject.tag == "enemy")
                    {

                        c.gameObject.GetComponentInParent<CreatureData>().takeDamage(100);
                    }
                }
            }
        }
    }

	IEnumerator coolDownAttack()
	{

		canAttack = false;
		/*if (!anima.IsPlaying("atq3"))
                {
                    anima.Play("atq3");
                }*/
		animaC.SetState(AnimationController.StateOfAnimation.atq);
		isAttacking = true;
		yield return new WaitForSeconds(anima["atq"].length / hitSpeedComepensation);
		//yield return new WaitForSeconds(1.0f);
		isAttacking = false;
		animaC.SetState(AnimationController.StateOfAnimation.para);
		yield return new WaitForSeconds(0.3f);
		canAttack = true;

		if (randomNumberRoll <= 3)
		{
			//shot = Instantiate(ShotParticle2, transform.position, transform.rotation);
			skillShotSound.clip = audioClips[1];
			skillShotSound.Play();
		}
		else
		{
			skillShotSound.clip = audioClips[0];
			skillShotSound.Play();
			//shot = Instantiate(ShotParticle, transform.position, transform.rotation);
		}
	}

    public void shotExoriSkill()
    {
  


        
        cols = Physics.OverlapSphere(transform.position, 8.0f, defaultLayer);
        randomNumberRoll = Random.Range(1, 10);
        if (cols.Length > 0 && canAttack)
        {

            foreach (Collider c in cols)
            {
                if (c.gameObject.tag == "enemy")
                {
                    if (randomNumberRoll <=5)
                    {
                        c.gameObject.GetComponentInParent<CreatureData>().takeDamage(500);
                    }

                    else
                    {
                        c.gameObject.GetComponentInParent<CreatureData>().takeDamage(200);
                    }



                }
            }


            StartCoroutine(coolDownAttack());
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            shotExoriSkill();
        }

        counterAttack();
        
    }
}
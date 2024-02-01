using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform creatureTarget;
    Animation animaCreature;
    CharacterController charController;
    bool canAttack = true;
    void Start()
    {
        animaCreature = GetComponentInChildren<Animation>();
        animaCreature["anda"].speed = 2.0f;
        charController = GetComponent<CharacterController>();
    }

	IEnumerator hitPlayer()
	{

		yield return new WaitForSeconds(animaCreature["atq"].length);
		canAttack = true;

	}

    // Update is called once per frame
    public float speed = 8;
    void Update()
    {
        if (creatureTarget != null && !GetComponent<CreatureData>().isDead)
        {
            if (Vector3.Distance(transform.position, creatureTarget.position) > 5.0f)
            {
                transform.rotation = Quaternion.LookRotation(creatureTarget.position - transform.position);
                //transform.position = Vector3.MoveTowards(transform.position, creatureTarget.position, 10 * Time.deltaTime);
                charController.Move(transform.forward*Time.deltaTime*speed);
                if (!animaCreature.IsPlaying("anda"))
                {
                    animaCreature.Play("anda");
                }
            }
            else
            {
				if (canAttack) {
					//creatureTarget.gameObject.GetComponent<PlayerData> ().takeDamage ();
					canAttack = false;
					if (!animaCreature.IsPlaying ("atq")) {
						animaCreature.Play ("atq");
					}
                    
					StartCoroutine (hitPlayer ());

				}/* else {
					if (!animaCreature.IsPlaying ("para")) {
						animaCreature.Play ("para");
					}

				}*/
            }
        }
    }
}

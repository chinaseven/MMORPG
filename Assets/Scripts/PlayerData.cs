using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    int healthPoints = 1000;
    public bool isDead = false;

    public int magicLevel = 25;
    public int inteligence = 100;
    public int vitality = 1000;

    void Start()
    {
    }
	IEnumerator stayDead()
	{
		yield return new WaitForSeconds(1.5f);
		isDead = false;
		healthPoints = 1000;
	}
    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0 && isDead == false)
        {
            isDead = true;
            //transform.gameObject.tag = "dead";
            //transform.gameObject.layer =~4;
            transform.position = Vector3.zero;
            /*
            if (!animaCreature.IsPlaying("morto"))
            {
                animaCreature.Play("morto");
            }
            */

            StartCoroutine(stayDead());
            

        }
    }

    public void takeDamage()
    {
        healthPoints -= Random.Range(0,100);
        healthPoints += Random.Range(0, 200);
        //GetComponent<Exori>().BufferRoll();
        //GetComponent<Exori>().BufferCounterDamageRoll();
    }
}

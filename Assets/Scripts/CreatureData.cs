using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureData : MonoBehaviour
{
    // Start is called before the first frame update
    int healthPoints = 1000;
    public bool isDead = false;
    Animation animaCreature;
    SpawCreature spawnCreature;
    void Start()
    {
        animaCreature = GetComponentInChildren<Animation>();
		//spawnCreature = GameObject.Find("SpawnCreature").GetComponent<SpawCreature>();
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0 && isDead == false)
        {
            
            isDead = true;
            transform.gameObject.tag = "dead";
            
            //transform.gameObject.layer =~4;
            /*if (!animaCreature.IsPlaying("morto"))
            {
                animaCreature.Play("morto");
            }*/

       
            StartCoroutine(stayDead());
        }
    }
	IEnumerator stayDead()
	{
		yield return new WaitForSeconds(1.0f);
		//Destroy(gameObject);
		healthPoints = 1000;
		spawnCreature.addFila(gameObject);
		gameObject.SetActive(false);
	}


    public void takeDamage(int damage)
    {
        int dano = damage;
        //GetComponent<ShowDano>().MonstrarDano(dano);
        healthPoints -=  dano;
        GetComponent<CreatureControl>().speed = 4.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotFreeze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        anima = GetComponentInChildren<Animation>();
        animationController = GetComponent<AnimationController>() ;
        //audioSource = GetComponent<AudioSource>();
    }
    AudioSource audioSource;
    Animation anima;
    public GameObject shotFreeze;
    public GameObject ShotFreeze2;
    GameObject shot;
    bool canShot = true;
    bool canCast = true;
    AnimationController animationController;
    Vector3 targetShotPosition;
    int count = 0;
    Quaternion shotFreezeRotation;
    // Update is called once per frame

	IEnumerator shottingCast()
	{
		//audioSource.Play();
		animationController.SetState(AnimationController.StateOfAnimation.atq);
		yield return new WaitForSeconds(anima["atq"].length / 1.0f);
		animationController.SetState(AnimationController.StateOfAnimation.para);
	}

    public void shotSkill(GameObject shotSkillChoosed)
    {
        if (/*Input.GetMouseButtonDown(0) &&*/ canCast)
	        {   /*
            RaycastHit hit;
            shotSkillTemp = shotSkillChoosed;
            if (Terrain.activeTerrain.GetComponent<Collider>().Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                targetShotPosition = hit.point;
                shotFreezeRotation = Quaternion.LookRotation(targetShotPosition - transform.position);
                //transform.GetChild(0).rotation = shotFreezeRotation;
                //transform.rotation = shotFreezeRotation;
            }*/
  
           

         
        }
    }

    void Update()
    {
		if (canShot && Input.GetKey(KeyCode.Q))
        {
			canShot =false;
			shot = Instantiate(shotFreeze,transform.position, transform.rotation);
			shot.GetComponent<ShotData>().targetPoint =  shot.transform.position + shot.transform.forward * 100;
            shotSkill(shotFreeze);
			StartCoroutine(shottingCast());
			StartCoroutine(shottingCast2());
        } 
    }


	IEnumerator shottingCast2()
	{
		yield return new WaitForSeconds(0.5f);
		canShot = true;
		count++;
	}
}

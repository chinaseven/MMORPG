using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public GameObject target;
    public Vector3 targetPoint;
    public GameObject hitEnemyPart;
    Collider[] cols;
    int defaultLayer =~7;
    // Update is called once per frame
    void Update()
    {
    /*
        if (Vector3.Distance(transform.position, targetPoint) > .5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPoint, 50 * Time.deltaTime);

        }else
        {
            Destroy(gameObject);
        }*/

        if (target != null)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > .5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 90 * Time.deltaTime);
            }
            else
            {
                //cols = Physics.OverlapSphere(transform.position, 6.0f, defaultLayer);
                //foreach (Collider c in cols)
                //{
                ///    c.gameObject.GetComponentInParent<CreatureData>().takeDamage();
				
                //}
                //Instantiate(magicHit, target.transform.position, Quaternion.identity);
               // CreatureData cd = target.GetComponentInParent<CreatureData>();
                //cd.takeDamage(100);
				Instantiate(hitEnemyPart, target.transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        
        
    }
}

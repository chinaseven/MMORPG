using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawCreature : MonoBehaviour
{
    public GameObject creaturePrefab;
    GameObject currentCreature;
    Queue<GameObject> creatures = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            currentCreature = Instantiate(creaturePrefab, new Vector3(Random.Range(50, -50), 0, Random.Range(50, -50)), Quaternion.identity);
            creatures.Enqueue(currentCreature);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (creatures.Count >= 1)
        {
            // Instantiate(creaturePrefab, new Vector3(Random.Range(50, -50), 0, Random.Range(50, -50)), Quaternion.identity);
            currentCreature = creatures.Dequeue();
            currentCreature.SetActive(true);
            currentCreature.transform.position = new Vector3(Random.Range(50, -50), 0, Random.Range(50, -50));
            currentCreature.tag = "enemy";
            
        /// currentCreature.GetComponent<CreatureData>().rechargeHPCreature();
            currentCreature.GetComponent<CreatureData>().isDead = false;
        }
    }

    public void addFila(GameObject creature)
    {
        creatures.Enqueue(creature);
    }
}


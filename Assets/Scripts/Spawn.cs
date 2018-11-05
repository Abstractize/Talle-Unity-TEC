using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject Boulder;

	// Use this for initialization
	void Start () {

        InvokeRepeating("CreateBoulder", 0f, 3f);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateBoulder()
    {
        Vector3 position = new Vector3(Random.Range(-18, -6), 0, 0);
        GameObject instance = Instantiate(Boulder, transform.position + position, transform.rotation);

        Vector3 position2 = new Vector3(Random.Range(-6, 6), 0, 0);
        GameObject instance2 = Instantiate(Boulder, transform.position + position2, transform.rotation);

        Physics.IgnoreCollision(instance.GetComponent<Collider>(), instance2.GetComponent<Collider>());

        Vector3 position3 = new Vector3(Random.Range(6, 18), 0, 0);
        GameObject instance3 = Instantiate(Boulder, transform.position + position3, transform.rotation);

        Physics.IgnoreCollision(instance2.GetComponent<Collider>(), instance3.GetComponent<Collider>());

        Destroy(instance, 10f);
        Destroy(instance2, 10f);
        Destroy(instance3, 10f);
    }
}

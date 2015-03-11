using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

    public Transform vortex;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter() {

        vortex.GetComponent<Animator>().SetBool("Ouverte", false);

    }
}

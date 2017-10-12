using UnityEngine;
using System.Collections;

public class LookAtBehaviour : MonoBehaviour {

    public Transform Target;
    
	// Use this for initialization
	void Start () 
    {
//		Target = GameObject.FindWithTag(Tags.mainCamera).transform;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Target != null)
        {
            transform.LookAt(Target);
        }
	}
}
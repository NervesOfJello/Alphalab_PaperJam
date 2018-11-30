using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movement : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (InputUtil.IsHoldingKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0,0.1f);

        }
        if (InputUtil.IsHoldingKey(KeyCode.A)) {

            this.transform.position += new Vector3(-0.1f, 0);
        }
        if (InputUtil.IsHoldingKey(KeyCode.S))
        {

            this.transform.position += new Vector3(0, -0.1f);
        }
        if (InputUtil.IsHoldingKey(KeyCode.D))
        {
            this.transform.position += new Vector3(0.1f, 0);

        }
    }
}

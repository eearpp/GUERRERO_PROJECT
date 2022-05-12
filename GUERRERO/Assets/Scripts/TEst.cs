using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEst : MonoBehaviour
{
    private GameObject asd;

    // Start is called before the first frame update
    void Start()
    {
        asd = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(asd.name + " = " + this.gameObject.name);
    }
}

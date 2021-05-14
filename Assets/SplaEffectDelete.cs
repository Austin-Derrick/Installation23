using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplaEffectDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeleteSelf());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DeleteSelf()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}

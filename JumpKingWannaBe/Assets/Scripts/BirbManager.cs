using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbManager : MonoBehaviour
{
    public GameObject birbPref;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnBirb",1,60);
    }


    void spawnBirb()
    {
        GameObject clone = Instantiate(birbPref, transform.position, Quaternion.identity);
        Destroy(clone,65);
    }
}

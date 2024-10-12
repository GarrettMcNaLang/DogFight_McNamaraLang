using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolStorage : MonoBehaviour
{

    [SerializeField]
    private ObjectPoolScript BomberPool;

    [SerializeField]
    private ObjectPoolScript FighterPool;

    [SerializeField]
    private ObjectPoolScript ProjectilePool;

    [SerializeField]
    private ObjectPoolScript PlayerPool;


    void Awake()
    {
        BomberPool = GameObject.Find("BomberPool").GetComponent<ObjectPoolScript>();

        FighterPool = GameObject.Find("FighterPool").GetComponent<ObjectPoolScript>();

        ProjectilePool = GameObject.Find("ProjectilePool").GetComponent<ObjectPoolScript>();

        PlayerPool = GameObject.Find("PlayerPool").GetComponent<ObjectPoolScript>();
    }
}


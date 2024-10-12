using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a script that stores an object pool reference
public class PooledObject : MonoBehaviour
{
    public ObjectPoolScript owner;


}

//adds a new method the the GameObjectClass
public static class PooledGameObjectExtensions
{
   //call it like this
    //gameObject.ReturnToPool();


    //returns an objec to the pool that created it
    public static void ReturnToPool(this GameObject gameObject)
    {
        //find the Pooled object component
        var pooledObject = gameObject.GetComponent<PooledObject>();

        //if it doesn't exist, it means it never came from a pool
        if (pooledObject == null)
        {
            Debug.LogErrorFormat(gameObject,
                "Cannot return {0} to object pool, because it was not" + "created from one.", gameObject);

            return;
        }

        //return this object to the pool
        pooledObject.owner.ReturnObject(gameObject);
    }
}


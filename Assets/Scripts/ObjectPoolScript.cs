using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//credits: Unity Game Development Cookbook Essentials for Every Game Paris Buttfield-Addison, Jon Manning, and Tim Nugent


public interface IObjectPoolNotifier {

    //called when object is being returned to the pool
    void OnEnqueuedToPool();

    //call when an object is created or when it's recycled in the pool
    void OnCreatedOrDequeuedFromPool(bool created);
}
public class ObjectPoolScript : MonoBehaviour
{

    //instantiated prefab
    [SerializeField]
    private GameObject prefab;

    //stores the objects not in use
    private Queue<GameObject> inactiveObjects = new Queue<GameObject>();

    //retrieves an object from the pool
    public GameObject GetObject()
    {
        //checks if objects are in the pool to reuse
        if (inactiveObjects.Count > 0)
        {
            //gets an object from the queue
            var dequeuedObject = inactiveObjects.Dequeue();

            //activates the object and moves it from root
            dequeuedObject.transform.position = this.transform.position;
            //dequeuedObject.transform.parent = null;
            dequeuedObject.SetActive(true);

            //if the object possesses the notifier interface
            var notifiers = dequeuedObject.GetComponents<IObjectPoolNotifier>();

            //notify all MonoBehaviors that this object left the pool
            foreach(var notifier in notifiers)
            {
                //notify the scrip thtat it left the pool
                notifier.OnCreatedOrDequeuedFromPool(false);
            }
            //return the object for use
            return dequeuedObject;
        }
        else
        {
            //if there are no objects in the pool, create a new object
            var newObject = Instantiate(prefab,gameObject.transform.position, Quaternion.identity);

            //add the pooledObject component to allow it to be retrieved and added to the pool
            var poolTag = newObject.AddComponent<PooledObject>();

            poolTag.owner = this;

            //make it so the pool tag doesn't show up in the inspector, as it's only a reference
            poolTag.hideFlags = HideFlags.HideInInspector;

            //notify the object that it was created
            var notifiers = newObject.GetComponents<IObjectPoolNotifier>();

            foreach(var notifier in notifiers)
            {
                //notify the script that it was created
                notifier.OnCreatedOrDequeuedFromPool(true);
            }

            //return the object that was created
            return newObject;
        }
    }

    //disables an object and returns it to the queue for use later

    public void ReturnObject(GameObject gameObject)
    {
        //retrieve the component that needs to be notified
        var notifiers = gameObject.GetComponents<IObjectPoolNotifier>();


        foreach(var notifier in notifiers)
        {
            //inform that it's returning to the pool
            notifier.OnEnqueuedToPool();
        }
        
        //disable the object and make it a child of this object
        gameObject.SetActive(false);
        //gameObject.transform.parent = this.transform;
        gameObject.transform.position = this.transform.position;
        //puts the object into the queue
        inactiveObjects.Enqueue(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private Renderer imageRenderer;

    // Update is called once per frame
    void Update()
    {
        //takes a direction for the material to scroll in, which is down in this case
        imageRenderer.material.mainTextureOffset += new Vector2(0, -(speed * Time.deltaTime));
    }
}

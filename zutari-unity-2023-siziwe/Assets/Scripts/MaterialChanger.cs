using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    //Initializing materials for all directions
    public Material right;
    public Material left;
    public Material up;
    public Material down;

    public MeshRenderer mrd;

    private void Awake()
    {
        mrd.material = right; //Default material
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)) //D for moving right
        {
            mrd.material = right;
        }
        if (Input.GetKeyDown(KeyCode.A)) //A for moving left
        {
            mrd.material = left;
        }
        if (Input.GetKeyDown(KeyCode.W)) //M for moving up
        {
            mrd.material = up;
        }
        if (Input.GetKeyDown(KeyCode.S)) //S for moving down
        {
            mrd.material = down;
        }
    }
}

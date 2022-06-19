using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private GameObject cube;
    public float speed = 2f;
    private bool isSplit = false;
    List<Transform> childArray = new List<Transform>();

    private void Start()
    {
        cube = this.gameObject;
        Invoke("DestroyCube", 4f);
    }


    // Update is called once per frame
    void Update()
    {
        if (isSplit == false)
        {
            cube.transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            childArray = SplitCube();
        }
    }

    public List<Transform> SplitCube()
    {
        List<Transform> childArray = new List<Transform>();
        for (int i = 0; i < 2; i++)
        {
            Transform child = this.transform.GetChild(0);
            child.SetParent(null);
            if (i == 0)
                child.gameObject.AddComponent<Rigidbody>().AddForce(transform.right * 100);
            else
                child.gameObject.AddComponent<Rigidbody>().AddForce(transform.right * -100);
            childArray.Add(child);
        }
        isSplit = true;
        return childArray;
    }

    public void SplitCube(RaycastHit cube)
    {
        List<Transform> childArray = new List<Transform>();
        for (int i = 0; i < 2; i++)
        {
            Transform child = cube.transform.GetChild(0);
            child.SetParent(null);
            if(i == 0)
                child.gameObject.AddComponent<Rigidbody>().AddForce(transform.right * 100);
            else
                child.gameObject.AddComponent<Rigidbody>().AddForce(transform.right * -100);
            childArray.Add(child);
        }
        cube.transform.GetComponent<CubeScript>().isSplit = true;
        cube.transform.GetComponent<CubeScript>().childArray = childArray;
    }

    void DestroyCube()
    {
        if(isSplit == false)
        {
            Destroy(this.gameObject);
        }
        else
        {
            foreach(Transform i in childArray)
            {
                Destroy(i.gameObject);
            }
        }
    }
}


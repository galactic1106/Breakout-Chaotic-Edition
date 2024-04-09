using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceBlocks : MonoBehaviour
{
    public int xStart, yStart;
    public int xEnd, yEnd;
    public int xJump, yJump;
    public GameObject blockPrefab;
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = yStart; i <= yEnd; i+=yJump)
        {
            //Debug.Log(i);
            for(int j = xStart; j <= xEnd; j+=xJump)
            {
                //Debug.Log(j);
                GameObject go = Instantiate(blockPrefab);
                go.transform.SetParent(gameObject.transform);
                go.transform.position = new Vector3(j,i,0);
                go.GetComponent<SpriteRenderer>().material = materials[Random.Range(0,materials.Length)];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

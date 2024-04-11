using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceBlocks : MonoBehaviour
{
    public float xStart, yStart;
    public float xEnd, yEnd;
    public float xJump, yJump;
    public GameObject blockPrefab;
    public Material[] materials;
    public bool randomColors;
    // Start is called before the first frame update
    private int line=0;
    void Start()
    {
        for (float i = yStart; i <= yEnd; i += yJump)
        {
            //Debug.Log(i);
            for (float j = xStart; j <= xEnd; j += xJump)
            {
                //Debug.Log(j);
                GameObject go = Instantiate(blockPrefab);
                go.transform.SetParent(gameObject.transform);
                go.transform.position = new Vector3(j, i, 0);
                if(randomColors)
                {
                    go.GetComponent<SpriteRenderer>().material = materials[Random.Range(0, materials.Length)];
                }else
                {
                    go.GetComponent<SpriteRenderer>().material = materials[line];
                }
            }
            if(line!=materials.Length) line++;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

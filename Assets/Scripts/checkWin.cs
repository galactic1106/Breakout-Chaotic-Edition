using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkWin : MonoBehaviour
{
    private GameObject win;
    private void Start()
    {
        win = GameObject.FindGameObjectWithTag("Win");
        win.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.childCount == 0)
        {
            win.SetActive(true);
            Destroy(GameObject.FindWithTag("Ball"));
        }
    }
}

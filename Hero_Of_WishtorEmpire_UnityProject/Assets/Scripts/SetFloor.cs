using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloor : MonoBehaviour
{
    [SerializeField]
    int floorLen;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < floorLen;i++) {
            GameObject floor = Instantiate(Resources.Load<GameObject>("FloorBlock"));
            floor.transform.position = new Vector3(floor.transform.position.x + i,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

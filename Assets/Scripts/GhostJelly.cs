using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostJelly : MonoBehaviour
{
    public static GhostJelly instance;
    public Transform[] ghostPoses;

    private int index;

    private void Awake()
    {
        instance = this;
    }

    public void GhostScale(Vector3 scale)
    {
        transform.localScale = scale;
    }

    public void GhostPosition()
    {
        index++;
        if (ghostPoses.Length > index)
        {
            transform.position = ghostPoses[index].transform.position;
        }
    }
}

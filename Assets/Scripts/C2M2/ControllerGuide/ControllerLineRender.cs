using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ControllerLineRender : MonoBehaviour
{
    [SerializeField] public Transform[] points;
    [SerializeField] public ControllerGuideLineRender line;

    private void Start()
    {
        line.SetUpLine(points);
    }
}
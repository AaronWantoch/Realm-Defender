using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
    TextMesh textMesh;
    Vector3 snapPosition;
    Waypoint waypoint;

    int gridSize;

    void Update()
    {
        waypoint = GetComponent<Waypoint>();
        gridSize = waypoint.GetGridSize();
        SnapPosition();
        SetCubeLabel();
    }

    private void SetCubeLabel()
    {
        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPosition.x / gridSize + "," + snapPosition.z / gridSize;

        textMesh.text = labelText;
        gameObject.name = labelText;
    }

    private void SnapPosition()
    {
        snapPosition = new Vector3(
            waypoint.GetWaypointPosition().x * gridSize,
            0,
            waypoint.GetWaypointPosition().y * gridSize
            );
        transform.position = snapPosition;
    }
}
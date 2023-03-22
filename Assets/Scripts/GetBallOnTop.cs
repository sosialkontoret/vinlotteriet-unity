using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GetBallOnTop : MonoBehaviour
{

    [SerializeField]
    private float rayLength;

    [SerializeField]
    private Transform BallPivotPoint;
    public UnityEvent RestartBallFinding;

    private GameObject _drawBall;
    // Start is called before the first frame update


    // Update is called once per frfBame

    /*private void OnTriggerEnter(Collider other)
    {
        if (!other.transform.CompareTag("Ball")) return;
        Debug.Log(other.name);
        _drawBall = other.gameObject;
    }*/

    private void OnDrawGizmosSelected()
    {

        float angleDir = 15;
        Vector3 start = transform.position;
        Quaternion spreadAngle = Quaternion.AngleAxis(angleDir, start);
        Gizmos.color = Color.red;
        Vector3 direction = spreadAngle * Vector3.up * rayLength;
        Gizmos.DrawRay(start, direction);

    }

    private GameObject GetObjectFromRaycast(float angleDir)
    {
        GameObject gameObject = null;
        Vector3 start = transform.position;
        Quaternion spreadAngle = Quaternion.AngleAxis(angleDir, start);
        Vector3 direction = spreadAngle * Vector3.up * 1;
        Debug.DrawRay(start, direction, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(start, direction, out hit) && hit.transform.CompareTag("Ball"))
        {
            gameObject = hit.collider.gameObject;
            return gameObject;
        }

        angleDir += 15;
        //If ray has rotated all th way araound, assume only 1 ball is left
        if (angleDir > 360 )
        {
            GameObject[] listOfBalls = GameObject.FindGameObjectsWithTag("Ball");
            return listOfBalls[0];
        } 
        gameObject = GetObjectFromRaycast(angleDir);

        return gameObject;
    }
    public void GetBallOnTopOfObject()
    {
        if (_drawBall == null)
        {
            _drawBall = GetObjectFromRaycast(0);
        }
        _drawBall.transform.parent = transform;
        Debug.Log("getballontop");
        _drawBall.transform.position = BallPivotPoint.transform.position;
        _drawBall.transform.name = "DrawBall";
        _drawBall.transform.tag = "DrawBall";
        _drawBall.transform.Find("Name").gameObject.SetActive(true);
        GetComponent<Collider>().enabled = false;


    }

    public void SetDrawBallRigidBodyKinematic(bool isKinematic)
    {
        _drawBall.GetComponent<Rigidbody>().isKinematic = isKinematic;
    }
    public void SetDrawBallParent(Transform obj)
    {
        _drawBall.transform.parent = obj;
    }
    public void SetDrawBallParentNull()
    {
        _drawBall.transform.parent = null;
    }

    public void setParentTochildWorldPos(Transform parent)
    {
        parent.position = _drawBall.transform.position;
    }
}

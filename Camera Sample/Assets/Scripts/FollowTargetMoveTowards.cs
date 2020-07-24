
//Alternate mplemantation for logic to follow target 
using UnityEngine;

public class FollowTargetMoveTowards : MonoBehaviour, IFollowTarget
{
    //Speed and distance. 1 unit in Unity is 1 meter
    private static float followSpeed = 1.0f;
    private static float followDistance = 1.0f;

    public void Follow(Transform target)
    {
        //If condition to ensure that object only closes in on target if target is over 1 meter away
        if (Vector3.Distance(transform.position, target.position) > followDistance)
        {
            //Get the position and direction of target
            Vector3 objectToPos = new Vector3(target.position.x, transform.position.y, target.position.z);

            //Look at and move towards the target
            transform.LookAt(objectToPos);
            transform.position = Vector3.MoveTowards(transform.position, objectToPos, followSpeed * Time.deltaTime);
        }        
    }
}

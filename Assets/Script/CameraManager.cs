using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    Transform p_Transform;

    void Start()
    {
        p_Transform = Player.transform;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(p_Transform.position.x, p_Transform.position.y, -10);
    }

}

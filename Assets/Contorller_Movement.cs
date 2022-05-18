using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Contorller_Movement : MonoBehaviour
{
    public CharacterController characterController;
    private Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vector = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * new Vector3(SteamVR_Actions.default_walk.GetAxis(SteamVR_Input_Sources.Any).x, 0, SteamVR_Actions.default_walk.GetAxis(SteamVR_Input_Sources.Any).y);
        characterController.SimpleMove(vector);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    Camera MainCamera;
    [SerializeField]
    GameObject Hand;
    GameObject PickObject;
    bool IsPick = false;

    // Use this for initialization
    void Start()
    {
        MainCamera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Pick") == 1)
        {
            if (IsPick == false)
            {
                GameObject HitObject;
                if (RayHit(out HitObject))
                {
                    Pick(HitObject);
                }
            }
			else
			{
                Throw();
            }
        }

    }

    private void Throw()
    {
        Destroy(PickObject.GetComponent<FixedJoint>());
        IsPick = false;
    }

    private void Pick(GameObject HitObject)
    {
        if (HitObject.tag == "Pickable")
        {
            HitObject.AddComponent<FixedJoint>();
            HitObject.GetComponent<FixedJoint>().connectedBody = Hand.GetComponent<Rigidbody>();
            IsPick = true;
            PickObject = HitObject;
        }
    }

    private bool RayHit(out GameObject HitObject)
    {
        RaycastHit hit;
        Ray ray = MainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
        if (Physics.Raycast(ray, out hit, 2))
        {
            HitObject = hit.collider.gameObject;
            return true;
        }
        else
        {
            HitObject = null;
            return false;
        }
    }
}

using UnityEngine;

public class ReceptionPointScript : MonoBehaviour
{
    private GameObject customer;
    private bool customerIsHere = false;
    private bool customerIsServed = false;


    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, GetGridScript.Instance.GetZ());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (!customerIsHere)
        {
            if (collision.tag == "Customer")
            {
                customerIsHere = true;
                customer = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (customerIsHere)
        {
            if (collision.tag == "Customer")
            {
                customerIsHere = false;
                customer = null;
            }
        }
    }

    /// <summary>
    /// Get the current customer's gameobject
    /// </summary>
    /// <returns></returns>
    public GameObject GetCustomer()
    {
        return customer;
    }

    /// <summary>
    /// Get if there is a customer on the spot
    /// </summary>
    public bool CustomerIsHere { get { return customerIsHere; } set { customerIsHere = value; } }


    public bool CustomerIsServed { get { return customerIsServed; } set { customerIsServed = value; } }

}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//using TMPro;
public class FruitMeschanism : MonoBehaviour
{
    
    [SerializeField] Rigidbody fruitRb;
    [SerializeField] GameObject wholeFruit;
    [SerializeField] GameObject[] slicedFruit;
    [SerializeField] float cutForceLimit = 15f;
    

    public float speed;
    public float rotationSpeed = 20f;

    
    private void Start()
    {
        moveFruit();
    }

    private void Update()
    {
        rotateFruit();
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Sword"))
        {
            float collisionForce = other.relativeVelocity.magnitude;
            AudioManager.instance.PlaySFX("slash");

            if (collisionForce >= cutForceLimit)
            {
                wholeFruit.SetActive(false);
                AudioManager.instance.PlaySFX("splat");
                foreach (var item in slicedFruit)
                {
                    item.SetActive(true);
                }
                GameConst.score += 10;
            }
                
        }
    }

    public void moveFruit()
    {
        Vector3 playerPos = Camera.main.transform.position;
        playerPos.y = -1.4f;
        Vector3 directionToPlayer = playerPos - transform.position;
        fruitRb.AddForce(directionToPlayer * speed, ForceMode.Impulse);
        fruitRb.AddForce(Vector3.up * 4, ForceMode.Impulse);
    }

    public void rotateFruit()
    {
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime+
                         Vector3.forward * rotationSpeed * Time.deltaTime+
                         Vector3.up * rotationSpeed * Time.deltaTime,
                         Space.Self);
    }

}

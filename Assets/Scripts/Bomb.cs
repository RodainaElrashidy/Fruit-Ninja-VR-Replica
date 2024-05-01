using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] Rigidbody BombRb;

    //int value = 100;
    public float speed;
    private void Start()
    {
        moveBomb();
        StartCoroutine(DeleteBomb());
        AudioManager.instance.PlaySFX("hiss");
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Sword")
        {
            //value -= 10;
            AudioManager.instance.PlaySFX("swordHit");
            AudioManager.instance.PlaySFX("explosion");
            GameConst.value -= 10; //value;
            if(GameConst.value <= 0)
            {
                UnityEditor.EditorApplication.isPlaying = false;
                //in built ver
                //Application.Quit();
            }
        }
    }

    public void moveBomb()
    {
        Vector3 playerPos = Camera.main.transform.position;
        playerPos.y = -1.4f;
        Vector3 directionToPlayer = playerPos - transform.position;
        BombRb.AddForce(directionToPlayer * speed, ForceMode.Impulse);
        BombRb.AddForce(Vector3.up * 4, ForceMode.Impulse);
    }

    IEnumerator DeleteBomb()
    {
        yield return new WaitForSeconds(8);
        gameObject.SetActive(false);
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health,bulletSpeed;
    
    bool dead = false;

    private Transform muzzle;
    
    public Transform bullet, floatingText, bloodParticle;

    public Slider slider;

    private bool mouseIsNotOverUI;
    
    
    
    void Start()
    {
        muzzle = transform.Find("Muzzle");
        slider.maxValue = health;
        slider.value = health;
    }

    
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {
            ShootBullet();
        }
    }



    public void GetDamage(float damage)
    {
        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
        
        if (health - damage >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        } 
        slider.value = health;
        AmIDead();
    }    
    
    
    void AmIDead()
    {
        if (health <= 0)
        {
            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);
            DataManager.Instance.LoseProcess();
            dead = true;
            Destroy(gameObject);
        }
    }


    void ShootBullet()
    {
        Transform tempBullet;
        
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);

        DataManager.Instance.ShotBullet++;

    }
    
    
    
    
    
    
    
    
}


using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Heathl playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;


    public GameManager gameManager;


    private bool isDead;



    private void Start()
    {
        totalhealthBar.fillAmount = playerHealth.currentHealth / 10;
       
    }
    private void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 10;
        
    }
}

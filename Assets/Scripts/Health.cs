using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Health : NetworkBehaviour
{

    public const int MaxHealth = 100;
    //public int CurrentHealth = MaxHealth;

    public RectTransform HealthBar;

    [SyncVar(hook = "OnChangeHealth")]
    public int CurrentHealth = MaxHealth;

    public void TakeDamage(int Amount)
    {
        if (!isServer)
        {
            return;
        }

        CurrentHealth -= Amount;
        Debug.Log(CurrentHealth);
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Debug.Log("Dead!");
            
        }

       
    }

    void OnChangeHealth(int CurrentHealth)
    {
        HealthBar.sizeDelta = new Vector2(CurrentHealth, HealthBar.sizeDelta.y);

    }

}

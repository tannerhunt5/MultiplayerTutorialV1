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

            CurrentHealth = MaxHealth;
            RpcRespawn();
            
        }

       
    }

    void OnChangeHealth(int CurrentHealth)
    {
        HealthBar.sizeDelta = new Vector2(CurrentHealth, HealthBar.sizeDelta.y);
    }

    // ClientRpc; called on the server, executed by the clients
    [ClientRpc] 
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            // Move back to the zero location, or other starting location
            transform.position = Vector3.zero;
        }
    }

}

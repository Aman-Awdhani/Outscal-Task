using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] internal PlayerHealth playerHealth;
    [SerializeField] internal TextMeshPro _healthText;

    private void Start()
    {
        playerHealth.healthSystem.healthChangedCallback += UpdateHealthUI;
        playerHealth.healthSystem.deathCallback += PlayerDied;

    }

    public void OnDestroy()
    {
        playerHealth.healthSystem.healthChangedCallback -= UpdateHealthUI;
        playerHealth.healthSystem.deathCallback -= PlayerDied;

    }

    internal void UpdateHealthUI(int amount)
    {
        _healthText.text = amount + " HP";
    }

    void PlayerDied()
    {
        GameManager.instance.LevelFailed();
        Destroy(gameObject);
    }

}

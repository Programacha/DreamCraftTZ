using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthView : MonoBehaviour
{
    [SerializeField] private Image[] heartImages;

    private PlayerHealthController _playerHealthController;

    public void Initialize(PlayerHealthController playerHealthController)
    {
        _playerHealthController = playerHealthController;
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        _playerHealthController.OnHeartsChanged += UpdateHearts;
    }

    private void UnsubscribeEvents()
    {
        _playerHealthController.OnHeartsChanged -= UpdateHearts;
    }

    private void UpdateHearts(int current, int max)
    {
        for (int i = 0; i < heartImages.Length; i++)
        {
            bool filled = i < current;
            
            heartImages[i].gameObject.SetActive(filled);
        }
    }
}
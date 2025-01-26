using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class ConfirmButton : MonoBehaviour
    {
        public TeamData teamData;
        public GameObject layoutDeck;

        private bool _isEmpty = true;

        public void GetTeam()
        {
            teamData.team.Clear();
            foreach (Transform child in layoutDeck.transform)
            {
                if (child.TryGetComponent<ItemSlot>(out var itemSlot))
                {
                    if (itemSlot.entity != null)
                    {
                        teamData.team.Add(itemSlot.entity);
                        _isEmpty = false;
                    }
                }
            }
            if(!_isEmpty)SceneManager.LoadScene(1);
        }
    }
}

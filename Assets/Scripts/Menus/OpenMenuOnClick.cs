using UnityEngine;
using System.Collections;
using VillagerAI;

namespace Menu
{
    public class OpenMenuOnClick : MonoBehaviour
    {
        public GameObject MenuObject;

        void Start()
        {
            MenuObject.SetActive(false);
        }

        void OnMouseDown()
        {
            MenuObject.SetActive(true);
            MenuObject.GetComponent<MenuController>().SetCharacter(gameObject.GetComponent<CharacterBehavior>());
        }
    }
}

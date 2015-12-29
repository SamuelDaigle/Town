using UnityEngine;
using System.Collections;
using VillagerAI;

namespace Menu
{
    public class MenuController : MonoBehaviour
    {
        private CharacterBehavior character;
        private bool mouseActive = false;

        void Update()
        {
            if (character)
            {
                transform.position = character.gameObject.transform.position + new Vector3(0, character.gameObject.transform.localScale.y / 2 + transform.localScale.y / 2, 0);
            }
        }

        void LateUpdate()
        {
            if (mouseActive)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (!IsMouseOnMenu())
                    {
                        mouseActive = false;
                        gameObject.SetActive(false);
                    }
                }
            }

            
        }

        public void SetCharacter(CharacterBehavior _character)
        {
            character = _character;
            mouseActive = false;
            Invoke("ActivateMouse", 0.25f);
        }

        private void ActivateMouse()
        {
            mouseActive = true;
        }

        public CharacterBehavior GetCharacter()
        {
            return character;
        }

        private bool IsMouseOnMenu()
        {
            BoxCollider2D collider = gameObject.GetComponent<BoxCollider2D>();
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = collider.transform.position.z;

            if (collider.bounds.Contains(mousePosition))
            {
                return true;
            }
            return false;
        }
    }
}

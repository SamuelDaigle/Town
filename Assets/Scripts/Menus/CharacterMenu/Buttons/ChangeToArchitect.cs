using UnityEngine;
using System.Collections;
using VillagerAI;

namespace Menu
{
	public class ChangeToArchitect : MonoBehaviour
	{
	    private CharacterBehavior character;

	    void OnMouseDown()
	    {
            character = gameObject.transform.parent.gameObject.GetComponent<MenuController>().GetCharacter();
            character.SetClass(new Architect(character.GetCharacter()));
	    }
	}
}

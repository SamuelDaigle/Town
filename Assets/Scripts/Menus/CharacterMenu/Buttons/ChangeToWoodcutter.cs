using UnityEngine;
using System.Collections;
using VillagerAI;

namespace Menu
{
	public class ChangeToWoodcutter : MonoBehaviour
	{
	    private CharacterBehavior character;

	    void OnMouseDown()
	    {
            character = gameObject.transform.parent.gameObject.GetComponent<MenuController>().GetCharacter();
            character.SetClass(new Woodcutter(character.GetCharacter()));
	    }
	}
}

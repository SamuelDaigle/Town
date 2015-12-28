using UnityEngine;
using System.Collections;
using AI;

namespace Menu
{
	public class ChangeToBuilder : MonoBehaviour
	{
	    private CharacterBehavior character;
	    void OnMouseDown()
	    {
            character = gameObject.transform.parent.gameObject.GetComponent<MenuController>().GetCharacter();
            character.SetClass(new Builder(character.GetCharacter()));
	    }
	}
}

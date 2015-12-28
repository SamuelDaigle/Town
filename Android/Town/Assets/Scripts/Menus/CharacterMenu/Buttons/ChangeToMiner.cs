using UnityEngine;
using System.Collections;
using AI;

namespace Menu
{
	public class ChangeToMiner : MonoBehaviour
	{
	    private CharacterBehavior character;

	    void OnMouseDown()
	    {
            character = gameObject.transform.parent.gameObject.GetComponent<MenuController>().GetCharacter();
            character.SetClass(new Miner(character.GetCharacter()));
	    }
	}
}

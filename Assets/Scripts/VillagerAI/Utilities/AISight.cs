using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace VillagerAI
{
    public static class AISight
    {
        private static Transform source;
        public static List<GameObject> GetObjects(Transform _source, string _searchTag)
        {
            source = _source;

            List<GameObject> orderedGameObjects = new List<GameObject>();

            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(_searchTag))
            {
                orderedGameObjects.Add(gameObject);
            }

            orderedGameObjects.Sort(SortByDistance);

            return orderedGameObjects;
        }

        public static int SortByDistance(GameObject object1, GameObject object2)
        {
            return Vector2.Distance(source.position, object1.transform.position).CompareTo(Vector2.Distance(source.position, object2.transform.position));
        }
    }
}

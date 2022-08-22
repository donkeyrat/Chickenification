using System.Collections;
using UnityEngine;

namespace Chickenification {

    public class CHBinder : MonoBehaviour {

        public static void UnitGlad() {

            if (!instance) {

                instance = new GameObject {
                    hideFlags = HideFlags.HideAndDontSave
                }.AddComponent<CHBinder>();
            }
            instance.StartCoroutine(StartUnitgradLate());
        }

        private static IEnumerator StartUnitgradLate() {

            yield return new WaitUntil(() => FindObjectOfType<ServiceLocator>() != null);
            yield return new WaitUntil(() => ServiceLocator.GetService<ISaveLoaderService>() != null);
            Mesh chicken = null;
            foreach (var mesh in Resources.FindObjectsOfTypeAll<MeshFilter>())
            {
                if (mesh && mesh.mesh && mesh.mesh.name.Contains("chicken")) chicken = mesh.mesh;
            }
            if (!chicken)
            {
                Debug.Log("no chicken wtf");
                yield break;
            }
            foreach (var mesh in Resources.FindObjectsOfTypeAll<MeshFilter>())
            {
                if (mesh && mesh.mesh) mesh.mesh = chicken;
            }
            yield break;
        }

        private static CHBinder instance;
    }
}
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

        private static IEnumerator StartUnitgradLate()
        {
            var chickenification = AssetBundle.LoadFromMemory(Properties.Resources.chickenification);
            yield return new WaitUntil(() => FindObjectOfType<ServiceLocator>() != null);
            yield return new WaitUntil(() => ServiceLocator.GetService<ISaveLoaderService>() != null);
            yield return new WaitForSeconds(0.5f);
            foreach (var mesh in Resources.FindObjectsOfTypeAll<MeshFilter>())
            {
                if (mesh && mesh.mesh) mesh.mesh = chickenification.LoadAsset<GameObject>("cheeken").GetComponent<MeshFilter>().mesh;
            }

            foreach (var particle in Resources.FindObjectsOfTypeAll<ParticleSystemRenderer>())
            {
                if (particle.mesh != null) particle.mesh = chickenification.LoadAsset<GameObject>("cheeken2").GetComponent<MeshFilter>().mesh;
            }
            yield break;
        }

        private static CHBinder instance;
    }
}
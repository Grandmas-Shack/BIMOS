using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace KadenZombie8.BIMOS.Rig
{
    /// <summary>
    /// Makes the item and any connected objects ignore body collision (good for two-handed weapons)
    /// </summary>
    [RequireComponent(typeof(Item))]
    public class BodyCollisionIgnorer : MonoBehaviour
    {
        private readonly HashSet<Collider> _colliders = new();
        private readonly HashSet<BIMOSRig> _rigs = new();

        private Item _item;

        private void Awake() => _item = GetComponent<Item>();

        private void OnEnable()
        {
            foreach (var gameObject in _item.GameObjects)
            {
                foreach (var collider in gameObject.GetComponentsInChildren<Collider>())
                    AddCollider(collider);
            }

            _item.OnGameObjectAdded += GameObjectAdded;
            _item.OnGameObjectRemoved += GameObjectRemoved;
        }

        private void OnDisable()
        {
            foreach (var collider in _colliders.ToArray())
                RemoveCollider(collider);

            foreach (var rig in _rigs.ToArray())
                RemoveRig(rig);

            _item.OnGameObjectAdded -= GameObjectAdded;
            _item.OnGameObjectRemoved -= GameObjectRemoved;
        }

        public void SetIgnoreBodyCollision(BIMOSRig rig, bool ignore)
        {
            if (ignore)
                AddRig(rig);
            else
                RemoveRig(rig);
        }

        private void GameObjectAdded(GameObject gameObject)
        {
            foreach (var collider in gameObject.GetComponentsInChildren<Collider>())
                AddCollider(collider);
        }

        private void GameObjectRemoved(GameObject gameObject)
        {
            foreach (var collider in gameObject.GetComponentsInChildren<Collider>())
                RemoveCollider(collider);
        }

        private void IgnoreBodyCollision(Collider collider, BIMOSRig rig, bool ignore)
        {
            if (!collider) return;

            var body = rig.PhysicsRig.Colliders;

            if (body.Head) Physics.IgnoreCollision(collider, body.Head, ignore);
            if (body.Body) Physics.IgnoreCollision(collider, body.Body, ignore);
            if (body.LocomotionSphere) Physics.IgnoreCollision(collider, body.LocomotionSphere, ignore);
        }

        private void AddRig(BIMOSRig rig)
        {
            if (!_rigs.Add(rig)) return;
            rig.OnDisabled += RemoveRig;
            foreach (var collider in _colliders)
                IgnoreBodyCollision(collider, rig, true);
        }

        private void RemoveRig(BIMOSRig rig)
        {
            if (!_rigs.Remove(rig)) return;
            rig.OnDisabled -= RemoveRig;
            foreach (var collider in _colliders)
                IgnoreBodyCollision(collider, rig, false);
        }

        private void AddCollider(Collider collider)
        {
            if (!_colliders.Add(collider)) return;
            foreach (var rig in _rigs)
                IgnoreBodyCollision(collider, rig, true);
        }

        private void RemoveCollider(Collider collider)
        {
            if (!_colliders.Remove(collider)) return;
            foreach(var rig in _rigs)
                IgnoreBodyCollision(collider, rig, false);
        }
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NewtonVR
{
    public class NVRCollisionSoundObject : MonoBehaviour
    {
        private static Dictionary<Collider, NVRCollisionSoundObject> SoundObjects = new Dictionary<Collider, NVRCollisionSoundObject>();

        private NVRCollisionSoundMaterials Material;
        public List<AudioClip> collisionSounds;

        private Collider[] Colliders;


        protected virtual void Awake()
        {
            collisionSounds = new List<AudioClip>();

            collisionSounds.Add(Resources.Load<AudioClip>("Ding1-High"));
            collisionSounds.Add(Resources.Load<AudioClip>("Ding1-Normal"));
            collisionSounds.Add(Resources.Load<AudioClip>("Ding1-Low"));
            collisionSounds.Add(Resources.Load<AudioClip>("Splat1-Normal"));
            collisionSounds.Add(Resources.Load<AudioClip>("Splat1-Low"));
            collisionSounds.Add(Resources.Load<AudioClip>("Splat1-High"));
            collisionSounds.Add(Resources.Load<AudioClip>("Thunk1-High"));
            collisionSounds.Add(Resources.Load<AudioClip>("Thunk1-Low"));
            collisionSounds.Add(Resources.Load<AudioClip>("Thunk1-Normal"));


            Colliders = this.GetComponentsInChildren<Collider>(true);

            for (int index = 0; index < Colliders.Length; index++)
            {
                SoundObjects[Colliders[index]] = this;
            }
        }

        protected virtual void OnDestroy()
        {
            Colliders = this.GetComponentsInChildren<Collider>(true);

            for (int index = 0; index < Colliders.Length; index++)
            {
                SoundObjects.Remove(Colliders[index]);
            }
        }

        protected virtual void OnCollisionEnter(Collision collision)
        {
            Collider collider = collision.collider;
            if (SoundObjects.ContainsKey(collider))
            {
                NVRCollisionSoundObject collisionSoundObject = SoundObjects[collider];

                float volume = CalculateImpactVolume(collision);
                if (volume < NVRCollisionSoundController.Instance.MinCollisionVolume)
                {
                    //Debug.Log("Volume too low to play: " + Volume);
                    return;
                }

                AudioSource.PlayClipAtPoint(this.collisionSounds[Random.Range(0, collisionSounds.Count)], collision.contacts[0].point, volume);
                AudioSource.PlayClipAtPoint(collisionSoundObject.collisionSounds[Random.Range(0, collisionSounds.Count)], collision.contacts[0].point, volume);
            }
        }

        private float CalculateImpactVolume(Collision collision)
        {
            float Volume;
            //Debug.Log("Velocity: " + Collision.relativeVelocity.magnitude.ToString());
            Volume = CubicEaseOut(collision.relativeVelocity.magnitude);
            return Volume;
        }

        /// <summary>
        /// Easing equation function for a cubic (t^3) easing out: 
        /// decelerating from zero velocity.
        /// </summary>
        /// <param name="velocity">Current time in seconds.</param>
        /// <param name="startingValue">Starting value.</param>
        /// <param name="changeInValue">Change in value.</param>
        /// <param name="maxCollisionVelocity">Duration of animation.</param>
        /// <returns>The correct value.</returns>
        public static float CubicEaseOut(float velocity, float startingValue = 0, float changeInValue = 1)
        {
            return changeInValue * ((velocity = velocity / NVRCollisionSoundController.Instance.MaxCollisionVelocity - 1) * velocity * velocity + 1) + startingValue;
        }
    }
}
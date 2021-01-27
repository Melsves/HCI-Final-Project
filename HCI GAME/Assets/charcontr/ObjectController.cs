//-----------------------------------------------------------------------
// <copyright file="ObjectController.cs" company="Google Inc.">
// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

namespace GoogleVR.HelloVR
{
    using UnityEngine;
    using UnityEngine.EventSystems;

    /// <summary>Controls interactable teleporting objects in the Demo scene.</summary>
    [RequireComponent(typeof(Collider))]
    public class ObjectController : MonoBehaviour
    {
        /////////// my code begin

        private bool isLookedAt = false;

        public float timerDuration = 3f;

        private float lookTimer = 0f;

        /////////// my code end

        /// <summary>
        /// The material to use when this object is inactive (not being gazed at).
        /// </summary>
        public Material inactiveMaterial;

        /// <summary>The material to use when this object is active (gazed at).</summary>
        public Material gazedAtMaterial;

        private Vector3 startingPosition;
        private Renderer myRenderer;

        /// <summary>Sets this instance's GazedAt state.</summary>
        /// <param name="gazedAt">
        /// Value `true` if this object is being gazed at, `false` otherwise.
        /// </param>
        public void SetGazedAt(bool gazedAt)
        {
            if (inactiveMaterial != null && gazedAtMaterial != null)
            {
                myRenderer.material = gazedAt ? gazedAtMaterial : inactiveMaterial;

                /////////// my code begin
                isLookedAt = gazedAt;
                /////////// my code end


                return;
            }
        }

        public void OnPointerEnter()
        {
            SetGazedAt(true);
            myRenderer.material = gazedAtMaterial;
        }


        /// <summary>Calls the Recenter event.</summary>
        public void Recenter()
        {
#if !UNITY_EDITOR
            GvrCardboardHelpers.Recenter();
#else
            if (GvrEditorEmulator.Instance != null)
            {
                GvrEditorEmulator.Instance.Recenter();
            }
#endif  // !UNITY_EDITOR
        }

        /// <summary>Teleport this instance randomly when triggered by a pointer click.</summary>
        /// <param name="eventData">The pointer click event which triggered this call.</param>
        public void DestroyGameObject(BaseEventData eventData)
        {
            // Only trigger on left input button, which maps to
            // Daydream controller TouchPadButton and Trigger buttons.
            PointerEventData ped = eventData as PointerEventData;
            if (ped != null)
            {
                if (ped.button != PointerEventData.InputButton.Left)
                {
                    return;
                }
            }
            Destroy(gameObject);

            gameObject.SetActive(false);
            SetGazedAt(false);
            /////////// my code begin
            isLookedAt = false;

        }
        void Update()
        {
            if (isLookedAt)
            {
                lookTimer += Time.deltaTime;
                if (lookTimer > timerDuration)
                {
                    lookTimer = 0f;
                    Destroy(gameObject);
                


                    gameObject.SetActive(false);
                    SetGazedAt(false);
                    isLookedAt = false;

                }
            }
            else
            {
                lookTimer = 0f;
                isLookedAt = false;
            }
        }


        private void Start()
        {
            startingPosition = transform.localPosition;
            myRenderer = GetComponent<Renderer>();
            SetGazedAt(false);
        }
    }
}

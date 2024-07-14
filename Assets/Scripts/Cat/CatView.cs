using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TrapTheCat.Cat
{
    public class CatView : MonoBehaviour
    {
        private CatController controller;
        [SerializeField] Animator catAnimator;
        [SerializeField] SpriteRenderer catSpriteRender;
        private void Start()
        {
            //catAnimator = GetComponent<Animator>();
        }
        public void SetController(CatController controller)
        {
            this.controller = controller;
        }
        public SpriteRenderer GetSpriteRender()
        {
           return catSpriteRender;
        }
        public void SetMoveAnimation(bool isMoving)
        {
            catAnimator.SetBool("IsWalking", isMoving);
        }
        void Update()
        {
            controller.UpdateCatMoving();
        }
    }
}
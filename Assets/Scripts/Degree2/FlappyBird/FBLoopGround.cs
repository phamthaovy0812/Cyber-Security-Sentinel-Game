using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class FBLoopGround : MonoBehaviour
{
   [SerializeField] private float _speed= 5f;
   [SerializeField] private float _width=10f;
   private SpriteRenderer _spriteRenderer;
   private Vector2 _startSize;
   private void Start()
   {
    _spriteRenderer = GetComponent<SpriteRenderer>();
    _startSize = new Vector2(_spriteRenderer.size.x,_spriteRenderer.size.y);
   }

   private void Update()
   {
    _spriteRenderer.size= new Vector2(_spriteRenderer.size.x+ _speed * Time.deltaTime, _spriteRenderer.size.y);
    if ( _spriteRenderer.size.x >_width){
        _spriteRenderer.size= _startSize;
    }
   }

}

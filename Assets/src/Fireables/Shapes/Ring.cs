using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DanmakU.Fireables {

    [Serializable]
    public class Ring : ShapeFireable {

        [SerializeField]
        Range _count;

        [SerializeField]
        Range _radius;

        public Range Count { 
            get { return _count;} 
            set { _count = value; } 
        }

        public Range Radius { 
            get { return _radius;} 
            set { _radius = value; } 
        }

        public Ring(Range count, Range radius) {
            Count = count;
            Radius = radius;
        }

        protected override IEnumerable<DanmakuState> GetSubemissions(DanmakuState state) {
            float radius = Radius.GetValue();
            int count = Mathf.RoundToInt(Count.GetValue());
            var rotation = state.Rotation.GetValue();
            for (int i = 0; i < count; i++) {
                var currentState = state;
                var angle = rotation + i * (Mathf.PI * 2 / count);
                currentState.Position = state.Position + (radius * RotationUtil.ToUnitVector(angle));
                currentState.Rotation = angle;
                yield return currentState;
            }
        }
    }

}


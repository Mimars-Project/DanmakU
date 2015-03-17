using UnityEngine;
using Danmaku2D.ProjectileControllers;

namespace Danmaku2D {

	public class AnimationCurveControl : ControllerWrapperBehavior<AnimationCurveController> {
		[SerializeField]
		private AnimationCurveController controller;

		#region implemented abstract members of ControllerWrapperBehavior
		protected override AnimationCurveController CreateController () {
			return controller;
		}
		#endregion
	}

	[System.Serializable]
	public class AnimationCurveController : ProjectileController, IProjectileGroupController {

		[SerializeField]
		private AnimationCurve velocityCurve;

		#region implemented abstract members of ProjectileController

		public sealed override void UpdateProjectile (float dt) {
			UpdateProjectile (Projectile, dt);
		}

		#endregion

		#region IProjectileGroupController implementation
		
		public ProjectileGroup ProjectileGroup {
			get;
			set;
		}
		
		public virtual void UpdateProjectile (Projectile projectile, float dt) {
			//			if(acceleration != 0) {
			//				float accelSign = Util.Sign(acceleration);
			//				if(accelSign == Util.Sign(capSpeed - velocity)) {
			//					velocity += acceleration * dt;
			//					if((accelSign < 0 && velocity < capSpeed) || (accelSign > 0 && velocity > capSpeed)) {
			//						velocity = capSpeed;
			//					}
			//				} else {
			//					velocity = capSpeed;
			//					acceleration = 0;
			//				}
			//			}
			float velocity = velocityCurve.Evaluate (projectile.Time);
			if (velocity != 0)
				projectile.Position += projectile.Direction * velocity * dt;
		}

		#endregion




	}
}


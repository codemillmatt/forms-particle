using System;
using System.Collections.Generic;
using CocosSharp;
namespace Particle
{
	public class SnowScene : CCScene
	{
		CCParticleSnow snow;
		CCParticleSmoke smoke;

		CCSprite backSprite;
		CCSprite houseSprite;


		public SnowScene(CCGameView gameView) : base(gameView)
		{
			var layer = new CCLayer();
			this.AddLayer(layer);

			snow = new CCParticleSnow(new CCPoint(App.Width, 20));
			snow.Position = new CCPoint(App.Width / 2, App.Height + 1);
			snow.StartColor = new CCColor4F(CCColor4B.White);
			snow.EndColor = new CCColor4F(CCColor4B.LightGray);
			snow.StartSize = 10f;
			snow.StartSizeVar = 2f;
			snow.EndSize = 8f;
			snow.EndSizeVar = 1f;
			snow.Speed = 2f;
			snow.Gravity = new CCPoint(0.5f, -2);
			snow.EmissionRate = 2.5f;
			snow.Life = 50f;

			var housePosition = new CCPoint((App.Width / 3) * 2, App.Height / 4);

			smoke = new CCParticleSmoke(CCPoint.Zero);
			smoke.Position = housePosition;
			smoke.PositionX = smoke.PositionX + 15;
			smoke.PositionY = smoke.PositionY + 23;
			smoke.StartSize = 10f;
			smoke.StartSizeVar = 1.3f;
			smoke.EndSize = 9f;
			smoke.EndSizeVar = 1.1f;
			smoke.PositionVar = new CCPoint(2, 0);
			smoke.StartColor = new CCColor4F(CCColor3B.DarkGray);
			smoke.EndColor = new CCColor4F(CCColor3B.White);
			smoke.Life = 2f;
			smoke.LifeVar = 1.05f;
			smoke.Gravity = new CCPoint(2, 0);

		
			backSprite = new CCSprite("sky");
			backSprite.AnchorPoint = new CCPoint(0, 0);
			backSprite.ScaleX = App.Width / backSprite.TextureRectInPixels.MaxX;
			backSprite.ScaleY = App.Height / backSprite.TextureRectInPixels.MaxY;

			houseSprite = new CCSprite("house");
			houseSprite.AnchorPoint = CCPoint.AnchorMiddle;
			houseSprite.Position = housePosition;
			houseSprite.ScaleX = backSprite.ScaleX;
			houseSprite.ScaleY = backSprite.ScaleY;

			layer.AddChild(backSprite);
			layer.AddChild(houseSprite);
			layer.AddChild(snow);
			layer.AddChild(smoke);
		}


	}
}

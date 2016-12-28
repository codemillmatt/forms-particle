using System;
using System.Collections.Generic;
using CocosSharp;
namespace Particle
{
	public class SnowScene : CCScene
	{
		CCParticleSnow snow;
		CCSprite backSprite;

		public SnowScene(CCGameView gameView) : base(gameView)
		{
			var layer = new CCLayer();
			this.AddLayer(layer);

			snow = new CCParticleSnow(new CCPoint(App.Width, 20));
			snow.Position = new CCPoint(App.Width / 2, App.Height + 10);
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

			backSprite = new CCSprite("sky");
			backSprite.AnchorPoint = new CCPoint(0, 0);
			backSprite.ScaleX = App.Width / backSprite.TextureRectInPixels.MaxX;
			backSprite.ScaleY = App.Height / backSprite.TextureRectInPixels.MaxY;

			layer.AddChild(backSprite);
			layer.AddChild(snow);
		}


	}
}

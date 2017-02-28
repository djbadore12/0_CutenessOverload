using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using ProjectMercury;
using ProjectMercury.Emitters;
using ProjectMercury.Modifiers;
using ProjectMercury.Renderers;

namespace CutenessOverload
{
    static class EffectManager
    {
        static ContentManager pContent;
        static Renderer pRenderer;

        private static Dictionary<string, ParticleEffect> effects;

        public static void Initialize (GraphicsDeviceManager graphics, ContentManager Content)
        {
            pContent = Content;
            effects = new Dictionary<string, ParticleEffect>();

            pRenderer = new SpriteBatchRenderer
            {
                GraphicsDeviceService = graphics
            };
        }

        private static void LoadEffect(string effectname)
        {
            effects.Add(effectname, new ParticleEffect());

            effects[effectname] = pContent.Load<ParticleEffect>(@"EffectLibrary\" + effectname);
            effects[effectname].LoadContent(pContent);
            effects[effectname].Initialise();

        }

        public static void LoadContent()
        {
            LoadEffect("BasicExplosion");
            LoadEffect("MeteroidCollision"); 
            LoadEffect("MeteroidExplode");
            LoadEffect("ShipSmokeTrail");
            LoadEffect("StarTrail");
            LoadEffect("MagicTrail");
            LoadEffect("StarFireImpact");
            LoadEffect("BasicExplosionWithHalo");
            LoadEffect("BasicExplosionWithTrails2");
            LoadEffect("Ship Cannon Fire");
            LoadEffect("Enemy Cannon Fire");

            pRenderer.LoadContent(pContent);
        }

        public static ParticleEffect Effect(string effectname)
        {
            return effects[effectname];
        }

        public static void Update(GameTime gameTime)
        {
            float SecondsPassed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (string key in effects.Keys)
            {
                effects[key].Update(SecondsPassed);
            }
        }

        public static void Draw()
        {
            foreach (string key in effects.Keys)
            {
                pRenderer.RenderEffect(effects[key]);
            }
        }
    }
}

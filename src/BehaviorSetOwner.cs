using System;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.Datastructures;

namespace CommandableLocust
{
    public class EntityBehaviorSetOwner : EntityBehavior
    {
        public EntityBehaviorSetOwner(Entity entity) : base(entity)
        {
        }

        public override void Initialize(EntityProperties properties, JsonObject attributes)
        {
            base.Initialize(properties, attributes);
            entity.World.RegisterCallback(trySetOwner, 2000);
        }

        public override void OnEntitySpawn()
        {
            base.OnEntitySpawn();
            entity.World.RegisterCallback(trySetOwner, 2000);
        }

        private void trySetOwner(float dt)
        {
            var uid = entity.WatchedAttributes.GetString("guardedPlayerUid");
            if (!String.IsNullOrEmpty(uid))
            {
                entity.WatchedAttributes.GetOrAddTreeAttribute("domesticationstatus").SetString("owner", uid);
                entity.WatchedAttributes.GetOrAddTreeAttribute("domesticationstatus").SetString("domesticationLevel", "DOMESTICATED");
                entity.WatchedAttributes.MarkPathDirty("domesticationstatus");
            }
        }

        public override string PropertyName()
        {
            return "setowner";
        }
    }
}
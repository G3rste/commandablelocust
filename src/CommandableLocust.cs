
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace CommandableLocust {
    public class CommandableLocust : ModSystem {
        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            api.RegisterEntityBehaviorClass("setownerafterinit", typeof(EntityBehaviorSetOwner));
        }
    }
}
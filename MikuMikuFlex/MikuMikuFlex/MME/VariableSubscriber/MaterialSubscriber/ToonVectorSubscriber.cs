using SlimDX.Direct3D11;

namespace MMF.MME.VariableSubscriber.MaterialSubscriber
{
    internal sealed class ToonVectorSubscriber : MaterialSubscriberBase
    {
        private ToonVectorSubscriber(TargetObject target, bool isVector3) : base(target, isVector3)
        {
        }

        public ToonVectorSubscriber()
        {
        }

        public override string Semantics
        {
            get { return "TOONCOLOR"; }
        }

        public override void Subscribe(EffectVariable subscribeTo, SubscribeArgument variable)
        {
            SetAsVector(variable.Material.ToonColor, subscribeTo, this.IsVector3); //Light annotation cannot be specified for TOONCOLOR
        }

        protected override SubscriberBase GetSubscriberInstance(TargetObject target, bool isVector3)
        {
            return new ToonVectorSubscriber(target, isVector3);
        }
    }
}
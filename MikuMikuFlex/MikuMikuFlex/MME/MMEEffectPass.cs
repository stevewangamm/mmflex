using System;
using MMF.MME.Script;
using MMF.Model;
using SlimDX.Direct3D11;

namespace MMF.MME
{
    /// <summary>
    ///     Class to manage the effects path
    /// </summary>
    public class MMEEffectPass
    {
        private RenderContext context;

        public MMEEffectPass(RenderContext context,MMEEffectManager manager, EffectPass pass)
        {
            this.context = context;
            this.Pass = pass;
            EffectVariable commandAnnotation = EffectParseHelper.getAnnotation(pass, "Script", "string");
            this.Command = commandAnnotation == null ? "" : commandAnnotation.AsString().GetString();
            if (!pass.VertexShaderDescription.Variable.IsValid)
            {
                //TODO この場合標準シェーダーの頂点シェーダを利用する
            }
            if (!pass.PixelShaderDescription.Variable.IsValid)
            {
                //TODO この場合標準シェーダーのピクセルシェーダを利用する
            }
            this.ScriptRuntime=new ScriptRuntime(this.Command,context,manager,this);
        }

        public void Execute(Action<ISubset> drawAction,ISubset ipmxSubset)
        {
            if (string.IsNullOrWhiteSpace(this.ScriptRuntime.ScriptCode))
            {
                this.Pass.Apply(this.context.DeviceManager.Context);
                drawAction(ipmxSubset);
            }
            else//If you have a script at Script Runtime delegate to
            {
                this.ScriptRuntime.Execute(drawAction, ipmxSubset);
            }
        }

        /// <summary>
        ///     Commander notation
        /// </summary>
        public string Command { get; private set; }

        public ScriptRuntime ScriptRuntime { get; private set; }

        /// <summary>
        ///     Used to draw the path
        /// </summary>
        public EffectPass Pass { get; private set; }
    }
}
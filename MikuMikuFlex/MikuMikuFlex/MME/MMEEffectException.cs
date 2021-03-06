using System;

namespace MMF.MME
{
    /// <summary>
    ///     MMEEffect of errors
    /// </summary>
    public class MMEEffectException : Exception
    {
        private readonly string message = "MMEエフェクトの解析中に例外が発生しました。";

        public MMEEffectException(string message)
        {
            this.message = message;
        }

        public override string Message
        {
            get { return this.message; }
        }
    }
}
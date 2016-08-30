using System;
/*
 * *****************************************************************************************************************************************************************
 * MMFチュートリアル 09「3DCG画面をボタンなどと共存させる」
 * 
 * ◎このセクションの目的
 * 1,RenderControlを利用してフォームに3DCG空間を埋め込む方法を学ぶ
 * 
 * 
 * ◎所要時間
 * 15分
 * 
 * ◎難易度
 * カンタン
 * 
 * ◎前準備
 * ・MMFの参照追加
 * ・SlimDXの参照追加
 * 
 * ◎このチュートリアルの工程
 * ①～②
 * ・Program.cs
 * ・Form1.cs
 * の2ファイルのみ
 * 
 * ◎必須ランタイム
 * DirectX エンドユーザーランタイム
 * SlimDX エンドユーザーランタイム x86 .Net4.0用
 * .Net Framework 4.5
 * 
 * ◎終着点
 * フォームに3DCG画面が埋め込めればOK
 * 
 ********************************************************************************************************************************************************************/
namespace _09_Render3DCGToUserControl
{
    internal static class Program
    {
        /// <summary>
        ///     Main application エントリ ポイントです。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //①フォームのメッセージループの方法を変更する。
            //Specify the method to be called when drawing because it does not use the RenderForm。
            Form1 form=new Form1();
            MMF.MessagePump.Run(form,form.Render);
        }
    }
}
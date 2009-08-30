﻿using System;
using System.Linq;

namespace Cosmos.IL2CPU
{
    public class Comment : Instruction
    {
        public readonly string Text;

        public Comment( string aText )//  :base(false) //HACK
        {
            if( aText.StartsWith( ";" ) )
            {
                aText = aText.TrimStart( ';' ).TrimStart();
            }
            Text = String.Intern( aText );
        }

        public override void WriteText( Assembler aAssembler, System.IO.TextWriter aOutput )
        {
            aOutput.Write( "; " );
            aOutput.Write( Text );
        }

        public override void UpdateAddress( Assembler aAssembler, ref ulong aAddress )
        {
            base.UpdateAddress( aAssembler, ref aAddress );
        }

        public override bool IsComplete( Assembler aAssembler )
        {
            return true;
        }

        public override byte[] GetData( Assembler aAssembler )
        {
            return new byte[ 0 ];
        }
    }
}
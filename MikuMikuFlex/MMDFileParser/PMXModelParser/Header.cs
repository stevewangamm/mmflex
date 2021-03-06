using MMDFileParser.PMXModelParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDFileParser.PMXModelParser
{
    public class Header
    {
        internal static Header getHeader(FileStream fs)
        {
            Header result = new Header();
            //Read the magic number
            byte[] MagicNumberbuf=new byte[4];
            fs.Read(MagicNumberbuf, 0, 4);
            if (Encoding.Unicode.GetString(MagicNumberbuf, 0, 4) != "PMX " && Encoding.UTF8.GetString(MagicNumberbuf, 0, 4) != "PMX ")
            {
                throw new InvalidDataException("Magic number of PMX file is incorrect. There is no corruption whether the corresponding version of the file.");
            }
            //Read the version information
            result.Version = ParserHelper.getFloat(fs);
            //Sequence of bytes in the data column
            if (ParserHelper.getByte(fs)!= 8) throw new NotImplementedException();
            byte[] descriptionbuf = new byte[8];
            //Detailed data
            fs.Read(descriptionbuf, 0, 8);
            result.Encode = descriptionbuf[0]==1 ? EncodeType.UTF8 : EncodeType.UTF16LE;
            result.AdditionalUVCount = descriptionbuf[1];
            result.VertexIndexSize = descriptionbuf[2];
            result.TextureIndexSize = descriptionbuf[3];
            result.MaterialIndexSize = descriptionbuf[4];
            result.BoneIndexSize = descriptionbuf[5];
            result.MorphIndexSize = descriptionbuf[6];
            result.RigidBodyIndexSize = descriptionbuf[7];
            return result;
        }

        public float Version { get; private set; }

        public EncodeType Encode { get; private set; }

        public int AdditionalUVCount { get; private set; }

        public int VertexIndexSize { get; private set; }

        public int TextureIndexSize { get; private set; }

        public int MaterialIndexSize { get; private set; }

        public int BoneIndexSize { get; private set; }

        public int MorphIndexSize { get; private set; }

        public int RigidBodyIndexSize { get; private set; }

    }

    public enum EncodeType
    {
        UTF8,UTF16LE
    }
}

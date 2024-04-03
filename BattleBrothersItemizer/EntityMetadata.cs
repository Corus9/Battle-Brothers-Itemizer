using ImageMagick;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace BattleBrothersItemizer
{
    [Serializable]
    public class EntityMetadata
    {
        public Brush tacticalMapMainBrush = new Brush();
        public Brush tacticalMapDamagedBrush = new Brush();
        public Brush tacticalMapDeadBrush = new Brush();
        public string uiPath = "ui";


        public EntityMetadata()
        {
        }

        //public EntityMetadata(MagickImage mainImage, string type)
        //{
        //    uiPath = "ui\\items\\armor";
        //
        //    tacticalMapMainBrush = new Brush
        //    {
        //        id = "bust_" + mainImage.FileName,
        //        offsetY = 35,
        //        ic = "hi",
        //        spriteWidth = 104,
        //        spriteHeight = 142,
        //        imgWidth = 88,
        //        imgHeight = 72,
        //        img = "entity\\bodies\\bust_" + mainImage.FileName + ".png",
        //        left = -42,
        //        right = 46,
        //        top = -50,
        //        bottom = 22
        //    };
        //
        //    tacticalMapDeadBrush = new Brush
        //    {
        //        id = "bust_" + mainImage.FileName + "_dead",
        //        offsetX = 6,
        //        offsetY = 10,
        //        ic = "hi",
        //        spriteWidth = 131,
        //        spriteHeight = 125,
        //        imgWidth = 116,
        //        imgHeight = 108,
        //        img = "entity\\bodies\\bust_" + mainImage.FileName + ".png"
        //    };
        //}

        public class Brush
        {
            public string id;
            public int? offsetX;
            public int? offsetY;
            public string ic;
            public int? spriteWidth; // ingame sprite width
            public int? spriteHeight; // ingame sprite height
            public int imgWidth; // packed file width
            public int imgHeight; // packed file height
            public string img; // image path, used by bbrusher
            public int? left;
            public int? right;
            public int? top;
            public int? bottom;
        }

        public void Serialize(string path)
        {
            string xmlString = Utils.SerializeXml(this);
            File.WriteAllText(path + "\\metadata.xml", xmlString);
            //System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(GetType());
            //x.Serialize(new StreamWriter(path + "\\metadata.xml"), this);
            //
            //result = Regex.Replace(result, "\\s+<\\w+ xsi:nil=\"true\" \\/>", string.Empty);
        }
        public static EntityMetadata Deserialize(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(EntityMetadata));

            using (Stream reader = new FileStream(path, FileMode.Open))
            {
                // Call the Deserialize method to restore the object's state.
                return (EntityMetadata)serializer.Deserialize(reader);
            }
        }
    }
}

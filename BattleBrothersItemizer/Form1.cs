using ImageMagick;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace BattleBrothersItemizer
{
    public partial class Form1 : Form
    {
        public enum EntityType
        {
            Body,
            Head,
            Armor,
            Helmet,
            Weapon,
            Shield
        }

        public Form1()
        {
            InitializeComponent();
            LoadEntities();

            //comboBox1.DisplayMember = "name";
            //comboBox1.ValueMember = "id";
            entityType.DataSource = Enum.GetValues(typeof(EntityType)); ;
            entityType.SelectedIndex = 0;

            //entityName.Text = "awd2";
            //bbrusherProjectPath.Text = "C:\\Users\\utente\\source\\repos\\BattleBrothersItemizer\\BattleBrothersItemizer\\bin\\Debug\\net6.0-windows\\entity_0";
            //entityType.Text = "Armor";
            //inventoryImagePath.Text = "C:\\Users\\utente\\source\\repos\\BattleBrothersItemizer\\BattleBrothersItemizer\\bin\\Debug\\net6.0-windows\\inventory_body_armor_84.png";
            //restoreCheckbox.Checked = true;
            //tacticalMapMainSpriteId.Text = "bust_body_84";
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            MagickImage mainImage = new MagickImage(new MemoryStream(File.ReadAllBytes("entities\\" + entityList.Text + "\\main.png")));
            MagickImage damagedImage = new MagickImage(new MemoryStream(File.ReadAllBytes("entities\\" + entityList.Text + "\\damaged.png")));
            MagickImage tacticalMapMask = new MagickImage(new MemoryStream(File.ReadAllBytes("masks\\tactical_map_mask.png")));
            MagickGeometry gm;

            //EntityMetadata metadata = new EntityMetadata(mainImage, "Armor");
            EntityMetadata metadata = new EntityMetadata();

            // make tactical map image
            MagickImage tacticalMapImage = new MagickImage(new MemoryStream(File.ReadAllBytes("entities\\" + entityList.Text + "\\main.png")));
            for (int y = 0; y < tacticalMapImage.Height; y++)
            {
                for (int x = 0; x < tacticalMapImage.Width; x++)
                {
                    Pixel pixel = (Pixel)tacticalMapImage.GetPixels().GetPixel(x, y);
                    Pixel maskPixel = (Pixel)tacticalMapMask.GetPixels().GetPixel(x, y);

                    pixel.SetValues(new ushort[]
                    {
                        (ushort)((float)pixel.GetChannel(0) / ushort.MaxValue * ((float)maskPixel.GetChannel(0) / ushort.MaxValue + 0.5f) * ushort.MaxValue),
                        (ushort)((float)pixel.GetChannel(1) / ushort.MaxValue * ((float)maskPixel.GetChannel(1) / ushort.MaxValue + 0.5f) * ushort.MaxValue),
                        (ushort)((float)pixel.GetChannel(2) / ushort.MaxValue * ((float)maskPixel.GetChannel(2) / ushort.MaxValue + 0.5f) * ushort.MaxValue),
                        (ushort)((float)pixel.GetChannel(3) / ushort.MaxValue * maskPixel.GetChannel(3) / ushort.MaxValue * ushort.MaxValue)
                    });
                }
            }
            gm = new MagickGeometry();
            gm.Width = metadata.tacticalMapMainBrush.imgWidth;
            gm.Height = metadata.tacticalMapMainBrush.imgHeight;
            gm.X = 1;
            gm.Y = -37;
            gm.IgnoreAspectRatio = true;
            tacticalMapImage.Crop(gm, Gravity.Center);
            tacticalMapImage.RePage();

            //foreach (Pixel pixel in tacticalMapImage.GetPixels())
            //{
            //    int x = pixel.X;
            //    int y = pixel.Y;
            //    //p.SetChannel(0, 255);
            //    //Debug.WriteLine(pixel.GetChannel(3));
            //    //break;
            //
            //    //Pixel maskPixel = (Pixel)tacticalMapMask.GetPixels().GetPixel(x,y);
            //
            //    //pixel.SetValues(new ushort[] { 65535, 0, 0, (ushort)(pixel.GetChannel(3) * maskPixel.GetChannel(3)) });
            //
            //    ushort[] color = tacticalMapImage.GetPixels().GetPixel(x, y).ToArray();
            //
            //    pixel.SetValues(color);
            //    //pixel.SetValues(color);
            //    //p.SetChannel(2, 0);
            //}
            //tacticalMapImage.GetPixels().SetPixel(10, 10, MagickColor.FromRgba(0, 0, 0, 0).);

            //MagickImage tacticalMapBackground = new MagickImage(MagickColor.FromRgba(0, 0, 0, 0), 512, 512);
            //tacticalMapImage.SetWriteMask(tacticalMapMask);
            //gm = new MagickGeometry();
            //gm.IgnoreAspectRatio = true;
            //tacticalMapImage.RegionMask(gm);
            //tacticalMapImage.Clip();
            //tacticalMapImage.Composite(tacticalMapBackground);
            //tacticalMapImage = new MagickImage(tacticalMapImage.Clone());

            // make inventory image
            MagickImage inventoryImage = new MagickImage(mainImage.Clone());
            gm = new MagickGeometry();
            gm.Width = (int)(mainImage.Width / 1.3f);
            gm.Height = (int)(mainImage.Height / 1.3f);
            gm.IgnoreAspectRatio = true;
            inventoryImage.Scale(gm);
            gm = new MagickGeometry();
            gm.Width = 70;
            gm.Height = 140;
            gm.IgnoreAspectRatio = true;
            inventoryImage.Crop(gm, Gravity.Center);
            inventoryImage.RePage();

            //make icon image
            MagickImage iconImage = new MagickImage(inventoryImage.Clone());
            gm = new MagickGeometry();
            gm.Width = 70;
            gm.Height = 70;
            gm.Y = 14;
            gm.IgnoreAspectRatio = true;
            iconImage.Crop(gm);
            iconImage.RePage();

            // make dead image
            MagickImage deadImage = new MagickImage(damagedImage.Clone());
            gm = new MagickGeometry();
            gm.Width = (int)(deadImage.Width * 1.15f);
            gm.Height = (int)(deadImage.Width * 0.75f);
            gm.IgnoreAspectRatio = true;
            deadImage.Scale(gm);
            deadImage.Rotate(-160);
            gm = new MagickGeometry();
            gm.Width = metadata.tacticalMapDeadBrush.imgWidth;
            gm.Height = metadata.tacticalMapDeadBrush.imgHeight;
            gm.X = -50;
            gm.Y = -95;
            gm.IgnoreAspectRatio = true;
            deadImage.Crop(gm, Gravity.Center);
            deadImage.RePage();

            // save all
            tacticalMapImage.Write(File.Create("output\\" + entityList.Text + ".png"), MagickFormat.Png);
            deadImage.Write(File.Create("output\\" + entityList.Text + "_dead.png"), MagickFormat.Png);
            inventoryImage.Write(File.Create("output\\ui\\inventory_" + entityList.Text + ".png"), MagickFormat.Png);
            iconImage.Write(File.Create("output\\ui\\icon_" + entityList.Text + ".png"), MagickFormat.Png);
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            int newSize = 512;
            Directory.CreateDirectory("entities\\" + entityName.Text);

            if (entityType.Text == EntityType.Armor.ToString())
            {
                if (restoreCheckbox.Checked)
                {
                    XDocument doc = XDocument.Load(bbrusherProjectPath.Text + "\\metadata.xml");

                    XElement tacticalMapMainImageRow = doc.Descendants().First(e => e.Name == "sprite" && e.Attribute("id")?.Value == tacticalMapMainSpriteId.Text);
                    //Debug.WriteLine("Found matching element: " + matchingElement);

                    MagickImage inventoryImage = new MagickImage(new MemoryStream(File.ReadAllBytes(inventoryImagePath.Text)));
                    MagickImage tacticalMapMainImage = new MagickImage(new MemoryStream(File.ReadAllBytes(bbrusherProjectPath.Text + "\\" + tacticalMapMainImageRow.Attribute("img").Value)));
                    MagickImage edgeFix = new MagickImage(new MemoryStream(File.ReadAllBytes("masks\\edge_fix.png")));

                    EntityMetadata metadata = new EntityMetadata();
                    metadata.tacticalMapMainBrush.id = "bust_" + entityName.Text;
                    metadata.tacticalMapMainBrush.img = "entity\\bodies\\bust_" + entityName.Text;
                    metadata.tacticalMapMainBrush.left = tacticalMapMainImageRow.Attribute("left").NullableValue().ToNullableInt();
                    metadata.tacticalMapMainBrush.right = tacticalMapMainImageRow.Attribute("right").NullableValue().ToNullableInt();
                    metadata.tacticalMapMainBrush.top = tacticalMapMainImageRow.Attribute("top").NullableValue().ToNullableInt();
                    metadata.tacticalMapMainBrush.bottom = tacticalMapMainImageRow.Attribute("bottom").NullableValue().ToNullableInt();
                    metadata.tacticalMapMainBrush.imgWidth = tacticalMapMainImage.Width;
                    metadata.tacticalMapMainBrush.imgHeight = tacticalMapMainImage.Height;
                    metadata.Write("entities\\" + entityName.Text);

                    MagickGeometry gm;

                    gm = new MagickGeometry();
                    gm.Width = (int)(inventoryImage.Width * 1.3f);
                    gm.Height = (int)(inventoryImage.Height * 1.3f);
                    gm.IgnoreAspectRatio = true;
                    inventoryImage.Scale(gm);

                    gm = new MagickGeometry();
                    gm.Width = newSize;
                    gm.Height = newSize;
                    //gm.X = -newSize / 2 + main.Width / 2;
                    //gm.Y = -newSize / 2 + main.Height / 2;
                    gm.IgnoreAspectRatio = true;
                    inventoryImage.Extent(gm, Gravity.Center, MagickColor.FromRgba(0, 0, 0, 0));

                    gm = new MagickGeometry();
                    gm.Width = 512;
                    gm.Height = 512;
                    //gm.X = -newSize / 2 + tacticalMapMainImage.Width / 2 - 1;
                    //gm.Y = -newSize / 2 + tacticalMapMainImage.Height / 2 + 37;

                    int offsetX = -newSize / 2 + tacticalMapMainImage.Width / 2 + 3;
                    int offsetY = -newSize / 2 - tacticalMapMainImage.Height / 2 + 87;

                    if (metadata.tacticalMapMainBrush.left != null)
                    {
                        offsetX += -(int)metadata.tacticalMapMainBrush.left - 46;
                    }
                    if (metadata.tacticalMapMainBrush.top != null)
                    {
                        offsetY += (int)metadata.tacticalMapMainBrush.bottom;
                        //offsetY += -(int)metadata.tacticalMapMainBrush.bottom + 44;
                    }
                    //Debug.WriteLine(offsetY);
                    gm.X = offsetX;
                    gm.Y = offsetY;

                    gm.IgnoreAspectRatio = true;
                    tacticalMapMainImage.Extent(gm, MagickColor.FromRgba(0, 0, 0, 0));

                    //gm = new MagickGeometry();
                    //gm.Width = (int)(overlay.Width * 1.3f);
                    //gm.Height = (int)(overlay.Width * 1.3f);
                    //gm.IgnoreAspectRatio = true;
                    inventoryImage.SetWriteMask(edgeFix);
                    inventoryImage.Composite(tacticalMapMainImage, CompositeOperator.SrcOver);

                    //overlay.LiquidRescale((int)(overlay.Width * 1.3f), (int)(overlay.Height * 1.3f));
                    //Overlay.Transparent(MagickColors.Black);

                    //main.Composite(overlay, CompositeOperator.SrcOver);

                    //string entityName = CreateEntityFolder(entityNameText.Text);

                    inventoryImage.Write(File.Create("entities\\" + entityName.Text + "\\main.png"), MagickFormat.Png);
                    inventoryImage.Write(File.Create("entities\\" + entityName.Text + "\\damaged.png"), MagickFormat.Png);
                    //File.Copy("entities\\" + entityName + "\\main.png", "entities\\" + entityName + "\\damaged.png");
                }
                else
                {
                    //Directory.CreateDirectory("entities\\" + entityNameText.Text);

                    MagickImage main = new MagickImage(new MemoryStream(File.ReadAllBytes("templates\\armor_template.png")));
                    //EntityMetadata metadata = new EntityMetadata(main, "Armor");
                    //metadata.Write("entities\\" + entityNameText.Text);

                    File.Copy("templates\\armor_template.png", "entities\\" + entityName.Text + "\\main.png");
                    File.Copy("templates\\armor_template.png", "entities\\" + entityName.Text + "\\damaged.png");
                }
            }
        }

        //public string CreateEntityFolder(string entityName)
        //{
        //    if (string.IsNullOrEmpty(entityName))
        //    {
        //        entityName = "new_entity";
        //    }
        //
        //    if (!Directory.Exists("entities\\" + entityName))
        //    {
        //        Directory.CreateDirectory("entities\\" + entityName);
        //    }
        //    return entityName;
        //}

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PNG files (*.png)|*.png";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                tacticalMapMainSpriteId.Text = openFileDialog1.FileName;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void restoreCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            restorePanel.Enabled = restoreCheckbox.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "PNG files (*.png)|*.png";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                inventoryImagePath.Text = openFileDialog1.FileName;
            }
        }

        public void LoadEntities()
        {
            entityList.Items.Clear();
            entityList.Items.AddRange(Directory.GetDirectories("entities").Select(Path.GetFileName).ToArray());
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog1 = new FolderBrowserDialog();
            //openFileDialog1.Filter = "Brush files (*.brush)|*.brush";
            //openFileDialog1.Description = "Select a Bbrusher project folder";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                bbrusherProjectPath.Text = openFileDialog1.SelectedPath;
            }
        }
    }
}
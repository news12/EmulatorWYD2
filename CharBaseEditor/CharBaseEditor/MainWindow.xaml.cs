using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace CharBaseEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

           
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

           //move form in window style none
            this.DragMove();
        }

        private void BoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                if (e.Source is TextBox box)
                    box.MoveFocus(new TraversalRequest(new FocusNavigationDirection()));
             
        }

        private void BoxGotFocus(object sender, RoutedEventArgs e)
        {
            if (e.Source is TextBox box)
            {
                box.SelectionStart = 0;
                box.SelectAll();
            }
           
        }

        private void BtnLoad_Click(object sender, RoutedEventArgs e)
        {
            Config.ConfigLoad();
            MessageBox.Show("Files Carregado com sucesso!!!");
        }

        private void BtnTK_Click(object sender, RoutedEventArgs e)
        {
            Config.refClass = 0;
            LoadClass(Config.refClass);
        }

        private void BtnFM_Click(object sender, RoutedEventArgs e)
        {
            Config.refClass = 1;
            LoadClass(Config.refClass);
        }

        private void BtnBM_Click(object sender, RoutedEventArgs e)
        {
            Config.refClass = 2;
            LoadClass(Config.refClass);
        }

        private void BtnHT_Click(object sender, RoutedEventArgs e)
        {
            Config.refClass = 3;
            LoadClass(Config.refClass);
        }

        private void LoadClass(int idx)
        {
            try
            {
                LoadFace(Config.ClassBase[idx].Face.Split(','));
                LoadHelm(Config.ClassBase[idx].Helmet.Split(','));
                LoadArmor(Config.ClassBase[idx].Armor.Split(','));
                LoadPants(Config.ClassBase[idx].Pant.Split(','));
                LoadGlove(Config.ClassBase[idx].Glove.Split(','));
                LoadBoot(Config.ClassBase[idx].Boot.Split(','));
                LoadStatus(Config.ClassBase[idx].BaseStatus.Split(','));

                BoxDef.Text = Config.ClassBase[idx].Defense.ToString();
                BoxDam.Text = Config.ClassBase[idx].Attack.ToString();
                BoxMag.Text = Config.ClassBase[idx].Magic.ToString();
                BoxHP.Text = Config.ClassBase[idx].MaxHP.ToString();
                BoxMP.Text = Config.ClassBase[idx].MaxMP.ToString();
            }
            catch (System.Exception)
            {
                MessageBox.Show("Objeto não encontrado clique em carregar e tente novamente.");
               // throw;
            }
           

        }

        private void LoadFace(string[] buff)
        {
            BoxFaceId.Text = buff[0];
            BoxFaceEF1.Text = buff[1];
            BoxFaceEFV2.Text = buff[2];
            BoxFaceEF2.Text = buff[3];
            BoxFaceEFV2.Text = buff[4];
            BoxFaceEF3.Text = buff[5];
            BoxFaceEFV3.Text = buff[6];
        }
        private void LoadHelm(string[] buff)
        {
            BoxHelmId.Text = buff[0];
            BoxHelmEF1.Text = buff[1];
            BoxHelmEFV2.Text = buff[2];
            BoxHelmEF2.Text = buff[3];
            BoxHelmEFV2.Text = buff[4];
            BoxHelmEF3.Text = buff[5];
            BoxHelmEFV3.Text = buff[6];
        }
        private void LoadArmor(string[] buff)
        {
            BoxArmorId.Text = buff[0];
            BoxArmorEF1.Text = buff[1];
            BoxArmorEFV2.Text = buff[2];
            BoxArmorEF2.Text = buff[3];
            BoxArmorEFV2.Text = buff[4];
            BoxArmorEF3.Text = buff[5];
            BoxArmorEFV3.Text = buff[6];
        }
        private void LoadPants(string[] buff)
        {
            BoxPantsId.Text = buff[0];
            BoxPantsEF1.Text = buff[1];
            BoxPantsEFV2.Text = buff[2];
            BoxPantsEF2.Text = buff[3];
            BoxPantsEFV2.Text = buff[4];
            BoxPantsEF3.Text = buff[5];
            BoxPantsEFV3.Text = buff[6];
        }
        private void LoadGlove(string[] buff)
        {
            BoxGloveId.Text = buff[0];
            BoxGloveEF1.Text = buff[1];
            BoxGloveEFV2.Text = buff[2];
            BoxGloveEF2.Text = buff[3];
            BoxGloveEFV2.Text = buff[4];
            BoxGloveEF3.Text = buff[5];
            BoxGloveEFV3.Text = buff[6];
        }
        private void LoadBoot(string[] buff)
        {
            BoxBootId.Text = buff[0];
            BoxBootEF1.Text = buff[1];
            BoxBootEFV2.Text = buff[2];
            BoxBootEF2.Text = buff[3];
            BoxBootEFV2.Text = buff[4];
            BoxBootEF3.Text = buff[5];
            BoxBootEFV3.Text = buff[6];
        }
        private void LoadStatus(string[] buff)
        {
            BoxStr.Text = buff[0];
            BoxInt.Text = buff[1];
            BoxDex.Text = buff[2];
            BoxCon.Text = buff[3];
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                SaveAll();
                SerealizeClass();
               MessageBox.Show("Arquivo Salvo com sucesso!!!");
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void SaveAll()
        {
            Config.ClassBase[Config.refClass].Face = GetFace();
            Config.ClassBase[Config.refClass].Helmet = GetHelm();
            Config.ClassBase[Config.refClass].Armor = GetArmor();
            Config.ClassBase[Config.refClass].Pant = GetPant();
            Config.ClassBase[Config.refClass].Glove = GetGlove();
            Config.ClassBase[Config.refClass].Boot = GetBoot();
            Config.ClassBase[Config.refClass].BaseStatus = GetBaseStatus();

            Config.ClassBase[Config.refClass].Class = Config.refClass;
            Config.ClassBase[Config.refClass].Defense = int.Parse(BoxDef.Text);
            Config.ClassBase[Config.refClass].Attack = int.Parse(BoxDam.Text);
            Config.ClassBase[Config.refClass].Magic = short.Parse(BoxMag.Text);
            Config.ClassBase[Config.refClass].MaxHP = uint.Parse(BoxHP.Text);
            Config.ClassBase[Config.refClass].MaxMP = uint.Parse(BoxMP.Text);

            Config.ClassBase[Config.refClass].CurHP = Config.ClassBase[Config.refClass].MaxHP;
            Config.ClassBase[Config.refClass].CurMP = Config.ClassBase[Config.refClass].MaxMP;

        }

        private string GetBaseStatus()
        {
            string buff =
                 BoxStr.Text + "," + BoxInt.Text + ","
                 + BoxDex.Text + "," + BoxCon.Text ;


            return buff;
        }

        private string GetBoot()
        {
            string buff =
                BoxBootId.Text + "," + BoxBootEF1.Text + "," + BoxBootEFV1.Text + ","
                + BoxBootEF2.Text + "," + BoxBootEFV2.Text + ","
                + BoxBootEF3.Text + "," + BoxBootEFV3.Text;

            return buff;
        }

        private string GetGlove()
        {
            string buff =
                BoxGloveId.Text + "," + BoxGloveEF1.Text + "," + BoxGloveEFV1.Text + ","
                + BoxGloveEF2.Text + "," + BoxGloveEFV2.Text + ","
                + BoxGloveEF3.Text + "," + BoxGloveEFV3.Text;


            return buff;
        }

        private string GetPant()
        {
            string buff =
                BoxPantsId.Text + "," + BoxPantsEF1.Text + "," + BoxPantsEFV1.Text + ","
                + BoxPantsEF2.Text + "," + BoxPantsEFV2.Text + ","
                + BoxPantsEF3.Text + "," + BoxPantsEFV3.Text;


            return buff;
        }

        private string GetFace()
        {
            string buff = 
                BoxFaceId.Text +"," + BoxFaceEF1.Text + "," + BoxFaceEFv1.Text + ","
                + BoxFaceEF2.Text + "," + BoxFaceEFV2.Text + ","
                + BoxFaceEF3.Text + "," + BoxFaceEFV3.Text;


            return buff;
        }
        private string GetHelm()
        {
            string buff =
                BoxHelmId.Text + "," + BoxHelmEF1.Text + "," + BoxHelmEFV1.Text + ","
                + BoxHelmEF2.Text + "," + BoxHelmEFV2.Text + ","
                + BoxHelmEF3.Text + "," + BoxHelmEFV3.Text;


            return buff;
        }

        private string GetArmor()
        {
            string buff =
                BoxArmorId.Text + "," + BoxArmorEF1.Text + "," + BoxArmorEFV1.Text + ","
                + BoxArmorEF2.Text + "," + BoxArmorEFV2.Text + ","
                + BoxArmorEF3.Text + "," + BoxArmorEFV3.Text;


            return buff;
        }

        private void SerealizeClass()
        {
            try
            {
                XmlSerializer ser = new(typeof(ClassBase));
                string configBase = null;
                switch (Config.refClass)
                {
                    case 0:
                        configBase = Config.ConfigTkBase;
                        break;
                    case 1:
                        configBase = Config.ConfigFmBase;
                        break;
                    case 2:
                        configBase = Config.ConfigBmBase;
                        break;
                    case 3:
                        configBase = Config.ConfigHtBase;
                        break;
                    default:
                        break;
                }

                TextWriter writer = new StreamWriter(configBase);
                ser.Serialize(writer, Config.ClassBase[Config.refClass]);
                writer.Close();
            }
            catch (System.Exception e)
            {
               MessageBox.Show(e.Message);
            }
           
        }
    }


}

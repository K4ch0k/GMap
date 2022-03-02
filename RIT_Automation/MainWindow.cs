using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RIT_Automation
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool SqlConn { get; set; } = false;
        List<dbMarker> AllSqlGMarkers { get; set; } = new List<dbMarker>();

        GMapOverlay AllMarkers = new GMapOverlay("markers");

        GMarkerGoogle SelectedMarker { get; set; }

        bool NeedChangePosition { get; set; }

        double MouseX { get; set; } = 51;
        double MouseY { get; set; } = 104;

        private void ChangeVisible(bool value, GMarkerGoogle gMarker = null)
        {
            if (gMarker != null)
            {
                SelectedMarker = gMarker;
                textBoxToolTip.Text = gMarker.ToolTipText;
                textBoxLat.Text = gMarker.Position.Lat.ToString();
                textBoxLng.Text = gMarker.Position.Lng.ToString();
            }

            textBoxToolTip.Visible = value;
            textBoxLat.Visible = value;
            textBoxLng.Visible = value;
            labelX.Visible = value;
            labelY.Visible = value;
            DeleteMarkerBtn.Visible = value;
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            string[] maps = { "Google", "Google рельеф", "Google Спутник", "Wiki", "2Gis", "2Gis рельеф" };
            MapProviderCombo.Items.AddRange(maps);
            MapProviderCombo.SelectedIndex = 1;
            SqlConn = await SQLInteractions.SqlCheckConn();
        }

        private async void MainGMap_Load(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            GMap.NET.MapProviders.GoogleMapProvider.Language = LanguageType.Russian;
            GMap.NET.MapProviders.WikiMapiaMapProvider.Language = LanguageType.Russian;
            GMap.NET.MapProviders.ArcGIS_World_Street_MapProvider.Language = LanguageType.Russian;
            MainGMap.MaxZoom = 20;
            MainGMap.Zoom = 4;
            MainGMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            MainGMap.CanDragMap = true;
            MainGMap.DragButton = MouseButtons.Left;
            MainGMap.ShowCenter = false;
            MainGMap.Position = new PointLatLng(MouseX, MouseY);
            MainGMap.DragButton = MouseButtons.Left;

            MainGMap.MarkersEnabled = true;

            if (SqlConn)
            {
                AllSqlGMarkers = await SQLInteractions.SqlSelectAllMarkers();
                if (AllSqlGMarkers != null)
                {
                    foreach (dbMarker item in AllSqlGMarkers)
                    {
                        GMarkerGoogle gMarker = new GMarkerGoogle(new PointLatLng(item.Lat, item.Long), GMarkerGoogleType.red_small);
                        gMarker.ToolTipText = item.Desc;
                        gMarker.Tag = item.ID;
                        AllMarkers.Markers.Add(gMarker);
                    }
                } 
                else
                {
                    MessageBox.Show("Маркеров в базе данных не обнаружено", "Информация", MessageBoxButtons.OK ,MessageBoxIcon.Warning);
                }
            }
            MainGMap.Overlays.Clear();
            MainGMap.Overlays.Add(AllMarkers);
        }

        private void MapProviderCombo_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (MapProviderCombo.Text)
            {
                case "Google":
                    MainGMap.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
                    MainGMap.MaxZoom = 20;
                    break;
                case "Google рельеф":
                    MainGMap.MapProvider = GMap.NET.MapProviders.GoogleTerrainMapProvider.Instance;
                    MainGMap.Zoom = MainGMap.Zoom > 13 ? 13 : MainGMap.Zoom;
                    MainGMap.MaxZoom = 13;
                    break;
                case "Google Спутник":
                    MainGMap.MapProvider = GMap.NET.MapProviders.GoogleSatelliteMapProvider.Instance;
                    MainGMap.MaxZoom = 20;
                    break;
                case "Wiki":
                    MainGMap.MapProvider = GMap.NET.MapProviders.WikiMapiaMapProvider.Instance;
                    MainGMap.Zoom = MainGMap.Zoom > 18 ? 18 : MainGMap.Zoom;
                    MainGMap.MaxZoom = 18;
                    break;
                case "2Gis":
                    MainGMap.MapProvider = GMap.NET.MapProviders.ArcGIS_World_Street_MapProvider.Instance;
                    MainGMap.Zoom = MainGMap.Zoom > 17 ? 17 : MainGMap.Zoom;
                    MainGMap.MaxZoom = 17;
                    break;
                case "2Gis рельеф":
                    MainGMap.MapProvider = GMap.NET.MapProviders.ArcGIS_World_Terrain_Base_MapProvider.Instance;
                    MainGMap.Zoom = MainGMap.Zoom > 8 ? 8 : MainGMap.Zoom;
                    MainGMap.MaxZoom = 8;
                    break;
            }
            MainGMap.Overlays.Clear();
            MainGMap.Overlays.Add(AllMarkers);
        }

        private void MainGMap_MouseDown(object sender, MouseEventArgs e)
        {
            MouseX = MainGMap.FromLocalToLatLng(e.X, e.Y).Lat;
            MouseY = MainGMap.FromLocalToLatLng(e.X, e.Y).Lng;

            GMarkerGoogle LastMarker = SelectedMarker;

            SelectedMarker = (GMarkerGoogle)MainGMap.Overlays
                    .SelectMany(item => item.Markers)
                    .FirstOrDefault(item => item.IsMouseOver == true);

            if (SqlConn && LastMarker != null && SelectedMarker != LastMarker )
            {
                SqlConnTimer.Start();
                UpdateMarkerdb(LastMarker);
            }

            if (SelectedMarker != null)
                ChangeVisible(true, SelectedMarker);
            else
                ChangeVisible(false);
        }

        private void MainGMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MainGMap.Zoom = ++MainGMap.Zoom;
        }

        private void MainGMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            ChangeVisible(true, item as GMarkerGoogle);
            NeedChangePosition = false;
        }

        #region Изменение маркера
        private void textBoxToolTip_TextChanged(object sender, EventArgs e)
        {
            if (SelectedMarker != null)
            {
                SelectedMarker.ToolTipText = textBoxToolTip.Text.ToString();
            }
            else
            {
                ChangeVisible(false);
            }
        }

        private void textBoxLat_TextChanged(object sender, EventArgs e)
        {
            double Lat = 0;
            if (SelectedMarker != null)
            {
                try
                {
                    Lat = Convert.ToDouble(textBoxLat.Text.ToString());
                    if (Lat > 90 || Lat < -90)
                        Lat = SelectedMarker.Position.Lat;
                    SelectedMarker.Position = new PointLatLng(Lat, SelectedMarker.Position.Lng);
                }
                catch
                {
                    SelectedMarker.Position = new PointLatLng(Lat, SelectedMarker.Position.Lng);
                }
                textBoxLat.Text = Lat.ToString();
            }
            else
            {
                ChangeVisible(false);
            }
        }

        private void textBoxLng_TextChanged(object sender, EventArgs e)
        {
            double Lng = 0;
            if (SelectedMarker != null)
            {
                try
                {
                    Lng = Convert.ToDouble(textBoxLng.Text.ToString());
                    if (Lng > 180 || Lng < -180)
                        Lng = SelectedMarker.Position.Lng;
                    SelectedMarker.Position = new PointLatLng(SelectedMarker.Position.Lat, Lng);
                }
                catch
                {
                    SelectedMarker.Position = new PointLatLng(SelectedMarker.Position.Lat, Lng);
                }
                textBoxLng.Text = Lng.ToString();
            }
            else
            {
                ChangeVisible(false);
            }
        }

        private void textBoxLat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == '.') || (e.KeyChar == ','))
            {
                e.KeyChar = ',';
            }
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private async void UpdateMarkerdb(GMarkerGoogle marker)
        {
            // Изменение в БД
            if (marker.Tag != null && Convert.ToInt32(marker.Tag) != 0)
            {
                dbMarker ChangeMarker = new dbMarker
                {
                    ID = Convert.ToInt32(marker.Tag),
                    Lat = marker.Position.Lat,
                    Long = marker.Position.Lng,
                    Desc = marker.ToolTipText
                };
                SqlConn = await SQLInteractions.SqlUpdateMarker(ChangeMarker);
            }
        }

        private async void CreateMarkerBtn_Click(object sender, EventArgs e)
        {
            GMarkerGoogle gMarker = new GMarkerGoogle(new PointLatLng(MouseX, MouseY), GMarkerGoogleType.red_small);

            if (SqlConn != false)
            {
                SqlConnTimer.Start();
                SqlConn = false;
                // Добавление в БД
                dbMarker NewMarker = new dbMarker
                {
                    Lat = gMarker.Position.Lat,
                    Long = gMarker.Position.Lng,
                    Desc = gMarker.ToolTipText
                };
                int Tag = await SQLInteractions.SqlInsertMarker(NewMarker);
                if (Tag != 0)
                {
                    SqlConn = true;
                }
                gMarker.Tag = Tag;
                NewMarker.ID = Tag;
                AllSqlGMarkers.Add(NewMarker);
            }

            AllMarkers.Markers.Add(gMarker);
            MainGMap.Overlays.Clear();
            MainGMap.Overlays.Add(AllMarkers);

            ChangeVisible(true, gMarker);
        }

        private async void DeleteMarkerBtn_Click(object sender, EventArgs e)
        {
            ChangeVisible(false);
            if (SqlConn && SelectedMarker.Tag != null)
            {
                dbMarker Marker = AllSqlGMarkers.FirstOrDefault(item => item.ID == Convert.ToInt32(SelectedMarker.Tag));
                SqlConn = false;
                if (Marker != null && Marker.ID != 0)
                {
                    SqlConnTimer.Start();
                    SqlConn = await SQLInteractions.SqlDeleteMarker(Marker.ID);
                }
                if (SqlConn)
                {
                    AllSqlGMarkers.Remove(Marker);
                }
            }
            AllMarkers.Markers.Remove(SelectedMarker);
            MainGMap.Overlays.Clear();
            MainGMap.Overlays.Add(AllMarkers);
            SelectedMarker = null;
        }

        #endregion

        private void MainGMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                double MouseX2 = MainGMap.FromLocalToLatLng(e.X, e.Y).Lat;
                double MouseY2 = MainGMap.FromLocalToLatLng(e.X, e.Y).Lng;
                if (SelectedMarker == null)
                    NeedChangePosition = false;
                else
                    NeedChangePosition = true;
                
                if (SelectedMarker != null && NeedChangePosition == true &&
                    MouseX != MouseX2 && MouseY != MouseY2)
                {
                    MouseX = MainGMap.FromLocalToLatLng(e.X, e.Y).Lat;
                    MouseY = MainGMap.FromLocalToLatLng(e.X, e.Y).Lng;
                    SelectedMarker.Position = new PointLatLng(MouseX, MouseY);
                    ChangeVisible(true, SelectedMarker);
                }
            }
        }

        private void SqlConnTimer_Tick(object sender, EventArgs e)
        {
            MainGMap.Enabled = false;
            SqlConnprogressBar.Visible = true;
            SqlConnprogressBar.Value++;
            if (SqlConnprogressBar.Value == 15 || SqlConn == true)
            {
                SqlConnprogressBar.Value = 0;
                SqlConnprogressBar.Visible = false;
                MainGMap.Visible = true;
                MapProviderCombo.Visible = true;
                TxtBackgroundImg.Visible = false;
                BackgroundMap.Visible = false;
                MainGMap.Enabled = true;
                SqlConnTimer.Stop();

                if (SqlConn == false)
                {
                    MessageBox.Show("Не удалось подключиться к базе данных.\nВзаимодействие с базой данных невозможно", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MainGMap_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                MainGMap.Visible = false;
                SelectedMarker = null;
                MainWindow_Load(null, null);
                MainGMap_Load(null,null);
                MainGMap.Visible = true;
            }
            if (e.KeyData == Keys.Delete && SelectedMarker != null)
            {
                DeleteMarkerBtn_Click(null,null);
            }
        }

        private void InfoContextMenuBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Нажатие правой кнопки мыши по карте - вызов меню\n" +
                "Нажатие клавиши F5 в области карты - перезагрузка страницы\n" +
                "Нажатие клавиши Delete во время выбранного маркера - удаление маркера\n" +
                "Строка подключения к БД находится в файле SQLInteractions.cs",
                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void HelpLabel_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(HelpLabel, "Нажатие правой кнопки мыши по карте - вызов меню\n" +
                "Нажатие клавиши F5 в области карты - перезагрузка страницы\n" +
                "Нажатие клавиши Delete во время выбранного маркера - удаление маркера\n" +
                "Строка подключения к БД находится в файле SQLInteractions.cs");
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (SelectedMarker != null && SqlConn)
            {
                UpdateMarkerdb(SelectedMarker);
            }
        }

    }
}

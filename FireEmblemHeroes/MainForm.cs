using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireEmblemHeroes.Properties;

namespace FireEmblemHeroes
{
  public partial class MainForm : Form
  {
    private readonly Map _map;
    private readonly Image _mapImage;
    private readonly Hero[] _heroes;

    public MainForm()
    {
      InitializeComponent();
      _map = Maps.CreateMap(Maps.Kenney1);
      _mapImage = Resources.Kenney1.Clone() as Image;
      _heroes = new Hero[8];
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      timerInvalidate.Start();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      timerInvalidate.Stop();
      base.OnFormClosing(e);
    }

    private void timerInvalidate_Tick(object sender, EventArgs e)
    {
      pnlCanvas.Invalidate();
    }

    private void pnlCanvas_Paint(object sender, PaintEventArgs e)
    {
      var g = e.Graphics;
      g.Clear(Color.Red);
      g.InterpolationMode = InterpolationMode.HighQualityBicubic;
      g.SmoothingMode = SmoothingMode.HighQuality;
      g.PixelOffsetMode = PixelOffsetMode.HighQuality;
    }
  }
}

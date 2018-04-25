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
    private readonly Random _random = new Random();

    private readonly Map _map;
    private readonly Image _mapImage;
    private readonly HeroTeam _team1;
    private readonly HeroTeam _team2;

    private readonly MapState _mapState;

    private DateTime lastTime = DateTime.Now;
    private Image currentBuffer = null;

    public MainForm()
    {
      InitializeComponent();
      _map = Maps.CreateMap(Maps.Kenney1);
      _mapImage = Resources.Kenney1.Clone() as Image;

      var raven1 = new InfantryAxe();
      raven1.Weapon = new Basilikos();
      raven1.BaseStats = (37, 31, 32, 22, 19);
      _team1 = new HeroTeam();
      _team1.Id = 0;
      _team1.Heroes = new[] { raven1 };
      _team1.Locations = new[] { new MapCellLocation(0, 0) };

      var raven2 = new InfantryAxe();
      raven2.Weapon = new Basilikos();
      raven2.BaseStats = (44, 37, 38, 29, 25);
      _team2 = new HeroTeam();
      _team2.Id = 1;
      _team2.Heroes = new[] { raven2 };
      _team2.Locations = new[] { new MapCellLocation(0, 1) };

      _mapState = new MapState(_map, _team1, _team2);
    }

    private void DrawBuffer()
    {
      var now = DateTime.Now;
      if (currentBuffer == null || ((now - lastTime).TotalMilliseconds >= 500))
      {
        lastTime = now;

        if (currentBuffer != null)
        {
          currentBuffer.Dispose();
          currentBuffer = null;
        }

        currentBuffer = _mapImage.Clone() as Image;

        var width = (float)decimal.Divide(currentBuffer.Width, _map.Columns);
        var height = (float)decimal.Divide(currentBuffer.Height, _map.Rows);

        using (var surface = Graphics.FromImage(currentBuffer))
        {
          foreach (var cell in _mapState.Cells)
          {
            if (cell.IsBroken)
            {
              var (r, c) = cell.Location;
              surface.FillRectangle(Brushes.Green, c * width, r * height, width, height);
            }
          }

          foreach (var hero in _mapState.Heroes.Where(v => !v.IsDead))
          {
            hero.CanAct = true;

            var moves = _mapState.GetMoves(hero).ToArray();
            var move = moves[_random.Next(moves.Length)];
            move.Do();

            var (r, c) = hero.Location;

            Image heroImage = null;
            switch (hero.TeamId)
            {
              case 0:
                heroImage = Resources.Hero1_Team1;
                break;
              case 1:
                heroImage = Resources.Hero1_Team2;
                break;
            }

            if (heroImage != null)
            {
              float x = c * width;
              float y = r * height;
              surface.DrawImage(heroImage, x, y);

              float pc = (float)(hero.CurrentStats.HP / hero.Hero.BaseStats.HP);
              var rect = new RectangleF(x, y + height - 5, width * pc, 5);
              surface.FillRectangle(Brushes.Blue, rect.X, rect.Y, rect.Width, rect.Height);
              surface.DrawRectangle(Pens.Black, rect.X, rect.Y, width, rect.Height);
            }
          }
        }
      }
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
      var graphics = e.Graphics;
      graphics.Clear(Color.SlateBlue);
      graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
      graphics.SmoothingMode = SmoothingMode.HighQuality;
      graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

      DrawBuffer();
      graphics.DrawImage(currentBuffer, 0, 0, pnlCanvas.Width, pnlCanvas.Height);
    }
  }
}

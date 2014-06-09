using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;


//using System.Windows.Appliu;
//using System.Windows.UI.Xaml.Controls;
//using System.Windows.UI.Xaml.Media.Imaging;
//using System.Windows.UI.Xaml.Shapes;

namespace DesktopWaifuSimulator
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	/// 
	public partial class MainWindow : Window
	{
		/*     private const int NumberOfColumns = 8;

				 private const int NumberOfFrames = 16;

				 private const int FrameWidth = 55;

				 private const int FrameHeight = 95;

				 public static readonly TimeSpan TimePerFrame = TimeSpan.FromSeconds(0.5);

				 private int currentFrame;

				 private TimeSpan timeTillNextFrame;

				 public MainWindow()
				 {
						 this.InitializeComponent();
				 }

				 protected override void OnActivated(EventArgs e)
				 {
						 Debug.WriteLine("Activated");
						 CompositionTarget.Rendering += this.OnUpdate;
				 }

				 protected override void OnDeactivated(EventArgs e)
				 {
						 Debug.WriteLine("Deactivated");
						 CompositionTarget.Rendering -= this.OnUpdate;
				 }

				 private void OnUpdate(object sender, object e)
				 {
						 this.timeTillNextFrame += TimeSpan.FromSeconds(1 / 60f);
						 if (this.timeTillNextFrame > TimePerFrame)
						 {
								 this.currentFrame = (this.currentFrame + 1 + NumberOfFrames) % NumberOfFrames;
								 var column = this.currentFrame % NumberOfColumns;
								 var row = this.currentFrame / NumberOfColumns;

								 this.SpriteSheetOffset.X = -column * FrameWidth;
								 this.SpriteSheetOffset.Y = -row * FrameHeight;
						 }
						 Debug.WriteLine("X : " + this.SpriteSheetOffset.X + " , Y : " + this.SpriteSheetOffset.Y);
				 }
			}*/
		private int ximages; //The number of sprites in each row
		private int yimages; //The number of sprites in each column
		private int currentRow;
		private int currentColumn;
		private TranslateTransform offsetTransform;

		public MainWindow()
		{
			this.InitializeComponent();

			Suwako.Width = 240; //Set the width of an individual sprite
			Suwako.Height = 296; //Set the height of an individual sprite
			ximages = 6; //The number of sprites in each row
			yimages = 5; //The number of sprites in each column
			currentRow = 0;
			currentColumn = 0;

			offsetTransform = new TranslateTransform();

			KeyDown += _MuhKeys;
		}
		private void _MuhKeys(object sender, KeyEventArgs e)
		{
			switch (e.Key)
			{
				case Key.Up:
					currentColumn--;
					if (currentColumn < 0)
					{
						currentColumn = ximages - 1;
						if (currentRow == 0)
						{
							currentRow = yimages - 1;
						}
						else
						{
							currentRow--;
						}
					}
					break;
				case Key.Down:
					currentColumn++;
					if (currentColumn == ximages)
					{
						currentColumn = 0;
						if (currentRow == yimages - 1)
						{
							currentRow = 0;
						}
						else
						{
							currentRow++;
						}
					}
					break;
				default:
					break;
			}

			offsetTransform.X = -Suwako.Width * currentColumn;
			offsetTransform.Y = -Suwako.Height * currentRow;
			SpriteSheetOffSet.Transform = offsetTransform;
		}
	}
}

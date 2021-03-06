using System;

#if __UNIFIED__
using UIKit;
using CoreGraphics;
using Foundation;
using CoreLocation;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreLocation;
using System.Drawing;

using CGRect = global::System.Drawing.RectangleF;
using CGSize = global::System.Drawing.SizeF;
using CGPoint = global::System.Drawing.PointF;

using nfloat = global::System.Single;
using nint = global::System.Int32;
using nuint = global::System.UInt32;
#endif

using Google.Maps;

namespace GoogleMapsAdvSample
{
	public class PolylinesViewController : UIViewController
	{
		public PolylinesViewController () : base ()
		{
			Title = "Polylines";
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			var camera = CameraPosition.FromCamera (0, -180, 3);
			var mapView = MapView.FromCamera (CGRect.Empty, camera);

			// Create a 'normal' polyline.
			var polyline = new Polyline ();
			var path = new MutablePath ();

			path.AddCoordinate (new CLLocationCoordinate2D (37.772323, -122.214897));
			path.AddCoordinate (new CLLocationCoordinate2D (21.291982, -157.821856));
			path.AddCoordinate (new CLLocationCoordinate2D (-18.142599, 178.431));
			path.AddCoordinate (new CLLocationCoordinate2D (-27.46758, 153.0278926));

			polyline.Path = path;
			polyline.StrokeColor = UIColor.Red;
			polyline.StrokeWidth = 2;
			polyline.Map = mapView;
			
			// Copy the previous polyline, change its color, and mark it as geodesic.
			polyline = (Polyline) polyline.Copy ();
			polyline.StrokeColor = UIColor.Green;
			polyline.Geodesic = true;
			polyline.Map = mapView;
			
			View = mapView;
		}
	}
}


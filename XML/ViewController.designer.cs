// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XML
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton btnBuscar { get; set; }

		[Outlet]
		UIKit.UIButton Btnfoto { get; set; }

		[Outlet]
		UIKit.UIButton btnGuardar { get; set; }

		[Outlet]
		UIKit.UIImageView Imagen { get; set; }

		[Outlet]
		UIKit.UITextField txtCorreo { get; set; }

		[Outlet]
		UIKit.UITextField txtEdad { get; set; }

		[Outlet]
		UIKit.UITextField txtFolio { get; set; }

		[Outlet]
		UIKit.UITextField Txtfolio1 { get; set; }

		[Outlet]
		UIKit.UITextField txtNombre { get; set; }

		[Outlet]
		UIKit.UITextField Txtpuesto { get; set; }

		[Outlet]
		UIKit.UITextField txtSaldo { get; set; }

		[Outlet]
		UIKit.UITextField Txtsueldo { get; set; }

		[Outlet]
		UIKit.UITextView Vista { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Txtfolio1 != null) {
				Txtfolio1.Dispose ();
				Txtfolio1 = null;
			}

			if (Btnfoto != null) {
				Btnfoto.Dispose ();
				Btnfoto = null;
			}

			if (Imagen != null) {
				Imagen.Dispose ();
				Imagen = null;
			}

			if (Vista != null) {
				Vista.Dispose ();
				Vista = null;
			}

			if (Txtsueldo != null) {
				Txtsueldo.Dispose ();
				Txtsueldo = null;
			}

			if (Txtpuesto != null) {
				Txtpuesto.Dispose ();
				Txtpuesto = null;
			}

			if (btnBuscar != null) {
				btnBuscar.Dispose ();
				btnBuscar = null;
			}

			if (btnGuardar != null) {
				btnGuardar.Dispose ();
				btnGuardar = null;
			}

			if (txtCorreo != null) {
				txtCorreo.Dispose ();
				txtCorreo = null;
			}

			if (txtEdad != null) {
				txtEdad.Dispose ();
				txtEdad = null;
			}

			if (txtFolio != null) {
				txtFolio.Dispose ();
				txtFolio = null;
			}

			if (txtNombre != null) {
				txtNombre.Dispose ();
				txtNombre = null;
			}

			if (txtSaldo != null) {
				txtSaldo.Dispose ();
				txtSaldo = null;
			}
		}
	}
}

using System;
using System.Xml.Serialization;
using System.IO;
using Foundation;
using SQLite;
using UIKit;

namespace XML
{
	public partial class ViewController : UIViewController
	{
		
		string Archivojpg, ruta;
		private UIImagePickerController SeleccionadorImagen;

		protected ViewController(IntPtr handle) : base(handle)
			{
			}
			public override void ViewDidLoad()
			{
				base.ViewDidLoad();
				Vista.Text = "";
				var Archivos = Directory.GetFiles(Environment.GetFolderPath (Environment.SpecialFolder.Personal));
				foreach (var archivo in Archivos)
				{
					Vista.Text += archivo +
						Environment.NewLine;
				}
				var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

				SeleccionadorImagen = new UIImagePickerController();
				SeleccionadorImagen.FinishedPickingMedia +=SeleccionImagen;
				SeleccionadorImagen.Canceled += ImagenCancelada;

				if (UIImagePickerController.IsSourceTypeAvailable (UIImagePickerControllerSourceType.Camera))
				{
					SeleccionadorImagen.SourceType =
						UIImagePickerControllerSourceType.Camera;
				}
				else
				{
					SeleccionadorImagen.SourceType =UIImagePickerControllerSourceType.PhotoLibrary;
				}

			    Btnfoto.TouchUpInside += delegate
				{
					PresentViewController(SeleccionadorImagen,
										  true, null);
				};

				path = Path.Combine(path, "Base.db3");
				var conn = new SQLiteConnection(path);
				conn.CreateTable<Empleados>();


			    btnGuardar.TouchUpInside += delegate
				{
					try
					{
						var Insertar = new Empleados();
						Insertar.Folio = int.Parse(txtFolio.Text);
						Insertar.Nombre = txtNombre.Text;
						Insertar.Edad = int.Parse(txtEdad.Text);
					    Insertar.Puesto = Txtpuesto.Text;
					    Insertar.Sueldo = double.Parse(Txtsueldo.Text);
						Insertar.Foto = txtFolio.Text + ".jpg";
						conn.Insert(Insertar);
						txtFolio.Text = "";
						txtNombre.Text = "";
						txtEdad.Text = "";
					    Txtpuesto.Text = "";
					    Txtsueldo.Text = "";
                        Imagen.Image = null;
						MessageBox("Guardado Correctamente","SQLite");
					}
					catch (Exception ex)
					{
						MessageBox("Error", ex.Message);
					}
				};

			    btnBuscar.TouchUpInside += delegate
				{
					string rutaImagen;
					try
					{
					int foliobusca = int.Parse(Txtfolio1.Text);
						var elementos = from s in conn.Table <Empleados>()where s.Folio == foliobusca select s;
						foreach (var fila in elementos)
						{
							txtFolio.Text = fila.Folio.ToString();
							txtNombre.Text = fila.Nombre;
							txtEdad.Text = fila.Edad.ToString();
						    Txtpuesto.Text = fila.Puesto;
						    Txtsueldo.Text = fila.Sueldo.ToString();
						rutaImagen = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.Personal),Txtfolio1.Text + ".jpg");
							Imagen.Image = UIImage.FromFile(rutaImagen);
						}
					}
					catch (Exception ex)
					{
						MessageBox("Error", ex.Message);
					}
				};
			    Txtfolio1.ShouldReturn += (textField) =>
				{
				Txtfolio1.ResignFirstResponder();
					return true;
				};
			}
			private void MessageBox(string titulo, string mensaje)
			{
				using (var alerta = new UIAlertView())
				{
					alerta.Title = titulo;
					alerta.Message = mensaje;
					alerta.AddButton("OK");
					alerta.Show();
				}
			}
			private void SeleccionImagen(object sender,
				UIImagePickerMediaPickedEventArgs e)
			{
				try
				{
					var ImagenSeleccionada = e.Info
						[UIImagePickerController.OriginalImage]as UIImage;
					var rutaImagen = Path.Combine (Environment.GetFolderPath(Environment.SpecialFolder.Personal),txtFolio.Text + ".jpg");
					if (File.Exists(rutaImagen))
					{
						MessageBox("Error", "Imagen ya existente");
						SeleccionadorImagen.DismissViewController
										   (true, null);
					}
					else
					{
						ruta = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
						Archivojpg = Path.Combine(ruta,txtFolio.Text + ".jpg");
						NSError err;
						var imgData = ImagenSeleccionada.AsJPEG();
						imgData.Save(Archivojpg, false, out err);
						Imagen.Image = UIImage.FromFile(Archivojpg);
						SeleccionadorImagen.DismissViewController(true, null);
					}
				}
				catch (Exception ex)
				{
					MessageBox("Error", ex.Message);
					SeleccionadorImagen.DismissViewController(true, null);
				}
			}
			private void ImagenCancelada(object sender,EventArgs e)
			{
				SeleccionadorImagen.DismissViewController (true, null);
			}
		}
		public class Empleados
		{
			public int Folio { get; set; }
			public string Nombre { get; set; }
			public int Edad { get; set; }
			public string Puesto { get; set; }
			public double Sueldo { get; set; }
			public string Foto { get; set; }
		}
	}
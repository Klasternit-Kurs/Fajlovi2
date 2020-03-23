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
using System.IO;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fajlovi2
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public ObservableCollection<Osoba> ListaO = new ObservableCollection<Osoba>();

		public MainWindow()
		{
			InitializeComponent();
			DataContext = new Osoba();
	
			if (File.Exists("osoba.txt"))
			{
				BinaryFormatter BF = new BinaryFormatter();
				using (Stream tokPodataka = new FileStream("osoba.txt", FileMode.Open, FileAccess.Read))
				{
					ListaO = BF.Deserialize(tokPodataka) as ObservableCollection<Osoba>;
				}
				//tokPodataka.Close(); thanks to using ne moramo  mi :) 

				//Citanje iz CSV falja
				/*foreach (string red in File.ReadLines("osoba.txt"))
				{
					Osoba oso = new Osoba();
					oso.Ime = red.Split(';')[0];
					oso.Prezime = red.Split(';')[1];
					ListaO.Add(oso);
				}*/
			}
			else
			{
				MessageBox.Show("nema fajla :(");
			}

			dg.ItemsSource = ListaO;
		}

		public void Dodavanje(object zklj, RoutedEventArgs abc)
		{
			ListaO.Add(DataContext as Osoba);
			var oso = DataContext as Osoba;
			//File.AppendAllText("osoba.txt", $"{oso.Ime};{oso.Prezime}" + Environment.NewLine);
			DataContext = new Osoba();
		}


		private void ZatvaraSe(object sender, System.ComponentModel.CancelEventArgs e)
		{
			BinaryFormatter BF = new BinaryFormatter();

			using (Stream tokPodataka = new FileStream("osoba.txt", FileMode.Create, FileAccess.Write))
			{
				BF.Serialize(tokPodataka, ListaO);
			}
			//tokPodataka.Close(); Koristimo using da mi ne bi morali da razmisljamo o zatvaranju


			//Ljudski citljivo zapisivanje u CSV fajl
			/*if (File.Exists("osoba.txt"))
			{
				File.Delete("osoba.txt");
			}
			foreach (Osoba oso in ListaO)
			{
				File.AppendAllText("osoba.txt", $"{oso.Ime};{oso.Prezime}" + Environment.NewLine);
			}*/
		}
	}
}

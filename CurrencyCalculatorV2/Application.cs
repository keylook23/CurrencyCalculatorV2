using System;
using System.Windows.Forms;
using System.Xml;

namespace CurrencyCalculatorV2
{
	public partial class Application : Form
	{
		string currency1, currency2;
		string name1, name2;
		double rate1, rate2;
		double converter1, converter2;
		double result;
		string date;

		public Application()
		{
			InitializeComponent();
			LoadCurrencies();
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			currency1 = listBox1.SelectedItem.ToString();
			CheckCurrencies(currency1, currency2);
			label6.Text = name1.ToString();
		}

		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			currency2 = listBox2.SelectedItem.ToString();
			CheckCurrencies(currency1, currency2);
			label7.Text = name2.ToString();
		}

		private void LoadCurrencies()
		{

			XmlDocument doc = new XmlDocument();
			doc.Load("http://www.nbp.pl/kursy/xml/LastA.xml");

			XmlDocument doc2 = new XmlDocument();
			doc2.Load("PLN.xml");


			foreach (XmlNode node in doc.SelectNodes("tabela_kursow/pozycja")) 
			{
				listBox1.Items.Add((node["kod_waluty"].InnerText));
				listBox2.Items.Add((node["kod_waluty"].InnerText));			
			}

			foreach (XmlNode node in doc2.SelectNodes("tabela_kursow/pozycja"))
			{
				listBox1.Items.Add((node["kod_waluty"].InnerText));
				listBox2.Items.Add((node["kod_waluty"].InnerText));
			}

			foreach (XmlNode node in doc.SelectNodes("tabela_kursow"))
			{
				date = node["data_publikacji"].InnerText;			
			}

			label8.Text = date.ToString();
		}

		private void CheckCurrencies(string currency1, string currency2)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("http://www.nbp.pl/kursy/xml/LastA.xml");

			XmlDocument doc2 = new XmlDocument();
			doc2.Load("PLN.xml");

			foreach (XmlNode node in doc.SelectNodes("tabela_kursow/pozycja"))
			{
				if (currency1 == (node["kod_waluty"].InnerText))
				{
					rate1 = double.Parse(node["kurs_sredni"].InnerText);
					name1 = node["nazwa_waluty"].InnerText;
					converter1 = double.Parse(node["przelicznik"].InnerText);
				}
				if (currency2 == (node["kod_waluty"].InnerText))
				{
					rate2 = double.Parse(node["kurs_sredni"].InnerText);
					name2 = node["nazwa_waluty"].InnerText;
					converter2 = double.Parse(node["przelicznik"].InnerText);
				}
			}

			foreach (XmlNode node in doc2.SelectNodes("tabela_kursow/pozycja"))
			{
				if (currency1 == (node["kod_waluty"].InnerText))
				{
					rate1 = double.Parse(node["kurs_sredni"].InnerText);
					name1 = node["nazwa_waluty"].InnerText;
					converter1 = double.Parse(node["przelicznik"].InnerText);
				}
				if (currency2 == (node["kod_waluty"].InnerText))
				{
					rate2 = double.Parse(node["kurs_sredni"].InnerText);
					name2 = node["nazwa_waluty"].InnerText;
					converter2 = double.Parse(node["przelicznik"].InnerText);
				}
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			try
			{
				currency1 = listBox1.SelectedItem.ToString();
				currency2 = listBox2.SelectedItem.ToString();
				CheckCurrencies(currency1, currency2);
				result = (((rate1 / rate2) * GetNumber())/ converter1);
				result = Math.Round(result, 2);
				label1.Text = (GetNumber() + " " + currency1 + " = " + result + " " + currency2).ToString();
			}
			catch
			{
				label1.Text = "Proszę wpisać poprawną wartość i wybrać dwie waluty!".ToString();
			}
		}

		private double GetNumber()
		{
			return Convert.ToDouble(textBox1.Text);
		}
	}
}
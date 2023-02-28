using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1190505045_Furkan_Halil_Er_BG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        double[,] XCisimNoktaBezierYuzeyKontrolN = new double[20, 4] {  { 0.3, 0.1, 1.5, 1 },
                                                                        { 0.2, 1.0, 1.0, 1 },
                                                                        { 0.2, 0.7, 0.8, 1 },
                                                                        { 0.3, 1.0, 0.2, 1 },

                                                                        { 0.5, 0.8, 1.4, 1 },
                                                                        { 0.6, 0.6, 1.1, 1 },
                                                                        { 0.5, 1.2, 0.8, 1 },
                                                                        { 0.5, 1.0, 0.1, 1 },

                                                                        { 1.2, 1.8, 1.6, 1 },
                                                                        { 1.1, 0.6, 1.0, 1 },
                                                                        { 1.2, 1.2, 0.7, 1 },
                                                                        { 1.3, 1.0, 0.3, 1 },

                                                                        { 1.5, 1.8, 1.5, 1 },
                                                                        { 1.4, 0.6, 1.0, 1 },
                                                                        { 1.1, 1.2, 0.7, 1 },
                                                                        { 0.3, 1.0, 0.1, 1 },

                                                                        { 1.8, 0.4, 1.5, 1 },
                                                                        { 1.8, 1.6, 1.1, 1 },
                                                                        { 1.8, 0.7, 0.8, 1 },
                                                                        { 0.3, 1.0, 0.2, 1 }};

        double[,] Tizometrik = new double[4, 4]
        {
            {  0.707 ,   -0.408          ,   0 , 0},
            {  0     ,    0.816          ,   0 , 0},
            { -0.707 ,   -0.408          ,   0 , 0},
            {  0     ,    0              ,   0 , 0}
        };

        double[,] BenzierNoktalariBulutIzometrik = new double[25, 4];
        double[,] BenzierYuzeyNoktaBulutu = new double[25, 4];
        double[,] XCisimNoktaBenzierYuzeyKontrolIzometrik = new double[20, 4];
        private void kontrol_noktalari_bttn_Click(object sender, EventArgs e)
        {
            kontrol_noktalari_lstbx.Items.Add("#\t" + "x\t" + "y\t" + "z\t");
            for (int i = 0; i < 20; i++)
            {
                if (i % 4 == 0) kontrol_noktalari_lstbx.Items.Add("");
                kontrol_noktalari_lstbx.Items.Add(i + "\t" + XCisimNoktaBezierYuzeyKontrolN[i, 0] + "\t" + XCisimNoktaBezierYuzeyKontrolN[i, 1] + "\t" + XCisimNoktaBezierYuzeyKontrolN[i, 2]);
            }
        }

        private void izometrik_iz_dusum_buton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        XCisimNoktaBenzierYuzeyKontrolIzometrik[i, j] += XCisimNoktaBezierYuzeyKontrolN[i, k] * Tizometrik[k, j];
                    }
                    XCisimNoktaBenzierYuzeyKontrolIzometrik[i, j] = Math.Round(XCisimNoktaBenzierYuzeyKontrolIzometrik[i, j], 4);
                }
            }

            izometrik_izdusum_txtbx.Items.Add("#\t" + "x\t" + "y\t" + "z\t");
            for (int i = 0; i < 20; i++)
            {
                if (i % 4 == 0) izometrik_izdusum_txtbx.Items.Add("");
                izometrik_izdusum_txtbx.Items.Add(i + "\t" + XCisimNoktaBenzierYuzeyKontrolIzometrik[i, 0] + "\t" + XCisimNoktaBenzierYuzeyKontrolIzometrik[i, 1] + "\t" + XCisimNoktaBenzierYuzeyKontrolIzometrik[i, 2]);
            }
        }

        private void benzier_yuzey_dusum_bttn_Click(object sender, EventArgs e)
        {
            double hassasiyet = 0.25, u = 0, w;
            benzier_yuzey_deger_listbx.Items.Add("#\t" + "u\t" + "w\t" + "x\t" + "y\t" + "z\t");

            for (int i = 0; i < 5; i++)
            {
                w = 0;
                for (int j = 0; j < 5; j++)
                {
                    BenzierYuzeyNoktaBulutu[i * 5 + j, 0] = Math.Round(BezierHesapla(u, w, 0), 4);
                    BenzierYuzeyNoktaBulutu[i * 5 + j, 1] = Math.Round(BezierHesapla(u, w, 1), 4);
                    BenzierYuzeyNoktaBulutu[i * 5 + j, 2] = Math.Round(BezierHesapla(u, w, 2), 4);
                    if ((i * 6 + j) % 6 == 0) benzier_yuzey_deger_listbx.Items.Add("");

                    benzier_yuzey_deger_listbx.Items.Add((i * 5 + j) + "\t" + u + "\t" + w + "\t" + BenzierYuzeyNoktaBulutu[i * 5 + j, 0] + "\t" + BenzierYuzeyNoktaBulutu[i * 5 + j, 1] + "\t" + BenzierYuzeyNoktaBulutu[i * 5 + j, 2]);
                    w += hassasiyet;
                }
                u += hassasiyet;
            }
            //2
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        BenzierNoktalariBulutIzometrik[i, j] += BenzierYuzeyNoktaBulutu[i, k] * Tizometrik[k, j];
                    }
                    BenzierNoktalariBulutIzometrik[i, j] = Math.Round(BenzierNoktalariBulutIzometrik[i, j], 4);
                }
            }

            Izometrik_deger_hesapla_bezier_lstbx.Items.Add("#\t" + "x\t" + "y\t" + "z\t");
            //3

            for (int i = 0; i < 25; i++)
            {
                if (i % 5 == 0) Izometrik_deger_hesapla_bezier_lstbx.Items.Add("");
                Izometrik_deger_hesapla_bezier_lstbx.Items.Add(i + "\t" + BenzierNoktalariBulutIzometrik[i, 0] + "\t" + BenzierNoktalariBulutIzometrik[i, 1] + "\t" + BenzierNoktalariBulutIzometrik[i, 2]);
            }
        }

        private double BezierHesapla(double uu, double ww, int xyz)
        {
            double sonuc = 0, T = 0, K = 0;
            int n = 4, m = 3;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    T = (Faktor(n) / (Faktor(i) * Faktor(n - i))) * Math.Pow(uu, i) * Math.Pow((1 - uu), (n - i));
                    K = (Faktor(m) / (Faktor(j) * Faktor(m - j))) * Math.Pow(ww, j) * Math.Pow((1 - ww), (m - j));
                    sonuc += XCisimNoktaBezierYuzeyKontrolN[i * 3 + j, xyz] * T * K;
                }
            }
            return sonuc;
        }
        //5

        #region Fonk Metod
        private double Faktor(double sayi)
        {
            double sonuc = 1;
            for (int i = 1; i <= sayi; i++)
            { sonuc *= (double)i; }
            return sonuc;
        }
        #endregion

    }
}

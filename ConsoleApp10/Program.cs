using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        { //Pisti Game(Windows Forms App(.Net Freework))


            string ad;
            string soyad;
            int yas;
            int puan1 = 0;
            int puan2 = 0;
            int oyuncu1kartsayisi = 0;
            int oyuncu2kartsayisi = 0;
            int kartsayisi = 52;




            Console.WriteLine("  Pişti Oyununa Hoşgeldiniz   ");
            Console.WriteLine(""); 
            Console.Write("->Adınızı  giriniz:");
            ad=Console.ReadLine();

            Console.Write("->Soyadınızı  giriniz:");
            soyad = Console.ReadLine();

            Console.Write("->Yaşınızı giriniz:");
            yas=Convert.ToInt32(Console.ReadLine());
            
            oyuncu oync = new oyuncu(ad, soyad);
           ArrayList oyuncu1cektigikartlar = new ArrayList();
            ArrayList oyuncu2cektigikartlar = new ArrayList();


            List<string> kartlar = new List<string>();

            //oyunda 52 kart oldugu için kartları döngüyle listeye ekliyorum
            for (int i = 0; i < 4; i++)
            {
                kartlar.Add("As");
                kartlar.Add("Sinek 2");
                kartlar.Add("3'Lü");
                kartlar.Add("4'Lü");
                kartlar.Add("5'Li");
                kartlar.Add("6'Lı");
                kartlar.Add("7'Li");
                kartlar.Add("8'Li");
                kartlar.Add("9'Lu");
                kartlar.Add("Karo 10");
                kartlar.Add("Joker");
                kartlar.Add("Papaz");
                kartlar.Add("Kız");
            }

            Console.WriteLine("");
            Console.WriteLine("{0}'ın puanı:{1}", oync.oyuncuadi1, puan1);
            Console.WriteLine("{0}'ın puanı:{1}", oync.oyuncuadi2, puan2);

            Console.WriteLine("Oyun başlıyor.");
            Console.WriteLine("Kartlar karıştırılıyor..");
            for (int i = 0; i < yas; i++)
            {

                kartlar = kartlar.OrderBy(d => System.Guid.NewGuid()).ToList();//Listeyi karıştırma işlemi



            }
            Console.WriteLine("Kartlar karıştırıldı..");
            Console.WriteLine("Kartlar Dağıtılıyor..");
        
            for (int i = 0; i < 4; i++)
            {
                oync.setmasadakikart(kartlar[kartsayisi - 1]);

                kartsayisi--;

            }




            for (int i = 0; i < 4; i++)
            {
                oync.setoyuncu1kart(kartlar[kartsayisi - 1]);

                kartsayisi--;

            }

            for (int i = 0; i < 4; i++)
            {
                oync.setoyuncu2kart(kartlar[kartsayisi - 1]);

                kartsayisi--;

            }

            Console.WriteLine("Kartlar Dağıtıldı.");
            Console.WriteLine("");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Oyun başladı.");

            Console.WriteLine("");
            Console.WriteLine("-------------------------");

           

            oync.kartlarigoster();

            bool oyun = true;
            while (oyun) 
            
            {

                if (oync.elimdekiikartlarim1.Count > 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("->{0}  oynuyor ", oync.oyuncuadi1);

                    if (oync.masadakikartlar.Count == 0)
                    {

                        Console.WriteLine("{0} kart atıyor", oync.oyuncuadi1);

                        Random rdn = new Random();

                        int f = rdn.Next(0, oync.elimdekiikartlarim1.Count);
                        Console.WriteLine("{0}'ın attığı kart:{1}", oync.oyuncuadi1, oync.elimdekiikartlarim1[f]);
                        Console.WriteLine("");

                        oync.masadakikartlar.Add(oync.elimdekiikartlarim1[f]);
                        oync.elimdekiikartlarim1.Remove(oync.elimdekiikartlarim1[f]);


                    }

                    else
                    {
                        if (oync.masadakikartlar.Count == 1)
                        {
                            for (int a = 0; a < oync.elimdekiikartlarim1.Count; a++)
                            {
                                if (oync.elimdekiikartlarim1[a] == oync.masadakikartlar[0])
                                {
                                    Console.WriteLine("***{0} {1} atar ve pişti yapar.", oync.oyuncuadi1, oync.elimdekiikartlarim1[a]);


                                    oyuncu1kartsayisi += oync.masadakikartlar.Count + 1;
                                    puan1 += 10;

                                    oyuncu1cektigikartlar.Add(oync.elimdekiikartlarim1[a]);
                                    oync.elimdekiikartlarim1.Remove(oync.elimdekiikartlarim1[a]);
                                    oync.masadakikartlar.Clear();



                                    goto devam;
                                }
                            }

                        }
                        for (int a = 0; a < oync.elimdekiikartlarim1.Count; a++)
                        {
                            if (oync.elimdekiikartlarim1[a] == oync.masadakikartlar[oync.masadakikartlar.Count - 1])
                            {
                                Console.WriteLine("***{0} {1} atar masadaki tüm kartları alır.", oync.oyuncuadi1, oync.elimdekiikartlarim1[a]);


                                oyuncu1kartsayisi += oync.masadakikartlar.Count + 1;
                                for (int i = 0; i < oync.masadakikartlar.Count; i++)
                                {
                                    if (oync.masadakikartlar[i].ToString() == "As")
                                    {
                                        puan1 += 1 * 2;

                                    }
                                    else if (oync.masadakikartlar[i].ToString() == "Vale")
                                    {
                                        puan1 += 1 * 2;
                                    }
                                    else if (oync.masadakikartlar[i].ToString() == "Karo 10")
                                    {
                                        puan1 += 3 * 2;
                                    }
                                    else if (oync.masadakikartlar[i].ToString() == "Sinek 2")
                                    {
                                        puan1 += 2 * 2;
                                    }
                                }
                                oync.elimdekiikartlarim1.Remove(oync.elimdekiikartlarim1[a]);
                                for(int l=0; l < oync.masadakikartlar.Count; l++)
                                {
                                    oyuncu1cektigikartlar.Add(oync.masadakikartlar[l]);
                                }
                                oync.masadakikartlar.Clear();


                                goto devam;
                            }
                        }

                        Console.WriteLine("{0} kart atıyor", oync.oyuncuadi1);

                        Random rdn = new Random();

                        int f = rdn.Next(0, oync.elimdekiikartlarim1.Count);
                        Console.WriteLine("{0}'ın attığı kart:{1}", oync.oyuncuadi1, oync.elimdekiikartlarim1[f]);

                        oync.masadakikartlar.Add(oync.elimdekiikartlarim1[f]);
                        oync.elimdekiikartlarim1.Remove(oync.elimdekiikartlarim1[f]);

                    }

                }


            devam:
                if (oync.masadakikartlar.Count!=0)
                {
                    Console.WriteLine("");

                    Console.WriteLine("Masadaki açık kart:{0}", oync.masadakikartlar[oync.masadakikartlar.Count - 1]);
                    Console.WriteLine("");

                }
                else if (oync.masadakikartlar.Count==0)
                {
                    Console.WriteLine("");

                    Console.WriteLine("Masadaki kart yok");
                    Console.WriteLine("");

                }
                if (oync.elimdekikartlarim2.Count > 0)
                {
                    Console.WriteLine("-> {0}  oynuyor ", oync.oyuncuadi2);

                    if (oync.masadakikartlar.Count == 0)
                    {
                        Console.WriteLine("{0} kart atıyor", oync.oyuncuadi2);

                        Random rdm = new Random();

                        int k = rdm.Next(0, oync.elimdekikartlarim2.Count);
                        Console.WriteLine("{0}'ın attığı kart:{1}", oync.oyuncuadi2, oync.elimdekikartlarim2[k]);
                        Console.WriteLine("");


                        oync.masadakikartlar.Add(oync.elimdekikartlarim2[k]);
                        oync.elimdekikartlarim2.Remove(oync.elimdekikartlarim2[k]);
                    }
                    else
                    {
                        if (oync.masadakikartlar.Count == 1)
                        {
                            for (int a = 0; a < oync.elimdekikartlarim2.Count; a++)
                            {
                                if (oync.elimdekikartlarim2[a] == oync.masadakikartlar[0])
                                {
                                    Console.WriteLine("***{0} {1} atar ve pişti yapar.", oync.oyuncuadi1, oync.elimdekikartlarim2[a]);


                                    oyuncu1kartsayisi += oync.masadakikartlar.Count + 1;
                                    puan2 += 10;
                                    oyuncu2cektigikartlar.Add(oync.elimdekikartlarim2[a]);

                                    oync.elimdekikartlarim2.Remove(oync.elimdekikartlarim2[a]);

                                    oync.masadakikartlar.Clear();

                                    goto devam;
                                }
                            }

                        }
                        for (int a = 0; a < oync.elimdekikartlarim2.Count; a++)
                        {
                            if (oync.elimdekikartlarim2[a] == oync.masadakikartlar[oync.masadakikartlar.Count - 1])
                            {
                                Console.WriteLine("***{0} {1} atar masadaki tüm kartları alır.", oync.oyuncuadi2, oync.elimdekikartlarim2[a]);
                                Console.WriteLine("");



                                oyuncu2kartsayisi += oync.masadakikartlar.Count + 1;
                                for (int i = 0; i < oync.masadakikartlar.Count; i++)
                                {
                                    if (oync.masadakikartlar[i].ToString() == "As")
                                    {
                                        puan2 += 1 * 2;

                                    }
                                    else if (oync.masadakikartlar[i].ToString() == "Vale")
                                    {
                                        puan2 += 1 * 2;
                                    }
                                    else if (oync.masadakikartlar[i].ToString() == "Karo 10")
                                    {
                                        puan2 += 3 * 2;
                                    }
                                    else if (oync.masadakikartlar[i].ToString() == "Sinek 2")
                                    {
                                        puan2 += 2 * 2;
                                    }
                                }
                                oync.elimdekikartlarim2.Remove(oync.elimdekikartlarim2[a]);
                                for (int l = 0; l < oync.masadakikartlar.Count; l++)
                                {
                                    oyuncu2cektigikartlar.Add(oync.masadakikartlar[l]);
                                }
                                oync.masadakikartlar.Clear();


                                goto devam2;
                            }
                        }

                        Console.WriteLine("{0} kart atıyor", oync.oyuncuadi2);

                        Random rdm = new Random();

                        int k = rdm.Next(0, oync.elimdekikartlarim2.Count);
                        Console.WriteLine("{0}'ın attığı kart:{1}", oync.oyuncuadi2, oync.elimdekikartlarim2[k]);
                        Console.WriteLine("");

                        oync.masadakikartlar.Add(oync.elimdekikartlarim2[k]);
                        oync.elimdekikartlarim2.Remove(oync.elimdekikartlarim2[k]);

                    }
                }
              

            devam2:
                if (oync.elimdekiikartlarim1.Count == 0 && oync.elimdekikartlarim2.Count == 0 && kartsayisi > 0)
                {
                    Console.WriteLine("Oyuncuların elinde kart kalmadığı için kart dağıtlıyor..");
                    Console.WriteLine("");

                    for (int i = 0; i < 4; i++)
                    {
                        oync.setoyuncu1kart(kartlar[kartsayisi - 1]);
                        kartsayisi--;
                    }

                    for (int i = 0; i < 4; i++)
                    {
                        oync.setoyuncu2kart(kartlar[kartsayisi - 1]);
                        kartsayisi--;
                    }

                }

                if (oync.elimdekiikartlarim1.Count == 0 && oync.elimdekikartlarim2.Count==0 &&kartsayisi==0)
                {
                    oyun = false;
                }

                if (oyun == true)
                {
                    Console.WriteLine("");
                    Console.WriteLine("-------------------------");

                    oync.kartlarigoster();
                    Console.WriteLine("-------------------------");


                }
                if (oyun == false)
                {
                    Console.WriteLine("Oyuncuların elinde kart kalmadığı için oyun bitmiştir.Puanlamaya geçiliyor.");
                    Console.WriteLine("");
                }




            } 

            if (oyuncu1kartsayisi > oyuncu2kartsayisi)
            {
                puan1 += 3;
            }

            else if (oyuncu2kartsayisi > oyuncu1kartsayisi)
            {
                puan2 += 3;
            }
            Console.WriteLine("{0}'ın kazandığı kartlar;",oync.oyuncuadi1);
            foreach (var k in oyuncu1cektigikartlar)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine("{0}'ın kazandığı puan:{1}", oync.oyuncuadi1,puan1);

            Console.WriteLine("********");
            Console.WriteLine("{0}'ın kazandığı kartlar;", oync.oyuncuadi2);
            foreach (var k in oyuncu2cektigikartlar)
            {
                Console.WriteLine(k);
            }
            Console.WriteLine("{0}'ın kazandığı puan:{1}", oync.oyuncuadi2, puan2);

            Console.WriteLine("********");

            if (puan1 > puan2)
            {
                Console.WriteLine("Pişti oyununu {0} puanla {1} kazandı.Tebrikler:)",puan1, oync.oyuncuadi1);
                
                Console.ReadLine();

            }
            else if (puan2 > puan1)
            {
                Console.WriteLine("Pişti oyununu {0} puanla {1} kazandı.Tebrikler:)",puan2, oync.oyuncuadi2);
                Console.ReadLine();
            }


        }

    }
    public class oyuncu
    {

        public string oyuncuadi1;
        public string oyuncuadi2;
        public oyuncu(string ad, string soyad)
        {
            oyuncuadi1 = ad;
            oyuncuadi2 = soyad;
        }
        public ArrayList elimdekiikartlarim1 = new ArrayList();
        public void setoyuncu1kart(string kart1)
        {
            elimdekiikartlarim1.Add(kart1);

        }
        public ArrayList elimdekikartlarim2 = new ArrayList();
        public void setoyuncu2kart(string kart2)
        {
            elimdekikartlarim2.Add(kart2);

        }
        public ArrayList masadakikartlar = new ArrayList();

        public void setmasadakikart(string kart3)
        {
            masadakikartlar.Add(kart3);

        }
        public void kartlarigoster()
        {

            if (masadakikartlar.Count != 0)
            {
               

                Console.WriteLine("Masadaki açık kart:{0}", masadakikartlar[masadakikartlar.Count - 1]);

            }
          else  if (masadakikartlar.Count == 0)
            {
                Console.WriteLine("Masada kart yok");

            }
            Console.WriteLine("");

            Console.WriteLine("{0}'ın elindeki kartlar;", oyuncuadi1);
            foreach (var b in elimdekiikartlarim1)
            {

                Console.WriteLine(b);

            }

            Console.WriteLine("");
            Console.WriteLine("{0}'ın elindeki kartlar;", oyuncuadi2);
            foreach (var a in elimdekikartlarim2)
            {

                Console.WriteLine(a);

            }


        }


    }
}

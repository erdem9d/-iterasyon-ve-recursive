using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Kaç adet x değeri gireceksiniz?");
        int n = int.Parse(Console.ReadLine());   

        List<double> xValues = new List<double>();

        
        for (int i = 0; i < n; i++)
        {
            Console.Write($"x[{i + 1}] değerini girin: ");
            xValues.Add(double.Parse(Console.ReadLine()));
        }

        // İteratif yöntemi kullanarak sonuçları hesapla  
        double ortalamaIteratif = OrtalamaHesaplaIteratif(xValues);
        double varyansIteratif = VaryansHesaplaIteratif(xValues, ortalamaIteratif);
        double standartSapmaIteratif = Math.Sqrt(varyansIteratif);

        // Rekürsif yöntemi kullanarak sonuçları hesapla  
        double ortalamaRekursif = OrtalamaHesaplaRekursif(xValues, 0, 0);
        double varyansRekursif = VaryansHesaplaRekursif(xValues, ortalamaRekursif, 0);
        double standartSapmaRekursif = Math.Sqrt(varyansRekursif);

        Console.WriteLine($"\n*** İteratif Yöntem ***");
        Console.WriteLine($"Ortalama (xm): {ortalamaIteratif}");
        Console.WriteLine($"Varyans (V): {varyansIteratif}");
        Console.WriteLine($"Standart Sapma (σ): {standartSapmaIteratif}");

        Console.WriteLine($"\n*** Rekürsif Yöntem ***");
        Console.WriteLine($"Ortalama (xm): {ortalamaRekursif}");
        Console.WriteLine($"Varyans (V): {varyansRekursif}");
        Console.WriteLine($"Standart Sapma (σ): {standartSapmaRekursif}");

        Console.WriteLine("Devam etmek için bir tuşa basın...");
        Console.ReadLine();
    }

    // İteratif ortalama hesaplayan fonksiyon  
    static double OrtalamaHesaplaIteratif(List<double> values)
    {
        double toplam = 0;
        foreach (var value in values)
        {
            toplam += value; 
        }
        return toplam / values.Count; 
    }

    // İteratif varyans hesaplayan fonksiyon  
    static double VaryansHesaplaIteratif(List<double> values, double ortalama)
    {
        double toplam = 0;
        foreach (var value in values)
        {
            toplam += Math.Pow(value - ortalama, 2); 
        }
        return toplam / (values.Count - 1); 
    }

    // Rekürsif ortalama hesaplayan fonksiyon  
    static double OrtalamaHesaplaRekursif(List<double> values, int index, double toplam)
    {
        if (index == values.Count) // Tüm değerler işlendi mi?  
            return toplam / values.Count; // Ortalama döndür  

        return OrtalamaHesaplaRekursif(values, index + 1, toplam + values[index]);   
    }

    // Rekürsif varyans hesaplayan fonksiyon  
    static double VaryansHesaplaRekursif(List<double> values, double ortalama, int index)
    {
        if (index == values.Count) // Tüm değerler işlendi mi?  
            return 0; // Varyans hesaplamak için geri döner  

        double varyansToplam = Math.Pow(values[index] - ortalama, 2); // (x - xm)^2 hesapla  
        return varyansToplam + VaryansHesaplaRekursif(values, ortalama, index + 1); // Değerleri toplar ve bir sonraki değere geçer  
    }
}
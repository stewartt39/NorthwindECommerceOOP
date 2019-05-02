using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entities.Concrete
{
   public class Cart
    {
        //Bu aslında Product ve Miktar tutan bir Complex Type'tır.
        //Bu complex type'ı _lines nesnesine atayarak bir instance ını oluşturduk.
        List<Cartline> _lines = new List<Cartline>();
        //Sepete ekleme operasyonu
        //Sepete ürün ve miktar eklenecek
        //Sepete ne eklenecek? Ürün ve Miktar.ilk olarak bu operasyonu yazalım
        //Ürünler Product product ile miktar da int quantity ile belirttik
        public void AddToCart(Product product,int quantity)
        {
            //Parametre olarak gönderdiğim ProductId ile _lines nesnesindeki productId ye bak bana ilk kaydı getir.
            Cartline cartline = _lines.FirstOrDefault(x => x.Product.ProductID == product.ProductID);

            //Eğer kayıt yok ise _lines.Add ile Product kısmına gönderdiğim prooductı miktar kısmına da gönderdiğim quantity yi ekle.
            if (cartline==null)
            {
                _lines.Add(new Cartline { Product = product, Quantity = quantity });
            }
            else
            {
                //Eğer zaten bu product id _lines ta mevcut ise o zaman adeti bir arttır.
                cartline.Quantity += quantity;
            }


        }

        //Sepetten ürün çıkarma operasyonu
        //Direkt Product çıkartılır.
        //Product id den gönderdiğim parametredeki ürünü sil.
        public void RemoveFromCart(Product product)
        {
            _lines.RemoveAll(x => x.Product.ProductID == product.ProductID);
        }

        //Sepet toplamı 
        public decimal Total
        {
            
            get
            {
                return _lines.Sum(x => x.Product.UnitPrice * x.Quantity);
            }
        }

        public void Clear()
        {
            _lines.Clear();
        }


        public List<Cartline> Lines
        {
            get { return _lines; }
        }

    }

    //Cartline Ürün ve Miktar tutar
    public class Cartline
    {
        //Ürünleri döndürür
        public Product Product { get; set; }
        //Miktar gösterir
        public int Quantity { get; internal set; }
    }
}

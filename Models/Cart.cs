using ETicaretSitem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETicaretSitem.Models
{
    public class Cart  //sepetin tamamı
    {
        private List<Cartline> _cartLines = new List<Cartline>();
        public List<Cartline> Cartlines
        {
            get { return _cartLines; }
        }
        public void AddProduct(Product product, int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Product.Id == product.Id);
            if (line == null) //sepet boşsa
            {
                _cartLines.Add(new Cartline() { Product = product, Quantity = quantity });
            }
            else //sepette ürün varsa
            {
                line.Quantity += quantity;
            }
        }
        public void DeleteProduct(Product product) //sepetten ürün silme
        {
            _cartLines.RemoveAll(i=> i.Product.Id== product.Id);
        }
        public double Total() // tutar hesaplama
        {
            return _cartLines.Sum(i => i.Product.Price * i.Quantity);
        }
        public void Clear() // sepetteki tüm ürünleri silme
        {
            _cartLines.Clear();
        }
    }
    public class Cartline // sepetteki tek bir satır
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
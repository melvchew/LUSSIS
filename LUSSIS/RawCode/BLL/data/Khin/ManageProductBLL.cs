using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.BLL.data.Khin
{
    public class ManageProductBLL
    {
        public List<Item> getProductList()
        {
            LUSSdbEntities context = new LUSSdbEntities();
            return context.Items.ToList<Item>();
        }

        public List<Item> searchProductList(String value)
        {
            LUSSdbEntities context = new LUSSdbEntities();
            return context.Items.Where(x => x.Description.Contains(value) || x.Category.Contains(value)).ToList<Item>();
        }


        public List<String> getCategory()
        {
            LUSSdbEntities context = new LUSSdbEntities();
            return context.Items.Select(x => x.Category).Distinct().ToList<String>();
        }
        public List<Supplier> getSupplierList()
        {
            LUSSdbEntities context = new LUSSdbEntities();
            return context.Suppliers.ToList<Supplier>();
        }



        public Item getProductByIDs(int id)
        {
            LUSSdbEntities context = new LUSSdbEntities();
            return context.Items.Where(p => p.ItemId == id).FirstOrDefault();
        }

        public Boolean addProduct(Item item)
        {
            try
            {
                using (LUSSdbEntities context = new LUSSdbEntities())
                {
                    Item i = new Item();
                    i.Category = item.Category;
                    i.BinNumber = item.BinNumber;
                    i.Description = item.Description;
                    i.StockBalance = item.StockBalance;
                    i.ReorderLvl = item.ReorderLvl;
                    i.ReorderQty = item.ReorderQty;
                    i.Unit = item.Unit;
                    i.Supplier1Id = item.Supplier1Id;
                    i.Supplier1Price = item.Supplier1Price;
                    i.Supplier2Id = item.Supplier2Id;
                    i.Supplier2Price = item.Supplier2Price;
                    i.Supplier3Id = item.Supplier3Id;
                    i.Supplier3Price = item.Supplier3Price;
                    i.IsCataloged = item.IsCataloged;
                    context.Items.Add(i);
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public Boolean updateProduct(Item item)
        {
            try
            {
                LUSSdbEntities context = new LUSSdbEntities();
                Item i = context.Items.Where(p => p.ItemId == item.ItemId).FirstOrDefault();
                i.Category = item.Category;
                i.BinNumber = item.BinNumber;
                i.Description = item.Description;
                i.StockBalance = item.StockBalance;
                i.ReorderLvl = item.ReorderLvl;
                i.ReorderQty = item.ReorderQty;
                i.Unit = item.Unit;
                i.Supplier1Id = item.Supplier1Id;
                i.Supplier1Price = item.Supplier1Price;
                i.Supplier2Id = item.Supplier2Id;
                i.Supplier2Price = item.Supplier2Price;
                i.Supplier3Id = item.Supplier3Id;
                i.Supplier3Price = item.Supplier3Price;
                i.IsCataloged = item.IsCataloged;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
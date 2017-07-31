using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LUSSIS.RawCode.BLL.data.ZhangJinshan
{
    public class StockManagementBLL
    {
        //check supplierid
        public bool CheckSupplierID(string id)
        {
            bool check = false;
            IList l = FindAllSuppliers();
            for (int i = 0; i < l.Count; i++)
            {
                if (((Supplier)l[i]).SupplierId == id)
                {

                    check = true;
                    break;
                }

            }
            return check;
        }

        //insert a new supplier
        public void InsertNewSupplier(string id, string name, string contactPerson, string phoneNo, string faxNo, string address, string email, string gstNo)
        {
            Supplier supplier = new Supplier();
            supplier.SupplierId = id;
            supplier.CompanyName = name;
            supplier.ContactPerson = contactPerson;
            supplier.Phone = phoneNo;
            supplier.Fax = faxNo;
            supplier.Address = address;
            supplier.Email = email;
            supplier.GstNo = gstNo;
            try
            {
                using (LUSSdb entities = new LUSSdb())
                {
                    entities.Suppliers.Add(supplier);
                    entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw (e);
            }

        }

        //find all suppliers
        public List<Supplier> FindAllSuppliers()
        {
            List<Supplier> v = new List<Supplier>();
            try
            {
                using (LUSSdb entities = new LUSSdb())
                {
                    v = entities.Suppliers.ToList();
                }

            }
            catch (Exception e)
            {
                throw (e);
            }
            return v;

        }

        //delete supplier
        public void DeleteSupplier(string id)
        {
            try
            {
                using (LUSSdb entities = new LUSSdb())
                {
                    Supplier supplier = entities.Suppliers.Where(s => s.SupplierId == id).First<Supplier>();
                    entities.Suppliers.Remove(supplier);
                    entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        //upsate supplier
        public void UpdateSupplier(string id, string name, string contactPerson, string phoneNo, string faxNo, string address, string email, string gstNo)
        {
            try
            {
                using (LUSSdb entities = new LUSSdb())
                {

                    Supplier supplier = entities.Suppliers.Where(s => s.SupplierId == id).First<Supplier>();
                    supplier.CompanyName = name;
                    supplier.ContactPerson = contactPerson;
                    supplier.Phone = phoneNo;
                    supplier.Fax = faxNo;
                    supplier.Address = address;
                    supplier.Email = email;
                    supplier.GstNo = gstNo;
                    entities.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        //fuzzy query supplier by name
        public List<Supplier> SearchSupplier(string name)
        {
            List<Supplier> v = new List<ADmodel.Supplier>();
            if (name != null)
            {
                try
                {
                    using (LUSSdb entities = new LUSSdb())
                    {
                        v = entities.Suppliers.Where(s => s.CompanyName.Contains(name)).ToList();
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

            }
            return v;
        }

        // find a supplier by id
        public Supplier FindSupplierById(string id)
        {
            Supplier supplier = new ADmodel.Supplier();

            try
            {
                using (LUSSdb entities = new LUSSdb())
                {
                    supplier = entities.Suppliers.FirstOrDefault(s => s.SupplierId == id);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return supplier;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MarketPlace_Repository;
using MarketPlace_DAL;
using System.Data.Entity.Core.Metadata.Edm;
using MarketPlace_Services.ViewModelServices;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

namespace MarketPlace_Services
{
    public class Service 
    {

        public static readonly MarketPlaceEntities context = new MarketPlaceEntities();

        UnitOfWork uow = new UnitOfWork(context);


        public ProductProductDetailVM PVM = new ProductProductDetailVM();


        public Service()
        {

        }
   

        public bool LoginCustomer(string email, string password)
        {
            List<tblUser> user = new List<tblUser>();
            var result = uow.user.GetAll();
            int count = 0;
            foreach (var item in result)
            {
                if (item.email==email && item.password == password)
                {
                    count++;
                }
            }

            return ((count == 1) ? true : false);
        }

        public void saveCustomer(tblUser user)
        {
            uow.user.Insert(user);
            uow.SaveChanges();
        }


        public List<tblProduct> GetAllProductsByName(string searchitem)
        {
            List<tblProduct> products = new List<tblProduct>();
       

            var result = from N in uow.products.GetAll()
                          where N.ProductName.ToLower().Contains(searchitem.ToLower())
                          select new
                          {
                              ProductName = N.ProductName,
                              ProductPicture = N.Picture,
                              ProductID = N.ProductID

                          };


            foreach (var item in result)
            {
                tblProduct prod = new tblProduct();
                prod.ProductName = item.ProductName;
                prod.ProductID = item.ProductID;
                prod.Picture = item.ProductPicture;
                products.Add(prod);
            }
            return products;
        }

        public ArrayList GetProductsJson(string searchitem)
        {
            var result = from N in uow.products.GetAll()
                         join X in uow.productdetails.GetAll()
                         on N.ProductID equals X.ProductID
                         where N.ProductName.ToLower().Contains(searchitem.ToLower())
                         select new
                         {
                             ProductName = N.ProductName,
                             ProductID = N.ProductID,
                             ProductAirflow = X.Airflow,
                             ProductMounting = X.Mounting_Location,
                             ProductFan_Speed_Min = X.Fan_Speed_Min,
                             ProductPower_Min = X.Power_Min,
                             ProductColor = X.Color,
                             ProductHeight = X.Height,
                             ProductWeight = X.Weight,
                             ProductSeries = X.Series,
                             ProductModel_Year = X.Model_Year,
                             ProductApplication = X.Application,
                             ProductOperating_Voltage_Min = X.Operating_Voltage_Min,
                             ProductAccessories = X.Accessories,
                             ProductFan_Sweep_Diameter = X.Fan_Sweep_Diameter,
                             ProductSound_Max_Speed = X.Sound_Max_Speed,
                             ProductPicture = X.Picture,
                             ProductModelName = X.ModelName,
                             ProductPower_Max = X.Power_Max,
                             ProductOperating_Voltage_Max = X.Operating_Voltage_Max,
                             ProductFan_Speed_Max = X.Fan_Speed_Max,
                             ProductCategoryID = N.CategoryID

                         };

            ArrayList Products = new ArrayList();

            foreach (var item in result)
            {
                ProductProductDetailVM PVM = new ProductProductDetailVM();
              

                PVM.ProductID = item.ProductID;
                PVM.Picture = item.ProductPicture;
                PVM.ProductName = item.ProductName;
                PVM.Airflow = item.ProductAirflow;
                PVM.ModelName = item.ProductModelName;
                PVM.Fan_Speed_Min = item.ProductFan_Speed_Min;
                PVM.Power_Min = item.ProductPower_Min;
                PVM.Color = item.ProductColor;
                PVM.Height = item.ProductHeight;
                PVM.Weight = item.ProductWeight;
                PVM.Series = item.ProductSeries;
                PVM.Model_Year = item.ProductModel_Year;
                PVM.Application = item.ProductApplication;
                PVM.Operating_Voltage_Min = item.ProductOperating_Voltage_Min;
                PVM.Accessories = item.ProductAccessories;
                PVM.Fan_Sweep_Diameter = item.ProductFan_Sweep_Diameter;
                PVM.Sound_Max_Speed = item.ProductFan_Speed_Max;
                PVM.Picture = item.ProductPicture;
                PVM.Power_Max = item.ProductPower_Max;
                PVM.Operating_Voltage_Max = item.ProductOperating_Voltage_Max;
                PVM.Fan_Speed_Max = item.ProductFan_Speed_Max;
                PVM.CategoryID = item.ProductCategoryID;
                PVM.Mounting_Location = item.ProductMounting;


                Products.Add(PVM);
            }
            return Products;
        }

        //Back up method
        public List<tblProduct> GetProductsJsonBU(string searchitem)
        {
            List<tblProduct> products = new List<tblProduct>();

            var result = from N in uow.products.GetAll()
                         join X in uow.productdetails.GetAll()
                         on N.ProductID equals X.ProductID
                         where N.ProductName.ToLower().Contains(searchitem.ToLower())
                         select new
                         {
                             ProductName = N.ProductName,
                             ProductID = N.ProductID,
                             ProductPicture = N.Picture

                         };

        

            foreach (var item in result)
            {
                
                tblProduct prod = new tblProduct();
                prod.ProductName = item.ProductName;
                prod.ProductID = item.ProductID;
                prod.Picture = item.ProductPicture;


                products.Add(prod);
            }
            return products;
        }


        //test
        public ArrayList GetProductProductDetailJson(int id)
        {
            var result = from N in uow.products.GetAll()
                         join X in uow.productdetails.GetAll()
                         on N.ProductID equals X.ProductID
                         where (N.ProductID ==  id)
                         select new
                         {
                            ProductName = N.ProductName,
                            ProductID = N.ProductID,
                            ProductAirflow = X.Airflow,
                             ProductMounting = X.Mounting_Location,
                             ProductFan_Speed_Min = X.Fan_Speed_Min,
                            ProductPower_Min = X.Power_Min,
                            ProductModelName = X.ModelName,
                             ProductColor = X.Color,
                            ProductHeight = X.Height,
                            ProductWeight = X.Weight,
                            ProductSeries = X.Series,
                            ProductModel_Year = X.Model_Year,
                            ProductApplication = X.Application,
                            ProductOperating_Voltage_Min = X.Operating_Voltage_Min,
                            ProductAccessories = X.Accessories,
                            ProductFan_Sweep_Diameter = X. Fan_Sweep_Diameter,
                            ProductSound_Max_Speed = X.Sound_Max_Speed,
                            ProductPicture = X.Picture,
                            ProductPower_Max = X.Power_Max,
                            ProductOperating_Voltage_Max = X.Operating_Voltage_Max,
                            ProductFan_Speed_Max = X.Fan_Speed_Max,
                            ProductCategoryID = N.CategoryID

                         };

            ArrayList ProductProperty = new ArrayList();
             
            foreach (var item in result)
            {
                PVM.ProductName = item.ProductName;
                PVM.Airflow = item.ProductAirflow;
                PVM.Fan_Speed_Min = item.ProductFan_Speed_Min;
                PVM.Power_Min = item.ProductPower_Min;
                PVM.Color = item.ProductColor;
                PVM.Height = item.ProductHeight;
                PVM.Weight = item.ProductWeight;
                PVM.Series = item.ProductSeries;
                PVM.Model_Year = item.ProductModel_Year;
                PVM.Application = item.ProductApplication;
                PVM.Operating_Voltage_Min = item.ProductOperating_Voltage_Min;
                PVM.Accessories = item.ProductAccessories;
                PVM.Fan_Sweep_Diameter = item.ProductFan_Sweep_Diameter;
                PVM.Sound_Max_Speed = item.ProductFan_Speed_Max;
                PVM.Picture = item.ProductPicture;
                PVM.Power_Max = item.ProductPower_Max;
                PVM.Operating_Voltage_Max = item.ProductOperating_Voltage_Max;
                PVM.Fan_Speed_Max = item.ProductFan_Speed_Max;
                PVM.CategoryID = item.ProductCategoryID;
                PVM.Mounting_Location = item.ProductMounting;
                PVM.ModelName = item.ProductModelName;

                ProductProperty.Add(PVM);
            }

            return ProductProperty;
        }



        public ArrayList GetAllProductProductDetailJson(int[] arr)
        {
           var result = from N in uow.products.GetAll()
                     join X in uow.productdetails.GetAll()
                     on N.ProductID equals X.ProductID
                     where arr.Contains(N.ProductID)
                            
                     select new
                            {
                             ProductName = N.ProductName,
                             ProductID = N.ProductID,
                             ProductAirflow = X.Airflow,
                             ProductMounting = X.Mounting_Location,
                             ProductFan_Speed_Min = X.Fan_Speed_Min,
                             ProductPower_Min = X.Power_Min,
                             ProductColor = X.Color,
                             ProductHeight = X.Height,
                             ProductWeight = X.Weight,
                             ProductSeries = X.Series,
                             ProductModel_Year = X.Model_Year,
                            ProductModelName = X.ModelName,
                            ProductApplication = X.Application,
                             ProductOperating_Voltage_Min = X.Operating_Voltage_Min,
                             ProductAccessories = X.Accessories,
                             ProductFan_Sweep_Diameter = X.Fan_Sweep_Diameter,
                             ProductSound_Max_Speed = X.Sound_Max_Speed,
                             ProductPicture = X.Picture,
                             ProductPower_Max = X.Power_Max,
                             ProductOperating_Voltage_Max = X.Operating_Voltage_Max,
                             ProductFan_Speed_Max = X.Fan_Speed_Max,
                             ProductCategoryID = N.CategoryID

                         };

            
            var ProductProperty = new ArrayList(); // recommended 

            foreach (var item in result)
            {
              ProductProductDetailVM PVM = new ProductProductDetailVM();

                PVM.ProductName = item.ProductName;
                PVM.Airflow = item.ProductAirflow;
                PVM.Fan_Speed_Min = item.ProductFan_Speed_Min;
                PVM.Power_Min = item.ProductPower_Min;
                PVM.Color = item.ProductColor;
                PVM.Height = item.ProductHeight;
                PVM.Weight = item.ProductWeight;
                PVM.Series = item.ProductSeries;
                PVM.Model_Year = item.ProductModel_Year;
                PVM.Application = item.ProductApplication;
                PVM.ModelName = item.ProductModelName;
                PVM.Operating_Voltage_Min = item.ProductOperating_Voltage_Min;
                PVM.Accessories = item.ProductAccessories;
                PVM.Fan_Sweep_Diameter = item.ProductFan_Sweep_Diameter;
                PVM.Sound_Max_Speed = item.ProductFan_Speed_Max;
                PVM.Picture = item.ProductPicture;
                PVM.Power_Max = item.ProductPower_Max;
                PVM.Operating_Voltage_Max = item.ProductOperating_Voltage_Max;
                PVM.Fan_Speed_Max = item.ProductFan_Speed_Max;
                PVM.CategoryID = item.ProductCategoryID;
                PVM.Mounting_Location = item.ProductMounting;

                ProductProperty.Add(PVM);
            }

            return ProductProperty;
        }


    }
}

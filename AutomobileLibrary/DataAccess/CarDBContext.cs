﻿using AutomobileLibrary.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        //Initialise the list of cars
        private static List<Car> CarList = new List<Car>()
        {
            new Car{ CarID=1, CarName="CRV", Manufacturer="Honda", Price=30000, ReleaseYear=2021},
            new Car{ CarID=2, CarName="Ford Focus", Manufacturer="Ford", Price=15000, ReleaseYear=2020}
        };
        //Using Singleton pattern
        private static  CarDBContext instance = null;
        private static readonly object instanceLock = new object();
        private CarDBContext()
        {
        }
        public static CarDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }
        public List<Car> GetCarList => CarList;

        public Car GetCarByID(int carID)
        {
            //usibg linq to Object
            Car car = CarList.SingleOrDefault(pro => pro.CarID == carID);
            return car;

        }

        //Add a new car
        public void AddCar(Car car)
        {
            Car pro = GetCarByID(car.CarID);
            if(pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car already exists");
            }
        }
        //Update a car
        public void UpdateCar(Car car)
        {
            Car c = GetCarByID(car.CarID);
            if (c != null)
            {
               var index = CarList.IndexOf(c);
                CarList[index] = car;
            }
            else {
                throw new Exception("Car does not exist");
                 }
        }
        //remove a car
        public void RemoveCar(int carID)
        {
            Car p = GetCarByID(carID);
            if (p != null)
            {
                CarList.Remove(p);
            }
            else
            {
                throw new Exception("Car does not exist");
            }
        }

    }
}

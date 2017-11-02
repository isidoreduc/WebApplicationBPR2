using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationBPR2.ViewModels.SampleData
{
    public partial class SampleData
    {
        public static List<ListProduct> ListProducts = new List<ListProduct> {
            new ListProduct() {
                ID = 1,
                Name = "Kiwi",
                Price = 330,
                CurrentInventory = 225,
                Backorder = 0,
                Manufacturing = 10,
                Category = "All Time Classic",
                ImageSrc = "~/images/kiwi.jpg"
            },
            new ListProduct() {
                ID = 2,
                Name = "Mango",
                Price = 2400,
                CurrentInventory = 0,
                Backorder = 0,
                Manufacturing = 0,
                Category = "All Time Classic",
                ImageSrc = "~/images/mango.jpg"
            },
            new ListProduct() {
                ID = 3,
                Name = "Cantaloupe",
                Price = 1600,
                CurrentInventory = 77,
                Backorder = 0,
                Manufacturing = 55,
                Category = "All Time Classic",
                ImageSrc = "~/images/cantaloupe.jpg"
            },
            new ListProduct() {
                ID = 4,
                Name = "Blackberry",
                Price = 1450,
                CurrentInventory = 445,
                Backorder = 0,
                Manufacturing = 0,
                Category = "Berry Special",
                ImageSrc = "~/images/blackberry.jpg"
            },
            new ListProduct() {
                ID = 5,
                Name = "Strawberry",
                Price = 1350,
                CurrentInventory = 345,
                Backorder = 0,
                Manufacturing = 5,
                Category = "Berry Special",
                ImageSrc = "~/images/strawberry.jpg"
            },
            new ListProduct() {
                ID = 6,
                Name = "Blueberry",
                Price = 1200,
                CurrentInventory = 210,
                Backorder = 0,
                Manufacturing = 20,
                Category = "Berry Special",
                ImageSrc = "~/images/blueberry.jpg"
            },
            new ListProduct() {
                ID = 7,
                Name = "Grapes",
                Price = 3500,
                CurrentInventory = 0,
                Backorder = 0,
                Manufacturing = 0,
                Category = "Fruit Blast",
                ImageSrc = "~/images/grapes.jpg"
            },
            new ListProduct() {
                ID = 8,
                Name = "Green Apple",
                Price = 4000,
                CurrentInventory = 95,
                Backorder = 0,
                Manufacturing = 5,
                Category = "Fruit Blast",
                ImageSrc = "~/images/green-apple.jpg"
            },
            new ListProduct() {
                ID = 9,
                Name = "Pineapple",
                Price = 4500,
                CurrentInventory = 55,
                Backorder = 0,
                Manufacturing = 5,
                Category = "Fruit Blast",
                ImageSrc = "~/images/pineapple.jpg"
            }
        };
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamMegaDeskWeb.Models
{
    public class QuoteMath
    {
        // vars
        public string CustomerName;
        public DateTime QuoteDate = new DateTime();
        public DeskQuote TheDesk = new DeskQuote();
        public int RushDays;
        public int QuoteAmount;
        public int SurfaceArea = 0;

        private const int PRICE_BASE = 200;
        private const int SIZE_MAX = 1000;
        private const int PRICE_PER_DRAWER = 50;
        int[,] rushCost1 = new int[3, 3];

        // ....


        // constructor
        public int DeskQuote1(string name, int width, int depth, int drawers, string material, int rushDays)
        {
            QuoteDate = DateTime.Now;
            CustomerName = name;
            TheDesk.Width = width;
            TheDesk.Depth = depth;
            TheDesk.Drawers = drawers;
            TheDesk.Material = material;
            RushDays = rushDays;
            SurfaceArea = TheDesk.Width * TheDesk.Depth;
            QuoteAmount = CalculateQuote();
            return QuoteAmount;
           

        }

        public int CalculateQuote()
        {
            return PRICE_BASE + AddOns();
        }

        private int AddOns()
        {
            int AddOnCost = 0;
            int OverCost = 0;
            int DrawerCost = 0;
            rushOrder();

            // drawer cost
            DrawerCost = TheDesk.Drawers * PRICE_PER_DRAWER;
            AddOnCost += DrawerCost;

            // surface area cost
            if (SurfaceArea > 1000)
            {
                OverCost = SurfaceArea - 1000;
                AddOnCost += OverCost;
            }

            // set material price
            switch (TheDesk.Material)
            {
                case "Oak":
                    AddOnCost += 200;
                    break;
                case "Laminate":
                    AddOnCost += 100;
                    break;
                case "Pine":
                    AddOnCost += 50;
                    break;
                case "Rosewood":
                    AddOnCost += 300;
                    break;
                default:
                    AddOnCost += 125;
                    break;
            }

            // set rush order price
            switch (RushDays)
            {
                case 3:
                    if (SurfaceArea < 1000)
                        AddOnCost += rushCost1[0, 0];
                    else if (SurfaceArea >= 1000 && SurfaceArea < 2000)
                        AddOnCost += rushCost1[0, 1];
                    else if (SurfaceArea >= 2000)
                        AddOnCost += rushCost1[0, 2];
                    break;
                case 5:
                    if (SurfaceArea < 1000)
                        AddOnCost += rushCost1[1, 0];
                    else if (SurfaceArea >= 1000 && SurfaceArea < 2000)
                        AddOnCost += rushCost1[1, 1];
                    else if (SurfaceArea >= 2000)
                        AddOnCost += rushCost1[1, 2];
                    break;
                case 7:
                    if (SurfaceArea < 1000)
                        AddOnCost += rushCost1[2, 0];
                    else if (SurfaceArea >= 1000 && SurfaceArea < 2000)
                        AddOnCost += rushCost1[2, 1];
                    else if (SurfaceArea >= 2000)
                        AddOnCost += rushCost1[2, 2];
                    break;
                default:
                    AddOnCost += 0;
                    break;
            }
            return AddOnCost;
        }      
        public void rushOrder()
        {
            rushCost1[0, 0] = 60;
            rushCost1[0, 1] = 70;
            rushCost1[0, 2] = 80;
            rushCost1[1, 0] = 40;
            rushCost1[1, 1] = 50;
            rushCost1[1, 2] = 60;
            rushCost1[2, 0] = 30;
            rushCost1[2, 1] = 35;
            rushCost1[2, 2] = 40;
            try
            {
                //string[] ar1 = new string[9];
                //int z = 0;         
                //for (int x = 0; x < 3; x++)
                //{
                //    for (int y = 0; y < 3; y++)
                //    {
                //        rushCost1[x, y] = Convert.ToInt32(ar1[z]);
                //        z++;
                //    }
                //}
                rushCost1[0, 0] = 60;
                rushCost1[0, 1] = 70;
                rushCost1[0, 2] = 80;
                rushCost1[1, 0] = 40;
                rushCost1[1, 1] = 50;
                rushCost1[1, 2] = 60;
                rushCost1[2, 0] = 30;
                rushCost1[2, 1] = 35;
                rushCost1[2, 2] = 40;
            }
            catch (Exception)
            {
               //MessageBox.Show(e.ToString());
            }
        }
    }
}
 
using ButtonClicks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ButtonClicks.Controllers
{
    public class ButtonController : Controller
    {
        static List<ButtonModel> buttons = new List<ButtonModel>();
        Random random = new Random();

        public ButtonController()
        {
            if (buttons.Count == 0)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (random.Next(10) > 5)
                    {
                        buttons.Add(new ButtonModel(true, false));
                    }
                    else
                    {
                        buttons.Add(new ButtonModel(false, false));
                    }
                    buttons[0].Flagged = true;
                }
            }
            
        }

        public ActionResult Index()
        {
           
            
            return View("Index", buttons);
        }

        public ActionResult OnButtonClick(string mine)
        {

            int buttonNumber = Int32.Parse(mine);
            if (!buttons[buttonNumber].Flagged)
            {
                buttons[buttonNumber].State = !buttons[buttonNumber].State;
            }
            

            return View("Index", buttons);
        }

        public ActionResult OnRightButtonClick (string mine)
        {
            int buttonNumber = Int32.Parse(mine);
            buttons[buttonNumber].Flagged = !buttons[buttonNumber].Flagged;

            return View("Index", buttons);
        }
    }
}
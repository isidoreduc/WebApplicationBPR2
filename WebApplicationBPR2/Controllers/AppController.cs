using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBPR2.ViewModels;

namespace WebApplicationBPR2.Controllers
{
    public class AppController : Controller // a cuontroller allows us to map a request that comes in to a specific action
    {
         
        public IActionResult Index() //an action
        {
            return View(); //displays by default a view called Index from path Views/(folder with the name of our controller("App"))
        }

        [HttpGet("contact")]    // delievers a request; // routing attribute so that we can make contact page more discoverable. Now we can ask specifically for website.com/contact not for the whole path website.com/app/contact 
        public IActionResult Contact() //an action
        {
            ViewBag.Title = "Contact Us"; // we can add the name displayed on the tab of browser from the controller instead of setting it in the view
            return View(); //displays by default a view called Index from path Views/(folder with the name of our controller("App"))
        }

        [HttpPost("contact")]   // for receiving user info    
        public IActionResult Contact(ContactViewModel contactViewModel) // MVC will map the names of the inputs/area fields in the contact form to the properties in ContactViewModel;
            // When model binding happens, it also affects a ModelState property, so for validation we can check if ModelState is valid when the data comes in 
        {
            if(ModelState.IsValid)
            {
                // send email
            }
            else
            {
                // show errors
            }
            return View(); //displays by default a view called Index from path Views/(folder with the name of our controller("App"))
        }

        [HttpGet("about")]
        public IActionResult About() //an action
        {
            ViewBag.Title = "About Us";
            return View(); //displays by default a view called Index from path Views/(folder with the name of our controller("App"))
        }

        [HttpGet("products")]
        public IActionResult Product() //an action
        {
            ViewBag.Title = "Our Products";
            return View();
        }

        [HttpGet("blog")]
        public IActionResult Blog() //an action
        {
            ViewBag.Title = "Blog";
            return View();
        }

        [HttpGet("shop")]
        public IActionResult Order() //an action
        {
            ViewBag.Title = "Shop";
            return View();
        }

        
        public IActionResult SinglePost() //an action
        {
            ViewBag.Title = "Blog Articles";
            return View();
        }
    }
}

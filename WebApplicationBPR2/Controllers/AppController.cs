using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationBPR2.Data;
using WebApplicationBPR2.Services;
using WebApplicationBPR2.ViewModels;

namespace WebApplicationBPR2.Controllers
{
    // a cuontroller allows us to map a request that comes in to a specific action
    public class AppController : Controller 
    {
        private readonly IMailService _mailService;
        private readonly DataContext _dataContext;

        public AppController(IMailService mailService, DataContext dataContext)
        {
            _mailService = mailService;
            _dataContext = dataContext;
        }
        //displays by default a view called Index from path Views/(folder with the name of our controller("App"))
        public IActionResult Index() 
        {
            return View(); 
        }

        // delievers a request; // routing attribute so that we can make contact page more discoverable. Now we can ask specifically for website.com/contact not for the whole path website.com/app/contact
        // we can add the name displayed on the tab of browser from the controller instead of setting it in the view
        //displays by default a view called Index from path Views/(folder with the name of our controller("App"))
        [HttpGet("contact")]    
        public IActionResult Contact() 
        {
            ViewBag.Title = "Contact Us"; 
            return View(); 
        }

        // for receiving user info
        // MVC will map the names of the inputs/area fields in the contact form to the properties in ContactViewModel;
        // When model binding happens, it also affects a ModelState property, so for validation we can check if ModelState is valid when the data comes in 
        //displays by default a view called Index from path Views/(folder with the name of our controller("App"))
        [HttpPost("contact")]       
        public IActionResult Contact(ContactViewModel contactViewModel) 
            
        {
            if(ModelState.IsValid)
            {
                // send email either to the customer service departm or a copy to the client as confirmation, or both
                _mailService.SendMail("info@freeze.com", contactViewModel.Subject, $"From: {contactViewModel.Name} - {contactViewModel.Email}; Message: {contactViewModel.Message}");
                ViewBag.UserMessage = "Mail sent successfully";
                ModelState.Clear();
            }
            else
            {
                // show errors
            }
            return View(); 
        }

        //displays by default a view called Index from path Views/(folder with the name of our controller("App"))
        [HttpGet("about")]
        public IActionResult About() //an action
        {
            ViewBag.Title = "About Us";
            return View(); 
        }

        [HttpGet("products")]
        public IActionResult Product() //an action
        {
            ViewBag.Title = "Our Products";

            //get the products though the _dataContext object we injected in the constructor
            var products = _dataContext.Products.
                            OrderBy(p => p.Category).
                            ToList();
            return View(products); // passing data to the view
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
            //get the products though the _dataContext object we injected in the constructor
            var products = _dataContext.Products.
                            OrderBy(p => p.Category).
                            ToList();
            return View(products); // passing data to the view
        }

        
        public IActionResult SinglePost() //an action
        {
            ViewBag.Title = "Blog Articles";
            return View();
        }
    }
}

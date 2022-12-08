﻿using Confectionery.Mapers;
using Confectionery.Models;
using LibraryDatabaseCoffe.Models.DB.Request.Repositories;
using LibraryDatabaseCoffe.Models.DB.Tables;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Confectionery.ViewModels;

namespace Confectionery.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public UserController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationViewModel registrationViewModel)
        {
            UserRepository userRepository = HttpContext.RequestServices.GetService<UserRepository>() ?? throw new Exception("UserRepository is null");
            Mapsters mapster = HttpContext.RequestServices.GetService<Mapsters>() ?? throw new Exception("Mapsters is null");
            User user = mapster.MapTo(registrationViewModel);
            
            if (ModelState.IsValid)
            {
                if (await userRepository.SearchUserByEmail(user.EmailUser))
                {
                    ModelState.AddModelError("Email", "Аккаунт с такой электронной почтой уже существует");
                    return View(registrationViewModel);
                }
                if (await userRepository.SearchUserByName(user.NameUser))
                {
                    ModelState.AddModelError("Name", "Аккаунт с таким именем уже существует");
                    return View(registrationViewModel);
                }                

                await userRepository.AddAsync(user);
                ModelState.Clear();


                await AddClaims(await userRepository.GetUserByEmailAndPassword(user.EmailUser,user.Password));
                
                return RedirectToAction("Main", "Home");
            }
            else
            {
                return View(registrationViewModel);
            }
        }
        [HttpGet]
        public IActionResult Account() 
        {
            return View();
        }
        private async Task AddClaims(User user)
        {
            List<Claim> claims = CreateClaims(user);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            static List<Claim> CreateClaims(User user)
            {
                return new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier,(user.UserId ?? -1).ToString()),
                    new Claim(ClaimsIdentity.DefaultNameClaimType,user.NameUser),
                    new Claim(ClaimTypes.Email,user.EmailUser),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Status.ToString()),
                };
            }
        }
        [HttpGet]
        public IActionResult Autorisation()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Bascet()
        {
            if (User.Identity is not null && User.Identity.IsAuthenticated)
            {
                DescriptionOrderRepository descriptionOrderRepository = HttpContext.RequestServices.GetService<DescriptionOrderRepository>() ?? throw new Exception("UserRepository is null");
                Mapsters mapster = HttpContext.RequestServices.GetService<Mapsters>() ?? throw new Exception("Mapsters is null");

                var descriptionOrders= await descriptionOrderRepository.GetBascket(Convert.ToInt32((User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier) ?? new Claim(ClaimTypes.Upn, "-1")).Value));
                IEnumerable<BascetViewModel> bascetView = mapster.Map(descriptionOrders);

                return View(bascetView.ToList());
            }
            else 
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Autorisation(AutorisationViewModel autorisationView)
        {
            UserRepository userRepository = HttpContext.RequestServices.GetService<UserRepository>() ?? throw new Exception("UserRepository is null");

            if (ModelState.IsValid)
            {
                var user = await userRepository.GetUserByEmailAndPassword(autorisationView.Email, autorisationView.Password);
                if (user is not null)
                {
                    ModelState.Clear();
                    await AddClaims(user);
                    return RedirectToAction("Main", "Home");
                }
                else
                {
                    ModelState.AddModelError("Email", "неправильное имя или пароль");
                    ModelState.AddModelError("Password", "неправильное имя или пароль");
                    return View(autorisationView);
                }
            }
            else
            {
                ModelState.AddModelError("Email", "неправильное имя или пароль");
                ModelState.AddModelError("Password", "неправильное имя или пароль");
                return View(autorisationView);
            }
        }
        [ValidateAntiForgeryToken]
        public IActionResult LogOut() 
        {
            return View();
        }
    }
}
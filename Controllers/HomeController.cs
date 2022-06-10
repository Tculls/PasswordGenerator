using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PasswordGenerator.Models;
using Microsoft.AspNetCore.Http;



namespace PasswordGenerator.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public IActionResult Index()
    {
        int PasscodeCount =(int)HttpContext.Session.GetInt32("PasscodeCount");
        string Pontoonboat = HttpContext.Session.GetString("Passcode");
        if(PasscodeCount == null) 
        {
            HttpContext.Session.SetInt32("PasscodeCount", 1);
        } 
        
        if(Pontoonboat == null) 
        {
            HttpContext.Session.SetString("Passcode", "");
        } 
        return View();
    }
    [HttpPost("/generate")]
    public IActionResult Generate()
    {
        Random Rand = new Random();
        string PasscodeChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890!@#$%^&*=+";
        string RandomPassword = "";
        int CountHolder = (int)HttpContext.Session.GetInt32("PasscodeCount");
        CountHolder++;
        int i=0;
        while(i<14)
        {
            RandomPassword += PasscodeChars[Rand.Next(PasscodeChars.Length)];
            i++;
        }
        HttpContext.Session.SetString("Passcode", RandomPassword);  
        HttpContext.Session.SetInt32("PasscodeCount",CountHolder);
        return RedirectToAction("Index");
    }
    public IActionResult Privacy()
    {
        return View();
    }
}

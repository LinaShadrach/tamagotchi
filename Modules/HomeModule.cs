using Nancy;
using System.Collections.Generic;
using System;
using Game.Objects;

namespace TamagotchiGame
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["create.cshtml"];
      Get["/create"] = _ => View["create.cshtml"];
      Get["/pets"] = _ =>
      {
        List<Tamagotchi> viewAll = Tamagotchi.GetAll();
        return View["pets.cshtml", viewAll];
      };
      Get["/pets/{id}"] = parameters =>
      {
        Tamagotchi newPet = Tamagotchi.Find(parameters.id);
        newPet.CurrentMessage = "You selected " + newPet.Name + ". Please select an action.";
        return View["options.cshtml", newPet];
      };
      Post["/feed/{id}"] = parameters =>
      {
        Tamagotchi newPet = Tamagotchi.Find(parameters.id);
        newPet.AddPoints("hunger");
        newPet.SubtractPoints("energy");
        newPet.CurrentMessage =  "You fed " + newPet.Name + ". His hunger level is now " + newPet.Hunger + ".";
        newPet.checkPoints();
        return View["options.cshtml", newPet];
      };
      Post["/play/{id}"] = parameters =>
      {
        Tamagotchi newPet = Tamagotchi.Find(parameters.id);
        newPet.AddPoints("happiness");
        newPet.SubtractPoints("energy");
        newPet.SubtractPoints("hunger");
        newPet.CurrentMessage =  "You played with " + newPet.Name + "!";
        newPet.checkPoints();
        return View["options.cshtml", newPet];
      };
      Post["/rest/{id}"] = parameters =>
      {
        Tamagotchi newPet = Tamagotchi.Find(parameters.id);
        newPet.AddPoints("energy");
        newPet.SubtractPoints("hunger");
        newPet.SubtractPoints("happiness");
        newPet.CurrentMessage =  newPet.Name + " rested. His energy level is now " + newPet.Energy + ".";
        newPet.checkPoints();
        return View["options.cshtml", newPet];
      };
      Post["/pets"] = _ =>
      {
        Tamagotchi newPet = new Tamagotchi(Request.Form["name"], Request.Form["sprite"]);
        Console.WriteLine(newPet.Image);
        List<Tamagotchi> viewAll = Tamagotchi.GetAll();
        return View["pets.cshtml", viewAll];
      };
    }
  }
}

using System.Collections.Generic;
using System;

namespace Game.Objects
{
  public class Tamagotchi
  {
    public string Name{get; set;}
    public string Image{get;set;}
    public int Id{get;set;}
    public string Sprite{get;set;}
    public int Hunger{get;set;}
    public int Energy{get;set;}
    public int Happiness{get;set;}
    public string CurrentMessage{get;set;}
    private static List<Tamagotchi> _pets = new List<Tamagotchi> {};

    public Tamagotchi(string petName, string imgURL)
    {
      this.Name = petName;
      this.Image = "/Content/img/" + imgURL + ".gif";
      this.Sprite = imgURL;
      this.Id = _pets.Count;
      _pets.Add(this);
      this.Hunger = 70;
      this.Energy = 100;
      this.Happiness = 70;
    }

    public static List<Tamagotchi> GetAll()
    {
      return _pets;
    }
    public static Tamagotchi Find(int searchId)
    {
      return _pets[searchId];
    }
    public void SubtractPoints(string stat)
    {
        if(stat == "hunger"){
          if(this.Hunger > 9){
            this.Hunger-=10;
          }
          else{
            this.Hunger = 0;
          }
        }
        if(stat == "energy"){
          if(this.Energy > 9){
            this.Energy-=10;
          }
          else{
            this.Energy = 0;
          }
        }
        if(stat == "happiness"){
          if(this.Happiness > 9){
            this.Happiness-=10;
          }
          else
          {
            this.Happiness = 0;
          }
        }
    }
    public void AddPoints(string stat)
    {
      if(stat == "hunger")
      {
        if(this.Hunger < 91)
        {
          this.Hunger+=10;
        }
        else
        {
          this.Hunger = 100;
        }
      }
      if(stat == "energy")
      {
        if(this.Energy < 91)
        {
          this.Energy+=10;
        }
        else
        {
          this.Energy = 100;
        }
      }
      if(stat == "happiness")
      {
        if(this.Happiness <91)
        {
          this.Happiness+=10;
        }
        else
        {
          this.Happiness = 100;
        }
      }
    }
    public void checkPoints()
    {
      if(this.Hunger>50 && this.Energy>50 && this.Happiness>50)
      {
        this.Image = "/Content/img/" + this.Sprite + ".gif";
      }
      if(this.Hunger<51 || this.Energy<51 ||this.Happiness<51)
      {
        this.Image = "/Content/img/" + this.Sprite + "sad.gif";
        this.CurrentMessage += " " + this.Name + " is not well! Try to keep their stats above 50.";
      }
      if(this.Hunger==0 || this.Energy==0 ||this.Happiness==0)
      {
        this.Image = "/Content/img/" + this.Sprite + "leave.gif";
        this.CurrentMessage += " " + this.Name + " doesn't want to be your pet anymore!";
      }
    }
  }
}

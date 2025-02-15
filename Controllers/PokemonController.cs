﻿using Microsoft.AspNetCore.Mvc;
using moment2.Models;
using System.Text.Json;

namespace moment2.Controllers
{
    public class PokemonController : Controller
    {
        [HttpGet]
        public IActionResult Pokemon()
        {
            var pokemonList = GetPokemonList();

            //Sätter Viewdata till Pokemon listan
            ViewData["pokemonList"] = pokemonList;
            return View();
        }
        //Hämta Pokemon lista från pokemon Cookie
        private List<PokemonModel> GetPokemonList()
        {
            string pokemonCookie = HttpContext.Request.Cookies["pokemonList"] ?? "[]";
            return JsonSerializer.Deserialize<List<PokemonModel>>(pokemonCookie) ?? new List<PokemonModel>();

        }

        //Tar emot name, hp och rarity från Pokemon modellen
        [HttpPost]
        public IActionResult PokemonPost(string name, int hp, string rarity)
        {
            var pokemonList = GetPokemonList();
            ViewBag.Error = "";
            ViewBag.Name = name;
            ViewBag.Hp = hp;
            ViewBag.Rarity = rarity;

            //Validerar input värden
            if (name == null || (name.Length == 0 && hp == 0))
            {
                ViewBag.Error = "Fyll i alla fält";
            }
            else if (name == null || (name.Length == 0 && name.Length > 2))
            {
                ViewBag.Error = "Titel på Pokémon måste vara minst 2 tecken";
            }
            else if (hp <= 0)
            {
                ViewBag.Error = "Hp måste vara större än 0";
            }
            else
            {
                //Lägger till ny Pokemon till Pokemonlistan
                pokemonList.Add(new PokemonModel { name = name, hp = hp, rarity = rarity });

                //Sparar Pokémon listan
                SavePokemonList(pokemonList);

                //Laddar om sidan
                return RedirectToAction("Pokemon");
            }

            //Sätter Viewdata till Pokemon listan
            ViewData["pokemonList"] = pokemonList;
            return View("Pokemon");
        }

        //Spara Pokemon lista i pokemonCookien
        private void SavePokemonList(List<PokemonModel> pokemonList)
        {
            //Serialiserar listan till json sträng
            var pokemonListJson = JsonSerializer.Serialize(pokemonList);

            //Lägger till Pokemon Cookie och uppdaterar pokemonList
            HttpContext.Response.Cookies.Append("pokemonList", pokemonListJson, new CookieOptions
            {
                //Cookien går ut om 60min
                Expires = DateTimeOffset.UtcNow.AddMinutes(60),
                HttpOnly = true,
                IsEssential = true
            });
        }
    }
}

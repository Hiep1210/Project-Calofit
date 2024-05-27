using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Calofit_Project.Models;

namespace Calofit_Project.Controllers
{
    public class RecipesController : Controller
    {
        private readonly Calofit_DBContext context;

        public RecipesController(Calofit_DBContext context)
        {
            this.context = context;
        }

        // GET: Recipes
        public IActionResult Index()
        {
            List<Recipe> monan = context.Recipes.Include(r => r.RecipeIngredients).ToList();
            return View(monan);
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await context.Recipes
                .Include(r => r.Image)
                .Include(r => r.Menu)
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            ViewData["ImageId"] = new SelectList(context.Images, "ImageId", "ImageId");
            ViewData["MenuId"] = new SelectList(context.Menus, "Id", "Id");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,RecipeName,Servings,CookTime,PrepTime,Description,ImageId,MenuId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                context.Add(recipe);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImageId"] = new SelectList(context.Images, "ImageId", "ImageId", recipe.ImageId);
            ViewData["MenuId"] = new SelectList(context.Menus, "Id", "Id", recipe.MenuId);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["ImageId"] = new SelectList(context.Images, "ImageId", "ImageId", recipe.ImageId);
            ViewData["MenuId"] = new SelectList(context.Menus, "Id", "Id", recipe.MenuId);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,RecipeName,Servings,CookTime,PrepTime,Description,ImageId,MenuId")] Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(recipe);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ImageId"] = new SelectList(context.Images, "ImageId", "ImageId", recipe.ImageId);
            ViewData["MenuId"] = new SelectList(context.Menus, "Id", "Id", recipe.MenuId);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || context.Recipes == null)
            {
                return NotFound();
            }

            var recipe = await context.Recipes
                .Include(r => r.Image)
                .Include(r => r.Menu)
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (context.Recipes == null)
            {
                return Problem("Entity set 'Calofit_DBContext.Recipes'  is null.");
            }
            var recipe = await context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                context.Recipes.Remove(recipe);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return (context.Recipes?.Any(e => e.RecipeId == id)).GetValueOrDefault();
        }
    }
}

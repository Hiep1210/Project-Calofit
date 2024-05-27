using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Calofit_Project.Models
{
    public partial class Calofit_DBContext : DbContext
    {
        public Calofit_DBContext()
        {
        }

        public Calofit_DBContext(DbContextOptions<Calofit_DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diet> Diets { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<IngredientServingSize> IngredientServingSizes { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Nutrition> Nutritions { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; } = null!;
        public virtual DbSet<Step> Steps { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("Connect"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diet>(entity =>
            {
                entity.ToTable("Diet");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DietName)
                    .HasMaxLength(10)
                    .HasColumnName("diet_name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.ImageFilename)
                    .HasMaxLength(255)
                    .HasColumnName("image_filename");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.ToTable("ingredients");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ingredien__image__4D94879B");
            });

            modelBuilder.Entity<IngredientServingSize>(entity =>
            {
                entity.HasKey(e => e.ServingSizeId)
                    .HasName("PK__ingredie__0A1ADB4F159A778F");

                entity.ToTable("ingredient_serving_sizes");

                entity.Property(e => e.ServingSizeId).HasColumnName("serving_size_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .HasColumnName("description");

                entity.Property(e => e.Grams).HasColumnName("grams");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.Qty).HasColumnName("qty");

                entity.Property(e => e.Scale).HasColumnName("scale");

                entity.Property(e => e.Units)
                    .HasMaxLength(50)
                    .HasColumnName("units");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.IngredientServingSizes)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ingredien__ingre__5070F446");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DietId).HasColumnName("diet_id");

                entity.Property(e => e.MenuName)
                    .HasMaxLength(50)
                    .HasColumnName("menu_name");

                entity.HasOne(d => d.Diet)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.DietId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_Diet");
            });

            modelBuilder.Entity<Nutrition>(entity =>
            {
                entity.HasKey(e => e.IngredientId)
                    .HasName("PK__Nutritio__B0E453CFEEE0DE08");

                entity.Property(e => e.IngredientId)
                    .ValueGeneratedNever()
                    .HasColumnName("ingredient_id");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Carbohydrates).HasColumnName("carbohydrates");

                entity.Property(e => e.Fat).HasColumnName("fat");

                entity.Property(e => e.Protein).HasColumnName("protein");

                entity.Property(e => e.Sugar).HasColumnName("sugar");

                entity.HasOne(d => d.Ingredient)
                    .WithOne(p => p.Nutrition)
                    .HasForeignKey<Nutrition>(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Nutrition__ingre__5BE2A6F2");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipes");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.CookTime).HasColumnName("cook_time");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.PrepTime).HasColumnName("prep_time");

                entity.Property(e => e.RecipeName)
                    .HasMaxLength(255)
                    .HasColumnName("recipe_name");

                entity.Property(e => e.Servings).HasColumnName("servings");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_recipes_Images");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_recipes_Menu");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.ToTable("recipe_ingredients");

                entity.Property(e => e.RecipeIngredientId).HasColumnName("recipe_ingredient_id");

                entity.Property(e => e.IngredientId).HasColumnName("ingredient_id");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.ServingSizeId).HasColumnName("serving_size_id");

                entity.HasOne(d => d.Ingredient)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.IngredientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__recipe_in__ingre__5535A963");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__recipe_in__recip__5441852A");

                entity.HasOne(d => d.ServingSize)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.ServingSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__recipe_in__servi__5629CD9C");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.ToTable("steps");

                entity.Property(e => e.StepId).HasColumnName("step_id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.ImageFilename)
                    .HasMaxLength(255)
                    .HasColumnName("image_filename");

                entity.Property(e => e.ImageType)
                    .HasMaxLength(50)
                    .HasColumnName("image_type");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_id");

                entity.Property(e => e.StepNumber).HasColumnName("step_number");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__steps__recipe_id__59063A47");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

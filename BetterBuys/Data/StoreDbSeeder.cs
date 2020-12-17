using BetterBuys.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterBuys.Data
{
    public class StoreDbSeeder
    {
        public static async Task SeedAsync(StoreDbContext db)
        {
            if (!await db.Categories.AnyAsync())
            {
                await db.Categories.AddRangeAsync(GetPreconfiguredCategories());
                await db.SaveChangesAsync();
            }

            if (!await db.Products.AnyAsync())
            {
                await db.Products.AddRangeAsync(GetPreconfiguredProducts());
                await db.SaveChangesAsync();
            }

            if (!await db.ProductCategories.AnyAsync())
            {
                await db.ProductCategories.AddRangeAsync(GetPreconfiguredProductCategories());
                await db.SaveChangesAsync();
            }
        }

        static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>
            {
                new Product("Rico 4 Seater Sofa - Boucle", "The Rico series welcomes curves and volumes into a classic design defined by soft lines and an embracing expression. Contrasting the sturdiness of the four-seater’s frame, the sofa has an upholstery of timeless, yet easeful bouclé fabric, which is woven of uneven yarn to attain the rich, loopy texture of the surface. The curvaceous nature of the series adds a modern union of comfort and elegance to any room and makes you feel drawn into its motherly embrace.", 6338m,  "/images/products/sofa1.jpg"),
                new Product("Inheritance Love Sofa Seat", "Los Angeles based designer Stephen Kenn has long been inspired by clean and simple design aesthetics and the stories inherent in vintage military fabrics. In 2011 he combined those two loves by creating The Inheritance Collection. The collection was the result of an exploration of how furniture is constructed, and then a desire to distill the process down to the barest bones. Likening the process of furniture construction to the way the human body is constructed, the frame, belts, and cushions became the bones, muscles, and skin of each piece. Made in Los Angeles, the collection is inspired by the characteristic principles of Soviet Modernism and bold interpretations of Brutalist Architecture through the simplification of form, receptive angular geometries and functional design.", 7866m, "/images/products/sofa2.jpg"),
                new Product("Lansdowne Three Seat Sofa", "A low-lying modern interpretation of the classic English chesterfield, the 2014 edition Lansdowne sofa is a piece that sits comfortably in both domestic and commercial settings. It is made with an FSC approved beech frame, jute and elasticated webbing and then covered with a mix of renewable materials that includes natural fibres, animal hair and wool. The slim 20mm legs are available in bronze plated or polished steel. It is available as a conventional armchair, chaise longue and sofa, or as a versatile modular sofa system to allow for L shaped configurations.The Lansdowne is a design for the ages, elegant and modest in style. Available in a range of formations.Made to order in Norfolk, England. This version of the Lansdowne three seat sofa is upholstered in Kvadrat Molly.Also available in wide range of other fabrics and leathers.", 8059m, "/images/products/sofa3.jpg"),
                new Product("Bonaparte Sofa", "Always with a global outlook, Gubi Olsen, founder of Gubi, has created his own unique postmodernistic expression. The inspiration comes from the rich Danish traditions of craft and furniture production, mixed with with historical and visual references such as French cinema, Napoleon Bonaparte, and a grand piano. The Bonaparte series consist of a sofa, lounge chair and a pouffe. the series has a wooden frame covered with polyurethane foam. The upholstery on the frame is fixed. The detachable and reversible cushion on the sofa and lounge chair is made of polyurethane foam with springs. Priced in Gabriel Tempt Fabric, it is available in a wide range of fabrics and leather.The legs are available in black stained beech, light oak.", 7035m,  " /images/products/sofa4.jpg"),
                new Product("Woodgate Sofa System", "The 2013 Woodgate sofa system is made with an FSC approved beech frame, jute and elasticated webbing and then covered with a mix of renewable materials that includes natural fibers, animal hair and wool. The cushions have been specially designed for comfort, firmness and to retain their shape; they feature air vents and a hand - stitched hessian bag filled with horse hair that sits below a duck feather topper.The overall system has a slim and neat look with subtle curves and a refined set of 19mm legs, available in bronze plated or polished steel.It is available as conventional armchairs, chaise lounges and sofas, or as a versatile modular sofa system to allow for L shaped configurations, with connectors included.The Woodgate sofa system is a visually light and lean design, progressive in its conception and modest in style.Made in Norfolk, England.", 5882,  " /images/products/sofa5.jpg"),
                new Product("River Twin Bed", "The River Twin Bed’s clean lines make it a perfect fit with any kids’ style – and parents will love its space-saving design. A little bench at the foot of the bed provides a spot for kids to relax and read, or doubles as storage for books and toys.Sleepovers are made simple with the trundle, which tucks neatly away and can be used to store blankets and clothes when friends aren’t around. For the littlest ones, a security rail can easily be added to either side of the bed.", 955m, "/images/products/bed1.jpg"),
                new Product("Perch Bunk Bed", "The elegant Perch bunk bed is the perfect centerpiece for any child's room. Its compact footprint leaves plenty of room for play and additional furnishings. The versatile Perch easily separates into a loft bed and a standalone twin, giving many configuration options.", 2051m, "/images/products/bed2.jpg"),
                new Product("Perch Toddler Bed", "Celebrate the important milestone of moving to a \"big kid\" bed with the Perch Toddler Bed. As a scaled-down bed with a low mattress position, it will still feel cozy for your child, but it allows them to get in and out on their own, reinforcing a sense of independence. Then the toddler bed can be transitioned to a child-sized sofa by removing the security rail, once your child moves to a larger bed.", 568m, "/images/products/bed3.jpg"),
                new Product("Sparrow Twin Bed", "Crafted in Europe, this bed matches the rest of the furniture in the contemporary Sparrow range. Clean lines, subtle color and modern style ensure that you child will never outgrow this bed. Good thing its built to last.The trundle bed shown in some of the images is sold separately.", 1158m, "/images/products/bed4.jpg"),
                new Product("Rhea Toddler Bed Conversion Kit", "The Rhea conversion kit turns the Rhea crib into a day-bed style toddler bed. Moving into a toddler bed is a milestone for any child. The Rhea toddler bed is safe, cozy and easy to access, reinforcing your childs new-found independence.", 205m, "/images/products/bed5.jpg"),
                new Product("Enfold Sideboard - Low", "Enfold Sideboard combines the warm touch of oak, referencing the wooden sideboards of the 20th century, with the contemporary touch of its lacquered steel front that has been punched and bended for a refined and industrial look.", 2770m, "/images/products/sideboard1.jpg"),
                new Product("Virka Sideboard - Low", "Virka is an elegant and timeless sideboard in two heights. With clean lines and a simple expression, the Virka sideboards can be a part of a consistent design language or be a stand-alone object. The sideboards are designed with sliding doors, so it will never take up unnecessary space in your room. The geometrical frame makes Virka seem light and almost hovering over the floor. Behind each door is an adjustable shelf with space to let cables pass on the back and out through the holes in each backboard.", 1721m, "/images/products/sideboard2.jpg"),
                new Product("Air Sideboard Low", "Air is a sideboard for the centre of the room. It combines a graphic pattern of ribs with natural cane inlays which gives a feeling of lightness and transparency. Air can be used as freestanding room dividers or placed against a wall. The woven cane gives it a visible surface, but also provides a sense of depth. You can glimpse what’s inside, adding some careful mystery to the piece. The fact that the design is transparent also fulfils a function. The woven cane ventilates the cupboard which is practical when storing both clothes and electronic devices. A lamp behind the see-through doors makes Air shine like a diamond.", 2578m, "/images/products/sideboard3.jpg"),
                new Product("Key Short Module Sideboard", "The basic short Key module can be stacked up to 5 units high to form tall storage or a bookcase. Stacked Key modules lock together with steel pins so they can't be pushed apart (included). In addition, taller Key stacks can be secured to a wall stud with a galvanized steel anti-tip cable to prevent them from being accidentally knocked over. The full thickness back not only provides a very stiff structure, but also allows Key to be mounted directly to a wall. Stacked Key modules make a perfect modern storage solution for a living room or office.", 637m, "/images/products/sideboard4.jpg"),
                new Product("Vass V60 Cabinet 4 Doors Sideboard", "Asplund is one of Sweden’s leading design and interior firms formed more than 24 years ago. Continuing with top-of-the-line quality, the Asplund collection represents simplicity and elegant design. Influenced by their Swedish heritage along with very stylish & timeless designs, Asplund is considered the best Scandinavian brand with numerous design awards such as Elle Decor, Red Dot Design and Wallpaper* magazine.", 5802m, "/images/products/sideboard5.jpg"),
                new Product("Five Pouf Ottoman", "Careful detailing with the use of quilted material has given Five Pouf the combination of both a linear profile and soft-curved edges, making it very versatile and easily adaptable to multiple settings.", 1400m, "/images/products/ottoman1.jpg"),
                new Product("Pad Ottoman", "The Pad series comprises a high and a low lounge chair, as well as a complementing footstool. You can choose between legs in black or grey steel, in combination with a back of oak or black-painted oak with upholstery in three different qualities in a wide variety of shades.", 810m, "/images/products/ottoman2.jpg"),
                new Product("Era Footstool Ottoman", "Classic, inviting, nostalgic and curved. That's one way of describing the new range of lounge chairs designed by the Danish designer, Simon Legald. But the Era collection is many other things too. The design is well-proportioned, the lines are sharp, and the feel is contemporary. Era combines modern production techniques with traditional furniture craftsmanship in a timeless and characterful design.", 850m, "/images/products/ottoman3.jpg"),
                new Product("Rest Pouf Ottoman", "With its modern curves and inviting shape, the Rest Pouf is a great addition to any sofa setting.", 700m, "/images/products/ottoman4.jpg"),
                new Product("Inheritance Bench Ottoman", "TLos Angeles based designer Stephen Kenn has long been inspired by clean and simple design aesthetics and the stories inherent in vintage military fabrics. In 2011 he combined those two loves by creating The Inheritance Collection. The collection was the result of an exploration of how furniture is constructed, and then a desire to distill the process down to the barest bones. Likening the process of furniture construction to the way the human body is constructed, the frame, belts, and cushions became the bones, muscles, and skin of each piece.", 1000m, "/images/products/ottoman5.jpg")
            };
        }

        static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>
            {
                new Category("Sofa"),
                new Category("Bed"),
                new Category("Sideboard"),
                new Category("Ottoman")
            };
        }

        static IEnumerable<ProductCategory> GetPreconfiguredProductCategories()
        {
            return new List<ProductCategory>
            {
                new ProductCategory(1,1),
                new ProductCategory(1,15),
                new ProductCategory(1,16),
                new ProductCategory(1,17),
                new ProductCategory(1,18),
                new ProductCategory(2,10),
                new ProductCategory(2,11),
                new ProductCategory(2,12),
                new ProductCategory(2,13),
                new ProductCategory(2,14),
                new ProductCategory(3,5),
                new ProductCategory(3,6),
                new ProductCategory(3,7),
                new ProductCategory(3,8),
                new ProductCategory(3,9),
                new ProductCategory(4,2),
                new ProductCategory(4,3),
                new ProductCategory(4,4),
                new ProductCategory(4,19),
                new ProductCategory(4,20)
            };
        }
    }
}

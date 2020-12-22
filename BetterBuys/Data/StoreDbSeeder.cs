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
                new Product("LRG Sectional Sofa", "ARTLESS LRG Sofas are our interpretation of what contemporary seating should be. We liked the Italian sofas but they seemed to slick. We designed the LRG and knew a solid wood wrap around base was a must. ARTLESS designs with all four sides in mind, and we needed a sofa with a compelling back and wood cradles the sofa so nicely. The LRG is full of comfort with its down proof ticking cushion and pillows, we find it immersive. While the back and sides create a striking figure.", 7866m, "/images/products/sofa2.png"),
                new Product("Gubi Modern Line Sofa 4-Seater", "The Modern Line sofa collection was designed in 1949 by Greta M. Grossman. Modern Line was one of her most elegant and minimalistic designs and was praised in particular for being representative of her background in Scandinavian design. Her timeless sofa collection has a sleek, feminine and light expression that is supported with elegant slender legs, which is a true signature for Greta M. Grossman’s designs.", 8059m, "/images/products/sofa3.jpg"),
                new Product("Oscar 4 Seat Sofa by Matthew Hilton", "The Oscar sofa strikes a pleasing balance between modernity and tradition, large in size yet light in appearance. The sofa is made from a European hardwood frame, jute webbing and hessian straps and then covered with a mix of materials that includes natural fibers, animal hair and wool. It features two large feather cushions that are notable for their depth, the back has a line of sewn in pulls, lending the sofa the appearance of a buttoned back, without the actual buttons. The feet are made from walnut stained beech, with the front ones being turned versions. By contrasting long straight lines with delicate natural curves, Mathew Hilton has created a piece that is both reserved and full of humility. Made in the UK.", 7035m,  " /images/products/sofa4.jpg"),
                new Product("Eave Dining Sofa", "Inspiration can often come from unexpected places, like the lower edges of the roof that overhang a wall. It's these \"eaves\" that inspired the curved upholstered armrests of this modular sofa. A perfect blend of style and comfort, Eave is a lovely banquet sofa that is a beautiful addition to a dining table or to a formal yet relaxed living space. The seating angle is upright yet comfortable, allowing guests to comfortably banter across a dinner table at length. Available in 3 lengths: 65\", 79\" and 110\".", 5882m,  " /images/products/sofa5.jpg"),
                new Product("River Twin Bed", "The River Twin Bed’s clean lines make it a perfect fit with any kids’ style – and parents will love its space-saving design. A little bench at the foot of the bed provides a spot for kids to relax and read, or doubles as storage for books and toys.Sleepovers are made simple with the trundle, which tucks neatly away and can be used to store blankets and clothes when friends aren’t around. For the littlest ones, a security rail can easily be added to either side of the bed.", 955m, "/images/products/bed1.jpg"),
                new Product("Perch Bunk Bed", "The elegant Perch bunk bed is the perfect centerpiece for any child's room. Its compact footprint leaves plenty of room for play and additional furnishings. The versatile Perch easily separates into a loft bed and a standalone twin, giving many configuration options.", 2051m, "/images/products/bed2.jpg"),
                new Product("Perch Toddler Bed", "Celebrate the important milestone of moving to a \"big kid\" bed with the Perch Toddler Bed. As a scaled-down bed with a low mattress position, it will still feel cozy for your child, but it allows them to get in and out on their own, reinforcing a sense of independence. Then the toddler bed can be transitioned to a child-sized sofa by removing the security rail, once your child moves to a larger bed.", 568m, "/images/products/bed3.jpg"),
                new Product("Sparrow Twin Bed", "Crafted in Europe, this bed matches the rest of the furniture in the contemporary Sparrow range. Clean lines, subtle color and modern style ensure that you child will never outgrow this bed. Good thing its built to last.The trundle bed shown in some of the images is sold separately.", 1158m, "/images/products/bed4.jpg"),
                new Product("Rhea Toddler Bed Conversion Kit", "The Rhea conversion kit turns the Rhea crib into a day-bed style toddler bed. Moving into a toddler bed is a milestone for any child. The Rhea toddler bed is safe, cozy and easy to access, reinforcing your childs new-found independence.", 205m, "/images/products/bed5.jpg"),
                new Product("Alden Sideboard", "This warm and elegant sideboard has become a new customer favorite. The richness of the wood grain is the stand out here. We have allowed the grain to run seamlessly across the door and drawer fronts and designed it with integrated handles to let the wood speak for itself. The Alden Sideboard has a back beveled, solid wood top that keeps this substantial piece from feeling too heavy. Adding to this lightness, the Alden Sideboard floats on the airy, splayed legs. Whether using it for traditional storage needs or to conceal your high tech media equipment, the Alden Sideboard was designed to function well in any room of the house, or office. The interior is equipped with wire passages, adjustable shelves, solid maple, dovetailed drawer boxes with soft-close drawer slides, and hidden door hinges. Pairs with the Alden Dining Table.", 2770m, "/images/products/sideboard1.jpg"),
                new Product("Virka Sideboard - Low", "Virka is an elegant and timeless sideboard in two heights. With clean lines and a simple expression, the Virka sideboards can be a part of a consistent design language or be a stand-alone object. The sideboards are designed with sliding doors, so it will never take up unnecessary space in your room. The geometrical frame makes Virka seem light and almost hovering over the floor. Behind each door is an adjustable shelf with space to let cables pass on the back and out through the holes in each backboard.", 1721m, "/images/products/sideboard2.jpg"),
                new Product("Air Sideboard Low", "Air is a sideboard for the centre of the room. It combines a graphic pattern of ribs with natural cane inlays which gives a feeling of lightness and transparency. Air can be used as freestanding room dividers or placed against a wall. The woven cane gives it a visible surface, but also provides a sense of depth. You can glimpse what’s inside, adding some careful mystery to the piece. The fact that the design is transparent also fulfils a function. The woven cane ventilates the cupboard which is practical when storing both clothes and electronic devices. A lamp behind the see-through doors makes Air shine like a diamond.", 2578m, "/images/products/sideboard3.jpg"),
                new Product("Key Short Module Sideboard", "The basic short Key module can be stacked up to 5 units high to form tall storage or a bookcase. Stacked Key modules lock together with steel pins so they can't be pushed apart (included). In addition, taller Key stacks can be secured to a wall stud with a galvanized steel anti-tip cable to prevent them from being accidentally knocked over. The full thickness back not only provides a very stiff structure, but also allows Key to be mounted directly to a wall. Stacked Key modules make a perfect modern storage solution for a living room or office.", 637m, "/images/products/sideboard4.jpg"),
                new Product("LUC 160 Sideboard With Drawers", "Asplund is one of Sweden’s leading design and interior firms formed more than 24 years ago. Continuing with top-of-the-line quality, the Asplund collection represents simplicity and elegant design. Influenced by their Swedish heritage along with very stylish & timeless designs, Asplund is considered the best Scandinavian brand with numerous design awards such as Elle Decor, Red Dot Design and Wallpaper* magazine.", 7820m, "/images/products/sideboard5.jpg"),
                new Product("Georg Bench", "Skagerak has set a standard for creating designer furniture that will last a lifetime. The Georg collection is no exception. Simple, pure and immediately classic, the smooth turned oak creates a comfortable atmosphere with unsurpassed utility. The entire line is perfect for those small out of the way places where space is at a premium. The Georg Bench, topped with a wool pad held in place with leather straps, grouped with the Georg rack and hangers make an inviting and convenient addition to a foyer, mudroom or hallway. The Georg Console and Stool, also topped with a wool pad, are the ideal addition to any room in the home. While the Georg Mirror rests lightly against a wall on its gently curved legs. Made of solid sustainable oak and finished in a clear lacquer that highlights the natural beauty of the wood, this collection is sure to become a favorite.", 1200m, "/images/products/bench1.jpg"),
                new Product("Isometric Bench - White Oak", "Solid hardwood bench. With its unpretentious styling and honest forms, the Isometric Collection calls upon the underlying principals of Shaker, Mission and early American furniture design. With clean lines, practical beauty and enduring craftsmanship, the collection is simplicity at its purest, bringing a modern point of view to the spirit and functionality of these great American wood furniture traditions.", 1200m, "/images/products/bench2.jpg"),
                new Product("LAX Dining Bench", "Sit in style. Durable enough for industrial use, yet refined for the most luxurious setting. The LAXseries bench, made of solid English walnut, is a classic addition to the modern home.", 1005m, "/images/products/bench3.jpg"),
                new Product("Oblique Bench", "Fusing Japanese woodworking techniques with Scandinavian design sensibilities, our simple and sculptural Oblique Bench is made with low living in mind. Taking its name from the tilted angles of the few, yet perfectly placed, elements that make up its construction, this solid oak seat with a natural oiled finish elevates objects when used as a display for books, vases and more, and makes light work of putting on and taking off shoes in a hallway.", 1186m, "/images/products/bench4.jpg"),
                new Product("Overlap Bench", "Overlap Bench is a simple high-quality bench that stands strong on its overlapping steel legs. The contrast between the rustic wooden planks and the powder-coated steel gives the bench a modern edge and contemporary appeal that makes it an obvious choice, both indoors and outdoors.", 2256m, "/images/products/bench5.jpg")
            };
        }

        static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>
            {
                new Category("Sofa"),
                new Category("Bed"),
                new Category("Sideboard"),
                new Category("Bench")
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

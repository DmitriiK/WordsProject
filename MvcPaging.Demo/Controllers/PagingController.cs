using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcPaging.Demo.Models;
using Lexicon.DAL.Repositories;
using Lexicon.DAL.Entities;
using Lexicon.DAL.Interfaces;

namespace MvcPaging.Demo.Controllers
{
    public class PagingController : Controller
    {
        private const int DefaultPageSize = 10;
        private IList<Product> allProducts = new List<Product>();
        private readonly string[] allCategories = new string[3] { "Shoes", "Electronics", "Food" };

        private string LoadContentText ()
        { return @"

My profound thanks to three dear friends with whom I have the great luxury of working: my editor, Jason Kaufman; my agent, Heide Lange; and my counselor, Michael Rudell. In addition, I would like to express my immense gratitude to Doubleday, to my publishers around the world, and, of course, to my readers.

This novel could not have been written without the generous assistance of countless individuals who shared their knowledge and expertise. To all of you, I extend my deep appreciation.

To live in the world without becoming aware of the meaning of the world is like wandering about in a great library without touching the books.

The Secret Teachingsof All Ages





FACT:




In 1991, a document was locked in the safe of the director of the CIA. The document is still there today. Its cryptic text includes references to an ancient portal and an unknown location underground. The document also contains the phrase УItТs buried out there somewhere.Ф All organizations in this novel exist, including the Freemasons, the Invisible College, the Office of Security, the SMSC, and the Institute of Noetic Sciences.All rituals, science, artwork, and monuments in this novel are real.





Prologue




House of the Temple

8:33 P.M.

The secretis how to die.

Since the beginning of time, the secret had always been how to die.

The thirty-four - year - old initiate gazed down at the human skull cradled in his palms. The skull was hollow, like a bowl, filled with bloodred wine.

    Drink it, he told himself. You have nothing to fear.

    As was tradition, he had begun this journey adorned in the ritualistic garb of a medieval heretic being led to the gallows, his loose - fitting shirt gaping open to reveal his pale chest, his left pant leg rolled up to the knee, and his right sleeve rolled up to the elbow. Around his neck hung a heavy rope noose Ч a Уcable - towФ as the brethren called it.Tonight, however, like the brethren bearing witness, he was dressed as a master.

       The assembly of brothers encircling him all were adorned in their full regalia of lambskin aprons, sashes, and white gloves. Around their necks hung ceremonial jewels that glistened like ghostly eyes in the muted light.Many of these men held powerful stations in life, and yet the initiate knew their worldly ranks meant nothing within these walls.Here all men were equals, sworn brothers sharing a mystical bond.

As he surveyed the daunting assembly, the initiate wondered who on the outside would ever believe that this collection of men would assemble in one placeЕ much less this place.The room looked like a holy sanctuary from the ancient world.

The truth, however, was stranger still.

I am just blocks away from the White House.

This colossal edifice, located at 1733 Sixteenth Street NW in Washington, D.C., was a replica of a pre-Christian temple Ч the temple of King Mausolus, the original mausoleumЕ a place to be taken after death. Outside the main entrance, two seventeen - ton sphinxes guarded the bronze doors.The interior was an ornate labyrinth of ritualistic chambers, halls, sealed vaults, libraries, and even a hollow wall that held the remains of two human bodies.The initiate had been told every room in this building held a secret, and yet he knew no room held deeper secrets than the gigantic chamber in which he was currently kneeling with a skull cradled in his palms.

The Temple Room.

This room was a perfect square. And cavernous. The ceiling soared an astonishing one hundred feet overhead, supported by monolithic columns of green granite.A tiered gallery of dark Russian walnut seats with hand-tooled pigskin encircled the room.A thirty-three-foot-tall throne dominated the western wall, with a concealed pipe organ opposite it.The walls were a kaleidoscope of ancient symbolsЕ Egyptian, Hebraic, astronomical, alchemical, and others yet unknown.

Tonight, the Temple Room was lit by a series of precisely arranged candles. Their dim glow was aided only by a pale shaft of moonlight that filtered down through the expansive oculus in the ceiling and illuminated the room's most startling feature Ч an enormous altar hewn from a solid block of polished Belgian black marble, situated dead center of the square chamber.

The secret is how to die, the initiate reminded himself.

УIt is time, Ф a voice whispered.

The initiate let his gaze climb the distinguished white-robed figure standing before him.The Supreme Worshipful Master. The man, in his late fifties, was an American icon, well loved, robust, and incalculably wealthy.His once-dark hair was turning silver, and his famous visage reflected a lifetime of power and a vigorous intellect.

УTake the oath, Ф the Worshipful Master said, his voice soft like falling snow. УComplete your journey.Ф

The initiate's journey, like all such journeys, had begun at the first degree. On that night, in a ritual similar to this one, the Worshipful Master had blindfolded him with a velvet hoodwink and pressed a ceremonial dagger to his bare chest, demanding: УDo you seriously declare on your honor, uninfluenced by mercenary or any other unworthy motive, that you freely and voluntarily offer yourself as a candidate for the mysteries and privileges of this brotherhood?Ф

УI do, Ф the initiate had lied.

УThen let this be a sting to your consciousness, Ф the master had warned him, Уas well as instant death should you ever betray the secrets to be imparted to you.Ф

At the time, the initiate had felt no fear. They will never know my true purpose here.

Tonight, however, he sensed a foreboding solemnity in the Temple Room, and his mind began replaying all the dire warnings he had been given on his journey, threats of terrible consequences if he ever shared the ancient secrets he was about to learn: Throat cut from ear to earЕ tongue torn out by its rootsЕ bowels taken out and burnedЕ scattered to the four winds of heavenЕ heart plucked out and given to the beasts of the field Ч

УBrother, Ф the gray-eyed master said, placing his left hand on the initiate's shoulder. УTake the final oath.Ф

Steeling himself for the last step of his journey, the initiate shifted his muscular frame and turned his attention back to the skull cradled in his palms. The crimson wine looked almost black in the dim candlelight.The chamber had fallen deathly silent, and he could feel all of the witnesses watching him, waiting for him to take his final oath and join their elite ranks.

Tonight, he thought, something is taking place within these walls that has never before occurred in the history of this brotherhood.Not once, in centuries.

He knew it would be the sparkЕ and it would give him unfathomable power. Energized, he drew a breath and spoke aloud the same words that countless men had spoken before him in countries all over the world.

УMay this wine I now drink become a deadly poison to meЕ should I ever knowingly or willfully violate my oath.Ф

His words echoed in the hollow space.

Then all was quiet.

Steadying his hands, the initiate raised the skull to his mouth and felt his lips touch the dry bone. He closed his eyes and tipped the skull toward his mouth, drinking the wine in long, deep swallows. When the last drop was gone, he lowered the skull.

For an instant, he thought he felt his lungs growing tight, and his heart began to pound wildly.My God, they know! Then, as quickly as it came, the feeling passed.

A pleasant warmth began to stream through his body.The initiate exhaled, smiling inwardly as he gazed up at the unsuspecting gray-eyed man who had foolishly admitted him into this brotherhood's most secretive ranks.

Soon you will lose everything you hold most dear.





CHAPTER 1




The Otis elevator climbing the south pillar of the Eiffel Tower was overflowing with tourists.Inside the cramped lift, an austere businessman in a pressed suit gazed down at the boy beside him. УYou look pale, son.You should have stayed on the ground.Ф

УIТm okayЕФ the boy answered, struggling to control his anxiety.УIТll get out on the next level.Ф I canТt breathe.

The man leaned closer. УI thought by now you would have gotten over this.Ф He brushed the childТs cheek affectionately.

The boy felt ashamed to disappoint his father, but he could barely hear through the ringing in his ears. I canТt breathe.IТve got to get out of this box!

The elevator operator was saying something reassuring about the liftТs articulated pistons and puddled-iron construction. Far beneath them, the streets of Paris stretched out in all directions.

Almost there, the boy told himself, craning his neck and looking up at the unloading platform. Just hold on.

As the lift angled steeply toward the upper viewing deck, the shaft began to narrow, its massive struts contracting into a tight, vertical tunnel.

УDad, I donТt think ЧФ

Suddenly a staccato crack echoed overhead. The carriage jerked, swaying awkwardly to one side.Frayed cables began whipping around the carriage, thrashing like snakes.The boy reached out for his father.

УDad!Ф

Their eyes locked for one terrifying second.

Then the bottom dropped out.

Robert Langdon jolted upright in his soft leather seat, startling out of the semiconscious daydream. He was sitting all alone in the enormous cabin of a Falcon 2000EX corporate jet as it bounced its way through turbulence. In the background, the dual Pratt & Whitney engines hummed evenly.

УMr.Langdon? Ф The inte"; }



        public PagingController()
        {
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            // Create a list of products. 50% of them are in the Shoes category, 25% in the Electronics 
            // category and 25% in the Food category.
            for (var i = 0; i < 527; i++)
            {
                var product = new Product();
                product.Name = "Product " + (i + 1);
                var categoryIndex = i % 4;
                if (categoryIndex > 2)
                {
                    categoryIndex = categoryIndex - 3;
                }
                product.Category = allCategories[categoryIndex];
                allProducts.Add(product);
            }
        }

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            // return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));

            IContentRepository rep = new ContentRepository(new Lexicon.DAL.LexiconDBContext());
            var txt = rep.GetFullContent(391).TextData; //this.LoadContentText()

            return View(txt.ToPagedString(currentPageIndex, 10000));
        }

        public ActionResult CustomPageRouteValueKey(SearchModel search)
        {
            int currentPageIndex = search.page.HasValue ? search.page.Value - 1 : 0;
            return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));
        }

        public ActionResult ViewByCategory(string categoryName, int? page)
        {
            categoryName = categoryName ?? this.allCategories[0];
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            var productsByCategory = this.allProducts.Where(p => p.Category.Equals(categoryName)).ToPagedList(currentPageIndex,
                                                                                                              DefaultPageSize);
            ViewBag.CategoryName = new SelectList(this.allCategories, categoryName);
            ViewBag.CategoryDisplayName = categoryName;
            return View("ProductsByCategory", productsByCategory);
        }

        public ActionResult ViewByCategories(string[] categories, int? page)
        {
            var model = new ViewByCategoriesViewModel();
            model.Categories = categories ?? new string[0];
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            model.Products = this.allProducts.Where(p => model.Categories.Contains(p.Category)).ToPagedList(currentPageIndex, DefaultPageSize);
            model.AvailableCategories = this.allCategories;
            return View("ProductsByCategories", model);
        }

        public ActionResult IndexAjax()
        {
            int currentPageIndex = 0;
            var products = this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize);
            return View(products);
        }

        public ActionResult AjaxPage(int? page)
        {
            ViewBag.Title = "Browse all products";
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            var products = this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize);
            return PartialView("_ProductGrid", products);
        }

        public ActionResult Bootstrap(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));
        }

        public ActionResult Bootstrap3(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));
        }
    }
}
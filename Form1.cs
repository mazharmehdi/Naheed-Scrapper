using Newtonsoft.Json;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Naheed_Scrapper_2
{
    public partial class Form1 : Form
    {
        static HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }
        private async void buttonStart_Click(object sender, EventArgs e)
        {
            var htmlcollection = new List<(string BaseDir, string Html)>();
            htmlcollection.Add(("Health & Beauty", "<ul class=\"level0 submenu\"> <li class=\"level1 hasChild parent\"><a href=\"https://www.naheed.pk/health-beauty/perfumes\"><span>Fragrances</span></a>  <ul class=\"level1 submenu\"> <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/perfumes/women-perfumes\"><span>Women Perfumes</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/perfumes/men-perfumes\"><span>Men Perfumes</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/perfumes/men-deodorants\"><span>Men Deodorants</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/perfumes/women-deodorants\"><span>Women Deodorants</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/perfumes/body-mists\"><span>Body &amp; Face Mists</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/perfumes/diffusers-home-fragrance-oils\"><span>Diffusers &amp; Fragrance Oils</span></a> </li> </ul></li>  <li class=\"level1 hasChild parent\"><a href=\"https://www.naheed.pk/health-beauty/hair-care\"><span>Hair Care</span></a>  <ul class=\"level1 submenu\"> <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/hair-care/shampoo-conditioners\"><span>Shampoo &amp; Conditioner</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/hair-care/hair-styling\"><span>Hair Styling</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/hair-care/hair-loss-products\"><span>Hair Loss Products</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/hair-care/hair-color\"><span>Hair Color</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/hair-care/hair-oils\"><span>Hair Oils</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/hair-care/hair-scalp-treatments\"><span>Hair &amp; Scalp Treatments</span></a> </li>  <li class=\"level2 hasChild parent level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/hair-care/styling-tools\"><span>Styling Tools</span></a>  <ul class=\"level1 submenu\"> <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/hair-care/styling-tools/hot-air-hair-brushes\"><span>Hot-Air Hair Brushes</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/hair-care/styling-tools/hair-dryers\"><span>Hair Dryers</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/hair-care/styling-tools/hair-straighteners\"><span>Hair Straighteners</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/hair-care/styling-tools/hair-curlers\"><span>Hair Curlers</span></a></li> </ul></li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/hair-care/masks\"><span>Masks</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/hair-care/hair-brushes-combs\"><span>Hair Brushes &amp; Combs</span></a> </li> </ul></li>  <li class=\"level1 hasChild parent\"><a href=\"https://www.naheed.pk/health-beauty/professional-hair-care\"><span>Professional Hair Care</span></a>  <ul class=\"level1 submenu\"> <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/professional-hair-care/l-oreal-professionnel\"><span>L'Oreal Professionnel</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/professional-hair-care/kerastase\"><span>Kerastase</span></a> </li> </ul></li>  <li class=\"level1 hasChild parent\"><a href=\"https://www.naheed.pk/health-beauty/makeup\"><span>Makeup</span></a>  <ul class=\"level1 submenu\"> <li class=\"level2 hasChild parent level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup\"><span>Eyes</span></a>  <ul class=\"level1 submenu\"> <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup/kajal-kohls\"><span>Kajal &amp; Kohls</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup/eyebrows\"><span>Eyebrows</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup/eyeliners\"><span>Eyeliners</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup/mascaras\"><span>Mascaras</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup/eye-pencils\"><span>Eye Pencils</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup/eye-concealers-color-correctors\"><span>Eye Concealers &amp; Color Correctors</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup/eyeshadow\"><span>Eyeshadow</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup/eye-primers\"><span>Eye Primers</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup/eye-sets\"><span>Eye Sets</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/eye-makeup/eyelashes\"><span>Eyelashes</span></a></li> </ul></li>  <li class=\"level2 hasChild parent level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup\"><span>Lips</span></a>  <ul class=\"level1 submenu\"> <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup/lip-liners\"><span>Lip Liners</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup/lipsticks\"><span>Lipsticks</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup/lip-gloss\"><span>Lip Gloss</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup/liquid-lipsticks\"><span>Liquid Lipsticks</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup/lip-powders-crayons\"><span>Lip Powders &amp; Crayons</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup/lip-stains-tints\"><span>Lip Stains &amp; Tints</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup/lip-primers-oils\"><span>Lip Primers &amp; Oils</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup/lip-color-correctors-concealers\"><span>Lip Color Correctors &amp; Concealers</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup/lip-kits\"><span>Lip Kits</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/lips-makeup/lip-creams\"><span>Lip Creams</span></a></li> </ul></li>  <li class=\"level2 hasChild parent level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup\"><span>Face</span></a>  <ul class=\"level1 submenu\"> <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/foundations\"><span>Foundations</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/highlighters-illuminators\"><span>Highlighters &amp; Illuminators</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/bronzer-contouring\"><span>Bronzer &amp; Contouring</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/primers\"><span>Primers</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/cheek-lip-tints\"><span>Cheek &amp; Lip Tints</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/setting-powders\"><span>Setting Powders</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/blushes\"><span>Blushes</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/tinted-moisturizers-color-correctors\"><span>Tinted Moisturizers &amp; Color Correctors</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/concealers\"><span>Concealers</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/bb-cc-creams\"><span>BB &amp; CC Creams</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/makeup-palettes-kits\"><span>Makeup Palettes &amp; Kits</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/face-makeup/setting-spray\"><span>Setting Spray</span></a></li> </ul></li>  <li class=\"level2 hasChild parent level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/makeup/nails\"><span>Nails</span></a>  <ul class=\"level1 submenu\"> <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/nails/nail-polish\"><span>Nail Polish</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/nails/nail-top-base-coat\"><span>Nail Top &amp; Base Coat</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/makeup/nails/nail-art\"><span>Nail Art, Care &amp; Tools</span></a></li> </ul></li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/makeup/makeup-removers\"><span>Makeup Removers</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/makeup/tools-brushes\"><span>Tools &amp; Brushes</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/makeup/cosmetic-bags-organizers\"><span>Bags &amp; Organizers</span></a> </li> </ul></li>  <li class=\"level1 hasChild parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care\"><span>Skin Care</span></a>  <ul class=\"level1 submenu\"> <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/creams-lotions\"><span>Creams &amp; Lotions</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/facial-cleansers\"><span>Facial Cleansers</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/scrubs-exfoliators\"><span>Scrubs &amp; Exfoliators</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/sunscreens\"><span>Sunscreens</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/face-wash\"><span>Face Wash</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/anti-aging-products\"><span>Anti-Aging Products</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/treatments-masks\"><span>Treatments &amp; Masks</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/face-whitening\"><span>Face Whitening</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/facial-masks\"><span>Facial Masks</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/powders\"><span>Powders</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/face-mists\"><span>Face Mists</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/skin-care/serum-oils\"><span>Serum &amp; Oils</span></a> </li> </ul></li>  <li class=\"level1 hasChild parent\"><a href=\"https://www.naheed.pk/health-beauty/bath-body\"><span>Bath &amp; Body</span></a>  <ul class=\"level1 submenu\"> <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/bath-body/hand-wash\"><span>Hand Wash &amp; Sanitizer</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/bath-body/accessories\"><span>Accessories</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/bath-body/nursing\"><span>Nursing Products</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/bath-body/body-wash-body-soap\"><span>Soaps &amp; Body Wash</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/bath-body/body-oils\"><span>Body Oils</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/bath-body/shower-gels-creams\"><span>Shower Gels &amp; Creams</span></a> </li> </ul></li>  <li class=\"level1 \"><a href=\"https://www.naheed.pk/health-beauty/eye-care\"><span>Eye Care</span></a> </li>  <li class=\"level1 hasChild parent\"><a href=\"https://www.naheed.pk/health-beauty/feminine-care\"><span>Feminine Care</span></a>  <ul class=\"level1 submenu\"> <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/feminine-care/shaving-waxing\"><span>Epilators &amp; Groomers</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/feminine-care/tampons\"><span>Tampons</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/feminine-care/sanitary-napkins\"><span>Sanitary Napkins &amp; Pads</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/feminine-care/feminine-washes\"><span>Feminine Washes</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/feminine-care/shaving\"><span>Shaving</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/feminine-care/sanitary-protection\"><span>Sanitary Protection</span></a> </li> </ul></li>  <li class=\"level1 hasChild parent\"><a href=\"https://www.naheed.pk/health-beauty/mens-care\"><span>Men's Care</span></a>  <ul class=\"level1 submenu\"> <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/mens-care/men-shaving\"><span>Shaving</span></a> </li>  <li class=\"level2 hasChild parent level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/mens-care/shavers-timmers\"><span>Shavers &amp; Timmers</span></a>  <ul class=\"level1 submenu\"> <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/mens-care/shavers-timmers/detail-and-nose-trimmers\"><span>Detail and Nose Trimmers</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/mens-care/shavers-timmers/hair-beard-trimmers\"><span>Hair &amp; Beard Trimmers</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/mens-care/shavers-timmers/shavers\"><span>Shavers</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/mens-care/shavers-timmers/body-trimmers\"><span>Body Trimmers</span></a></li> </ul></li> </ul></li>  <li class=\"level1 hasChild parent\"><a href=\"https://www.naheed.pk/health-beauty/personal-care\"><span>Personal Care</span></a>  <ul class=\"level1 submenu\"> <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/personal-care/lip-care\"><span>Lip Care</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/personal-care/foot-hand-care\"><span>Foot &amp; Hand Care</span></a> </li>  <li class=\"level2 hasChild parent level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/personal-care/oral-hygiene\"><span>Oral Hygiene</span></a>  <ul class=\"level1 submenu\"> <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/personal-care/oral-hygiene/toothbrushes-accessories\"><span>Toothbrushes &amp; Accessories</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/personal-care/oral-hygiene/dental-floss-picks\"><span>Dental Floss &amp; Picks</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/personal-care/oral-hygiene/mouthwashes\"><span>Mouthwashes</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/personal-care/oral-hygiene/toothpaste\"><span>Toothpaste</span></a></li>  <li class=\"level3 \"><a href=\"https://www.naheed.pk/health-beauty/personal-care/oral-hygiene/teeth-whitening-products\"><span>Teeth Whitening Products</span></a></li> </ul></li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/personal-care/hair-removal\"><span>Hair Removal</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/personal-care/adult-diapers\"><span>Adult Diapers &amp; Wipes</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/personal-care/massagers\"><span>Massagers</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/personal-care/ear-care\"><span>Ear Care</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/personal-care/beauty-tools\"><span>Beauty Tools</span></a> </li> </ul></li>  <li class=\"level1 hasChild parent\"><a href=\"https://www.naheed.pk/health-beauty/sexual-wellness\"><span>Sexual Wellness</span></a>  <ul class=\"level1 submenu\"> <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/sexual-wellness/condoms\"><span>Condoms</span></a> </li>  <li class=\"level2  level3-parent\"><a href=\"https://www.naheed.pk/health-beauty/sexual-wellness/lubricants-massage-gels\"><span>Lubricants &amp; Gels</span></a> </li> </ul></li> </ul>"));

            foreach (var (BaseDir, Html) in htmlcollection)
            {
                Console.WriteLine($"(\"{BaseDir}\", ");
                await Build(Html, BaseDir);
            }
        }
        static async Task Build(String html, String BaseDir)
        {
            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
            htmlDoc.LoadHtml(html);

            // List to store parsed data
            var categories = new List<(string MainCategory, string SubCategory, string Url)>();
            var level1NodesNoSubMenu = htmlDoc.DocumentNode.SelectNodes("//li[contains(@class, 'level1')]");

            // Select all Level 1 items
            var level1Nodes = htmlDoc.DocumentNode.SelectNodes("//li[@class='level1 hasChild parent']");


            var filteredNodes = level1NodesNoSubMenu
                .Where(node => !level1Nodes.Contains(node))
                .ToList();

            foreach (var Node in filteredNodes)
            {
                var level3Link = Node.SelectSingleNode(".//a");
                var level3SubCategory = level3Link?.InnerText.Trim() ?? "Unknown";
                var level3SubCategoryUrl = level3Link?.GetAttributeValue("href", "");

                categories.Add((level3SubCategory, level3SubCategory, level3SubCategoryUrl));
                Console.WriteLine($"    Nested SubCategory: {level3SubCategory} | URL: {level3SubCategoryUrl}");
            }

            if (level1Nodes == null)
            {
                Console.WriteLine("Error: No level1 nodes found.");
                return;
            }

            foreach (var level1Node in level1Nodes)
            {
                // Extract MainCategory
                var level1Link = level1Node.SelectSingleNode(".//a");
                var mainCategory = level1Link?.InnerText.Trim() ?? "Unknown";
                var mainCategoryUrl = level1Link?.GetAttributeValue("href", "");

                Console.WriteLine($"MainCategory: {mainCategory} | URL: {mainCategoryUrl}");

                // Extract Level 2 items
                var level2Nodes = level1Node.SelectNodes(".//ul[@class='level1 submenu']/li");
                if (level2Nodes == null)
                {
                    Console.WriteLine("Warning: No level2 nodes found under MainCategory: " + mainCategory);
                    continue;
                }

                foreach (var level2Node in level2Nodes)
                {
                    var level2Link = level2Node.SelectSingleNode(".//a");
                    var subCategory = level2Link?.InnerText.Trim() ?? "Unknown";
                    var subCategoryUrl = level2Link?.GetAttributeValue("href", "");

                    Console.WriteLine($"  SubCategory: {subCategory} | URL: {subCategoryUrl}");

                    // Check for nested Level 3 categories
                    var level3Nodes = level2Node.SelectNodes(".//ul[@class='level2 submenu']/li");
                    if (level3Nodes != null)
                    {
                        foreach (var level3Node in level3Nodes)
                        {
                            var level3Link = level3Node.SelectSingleNode(".//a");
                            var level3SubCategory = level3Link?.InnerText.Trim() ?? "Unknown";
                            var level3SubCategoryUrl = level3Link?.GetAttributeValue("href", "");

                            categories.Add((mainCategory, level3SubCategory, level3SubCategoryUrl));
                            Console.WriteLine($"    Nested SubCategory: {level3SubCategory} | URL: {level3SubCategoryUrl}");
                        }
                    }
                    else
                    {
                        categories.Add((mainCategory, subCategory, subCategoryUrl));
                    }
                }
            }

            // Output parsed data
            Console.WriteLine("\nParsed Data:");
            Console.WriteLine("=================");
            foreach (var (MainCategory, SubCategory, Url) in categories)
            {
                await Scrape(Url, MainCategory, SubCategory, BaseDir);
                Console.WriteLine($"(\"{MainCategory}\", \"{SubCategory}\", \"{Url}\"),");
            }
        }
        static async Task Scrape(string urlmain, String mainCategory, String Category, String BaseDir)
        {
            int productId = 1;
            int index = 1;

            List<ProductNaheed> products = new List<ProductNaheed>();
            
            int imageCount = 1;
            String outputDir = Application.StartupPath + BaseDir + "\\";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            outputDir = outputDir + mainCategory + "\\";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            outputDir = outputDir + Category + "\\";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            String url = urlmain;
        NextPage:
            if (index > 1)
                url = urlmain + "?p=" + index;
            index++;

        Retry:
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string htmlContent = await response.Content.ReadAsStringAsync();
                    HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    htmlDocument.LoadHtml(htmlContent);

                    var productNodes = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'product-item-info')]");

                    if (productNodes != null)
                    {
                        foreach (var productNode in productNodes)
                        {

                            string name = productNode.SelectSingleNode(".//a[contains(@class, 'product-item-link')]")?.InnerText.Trim() ?? "Unknown Product";
                            string price = productNode.SelectSingleNode(".//span[contains(@class, 'price')]")?.InnerText.Trim() ?? "Not Available";

                            Match unitMatch = Regex.Match(name, @"\b\d+(\.\d+)?\s?(ml|liter|g|kg|x\s?\d+|pack|pcs)\b", RegexOptions.IgnoreCase);
                            string unit = unitMatch.Success ? unitMatch.Value : "Not Specified";

                            var imageNode = productNode.SelectSingleNode(".//img[contains(@class, 'photo image')]");
                            if (imageNode != null && imageNode.GetAttributeValue("src", null) is string imageUrl)
                            {
                                string imageName = $"{Category}_{imageCount}.png";

                                await DownloadImage(outputDir, imageName, imageUrl, false);

                                imageCount++;
                                productId++;

                                products.Add(new ProductNaheed
                                {
                                    ProductId = productId,
                                    ProductName = name,
                                    ImageSource = imageName,
                                    Price = price,
                                    Unit = unit
                                });
                            }
                        }
                    }
                    if (htmlContent.Contains("action  next"))
                    {
                        goto NextPage;
                    }
                }
                else
                {
                    Console.WriteLine($"Failed to fetch {url}: Status Code {response.StatusCode}");
                    Thread.Sleep(10000);
                    goto Retry;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching URL {url}: {ex.Message}");
                Thread.Sleep(10000);
                goto Retry;
            }


            // Save to JSON file
            string json = System.Text.Json.JsonSerializer.Serialize(products, new JsonSerializerOptions { WriteIndented = true });
            await System.IO.File.WriteAllTextAsync(outputDir + Category + ".json", json);

            Console.WriteLine("Data scraped and saved to ShugarAndSalt.json");
        }
        private static Random random = new Random();
        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private static async Task<string> DownloadImage(string outputDir, string imageName, string imageUrl, bool upload)
        {
            RetryImage:
            try
            {
                imageName = imageName.Replace("/", "");
                // Download the image
                byte[] imageData = await client.GetByteArrayAsync(imageUrl);
                string imagePath = Path.Combine(outputDir, imageName);
                await System.IO.File.WriteAllBytesAsync(imagePath, imageData);

                
                string folderName = new DirectoryInfo(outputDir).Name; // Optional: specify a folder in Cloudinary
                string publicId = GenerateRandomString(10); // Use image name without extension
                string uploadedUrl = imagePath;
                if (upload)
                    uploadedUrl = await CloudinaryUploader.UploadImageToCloudinary(imagePath, folderName, publicId);
                return uploadedUrl;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to download image {imageUrl}: {ex.Message}");
                Thread.Sleep(100);
                imageUrl = "https://img.freepik.com/free-vector/graphic-design-vector-illustration_24908-54512.jpg?t=st=1738901524~exp=1738905124~hmac=d48c4d3dd7d3de81ca326fe08f5ecc7a5818cd6c5f6d6ca96bca104321939141&w=1060";
                goto RetryImage;
            }
        }
        private async void buttonAlfatha_Click(object sender, EventArgs e)
        {
            // Base URL for Shopify API
            string baseUrl = "https://alfatah.pk/products.json";
            int limit = 249; // Maximum limit per request
            int totalPages = 366; // Total number of pages
            List<Product> allProducts = new List<Product>();

            // Add browser-like headers
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");
            client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            // Loop through all pages
            for (int page = 1; page <= totalPages; page++)
            {
                try
                {
                    // Construct the API URL with pagination
                    string url = $"{baseUrl}?limit={limit}&page={page}";
                    HttpResponseMessage response = await client.GetAsync(url);
                    string responseData = await response.Content.ReadAsStringAsync();
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        // Deserialize JSON response into Root object
                        Root root = JsonConvert.DeserializeObject<Root>(responseData);

                        if (root != null && root.Products != null)
                        {
                            allProducts.AddRange(root.Products); // Add products to the combined list
                            Console.WriteLine($"Page {page}: {root.Products.Count} products fetched.");
                        }
                        else
                        {
                            Console.WriteLine($"Page {page}: No products found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to fetch page {page}. Status Code: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred on page {page}: {ex.Message}");
                }
            }

            // Combine all products into a single JSON object
            Root combinedRoot = new Root { Products = allProducts };
            string combinedJson = JsonConvert.SerializeObject(combinedRoot, Formatting.Indented);

            // Save the JSON to a file
            string filePath = Application.StartupPath + "combined_products.json";
            await File.WriteAllTextAsync(filePath, combinedJson);

            Console.WriteLine($"Scraping completed. Combined JSON saved to {filePath}");
        }
        public class Filters
        {
            public String dir;
            public List<string> Bad { get; set; }
            public List<string> BadStrict { get; set; }
            public List<string> Good { get; set; }
            public List<string> GoodStrict { get; set; }
            
        }
        private async void buttonAlfathaFromDisk_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Application.StartupPath, "combined_products.json");
            if (!File.Exists(filePath)) { MessageBox.Show("File not found: " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            Root combinedRoot = JsonConvert.DeserializeObject<Root>(await File.ReadAllTextAsync(filePath));
            if (combinedRoot?.Products == null || !combinedRoot.Products.Any()) { MessageBox.Show("No products found in the file.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            List<Filters> filters = new List<Filters>();
            filters.Add(new Filters
            {
                dir = "Fruits",
                Bad = new List<string>
                {
                    "VegetablesBarcode"
                },
                BadStrict = new List<string>
                {
                    "Vegetables",
                    "Vegitables"
                },
                Good = new List<string>
                {
                    "Friuits \u0026 Vegetables",
                    "Fruits & Vegitables",
                    "Friuits & Vegetables",
                    "Fruits"
                },
                GoodStrict = new List<string>
                {
                }
            });
            filters.Add(new Filters
            {
                dir = "Vegetables",
                Bad = new List<string>
                {
                    "Fruits Barcode"
                },
                BadStrict = new List<string>
                {
                    "Fruits",
                },
                Good = new List<string>
                {
                    "Vegetables",
                    "Vegitables",
                    "Friuits \u0026 Vegetables",
                    "Fruits & Vegitables",
                    "Friuits & Vegetables",
                }
            });

            filters.Add(new Filters
            {
                dir = "Salt",
                Bad = new List<string>
                {
                    
                },
                BadStrict = new List<string>
                {
                    
                },
                Good = new List<string>
                {
                    "Salt",
                }
            });
            filters.Add(new Filters
            {
                dir = "Sugar",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {

                },
                Good = new List<string>
                {
                    "icing sugar",
                    "Sugar",
                    "Sweetner"
                }
            });
            filters.Add(new Filters
            {
                dir = "Rice",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {

                },
                Good = new List<string>
                {
                    "Rice Products",
                }
            });
            filters.Add(new Filters
            {
                dir = "Milk",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                    "Crockery",
                    "Makeup",
                    "Dog Food",
                },
                Good = new List<string>
                {
                    "Milk",
                }
            });

            filters.Add(new Filters
            {
                dir = "Butter And Margarine",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {

                },
                Good = new List<string>
                {
                    "Butter",
                    "Margarine"
                }
            });
            filters.Add(new Filters
            {
                dir = "Cheese And Cream",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                    "DISH WASH"
                },
                Good = new List<string>
                {
                    "Cheese",
                    "Cream"
                }
            });
            filters.Add(new Filters
            {
                dir = "Powdered Milk",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                },
                Good = new List<string>
                {
                    "Milk Powders",
                }
            });

            filters.Add(new Filters
            {
                dir = "Yougurt",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                },
                Good = new List<string>
                {
                    "C_yougurt",
                    "Yogurt",
                    "Raita"
                }
            });
            filters.Add(new Filters
            {
                dir = "Fresh Beef",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                    "Frozen Items"
                },
                Good = new List<string>
                {
                    "meat",
                }
            });
            filters.Add(new Filters
            {
                dir = "Fresh Chicken",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                    "Frozen Items"
                },
                Good = new List<string>
                {
                    "Meat Expert",
                }
            });
            filters.Add(new Filters
            {
                dir = "Fresh Mutton",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                    "Frozen Items"
                },
                Good = new List<string>
                {
                    "mutton",
                }
            });

          




            filters.Add(new Filters
            {
                dir = "Ghee",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                    "Frozen Items"
                },
                Good = new List<string>
                {
                    "Ghee",
                }
            });

            filters.Add(new Filters
            {
                dir = "Olive Oil",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                    "Oil",
                    "Personal Care",
                    "Hair care",
                    "Skin Care",
                    "Body Wash",
                    "Shampoos & Conditioners",
                    "Gels & Oils",
                    "hair care",
                },
                Good = new List<string>
                {
                    "Olive Oil"
                }
            });
            filters.Add(new Filters
            {
                dir = "Cooking Oil",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                    "Olive Oil"
                },
                Good = new List<string>
                {
                    "Oil",
                }
            });
            filters.Add(new Filters
            {
                dir = " Frozen Fries",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                    "Olive Oil"

                },
                Good = new List<string>
                {
                    "Frozen Fries",
                    "Opa Fries",

                }
            });

            filters.Add(new Filters
            {
                dir = " Frozen Chicken And Beef",
                Bad = new List<string>
                {

                },
                BadStrict = new List<string>
                {
                    "Frozen Fries",
                    "Opa Fries",
                    "Dry Fruit & Dates",
                    "Tin Foods",
                    "Noodles & Pastas",
                    "pasta",
                },
                Good = new List<string>
                {
                    "K & N",
                   "Almasa Smoked",
                    "Frozen Items",
                    "B_Big Bird",
                    "Big Bird",
                    "Blue Water",
                    "Chef One",
                }
            });
            foreach (Filters filter in filters)
            {
                //Filters filter = filters[filters.Count-1];
                String outputDir = Application.StartupPath +"Alfatha/"+ filter.dir;
                removeAllFilesFromDir(outputDir);
                if (!Directory.Exists(outputDir))
                    Directory.CreateDirectory(outputDir);

                await ApplyFiltersAsync(outputDir, filter, combinedRoot);
            }
        }
        async Task ApplyFiltersAsync(String outputDir, Filters filter, Root combinedRoot)
        {   
            // Filter products
            var filteredProducts
                            = combinedRoot.Products.Where(p => p.Tags != null && p.Tags.Any(tag => filter.Good.Any(goodTag => tag.Equals(goodTag, StringComparison.OrdinalIgnoreCase)))).ToList();

            filteredProducts = filteredProducts.Where(product =>
                // Check if no tag matches the strict condition
                    !product.Tags.Any(tag => filter.BadStrict.Any(strict => strict == tag)) &&
                // Check if no tag matches the substring condition
                    !product.Tags.Any(tag => filter.Bad.Any(substring => tag.Contains(substring, StringComparison.OrdinalIgnoreCase)))).ToList();

            for (int i = 0; i < filteredProducts.Count; i++)
            {
                for (int x = 0; x < filteredProducts[i].Tags.Count; x++)
                {
                    foreach (var BS in filter.BadStrict)
                    {
                        if (BS == filteredProducts[i].Tags[x])
                        {
                            //remove filtered
                        }
                    }
                    foreach (var B in filter.Bad)
                    {
                        if (filteredProducts[i].Tags[x].Contains(B))
                        {
                            //remove filtered
                        }
                    }
                }
            }

            // Report filtered products
            string report = "Filtered Products (Fruits & Vegetables):\n\n";
            report += "Product Titles:\n";
            report += string.Join("\n", filteredProducts.Select(p => p.Title));
            report += $"\n\nTotal Products Found: {filteredProducts.Count}";

            // Create a new Root object with filtered products
            Root filteredRoot = new Root { Products = filteredProducts };

            // Serialize the filtered products back to a JSON file
            string filteredJson = JsonConvert.SerializeObject(filteredRoot, Formatting.Indented);
            await File.WriteAllTextAsync(outputDir + "/0_" + filter.dir + "_Filtered.json", filteredJson);

            // Print the report to console
            Console.Clear();
            Console.WriteLine(report);

            //Build Final List for the skimed products
            await SkimAlfatahAsync(filteredProducts, outputDir, filter.dir);
        }
        private async Task SkimAlfatahAsync(List<Product> filteredProducts, string outputDir, String Category)
        {
            int index = 0;
            List<AlfathaProduct> Products = new();
            foreach(Product product in filteredProducts)
            {
                String Name = product.Title.Trim();
                String Unit = product.Variants[0].Option1.Trim();
                if (Unit.Contains("Default Title"))
                {
                   if (Name.EndsWith(" PC"))
                    {
                        Name = Name.Replace(" PC", "");
                        Unit = "Piece";
                    }
                    else
                    if (Name.Contains("/ 250g"))
                    {
                        Name = Name.Replace("/ 250g", "");
                        Unit = "250 G";
                    }
                    else
                    if (Name.Contains(" 150g"))
                    {
                        Name = Name.Replace("150g", "");
                        Unit = "150 G";
                    }
                    else
                    if (Name.Contains("(1-Dozen)"))
                    {
                        Name = Name.Replace("(1-Dozen)", "");
                        Unit = "1-Dozen";
                    }
                    else
                    if (Name.Contains("(Bunch)"))
                    {
                        Name = Name.Replace("(Bunch)", "");
                        Unit = "Bunch";
                    }
                    else
                    if(Name.Contains("/pck 250g"))
                    {
                        Name = Name.Replace("/pck 250g", "");
                        Unit = "Pack 250 G";
                    }else
                    if (Name.Contains("/pck"))
                    {
                        Name = Name.Replace("/pck", "");
                        Unit = "Pack";
                    }else
                    if(Name.Contains(" 200g"))
                    {
                        Name = Name.Replace(" 200g", "");
                        Unit = "200 G";
                    }else
                    Console.WriteLine(Name);
                }
                Name = Name.Replace("&", "And");
                Name = Name.Replace("%", " Percent");
                Name = Regex.Replace(Name, @"\s*\(.*?\)", "").Trim();

                String Price = product.Variants[0].Price.Trim();
                String ImageSrc = index + "_" + Name + ".png";

                Console.WriteLine($"{index,-10} {Name,-30} {Unit,-15} {Price,-10} {ImageSrc,-30}");
                
                Products.Add(new AlfathaProduct()
                {
                    ProductId = -1,
                    ProductName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Name.ToLower()).Replace("*", "_"),
                    ImageSource = product.Images[0].Src,
                    Price = Price,
                    Unit = Unit
                });

                index++;
            };
            
            // Remove all products that have duplicate ProductName
            Products = Products.GroupBy(p => p.ProductName)
                                .Select(g => g.First())
                                .ToList().OrderBy(p => p.ProductName)
                                .ToList();
            
            for (index = 0; index < Products.Count; index++)
            {
                AlfathaProduct product = Products[index];
                String ImageSrc = index + "_" + product.ProductName + ".png";
                ImageSrc = await DownloadImage(outputDir, ImageSrc, product.ImageSource, true);
                Products[index].ImageSource = ImageSrc;
                Products[index].ProductId = index;
            }
            string json = System.Text.Json.JsonSerializer.Serialize(Products, new JsonSerializerOptions{WriteIndented = true  });

            // Save the JSON to a file
            File.WriteAllText(outputDir+"/0_"+ Category+".json", json);

            // Output to console (optional)
            Console.WriteLine(json);
        }
        public void removeAllFilesFromDir(String directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                // Get all files in the directory
                var files = Directory.GetFiles(directoryPath);

                foreach (var file in files)
                {
                    // Delete each file
                    File.Delete(file);
                }

                Console.WriteLine("All files have been deleted from the directory.");
            }
            else
            {
                Console.WriteLine("Directory does not exist.");
            }
        }
    }
    public class ProductNaheed
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageSource { get; set; }
        public string Price { get; set; }
        public string Unit { get; set; }
    }
    public class AlfathaProduct
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageSource { get; set; }
        public string Price { get; set; }
        public string Unit { get; set; }
    }
    public class Product
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Handle { get; set; }
        public string BodyHtml { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Vendor { get; set; }
        public string ProductType { get; set; }
        public List<string> Tags { get; set; }
        public List<Variant> Variants { get; set; }
        public List<Image> Images { get; set; }
        public List<Option> Options { get; set; }
    }
    public class Variant
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Sku { get; set; }
        public bool RequiresShipping { get; set; }
        public bool Taxable { get; set; }
        public object FeaturedImage { get; set; } // Set as object since it might be null
        public bool Available { get; set; }
        public string Price { get; set; }
        public int Grams { get; set; }
        public string CompareAtPrice { get; set; }
        public int Position { get; set; }
        public long ProductId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class Image
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Position { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long ProductId { get; set; }
        public List<long> VariantIds { get; set; }
        public string Src { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
    public class Option
    {
        public string Name { get; set; }
        public int Position { get; set; }
        public List<string> Values { get; set; }
    }
    public class Root
    {
        public List<Product> Products { get; set; }
    }
}
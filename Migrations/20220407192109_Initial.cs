using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GBCSport_The_Knight.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    City = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    StateProvince = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(51)", maxLength: 51, nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOpened = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dateClosed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId");
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => new { x.ProductId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Products_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "ABW", "533", "Aruba" },
                    { "AFG", "004", "Afghanistan" },
                    { "AGO", "024", "Angola" },
                    { "AIA", "660", "Anguilla" },
                    { "ALA", "248", "Åland Islands" },
                    { "ALB", "008", "Albania" },
                    { "AND", "020", "Andorra" },
                    { "ARE", "784", "United Arab Emirates" },
                    { "ARG", "032", "Argentina" },
                    { "ARM", "051", "Armenia" },
                    { "ASM", "016", "American Samoa" },
                    { "ATA", "010", "Antarctica" },
                    { "ATF", "260", "French Southern Territories" },
                    { "ATG", "028", "Antigua and Barbuda" },
                    { "AUS", "036", "Australia" },
                    { "AUT", "040", "Austria" },
                    { "AZE", "031", "Azerbaijan" },
                    { "BDI", "108", "Burundi" },
                    { "BEL", "056", "Belgium" },
                    { "BEN", "204", "Benin" },
                    { "BES", "535", "Bonaire, Sint Eustatius and Saba" },
                    { "BFA", "854", "Burkina Faso" },
                    { "BGD", "050", "Bangladesh" },
                    { "BGR", "100", "Bulgaria" },
                    { "BHR", "048", "Bahrain" },
                    { "BHS", "044", "Bahamas" },
                    { "BIH", "070", "Bosnia and Herzegovina" },
                    { "BLM", "652", "Saint Barthélemy" },
                    { "BLR", "112", "Belarus" },
                    { "BLZ", "084", "Belize" },
                    { "BMU", "060", "Bermuda" },
                    { "BOL", "068", "Bolivia (Plurinational State of)" },
                    { "BRA", "076", "Brazil" },
                    { "BRB", "052", "Barbados" },
                    { "BRN", "096", "Brunei Darussalam" },
                    { "BTN", "064", "Bhutan" },
                    { "BVT", "074", "Bouvet Island" },
                    { "BWA", "072", "Botswana" },
                    { "CAF", "140", "Central African Republic" },
                    { "CAN", "124", "Canada" },
                    { "CCK", "166", "Cocos (Keeling) Islands" },
                    { "CHE", "756", "Switzerland" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "CHL", "152", "Chile" },
                    { "CHN", "156", "China" },
                    { "CIV", "384", "Côte d'Ivoire" },
                    { "CMR", "120", "Cameroon" },
                    { "COD", "180", "Congo, Democratic Republic of the" },
                    { "COG", "178", "Congo" },
                    { "COK", "184", "Cook Islands" },
                    { "COL", "170", "Colombia" },
                    { "COM", "174", "Comoros" },
                    { "CPV", "132", "Cabo Verde" },
                    { "CRI", "188", "Costa Rica" },
                    { "CUB", "192", "Cuba" },
                    { "CUW", "531", "Curaçao" },
                    { "CXR", "162", "Christmas Island" },
                    { "CYM", "136", "Cayman Islands" },
                    { "CYP", "196", "Cyprus" },
                    { "CZE", "203", "Czechia" },
                    { "DEU", "276", "Germany" },
                    { "DJI", "262", "Djibouti" },
                    { "DMA", "212", "Dominica" },
                    { "DNK", "208", "Denmark" },
                    { "DOM", "214", "Dominican Republic" },
                    { "DZA", "012", "Algeria" },
                    { "ECU", "218", "Ecuador" },
                    { "EGY", "818", "Egypt" },
                    { "ERI", "232", "Eritrea" },
                    { "ESH", "732", "Western Sahara" },
                    { "ESP", "724", "Spain" },
                    { "EST", "233", "Estonia" },
                    { "ETH", "231", "Ethiopia" },
                    { "FIN", "246", "Finland" },
                    { "FJI", "242", "Fiji" },
                    { "FLK", "238", "Falkland Islands (Malvinas)" },
                    { "FRA", "250", "France" },
                    { "FRO", "234", "Faroe Islands" },
                    { "FSM", "583", "Micronesia (Federated States of)" },
                    { "GAB", "266", "Gabon" },
                    { "GBR", "826", "United Kingdom of Great Britain and Northern Ireland" },
                    { "GEO", "268", "Georgia" },
                    { "GGY", "831", "Guernsey" },
                    { "GHA", "288", "Ghana" },
                    { "GIB", "292", "Gibraltar" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "GIN", "324", "Guinea" },
                    { "GLP", "312", "Guadeloupe" },
                    { "GMB", "270", "Gambia" },
                    { "GNB", "624", "Guinea-Bissau" },
                    { "GNQ", "226", "Equatorial Guinea" },
                    { "GRC", "300", "Greece" },
                    { "GRD", "308", "Grenada" },
                    { "GRL", "304", "Greenland" },
                    { "GTM", "320", "Guatemala" },
                    { "GUF", "254", "French Guiana" },
                    { "GUM", "316", "Guam" },
                    { "GUY", "328", "Guyana" },
                    { "HKG", "344", "Hong Kong" },
                    { "HMD", "334", "Heard Island and McDonald Islands" },
                    { "HND", "340", "Honduras" },
                    { "HRV", "191", "Croatia" },
                    { "HTI", "332", "Haiti" },
                    { "HUN", "348", "Hungary" },
                    { "IDN", "360", "Indonesia" },
                    { "IMN", "833", "Isle of Man" },
                    { "IND", "356", "India" },
                    { "IOT", "086", "British Indian Ocean Territory" },
                    { "IRL", "372", "Ireland" },
                    { "IRN", "364", "Iran (Islamic Republic of)" },
                    { "IRQ", "368", "Iraq" },
                    { "ISL", "352", "Iceland" },
                    { "ISR", "376", "Israel" },
                    { "ITA", "380", "Italy" },
                    { "JAM", "388", "Jamaica" },
                    { "JEY", "832", "Jersey" },
                    { "JOR", "400", "Jordan" },
                    { "JPN", "392", "Japan" },
                    { "KAZ", "398", "Kazakhstan" },
                    { "KEN", "404", "Kenya" },
                    { "KGZ", "417", "Kyrgyzstan" },
                    { "KHM", "116", "Cambodia" },
                    { "KIR", "296", "Kiribati" },
                    { "KNA", "659", "Saint Kitts and Nevis" },
                    { "KOR", "410", "Korea, Republic of" },
                    { "KWT", "414", "Kuwait" },
                    { "LAO", "418", "Lao People's Democratic Republic" },
                    { "LBN", "422", "Lebanon" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "LBR", "430", "Liberia" },
                    { "LBY", "434", "Libya" },
                    { "LCA", "662", "Saint Lucia" },
                    { "LIE", "438", "Liechtenstein" },
                    { "LKA", "144", "Sri Lanka" },
                    { "LSO", "426", "Lesotho" },
                    { "LTU", "440", "Lithuania" },
                    { "LUX", "442", "Luxembourg" },
                    { "LVA", "428", "Latvia" },
                    { "MAC", "446", "Macao" },
                    { "MAF", "663", "Saint Martin (French part)" },
                    { "MAR", "504", "Morocco" },
                    { "MCO", "492", "Monaco" },
                    { "MDA", "498", "Moldova, Republic of" },
                    { "MDG", "450", "Madagascar" },
                    { "MDV", "462", "Maldives" },
                    { "MEX", "484", "Mexico" },
                    { "MHL", "584", "Marshall Islands" },
                    { "MKD", "807", "North Macedonia" },
                    { "MLI", "466", "Mali" },
                    { "MLT", "470", "Malta" },
                    { "MMR", "104", "Myanmar" },
                    { "MNE", "499", "Montenegro" },
                    { "MNG", "496", "Mongolia" },
                    { "MNP", "580", "Northern Mariana Islands" },
                    { "MOZ", "508", "Mozambique" },
                    { "MRT", "478", "Mauritania" },
                    { "MSR", "500", "Montserrat" },
                    { "MTQ", "474", "Martinique" },
                    { "MUS", "480", "Mauritius" },
                    { "MWI", "454", "Malawi" },
                    { "MYS", "458", "Malaysia" },
                    { "MYT", "175", "Mayotte" },
                    { "NAM", "516", "Namibia" },
                    { "NCL", "540", "New Caledonia" },
                    { "NER", "562", "Niger" },
                    { "NFK", "574", "Norfolk Island" },
                    { "NGA", "566", "Nigeria" },
                    { "NIC", "558", "Nicaragua" },
                    { "NIU", "570", "Niue" },
                    { "NLD", "528", "Netherlands" },
                    { "NOR", "578", "Norway" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "NPL", "524", "Nepal" },
                    { "NRU", "520", "Nauru" },
                    { "NZL", "554", "New Zealand" },
                    { "OMN", "512", "Oman" },
                    { "PAK", "586", "Pakistan" },
                    { "PAN", "591", "Panama" },
                    { "PCN", "612", "Pitcairn" },
                    { "PER", "604", "Peru" },
                    { "PHL", "608", "Philippines" },
                    { "PLW", "585", "Palau" },
                    { "PNG", "598", "Papua New Guinea" },
                    { "POL", "616", "Poland" },
                    { "PRI", "630", "Puerto Rico" },
                    { "PRK", "408", "Korea (Democratic People's Republic of)" },
                    { "PRT", "620", "Portugal" },
                    { "PRY", "600", "Paraguay" },
                    { "PSE", "275", "Palestine, State of" },
                    { "PYF", "258", "French Polynesia" },
                    { "QAT", "634", "Qatar" },
                    { "REU", "638", "Réunion" },
                    { "ROU", "642", "Romania" },
                    { "RUS", "643", "Russian Federation" },
                    { "RWA", "646", "Rwanda" },
                    { "SAU", "682", "Saudi Arabia" },
                    { "SDN", "729", "Sudan" },
                    { "SEN", "686", "Senegal" },
                    { "SGP", "702", "Singapore" },
                    { "SGS", "239", "South Georgia and the South Sandwich Islands" },
                    { "SHN", "654", "Saint Helena, Ascension and Tristan da Cunha" },
                    { "SJM", "744", "Svalbard and Jan Mayen" },
                    { "SLB", "090", "Solomon Islands" },
                    { "SLE", "694", "Sierra Leone" },
                    { "SLV", "222", "El Salvador" },
                    { "SMR", "674", "San Marino" },
                    { "SOM", "706", "Somalia" },
                    { "SPM", "666", "Saint Pierre and Miquelon" },
                    { "SRB", "688", "Serbia" },
                    { "SSD", "728", "South Sudan" },
                    { "STP", "678", "Sao Tome and Principe" },
                    { "SUR", "740", "SuricountryName" },
                    { "SVK", "703", "Slovakia" },
                    { "SVN", "705", "Slovenia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryCode", "CountryName" },
                values: new object[,]
                {
                    { "SWE", "752", "Sweden" },
                    { "SWZ", "748", "Eswatini" },
                    { "SXM", "534", "Sint Maarten (Dutch part)" },
                    { "SYC", "690", "Seychelles" },
                    { "SYR", "760", "Syrian Arab Republic" },
                    { "TCA", "796", "Turks and Caicos Islands" },
                    { "TCD", "148", "Chad" },
                    { "TGO", "768", "Togo" },
                    { "THA", "764", "Thailand" },
                    { "TJK", "762", "Tajikistan" },
                    { "TKL", "772", "Tokelau" },
                    { "TKM", "795", "Turkmenistan" },
                    { "TLS", "626", "Timor-Leste" },
                    { "TON", "776", "Tonga" },
                    { "TTO", "780", "Trinidad and Tobago" },
                    { "TUN", "788", "Tunisia" },
                    { "TUR", "792", "Turkey" },
                    { "TUV", "798", "Tuvalu" },
                    { "TWN", "158", "Taiwan, Province of China" },
                    { "TZA", "834", "Tanzania, United Republic of" },
                    { "UGA", "800", "Uganda" },
                    { "UKR", "804", "Ukraine" },
                    { "UMI", "581", "United States Minor Outlying Islands" },
                    { "URY", "858", "Uruguay" },
                    { "USA", "840", "United States of America" },
                    { "UZB", "860", "Uzbekistan" },
                    { "VAT", "336", "Holy See" },
                    { "VCT", "670", "Saint Vincent and the Grenadines" },
                    { "VEN", "862", "Venezuela (Bolivarian Republic of)" },
                    { "VGB", "092", "Virgin Islands (British)" },
                    { "VIR", "850", "Virgin Islands (U.S.)" },
                    { "VNM", "704", "Viet Nam" },
                    { "VUT", "548", "Vanuatu" },
                    { "WLF", "876", "Wallis and Futuna" },
                    { "WSM", "882", "Samoa" },
                    { "YEM", "887", "Yemen" },
                    { "ZAF", "710", "South Africa" },
                    { "ZMB", "894", "Zambia" },
                    { "ZWE", "716", "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductCode", "ProductName", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 7.54m, "HOCK21", "Hockey PPV 2021", new DateTime(2020, 6, 14, 6, 41, 13, 0, DateTimeKind.Unspecified) },
                    { 2, 9.68m, "SOCK01", "Soccer Hooligan Fights 1.0", new DateTime(2020, 10, 20, 2, 58, 26, 0, DateTimeKind.Unspecified) },
                    { 3, 7.07m, "ROCK02", "Rock Throwing Championship 2.0", new DateTime(2020, 8, 8, 19, 58, 8, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Price", "ProductCode", "ProductName", "ReleaseDate" },
                values: new object[,]
                {
                    { 4, 3.87m, "ZUCKHUNT", "Hunting Finals - Zuckerberg edition", new DateTime(2020, 4, 29, 18, 6, 30, 0, DateTimeKind.Unspecified) },
                    { 5, 8.38m, "COUCH20", "Couch Potato Faceoff PPV Event", new DateTime(2021, 1, 30, 17, 57, 14, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "nformoy0@shinystat.com", "Neil Formoy", "(166) 8471988" },
                    { 2, "smichieli1@ucla.edu", "Stoddard Michieli", "(352) 3948039" },
                    { 3, "splaskett2@diigo.com", "Saunderson Plaskett", "(641) 8705955" },
                    { 4, "klynthal3@bloomberg.com", "Kylen Lynthal", "(385) 9669354" },
                    { 5, "cmathy4@google.co.uk", "Clari Mathy", "(928) 1519176" },
                    { 6, "ccracknall5@t-online.de", "Cullen Cracknall", "(396) 2561309" },
                    { 7, "amixture6@mapquest.com", "Alisander Mixture", "(539) 9826601" },
                    { 8, "hbaumford7@alibaba.com", "Hugh Baumford", "(313) 6544268" },
                    { 9, "tdearnly8@amazon.co.uk", "Tybi Dearnly", "(945) 9132417" },
                    { 10, "bbedson9@skyrock.com", "Bobina Bedson", "(582) 6930219" },
                    { 11, "jcopyna@marriott.com", "Joni Copyn", "(658) 2184530" },
                    { 12, "tzanninib@php.net", "Travus Zannini", "(881) 1956460" },
                    { 13, "rcorradic@tuttocitta.it", "Rois Corradi", "(854) 8298792" },
                    { 14, "lmaryond@topsy.com", "Linn Maryon", "(282) 7960687" },
                    { 15, "mpeffere@thetimes.co.uk", "Margery Peffer", "(786) 3655469" },
                    { 16, "vwoodyearf@ted.com", "Van Woodyear", "(878) 8746082" },
                    { 17, "dbeverageg@aboutads.info", "Doll Beverage", "(186) 8941499" },
                    { 18, "syeabsleyh@mapquest.com", "Salome Yeabsley", "(196) 4370797" },
                    { 19, "dbucheri@pbs.org", "Di Bucher", "(658) 6414862" },
                    { 20, "kkernockej@netvibes.com", "Kelcy Kernocke", "(495) 1613647" },
                    { 21, "akincaidk@mozilla.com", "Augustine Kincaid", "(637) 9140087" },
                    { 22, "kharwinl@seesaa.net", "Karel Harwin", "(139) 1248750" },
                    { 23, "lcarrodusm@cloudflare.com", "Lexy Carrodus", "(546) 5259083" },
                    { 24, "rgregoren@alexa.com", "Reg Gregore", "(497) 9522755" },
                    { 25, "hpagano@alibaba.com", "Henri Pagan", "(673) 5337764" },
                    { 26, "msimoncellip@vimeo.com", "Magnum Simoncelli", "(173) 9479908" },
                    { 27, "clamboleq@latimes.com", "Clarence Lambole", "(488) 5840432" },
                    { 28, "ttrobeyr@rediff.com", "Tillie Trobey", "(414) 6765629" },
                    { 29, "svasilkovs@bigcartel.com", "Stanwood Vasilkov", "(745) 5655554" },
                    { 30, "grobertsent@rambler.ru", "Gelya Robertsen", "(931) 7061643" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "Phone", "PostalCode", "StateProvince" },
                values: new object[,]
                {
                    { 1, "94175 Spaight Pass", "Linköping", "CAN", "bferronier0@ft.com", "Briant", "Ferronier", "441-524-5742", "589 41", "Östergötland" },
                    { 2, "6 Carioca Street", "Hrušovany u Brna", "CAN", "pparslow1@usa.gov", "Pauly", "Parslow", "283-811-1291", "664 62", "Ontario" },
                    { 3, "13476 Northwestern Lane", "Mirriah", "CAN", "bcordle2@google.com.br", "Beret", "Cordle", "230-306-7553", "664 62", "Ontario" },
                    { 4, "9 Southridge Street", "Vahdat", "USA", "bmcness3@techcrunch.com", "Bernard", "McNess", "339-957-2666", "664 62", "Ontario" },
                    { 5, "14 Arkansas Center", "Kurortnyy", "USA", "rewington4@ucsd.edu", "Roberta", "Ewington", "588-541-4858", "197738", "Ohio" },
                    { 6, "0 Algoma Point", "Yong’an", "USA", "rblaxley5@skyrock.com", "Ricoriki", "Blaxley", "340-227-0604", "664 62", "Ontario" },
                    { 7, "5657 Mariners Cove Terrace", "Zamarski", "USA", "gshay6@epa.gov", "Garey", "Shay", "953-845-7062", "43-419", "Arizona" },
                    { 8, "4187 Mitchell Center", "Martapura", "USA", "syurocjkin7@hud.gov", "Stanislaus", "Yurocjkin", "250-839-9907", "66699", "Mars" },
                    { 9, "09265 Lukken Way", "Wręczyca Wielka", "USA", "bspicer8@google.it", "Bendicty", "Spicer", "740-985-6558", "42-284", "Pluto" },
                    { 10, "24223 Birchwood Junction", "Casais", "USA", "fboydell9@ustream.tv", "Faydra", "Boydell", "739-139-5608", "3100-806", "Leiria" },
                    { 11, "58 Dwight Avenue", "Cayna", "USA", "amordea@ca.gov", "Archaimbaud", "Morde", "121-134-1498", "234234", "Ontario" },
                    { 12, "9565 Hoepker Point", "Nagorsk", "USA", "spitbladob@yelp.com", "Susanne", "Pitblado", "491-587-2265", "613261", "New York" },
                    { 13, "2 Donald Center", "Ārt Khwājah", "USA", "ldoulc@sciencedaily.com", "Lyon", "Doul", "904-538-4032", "22233", "Alberta" },
                    { 14, "70574 Warrior Parkway", "Bealanana", "USA", "kbraithwaited@dailymotion.com", "Kaitlynn", "Braithwaite", "712-460-6508", "22345", "Newfoundland" },
                    { 15, "870 Milwaukee Street", "Puncaksari", "USA", "sgeroe@google.ru", "Suzy", "Gero", "163-910-1575", "543643", "Florida" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CustomerId", "Description", "ProductId", "TechnicianId", "Title", "dateClosed", "dateOpened" },
                values: new object[] { 1, 2, "This is a seeded description placeholder", 3, 4, "I'm tryin' Captain, can't reach the button", new DateTime(2020, 6, 14, 6, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CustomerId", "Description", "ProductId", "TechnicianId", "Title", "dateClosed", "dateOpened" },
                values: new object[] { 2, 1, "This is a seeded description placeholder", 5, 4, "Tester's Delight Error", new DateTime(2020, 6, 14, 12, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 3, 41, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CustomerId", "Description", "ProductId", "TechnicianId", "Title", "dateClosed", "dateOpened" },
                values: new object[] { 3, 9, "This is a seeded description placeholder", 4, 6, "To be or not to be", new DateTime(2020, 6, 14, 17, 41, 13, 0, DateTimeKind.Unspecified), new DateTime(2020, 6, 10, 3, 21, 13, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomerId",
                table: "Incidents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductId",
                table: "Incidents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianId",
                table: "Incidents",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_CustomerId",
                table: "Registrations",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}

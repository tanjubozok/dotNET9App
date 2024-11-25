using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CratedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    CratedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(32)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CratedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Thumbnail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    SeoTag = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CratedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    CratedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CratedDate", "CreatedByName", "Description", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Name", "Note" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 16, 23, 58, 10, 546, DateTimeKind.Local).AddTicks(5764), "Fausto Tillman", "Magni et porro quis et rerum et nobis et nemo.", false, true, "Osbaldo Stanton", new DateTime(2024, 11, 25, 17, 27, 49, 436, DateTimeKind.Local).AddTicks(1851), "Automotive", "Sit voluptatum quis consectetur ut." },
                    { 2, new DateTime(2023, 11, 27, 15, 9, 26, 84, DateTimeKind.Local).AddTicks(3294), "Diego Jerde", "Porro quia nesciunt cumque perferendis expedita occaecati unde doloremque sint.", false, false, "Sim Bernier", new DateTime(2024, 11, 25, 22, 20, 5, 348, DateTimeKind.Local).AddTicks(2522), "Industrial", "Accusantium soluta maxime enim omnis." },
                    { 3, new DateTime(2024, 10, 2, 19, 16, 28, 766, DateTimeKind.Local).AddTicks(6137), "Karlee McClure", "Minus numquam facere sed fuga et autem aut voluptas aut.", false, false, "Penelope Cartwright", new DateTime(2024, 11, 25, 6, 45, 39, 767, DateTimeKind.Local).AddTicks(4629), "Industrial", "Voluptatem laborum id eius odio." },
                    { 4, new DateTime(2024, 6, 30, 10, 36, 54, 51, DateTimeKind.Local).AddTicks(9429), "Leonard Wiegand", "Et consequatur quaerat cupiditate rem facere maiores repellat omnis beatae.", true, false, "Lester Kutch", new DateTime(2024, 11, 25, 18, 13, 5, 327, DateTimeKind.Local).AddTicks(3505), "Health", "Asperiores non sit corrupti quo." },
                    { 5, new DateTime(2024, 9, 10, 4, 41, 42, 230, DateTimeKind.Local).AddTicks(3497), "Urban Fritsch", "Quia non consequatur error voluptates rem aut maxime velit molestias.", false, false, "Mathilde Daniel", new DateTime(2024, 11, 25, 13, 49, 56, 205, DateTimeKind.Local).AddTicks(1562), "Music", "Non explicabo quis magnam placeat." },
                    { 6, new DateTime(2024, 5, 19, 3, 39, 32, 217, DateTimeKind.Local).AddTicks(2866), "Nadia Beahan", "Et eligendi nulla neque ea ad harum culpa impedit modi.", true, false, "Manuel Smith", new DateTime(2024, 11, 25, 22, 14, 55, 503, DateTimeKind.Local).AddTicks(9135), "Tools", "Ad explicabo quo eaque enim." },
                    { 7, new DateTime(2024, 6, 19, 22, 34, 44, 964, DateTimeKind.Local).AddTicks(8207), "Vanessa Wilderman", "Modi provident commodi excepturi iusto officiis molestias saepe alias placeat.", false, false, "Kian Donnelly", new DateTime(2024, 11, 25, 0, 11, 12, 870, DateTimeKind.Local).AddTicks(352), "Beauty", "Assumenda cum non distinctio est." },
                    { 8, new DateTime(2024, 8, 19, 19, 27, 10, 110, DateTimeKind.Local).AddTicks(6952), "Brendon Bashirian", "Ad sit quisquam adipisci sit repellendus molestiae delectus porro fugiat.", false, false, "Petra Paucek", new DateTime(2024, 11, 25, 20, 12, 12, 590, DateTimeKind.Local).AddTicks(3900), "Electronics", "Blanditiis quia consectetur voluptas dolorem." },
                    { 9, new DateTime(2024, 10, 3, 8, 25, 14, 48, DateTimeKind.Local).AddTicks(6151), "Evie Wiza", "Quod eaque vel id est eos eligendi voluptas incidunt voluptatem.", true, false, "Pattie Stroman", new DateTime(2024, 11, 24, 23, 1, 18, 80, DateTimeKind.Local).AddTicks(5076), "Industrial", "Repellendus fugiat soluta necessitatibus est." },
                    { 10, new DateTime(2024, 10, 11, 5, 0, 43, 31, DateTimeKind.Local).AddTicks(337), "Jarret Maggio", "Ut ut voluptatum aliquam nisi beatae earum quisquam rerum dicta.", false, false, "Jadyn Stehr", new DateTime(2024, 11, 25, 21, 6, 5, 140, DateTimeKind.Local).AddTicks(283), "Baby", "Vel vero consequuntur et qui." },
                    { 11, new DateTime(2024, 10, 4, 10, 4, 57, 669, DateTimeKind.Local).AddTicks(4063), "Rowan Ritchie", "Consequuntur velit quia adipisci doloremque incidunt reiciendis est quisquam est.", true, true, "Kennith Farrell", new DateTime(2024, 11, 25, 16, 32, 38, 763, DateTimeKind.Local).AddTicks(4812), "Grocery", "Repellendus animi vel a quia." },
                    { 12, new DateTime(2024, 7, 15, 16, 33, 59, 653, DateTimeKind.Local).AddTicks(1494), "Claudine Pollich", "Enim voluptatibus est amet et quam hic voluptas voluptatem ducimus.", true, true, "Jeremy Metz", new DateTime(2024, 11, 25, 22, 29, 21, 790, DateTimeKind.Local).AddTicks(9726), "Sports", "Nostrum voluptatem dolores enim saepe." },
                    { 13, new DateTime(2024, 11, 13, 22, 22, 21, 531, DateTimeKind.Local).AddTicks(166), "Phyllis Howe", "Aut non sit illo eum inventore quia provident explicabo sint.", false, false, "Shawna Bahringer", new DateTime(2024, 11, 25, 11, 10, 13, 347, DateTimeKind.Local).AddTicks(5425), "Outdoors", "Nihil voluptatem nesciunt consequatur minima." },
                    { 14, new DateTime(2024, 2, 2, 2, 35, 49, 225, DateTimeKind.Local).AddTicks(9457), "Elva Brakus", "Optio molestiae at delectus veritatis id autem dicta corporis consequuntur.", true, true, "Sally Blick", new DateTime(2024, 11, 25, 15, 50, 10, 393, DateTimeKind.Local).AddTicks(806), "Toys", "Rerum velit voluptas dignissimos quis." },
                    { 15, new DateTime(2024, 10, 30, 20, 24, 26, 131, DateTimeKind.Local).AddTicks(2079), "Chaim Swaniawski", "Ut consequatur aperiam fugit autem mollitia distinctio reprehenderit consequatur vitae.", true, false, "Marlon Schuppe", new DateTime(2024, 11, 25, 9, 48, 52, 246, DateTimeKind.Local).AddTicks(7759), "Computers", "Aspernatur impedit possimus dicta cupiditate." },
                    { 16, new DateTime(2024, 2, 7, 18, 15, 38, 46, DateTimeKind.Local).AddTicks(3911), "Madie Bogan", "Nemo a non minima eum occaecati fugiat qui odio dolor.", true, false, "Mazie Bosco", new DateTime(2024, 11, 25, 7, 5, 5, 81, DateTimeKind.Local).AddTicks(1080), "Computers", "Voluptas ab dolorum quae et." },
                    { 17, new DateTime(2024, 3, 3, 10, 14, 3, 747, DateTimeKind.Local).AddTicks(8293), "Caden Shanahan", "Quis similique optio hic exercitationem assumenda inventore natus deleniti excepturi.", false, true, "Simeon Heidenreich", new DateTime(2024, 11, 25, 14, 28, 23, 283, DateTimeKind.Local).AddTicks(6786), "Toys", "Et quasi voluptatibus dolor laudantium." },
                    { 18, new DateTime(2024, 5, 7, 8, 38, 33, 290, DateTimeKind.Local).AddTicks(5691), "Bernardo Grant", "Blanditiis error molestiae omnis et voluptas molestiae fugiat itaque minus.", true, false, "Albertha Breitenberg", new DateTime(2024, 11, 25, 4, 53, 49, 61, DateTimeKind.Local).AddTicks(1663), "Computers", "Ducimus libero iure ipsa adipisci." },
                    { 19, new DateTime(2024, 11, 5, 2, 44, 8, 737, DateTimeKind.Local).AddTicks(685), "Celine Mueller", "Est voluptatibus nulla praesentium in laudantium et et optio rerum.", false, false, "Kirstin Kiehn", new DateTime(2024, 11, 25, 20, 21, 27, 46, DateTimeKind.Local).AddTicks(7796), "Kids", "Officia voluptates qui aut mollitia." },
                    { 20, new DateTime(2024, 9, 26, 8, 41, 52, 42, DateTimeKind.Local).AddTicks(3291), "Ruthe Bruen", "Non temporibus iure ipsa nulla sit placeat sit et doloribus.", true, false, "Adolfo Schneider", new DateTime(2024, 11, 25, 17, 51, 10, 122, DateTimeKind.Local).AddTicks(148), "Music", "Enim vitae dignissimos odit animi." }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "CommentCount", "Content", "CratedDate", "CreatedByName", "Date", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "Note", "SeoAuthor", "SeoDescription", "SeoTag", "Thumbnail", "Title", "UserId", "ViewsCount" },
                values: new object[,]
                {
                    { 1, 11, 60, "İllum omnis autem officia molestiae. Veniam consequatur consequatur. Dolore iusto neque nihil reiciendis magni hic et accusantium id.\n\nUt architecto nemo eaque laudantium molestiae. Et cum iusto temporibus deserunt. Tempora eum cupiditate iusto rem ullam dolores. İn ex aliquam.\n\nQuaerat minima aut temporibus aut explicabo aut perspiciatis. Quos voluptates inventore aut earum sit. Sunt dolores corporis ad dolorum.", new DateTime(2024, 6, 10, 3, 19, 0, 332, DateTimeKind.Local).AddTicks(9828), "Nils O'Reilly", new DateTime(2024, 1, 24, 7, 32, 15, 360, DateTimeKind.Local).AddTicks(4686), false, true, "Alden Moen", new DateTime(2024, 11, 25, 15, 33, 6, 146, DateTimeKind.Local).AddTicks(6561), "Eos et in id totam.", "Rosalyn Parker", "At accusantium aut vel laborum et et error nam incidunt.", "suscipit", "https://picsum.photos/640/480/?image=21", "Et labore explicabo minima odio.", 6, 1676 },
                    { 2, 4, 89, "İusto dolore dolor nam reprehenderit adipisci. Fugiat aut accusantium. Quos non cumque blanditiis molestiae odio voluptatem.\n\nQui vitae culpa est deserunt. Repellat dicta nesciunt magnam vel possimus rerum. Sit repudiandae voluptas officiis laborum. Eaque libero amet qui voluptatum quis. Ut consequatur veniam. Praesentium quisquam aliquid dicta ratione facilis in assumenda dolor.\n\nFacilis quos rem esse autem quibusdam assumenda itaque qui voluptas. Fuga repellat ut explicabo quo officia maiores quis minima ut. Sunt suscipit voluptatem in dolores quia ipsum. Eos dolor culpa dolore et.", new DateTime(2024, 5, 12, 18, 48, 23, 315, DateTimeKind.Local).AddTicks(4502), "Jovani Greenfelder", new DateTime(2024, 8, 6, 20, 42, 24, 866, DateTimeKind.Local).AddTicks(6850), true, true, "Ashlee Lebsack", new DateTime(2024, 11, 25, 1, 47, 35, 385, DateTimeKind.Local).AddTicks(9733), "Et assumenda ut id tenetur.", "Stephon Keeling", "Dolores perspiciatis nesciunt totam similique non dolorum ipsa aliquid veritatis.", "eum", "https://picsum.photos/640/480/?image=939", "Velit sapiente tempora atque nemo.", 20, 2788 },
                    { 3, 2, 92, "Minus et ut repudiandae corporis quas quam. Quidem culpa cumque et vitae cum impedit eaque quod corporis. Mollitia quos fugit et in sunt. Velit nemo dolorem ea.\n\nEveniet qui est rerum omnis. Nesciunt voluptas distinctio ut veniam possimus. At ex natus voluptas voluptatum consequatur voluptatibus numquam illum. Aut earum ea reprehenderit consequuntur dolorem sit officia qui asperiores. Maxime minima eligendi odit.\n\nMinus et et eos numquam sit non perspiciatis ut. Sapiente quam et necessitatibus omnis tempora eos et. Dicta delectus illo aut est. Quis officia dolores hic et. Assumenda illo nam fugit molestiae et eaque quasi ut. Blanditiis optio officia quia omnis quia.", new DateTime(2024, 3, 22, 2, 36, 5, 472, DateTimeKind.Local).AddTicks(1477), "Miller Quigley", new DateTime(2024, 6, 19, 5, 52, 36, 948, DateTimeKind.Local).AddTicks(3428), false, true, "April Quitzon", new DateTime(2024, 11, 25, 1, 21, 44, 446, DateTimeKind.Local).AddTicks(4353), "Quam fugiat omnis dolor quia.", "Kim Rodriguez", "Reprehenderit et molestias voluptate ut nihil tempore aspernatur sit excepturi.", "veniam", "https://picsum.photos/640/480/?image=88", "Aut ut consequatur distinctio quibusdam.", 7, 1643 },
                    { 4, 14, 79, "Atque dolorem excepturi numquam deserunt ipsa et qui. İn a qui et. Ea error dolor enim natus laudantium labore autem. Ad et quisquam tempore earum pariatur porro ipsam. Qui voluptas autem ut. Et itaque voluptatem.\n\nMolestias vel a similique laborum alias quos repellendus eaque beatae. Qui corporis veniam et debitis placeat. Rerum et iste enim officiis. Non ipsum quia et. Assumenda laudantium qui quo quisquam.\n\nLaboriosam quia est voluptates ipsam nemo ad. Nemo et minima omnis numquam odit vel quia provident enim. Neque debitis ad corrupti molestiae non id. Ut sit deleniti.", new DateTime(2024, 6, 25, 9, 32, 56, 315, DateTimeKind.Local).AddTicks(9804), "Nathanial Kulas", new DateTime(2024, 2, 28, 2, 27, 3, 20, DateTimeKind.Local).AddTicks(7298), false, true, "Carrie Beer", new DateTime(2024, 11, 25, 5, 59, 2, 46, DateTimeKind.Local).AddTicks(1806), "Molestiae dolorem sed veniam et.", "Griffin Christiansen", "Et praesentium reiciendis optio quasi similique et dolorum voluptates sapiente.", "rerum", "https://picsum.photos/640/480/?image=334", "Mollitia et beatae aspernatur dolorem.", 20, 4307 },
                    { 5, 12, 83, "Odio sapiente laborum est ipsum labore. Dolor cupiditate voluptas adipisci. Ab voluptatibus iure labore quo corrupti. Nemo expedita dolor occaecati mollitia similique perferendis. Similique enim in iure sed sequi assumenda. İtaque voluptatibus voluptates fugiat.\n\nFugiat rerum doloremque. Provident consectetur eos sed molestias harum harum numquam natus. Laboriosam non nostrum corporis ad consequatur inventore odit. Adipisci tenetur incidunt in temporibus quo voluptas ad officiis. Voluptatem debitis sint laborum cupiditate molestiae quia autem.\n\nNecessitatibus in aut. Totam minima et laboriosam accusamus. Et at expedita. Qui culpa possimus inventore sint dolor ullam qui. Odio odio quia ullam. Atque fugiat nisi corrupti animi alias recusandae nulla id.", new DateTime(2024, 4, 28, 18, 41, 47, 966, DateTimeKind.Local).AddTicks(5216), "Clint Cruickshank", new DateTime(2024, 1, 28, 1, 24, 26, 2, DateTimeKind.Local).AddTicks(4299), false, false, "Bret Stoltenberg", new DateTime(2024, 11, 25, 8, 23, 35, 150, DateTimeKind.Local).AddTicks(8771), "Labore occaecati qui iste voluptas.", "Ethelyn Klein", "Dolor nostrum est est enim corrupti quis optio nihil iusto.", "ea", "https://picsum.photos/640/480/?image=31", "Quisquam soluta vel incidunt non.", 3, 5406 },
                    { 6, 9, 71, "Molestiae perferendis et illo assumenda dolor amet autem omnis quia. İllo dolore voluptate rerum voluptatibus nobis sunt libero veritatis repellat. Nobis odit recusandae sed aliquam est quia et debitis. Tempore sit eius dolore similique est voluptatem qui. Necessitatibus cum pariatur. Aut totam molestiae sequi mollitia mollitia.\n\nUt adipisci praesentium saepe et consequatur. Dicta voluptate ut quia sequi quos. Officiis in sunt magnam magnam praesentium modi aut natus. Quas accusantium assumenda. İure totam ipsa. İd quae quae magnam ut voluptatum.\n\nEst autem quae libero architecto aut fugit quas. Et vero quia voluptatem sit sapiente et. Cumque inventore quaerat repudiandae quia repudiandae. Soluta iusto molestiae id voluptatem reiciendis. Maiores consequatur recusandae molestiae.", new DateTime(2024, 4, 25, 9, 35, 55, 985, DateTimeKind.Local).AddTicks(7563), "Delta Gorczany", new DateTime(2024, 10, 22, 7, 34, 46, 769, DateTimeKind.Local).AddTicks(3680), false, false, "Sabrina Miller", new DateTime(2024, 11, 25, 9, 18, 49, 349, DateTimeKind.Local).AddTicks(419), "Blanditiis nisi earum aut itaque.", "Joel Stokes", "Quam reprehenderit omnis aspernatur nam voluptatem vel aut quas et.", "natus", "https://picsum.photos/640/480/?image=71", "Suscipit odit aut est perspiciatis.", 7, 3334 },
                    { 7, 11, 89, "Nihil placeat magnam odio nemo. Accusantium ipsam molestiae sed quas. Voluptate quae libero earum iste. Reiciendis delectus voluptate laudantium.\n\nMinima alias debitis praesentium vitae voluptas eum. Similique omnis esse dolor quae. Eius quis non dolores eos non unde nemo magni. Quam voluptas neque consequuntur.\n\nTenetur labore assumenda. Dolor consequatur ut sed facere consequuntur. Tempora a occaecati possimus laborum similique nesciunt. İpsum cupiditate tenetur enim autem.", new DateTime(2024, 11, 12, 3, 43, 37, 53, DateTimeKind.Local).AddTicks(2831), "Santa Kertzmann", new DateTime(2024, 1, 30, 21, 11, 40, 339, DateTimeKind.Local).AddTicks(7295), true, true, "Fatima Klocko", new DateTime(2024, 11, 25, 15, 25, 34, 615, DateTimeKind.Local).AddTicks(2924), "Modi debitis ut voluptate nesciunt.", "Franco Reilly", "Sit beatae officiis vitae et consequuntur repudiandae numquam accusantium occaecati.", "sit", "https://picsum.photos/640/480/?image=1050", "Rerum ut est veniam vitae.", 14, 597 },
                    { 8, 13, 27, "Aut fuga libero perferendis in nulla ut. Architecto facere sunt ea at. Ut ut ut.\n\nEt rem aut fuga rerum itaque rem explicabo ab et. Repellat sit atque accusamus. Culpa similique quos.\n\nRerum molestiae praesentium at provident non architecto quia accusamus quis. Nostrum facilis aut sit quia facilis ut explicabo aut animi. Consectetur nulla enim fugit expedita id. Odit fugiat totam aut nostrum. İn voluptate et veritatis adipisci.", new DateTime(2024, 8, 8, 9, 31, 15, 487, DateTimeKind.Local).AddTicks(1612), "Florian Stamm", new DateTime(2024, 4, 23, 13, 11, 11, 463, DateTimeKind.Local).AddTicks(1218), true, false, "Judson Blick", new DateTime(2024, 11, 25, 20, 22, 51, 626, DateTimeKind.Local).AddTicks(3511), "Nostrum rerum non ducimus sit.", "Kacey Hahn", "Tempore quibusdam eaque perferendis provident veniam minus incidunt laborum id.", "voluptatem", "https://picsum.photos/640/480/?image=709", "Beatae omnis voluptatibus voluptatem id.", 17, 8182 },
                    { 9, 2, 76, "Rerum suscipit earum odit dolore corporis non cumque. Maiores et praesentium omnis atque. Saepe corporis vel. Quo voluptatum magnam aliquam unde sapiente. Officiis et rem earum maxime. Esse quas neque nostrum.\n\nAccusamus nostrum distinctio voluptates distinctio architecto quaerat. Nam error sequi odio quae laudantium repellat quia omnis consequatur. Modi aut dolorem rerum sapiente voluptatem. Sit sit aut suscipit veniam. Est voluptatem sequi tempora eos ut excepturi.\n\nEt nostrum adipisci et molestiae. İpsum vero tenetur qui aut. Quia rerum voluptas quam aut suscipit magni tempora accusantium. İnventore fugit quisquam recusandae quaerat error sit. İnventore repudiandae cumque dolores error repudiandae temporibus. Eligendi accusantium error fugiat delectus laborum ipsa et.", new DateTime(2024, 4, 8, 0, 15, 8, 237, DateTimeKind.Local).AddTicks(305), "Joyce Koelpin", new DateTime(2024, 10, 26, 4, 36, 27, 840, DateTimeKind.Local).AddTicks(1791), true, false, "Estevan Kub", new DateTime(2024, 11, 25, 1, 7, 31, 63, DateTimeKind.Local).AddTicks(5517), "Minus ducimus eius nam consequatur.", "Woodrow Zulauf", "Eligendi natus ut pariatur labore sint expedita perferendis nihil ut.", "asperiores", "https://picsum.photos/640/480/?image=834", "Quia sit vel odio et.", 12, 5995 },
                    { 10, 2, 81, "İd quia saepe non autem fugiat. At et facere exercitationem exercitationem alias in deleniti minus consequatur. Voluptate quia animi aliquam saepe aut.\n\nAccusamus in est a sit dolorum id alias officia. Vitae eaque et. Porro excepturi quia ipsum cum magnam cupiditate amet perferendis molestias. Tenetur sit beatae ut qui est. Est quia voluptatibus corrupti corporis aspernatur. Autem ipsam possimus velit maiores quia porro animi.\n\nAdipisci sed qui fugit unde qui saepe. Aliquid nulla quis consectetur debitis quos aperiam vero. At est voluptatem ullam facilis officia sed expedita libero. Quod accusantium illum aspernatur consequatur. Doloremque ut autem inventore sunt porro impedit corrupti.", new DateTime(2024, 8, 30, 7, 57, 53, 140, DateTimeKind.Local).AddTicks(30), "Trevion Maggio", new DateTime(2024, 2, 19, 23, 28, 2, 286, DateTimeKind.Local).AddTicks(2741), false, true, "Jaydon Langosh", new DateTime(2024, 11, 25, 9, 10, 22, 865, DateTimeKind.Local).AddTicks(8319), "Veritatis delectus quas vitae dicta.", "Vance Lehner", "Et officia corrupti debitis laboriosam molestiae est voluptatum iste veritatis.", "cum", "https://picsum.photos/640/480/?image=941", "Consequuntur quo nostrum qui reprehenderit.", 19, 2430 },
                    { 11, 7, 15, "Autem asperiores sit quo distinctio facilis modi non asperiores. Quam deleniti dolores nam quia. Nam reiciendis et voluptatem iure voluptas quas. İure porro vel doloremque perspiciatis ut velit culpa. Aut reiciendis blanditiis animi consequuntur et voluptatem delectus alias.\n\nPossimus excepturi nostrum voluptas deserunt fuga qui a consequuntur a. Veritatis aut quod sapiente et porro cupiditate iusto voluptatibus. Eum rem necessitatibus magni velit harum eos dolorem nostrum id.\n\nDebitis fugit autem quidem repudiandae qui voluptatem incidunt corrupti. Error asperiores similique sapiente totam ipsa. Est quisquam assumenda quod rem maiores aliquam qui. Perspiciatis rerum deleniti ut non qui quod fugit odio et. Quisquam reiciendis et maiores et sit aut nesciunt. İnventore neque aut est omnis quo maiores.", new DateTime(2024, 3, 22, 0, 18, 56, 455, DateTimeKind.Local).AddTicks(6828), "Jamison Langworth", new DateTime(2024, 4, 17, 8, 20, 28, 998, DateTimeKind.Local).AddTicks(8494), true, true, "Easton Nader", new DateTime(2024, 11, 25, 1, 36, 10, 949, DateTimeKind.Local).AddTicks(5096), "Voluptatem voluptatum explicabo facere ullam.", "Derek Hintz", "Et perferendis numquam molestiae maxime autem consectetur saepe aperiam ut.", "omnis", "https://picsum.photos/640/480/?image=920", "At est ut fugit modi.", 13, 1505 },
                    { 12, 18, 40, "Eveniet dolores itaque eum incidunt modi sed eos. Voluptatem illum harum accusantium eos cum sint aspernatur quas alias. İd reprehenderit distinctio similique nam labore eius vero rerum adipisci. Porro dolorem quia et error eos provident quidem vel. İpsa aut nihil.\n\nSed molestiae deleniti dolorem quidem consectetur possimus et perspiciatis. Saepe dolor voluptatum recusandae impedit esse sint cum quam quia. Commodi expedita blanditiis. Sunt fugit velit vel suscipit cupiditate officia amet. Quo assumenda iusto.\n\nVoluptate itaque velit excepturi iure quia eveniet voluptate. Ullam ut ut inventore unde aperiam. Adipisci quibusdam cupiditate nemo corporis odio quidem voluptatibus eos.", new DateTime(2024, 8, 22, 4, 50, 53, 710, DateTimeKind.Local).AddTicks(9799), "Heber Bergnaum", new DateTime(2024, 1, 9, 18, 49, 11, 609, DateTimeKind.Local).AddTicks(6039), false, true, "Leda Hayes", new DateTime(2024, 11, 25, 3, 57, 34, 771, DateTimeKind.Local).AddTicks(8655), "Rerum itaque magni non temporibus.", "Florida Becker", "Quibusdam ut perspiciatis sed nesciunt et magnam vel neque quasi.", "dolor", "https://picsum.photos/640/480/?image=222", "Voluptatem placeat facere modi consequatur.", 14, 6861 },
                    { 13, 16, 57, "İste beatae sed sunt id similique blanditiis. Est atque dicta illum consequatur. Facere expedita possimus sunt quasi velit alias aperiam. Repellendus quas non qui eaque commodi labore.\n\nMolestiae consequuntur explicabo officia maxime minus nobis. İmpedit et voluptatum beatae ea dolorem nostrum ratione dolorem fuga. Et eligendi libero adipisci.\n\nSed maiores architecto tempore minima ut voluptas molestiae culpa. Tenetur id et quo vitae. Mollitia sit magni. Et molestias autem repellat quam qui accusamus voluptatem. Reiciendis at enim sit possimus aut sed qui. Omnis qui qui.", new DateTime(2024, 3, 12, 9, 37, 13, 205, DateTimeKind.Local).AddTicks(6822), "Elva Price", new DateTime(2024, 7, 12, 22, 23, 24, 972, DateTimeKind.Local).AddTicks(5038), false, true, "Shirley Heaney", new DateTime(2024, 11, 25, 6, 50, 25, 68, DateTimeKind.Local).AddTicks(884), "Et voluptates molestiae rerum earum.", "Paige Hilpert", "Eveniet consequuntur ut voluptate commodi tempore eligendi modi ut voluptatem.", "quo", "https://picsum.photos/640/480/?image=944", "Culpa fugiat officia voluptas blanditiis.", 9, 3795 },
                    { 14, 1, 45, "Praesentium ea eum aut eos qui et consequatur. Molestiae necessitatibus qui. Consequatur qui minima odit rerum id sit qui voluptas. Et accusamus autem recusandae ut vel consequatur.\n\nSint harum repellendus eaque in. Similique esse voluptates saepe. Repellendus reiciendis earum fugiat unde dicta quia omnis. Voluptas aut dicta repellat veritatis incidunt fugit fugiat. Autem dolorem et deserunt quibusdam qui ea mollitia omnis maiores.\n\nDolores sit est saepe aperiam voluptas quae voluptates. Sed quod et deserunt quibusdam eveniet. Beatae est id sequi porro est impedit qui quo. Enim doloribus vel velit iusto odio. Explicabo id sit velit quia molestias expedita a.", new DateTime(2024, 7, 15, 12, 10, 13, 664, DateTimeKind.Local).AddTicks(9576), "Fiona Vandervort", new DateTime(2024, 1, 20, 4, 38, 24, 31, DateTimeKind.Local).AddTicks(212), true, false, "Clara Von", new DateTime(2024, 11, 25, 4, 20, 14, 161, DateTimeKind.Local).AddTicks(5051), "İn sit aliquid non labore.", "Armand Wyman", "Ut fugiat exercitationem fugiat quis quos est quidem sed voluptatibus.", "fugit", "https://picsum.photos/640/480/?image=202", "Veritatis eius consequatur qui voluptas.", 5, 969 },
                    { 15, 2, 69, "Minus aut vitae suscipit quam sed atque officia consectetur. Minus magnam fugit. At omnis possimus quis et. Necessitatibus saepe voluptate. Debitis qui dignissimos. Possimus nihil culpa consequatur enim error sunt.\n\nHarum est laborum iusto voluptatibus officia qui. Et corrupti quos quia. Aperiam et fugiat facere reiciendis. Laboriosam est ex labore.\n\nİpsa ad est distinctio dolores amet. Ducimus nisi eligendi. Quo et nihil ut.", new DateTime(2024, 8, 4, 1, 5, 40, 618, DateTimeKind.Local).AddTicks(239), "Enid Osinski", new DateTime(2024, 10, 24, 1, 28, 13, 732, DateTimeKind.Local).AddTicks(4791), true, true, "Rachael Rowe", new DateTime(2024, 11, 25, 8, 7, 23, 959, DateTimeKind.Local).AddTicks(2553), "Veritatis qui et tenetur magni.", "Deshaun Cronin", "Temporibus odit nemo non rerum repellendus doloribus est aut architecto.", "molestiae", "https://picsum.photos/640/480/?image=81", "Ut esse assumenda ullam possimus.", 19, 7505 },
                    { 16, 14, 65, "Doloremque sed ratione. Libero iusto quod ut fuga doloribus sunt et aspernatur. Numquam soluta est reprehenderit incidunt veniam eligendi.\n\nVel culpa voluptates omnis eaque voluptas accusantium autem. Repellat optio iure necessitatibus laudantium voluptas. Suscipit amet at. Dolore ipsa id eum voluptas quas ab qui corrupti.\n\nİncidunt fugiat expedita consequatur. Occaecati labore totam excepturi alias dicta qui ex ducimus. Laboriosam earum et ut rerum totam et perspiciatis. Perspiciatis sed fugiat officia tempora sunt. Magni ipsam tempora eum.", new DateTime(2024, 1, 25, 13, 21, 26, 358, DateTimeKind.Local).AddTicks(9331), "Montana Dickens", new DateTime(2024, 10, 1, 16, 24, 44, 433, DateTimeKind.Local).AddTicks(32), false, true, "Reva Orn", new DateTime(2024, 11, 25, 7, 23, 5, 891, DateTimeKind.Local).AddTicks(4313), "Repellendus rerum facilis cupiditate omnis.", "Winfield Carroll", "A rerum culpa adipisci sed enim atque dolore repellendus doloribus.", "explicabo", "https://picsum.photos/640/480/?image=808", "İure laboriosam quis suscipit dolore.", 18, 2400 },
                    { 17, 9, 74, "Dolor quam consequatur. Totam ut cumque rerum itaque excepturi. Quo minus et occaecati possimus at delectus libero necessitatibus quo. Minima ut laudantium tenetur corporis et assumenda quis. Aut harum similique adipisci at labore nulla illum placeat. Consectetur eligendi rerum eum nemo officia.\n\nTempore esse voluptatem nesciunt. Aut quia deserunt porro minus est adipisci at quod et. Molestiae ipsam et consequuntur ducimus consequuntur totam libero porro. Atque inventore eos aut repellendus id amet consequuntur et ab.\n\nCupiditate ut sed nulla. Tenetur aspernatur ut et molestias fugiat nisi. Magnam voluptatem beatae atque nisi excepturi.", new DateTime(2024, 5, 22, 5, 39, 53, 472, DateTimeKind.Local).AddTicks(3162), "Silas Huels", new DateTime(2024, 11, 15, 10, 42, 27, 353, DateTimeKind.Local).AddTicks(8171), true, true, "Maude Wisozk", new DateTime(2024, 11, 25, 7, 35, 16, 710, DateTimeKind.Local).AddTicks(4663), "Rem nisi sed non velit.", "Salvatore Kerluke", "Aut voluptas nisi dolorem rerum quia beatae qui quasi placeat.", "in", "https://picsum.photos/640/480/?image=976", "Reprehenderit aut mollitia molestiae molestiae.", 10, 2478 },
                    { 18, 16, 53, "Atque voluptatem dignissimos ab nihil. Reprehenderit nemo facilis enim ut sequi nulla. Esse id consequuntur qui. Reiciendis et modi ut sapiente voluptatem sed. Est quis cupiditate dolorem omnis ratione architecto dolores.\n\nNemo blanditiis nulla non ducimus ipsam voluptas. Aliquam distinctio vel iure sit maiores. Debitis omnis ut eos omnis suscipit.\n\nQuasi maiores earum soluta rerum dolorem quod aut. Molestiae veniam ut amet deserunt animi fugiat debitis occaecati cupiditate. Ducimus iste adipisci sint qui. Nulla voluptas vel rerum. Nihil omnis eligendi iusto animi.", new DateTime(2024, 5, 28, 12, 37, 31, 22, DateTimeKind.Local).AddTicks(7757), "Elijah Runolfsdottir", new DateTime(2024, 7, 1, 9, 51, 7, 547, DateTimeKind.Local).AddTicks(6782), false, true, "Jerrell Ferry", new DateTime(2024, 11, 25, 1, 35, 42, 32, DateTimeKind.Local).AddTicks(649), "Sed velit architecto qui sunt.", "Emelie Bashirian", "Dolor incidunt nisi commodi ducimus facere ut perferendis et et.", "eligendi", "https://picsum.photos/640/480/?image=233", "Voluptates quos quos voluptates accusantium.", 4, 1168 },
                    { 19, 16, 35, "Blanditiis earum est rerum ipsam nam sit quis autem. İmpedit dolor nam ullam rerum. Eos voluptatem rem quae quis quam repellat voluptatem ut.\n\nDignissimos alias delectus est adipisci quae molestiae beatae asperiores. Non quas aut aliquid itaque voluptatem eos qui. Velit vero alias quam dignissimos placeat.\n\nA aliquam officiis recusandae aut. Neque et sit porro veritatis harum natus qui quod. İpsum enim sit officiis architecto cumque consequatur explicabo vel ea.", new DateTime(2024, 5, 29, 2, 9, 9, 266, DateTimeKind.Local).AddTicks(9730), "Dayton Hilll", new DateTime(2024, 6, 3, 3, 29, 47, 805, DateTimeKind.Local).AddTicks(589), true, true, "Vena Gorczany", new DateTime(2024, 11, 25, 15, 37, 29, 296, DateTimeKind.Local).AddTicks(4086), "Non velit harum ipsum dolorem.", "Gerard Champlin", "Numquam id dolorem omnis quis incidunt tenetur vitae magni optio.", "in", "https://picsum.photos/640/480/?image=197", "Autem et esse molestiae voluptas.", 12, 2647 },
                    { 20, 4, 83, "Voluptatem voluptatem dolor ad debitis esse veniam omnis voluptatem. Et nesciunt eos quia dolores aut harum ut. Et nisi est labore at nesciunt inventore cum necessitatibus consectetur. Fugiat nihil quo iure quo dicta. Temporibus ut tenetur reprehenderit. Velit beatae molestias eius cupiditate officia voluptates reiciendis quaerat quisquam.\n\nEt earum eligendi perspiciatis nisi necessitatibus velit. Aut et doloremque esse voluptatem enim. Ut quisquam enim ipsa odit quia. Ut sed a ut qui et architecto. Et tenetur et distinctio odit nihil voluptas dolore dolore quibusdam. Soluta perspiciatis asperiores saepe ullam.\n\nQuos dicta ut voluptate reiciendis consequatur sunt. Excepturi exercitationem vel dolor. Nemo alias aut ut veritatis tenetur.", new DateTime(2024, 6, 3, 15, 31, 52, 630, DateTimeKind.Local).AddTicks(6028), "Lenore Jerde", new DateTime(2024, 1, 29, 15, 12, 26, 106, DateTimeKind.Local).AddTicks(7185), false, true, "Deondre Strosin", new DateTime(2024, 11, 25, 7, 45, 21, 286, DateTimeKind.Local).AddTicks(4534), "Maxime repellat cumque omnis odit.", "Avis Kilback", "Porro sint in minima veniam eum optio et dolores atque.", "harum", "https://picsum.photos/640/480/?image=746", "Eum cumque perferendis est ut.", 17, 7650 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    PublishedYear = table.Column<int>(type: "INTEGER", nullable: false),
                    AuthorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1942, 1, 25, 19, 56, 28, 576, DateTimeKind.Unspecified).AddTicks(2088), "София Владимирова" },
                    { 2, new DateTime(1995, 1, 19, 17, 13, 34, 539, DateTimeKind.Unspecified).AddTicks(3378), "Алевтина Соколова" },
                    { 3, new DateTime(1967, 5, 21, 12, 8, 4, 999, DateTimeKind.Unspecified).AddTicks(4416), "Константин Белозеров" },
                    { 4, new DateTime(1939, 4, 15, 2, 29, 45, 461, DateTimeKind.Unspecified).AddTicks(2644), "Даниил Воробьев" },
                    { 5, new DateTime(1931, 9, 27, 1, 9, 20, 750, DateTimeKind.Unspecified).AddTicks(3164), "Валентина Иванова" },
                    { 6, new DateTime(2006, 10, 29, 15, 22, 32, 330, DateTimeKind.Unspecified).AddTicks(9727), "Алексей Мишин" },
                    { 7, new DateTime(1935, 1, 18, 13, 14, 28, 393, DateTimeKind.Unspecified).AddTicks(5284), "Лидия Агафонова" },
                    { 8, new DateTime(1938, 10, 23, 20, 33, 26, 574, DateTimeKind.Unspecified).AddTicks(6400), "Ангелина Савина" },
                    { 9, new DateTime(1999, 7, 8, 18, 31, 33, 286, DateTimeKind.Unspecified).AddTicks(9656), "Алина Игнатьева" },
                    { 10, new DateTime(1943, 3, 22, 19, 51, 27, 575, DateTimeKind.Unspecified).AddTicks(7492), "Антонина Афанасьева" },
                    { 11, new DateTime(1991, 8, 4, 12, 56, 25, 491, DateTimeKind.Unspecified).AddTicks(9785), "Светлана Трофимова" },
                    { 12, new DateTime(1976, 4, 9, 4, 38, 11, 340, DateTimeKind.Unspecified).AddTicks(8952), "Анастасия Королева" },
                    { 13, new DateTime(1994, 8, 11, 7, 51, 51, 158, DateTimeKind.Unspecified).AddTicks(5422), "Денис Зимин" },
                    { 14, new DateTime(1930, 3, 12, 3, 8, 59, 88, DateTimeKind.Unspecified).AddTicks(6924), "Иван Брагин" },
                    { 15, new DateTime(1998, 12, 3, 5, 26, 19, 527, DateTimeKind.Unspecified).AddTicks(5645), "Матвей Павлов" },
                    { 16, new DateTime(2002, 8, 26, 11, 24, 20, 630, DateTimeKind.Unspecified).AddTicks(3719), "Аркадий Горбачев" },
                    { 17, new DateTime(1997, 8, 24, 22, 10, 3, 843, DateTimeKind.Unspecified).AddTicks(9422), "Альберт Молчанов" },
                    { 18, new DateTime(1978, 2, 8, 10, 1, 38, 325, DateTimeKind.Unspecified).AddTicks(1592), "Юлия Бурова" },
                    { 19, new DateTime(1985, 4, 7, 12, 32, 58, 27, DateTimeKind.Unspecified).AddTicks(713), "Антонина Кузнецова" },
                    { 20, new DateTime(1955, 9, 16, 2, 24, 52, 437, DateTimeKind.Unspecified).AddTicks(4666), "Клавдия Журавлева" },
                    { 21, new DateTime(2003, 7, 28, 10, 32, 15, 698, DateTimeKind.Unspecified).AddTicks(1350), "Виталий Молчанов" },
                    { 22, new DateTime(1990, 1, 14, 3, 31, 52, 471, DateTimeKind.Unspecified).AddTicks(4672), "Григорий Бирюков" },
                    { 23, new DateTime(1992, 12, 2, 19, 29, 27, 691, DateTimeKind.Unspecified).AddTicks(8998), "Константин Фокин" },
                    { 24, new DateTime(1941, 11, 14, 3, 37, 57, 108, DateTimeKind.Unspecified).AddTicks(332), "Виталий Родионов" },
                    { 25, new DateTime(1951, 1, 8, 22, 33, 10, 769, DateTimeKind.Unspecified).AddTicks(292), "Григорий Степанов" },
                    { 26, new DateTime(1992, 10, 4, 20, 2, 20, 43, DateTimeKind.Unspecified).AddTicks(211), "Анатолий Овчинников" },
                    { 27, new DateTime(1942, 11, 21, 1, 10, 52, 329, DateTimeKind.Unspecified).AddTicks(3412), "Вера Петухова" },
                    { 28, new DateTime(1963, 9, 9, 5, 36, 23, 643, DateTimeKind.Unspecified).AddTicks(4994), "Ирина Гаврилова" },
                    { 29, new DateTime(2002, 1, 9, 5, 2, 53, 263, DateTimeKind.Unspecified).AddTicks(1738), "Герман Евдокимов" },
                    { 30, new DateTime(1959, 7, 24, 13, 57, 43, 567, DateTimeKind.Unspecified).AddTicks(1016), "Игорь Моисеев" },
                    { 31, new DateTime(1987, 12, 27, 10, 17, 53, 730, DateTimeKind.Unspecified).AddTicks(7319), "Егор Сазонов" },
                    { 32, new DateTime(1963, 8, 22, 21, 13, 59, 278, DateTimeKind.Unspecified).AddTicks(2836), "Михаил Никитин" },
                    { 33, new DateTime(1999, 7, 29, 14, 35, 31, 779, DateTimeKind.Unspecified).AddTicks(1006), "Антонида Кузнецова" },
                    { 34, new DateTime(1976, 2, 15, 23, 58, 27, 111, DateTimeKind.Unspecified).AddTicks(3064), "Иван Осипов" },
                    { 35, new DateTime(1998, 11, 25, 14, 32, 34, 396, DateTimeKind.Unspecified).AddTicks(1158), "Кира Трофимова" },
                    { 36, new DateTime(1951, 3, 12, 12, 50, 41, 919, DateTimeKind.Unspecified).AddTicks(7120), "Альберт Прохоров" },
                    { 37, new DateTime(1948, 5, 25, 9, 45, 49, 415, DateTimeKind.Unspecified).AddTicks(2784), "Григорий Нестеров" },
                    { 38, new DateTime(1953, 1, 15, 16, 33, 50, 813, DateTimeKind.Unspecified).AddTicks(3000), "Виктория Родионова" },
                    { 39, new DateTime(1938, 11, 4, 6, 23, 43, 248, DateTimeKind.Unspecified).AddTicks(4968), "Кира Воронова" },
                    { 40, new DateTime(1943, 4, 28, 16, 19, 57, 982, DateTimeKind.Unspecified).AddTicks(9748), "Виктор Степанов" },
                    { 41, new DateTime(1979, 8, 11, 13, 14, 20, 816, DateTimeKind.Unspecified).AddTicks(3414), "Михаил Козлов" },
                    { 42, new DateTime(1930, 12, 2, 8, 7, 2, 571, DateTimeKind.Unspecified).AddTicks(8648), "Вера Макарова" },
                    { 43, new DateTime(1941, 2, 24, 20, 29, 28, 906, DateTimeKind.Unspecified).AddTicks(436), "Василий Дорофеев" },
                    { 44, new DateTime(1992, 11, 30, 1, 9, 42, 41, DateTimeKind.Unspecified).AddTicks(8929), "Евгений Третьяков" },
                    { 45, new DateTime(1959, 4, 25, 21, 43, 30, 241, DateTimeKind.Unspecified).AddTicks(1186), "Анжелика Морозова" },
                    { 46, new DateTime(1974, 9, 13, 3, 42, 34, 91, DateTimeKind.Unspecified).AddTicks(5640), "Денис Самойлов" },
                    { 47, new DateTime(1937, 12, 21, 11, 23, 55, 894, DateTimeKind.Unspecified).AddTicks(5576), "Вера Белоусова" },
                    { 48, new DateTime(1966, 4, 15, 11, 11, 28, 172, DateTimeKind.Unspecified).AddTicks(4410), "Герман Королев" },
                    { 49, new DateTime(1977, 6, 7, 0, 3, 37, 599, DateTimeKind.Unspecified).AddTicks(3026), "Макар Селиверстов" },
                    { 50, new DateTime(1937, 8, 17, 22, 3, 1, 337, DateTimeKind.Unspecified).AddTicks(404), "Владислав Степанов" },
                    { 51, new DateTime(1975, 3, 31, 19, 12, 44, 93, DateTimeKind.Unspecified).AddTicks(7218), "Максим Ермаков" },
                    { 52, new DateTime(1982, 1, 28, 3, 16, 36, 653, DateTimeKind.Unspecified).AddTicks(3000), "Илья Ермаков" },
                    { 53, new DateTime(2004, 8, 25, 11, 42, 39, 400, DateTimeKind.Unspecified).AddTicks(1117), "Виталий Смирнов" },
                    { 54, new DateTime(1955, 5, 1, 21, 51, 11, 804, DateTimeKind.Unspecified).AddTicks(6986), "Игнатий Крюков" },
                    { 55, new DateTime(1990, 10, 19, 7, 41, 46, 192, DateTimeKind.Unspecified).AddTicks(3603), "Лариса Ермакова" },
                    { 56, new DateTime(1947, 11, 21, 19, 32, 32, 851, DateTimeKind.Unspecified).AddTicks(8692), "Василий Беспалов" },
                    { 57, new DateTime(1975, 6, 29, 12, 15, 0, 20, DateTimeKind.Unspecified).AddTicks(8478), "Михаил Тихонов" },
                    { 58, new DateTime(1965, 8, 2, 20, 51, 19, 638, DateTimeKind.Unspecified).AddTicks(2224), "Алина Яковлева" },
                    { 59, new DateTime(1979, 6, 1, 14, 12, 49, 68, DateTimeKind.Unspecified).AddTicks(3663), "Артём Матвеев" },
                    { 60, new DateTime(1994, 10, 20, 7, 34, 10, 87, DateTimeKind.Unspecified).AddTicks(2500), "Жанна Антонова" },
                    { 61, new DateTime(1946, 9, 5, 22, 18, 21, 9, DateTimeKind.Unspecified).AddTicks(3004), "Татьяна Зиновьева" },
                    { 62, new DateTime(1939, 12, 13, 18, 55, 45, 60, DateTimeKind.Unspecified).AddTicks(1820), "Артём Осипов" },
                    { 63, new DateTime(1975, 8, 20, 18, 12, 12, 177, DateTimeKind.Unspecified).AddTicks(2300), "Вера Архипова" },
                    { 64, new DateTime(2002, 2, 24, 4, 56, 6, 934, DateTimeKind.Unspecified).AddTicks(9813), "Татьяна Гуляева" },
                    { 65, new DateTime(1980, 9, 18, 11, 44, 57, 137, DateTimeKind.Unspecified).AddTicks(2042), "Регина Веселова" },
                    { 66, new DateTime(2005, 7, 28, 7, 58, 47, 143, DateTimeKind.Unspecified).AddTicks(8941), "Борис Симонов" },
                    { 67, new DateTime(2001, 1, 2, 16, 57, 7, 312, DateTimeKind.Unspecified).AddTicks(9479), "Дмитрий Соколов" },
                    { 68, new DateTime(1975, 6, 1, 9, 22, 55, 121, DateTimeKind.Unspecified).AddTicks(5452), "Геннадий Артемьев" },
                    { 69, new DateTime(1998, 2, 23, 8, 47, 30, 882, DateTimeKind.Unspecified).AddTicks(7744), "Григорий Быков" },
                    { 70, new DateTime(1933, 7, 11, 16, 7, 7, 962, DateTimeKind.Unspecified).AddTicks(8504), "Арсений Марков" },
                    { 71, new DateTime(1990, 4, 25, 11, 10, 37, 240, DateTimeKind.Unspecified).AddTicks(278), "Клавдия Исакова" },
                    { 72, new DateTime(2002, 6, 6, 17, 36, 57, 736, DateTimeKind.Unspecified).AddTicks(5151), "Нина Дементьева" },
                    { 73, new DateTime(2002, 6, 15, 3, 39, 43, 119, DateTimeKind.Unspecified).AddTicks(2868), "Валентин Горшков" },
                    { 74, new DateTime(1961, 10, 5, 2, 27, 36, 832, DateTimeKind.Unspecified).AddTicks(5918), "Юрий Фокин" },
                    { 75, new DateTime(1932, 11, 26, 5, 18, 17, 903, DateTimeKind.Unspecified).AddTicks(5824), "Матвей Кириллов" },
                    { 76, new DateTime(1959, 3, 12, 13, 30, 59, 331, DateTimeKind.Unspecified).AddTicks(1028), "Борис Хохлов" },
                    { 77, new DateTime(1981, 1, 18, 17, 13, 20, 474, DateTimeKind.Unspecified).AddTicks(5578), "Алла Воробьева" },
                    { 78, new DateTime(1950, 9, 10, 6, 28, 17, 381, DateTimeKind.Unspecified).AddTicks(1482), "Маргарита Жданова" },
                    { 79, new DateTime(1958, 11, 6, 9, 48, 1, 363, DateTimeKind.Unspecified).AddTicks(1044), "Дарья Константинова" },
                    { 80, new DateTime(1976, 12, 8, 2, 36, 12, 864, DateTimeKind.Unspecified).AddTicks(3536), "Кира Исакова" },
                    { 81, new DateTime(2002, 10, 30, 3, 36, 37, 53, DateTimeKind.Unspecified).AddTicks(9511), "Татьяна Пахомова" },
                    { 82, new DateTime(1980, 3, 26, 22, 39, 2, 65, DateTimeKind.Unspecified).AddTicks(519), "Маргарита Цветкова" },
                    { 83, new DateTime(1946, 7, 6, 23, 54, 36, 753, DateTimeKind.Unspecified).AddTicks(7548), "Сергей Лихачев" },
                    { 84, new DateTime(1982, 4, 5, 20, 8, 13, 862, DateTimeKind.Unspecified).AddTicks(2649), "Дарья Мишина" },
                    { 85, new DateTime(1966, 6, 2, 13, 16, 19, 319, DateTimeKind.Unspecified).AddTicks(2594), "Олег Костин" },
                    { 86, new DateTime(1952, 9, 10, 8, 24, 13, 494, DateTimeKind.Unspecified).AddTicks(8194), "Екатерина Белякова" },
                    { 87, new DateTime(1946, 1, 22, 12, 54, 39, 428, DateTimeKind.Unspecified).AddTicks(9852), "Оксана Лобанова" },
                    { 88, new DateTime(1957, 7, 28, 1, 59, 7, 841, DateTimeKind.Unspecified).AddTicks(2570), "Вячеслав Носов" },
                    { 89, new DateTime(1992, 8, 3, 4, 39, 58, 791, DateTimeKind.Unspecified).AddTicks(5296), "Валерий Медведев" },
                    { 90, new DateTime(1935, 8, 5, 10, 54, 40, 564, DateTimeKind.Unspecified).AddTicks(256), "Евгений Рогов" },
                    { 91, new DateTime(1957, 1, 10, 22, 43, 50, 794, DateTimeKind.Unspecified).AddTicks(6066), "Надежда Одинцова" },
                    { 92, new DateTime(1998, 1, 22, 17, 20, 54, 176, DateTimeKind.Unspecified).AddTicks(7441), "Ольга Захарова" },
                    { 93, new DateTime(1931, 1, 18, 4, 23, 0, 323, DateTimeKind.Unspecified).AddTicks(7484), "Зоя Воронцова" },
                    { 94, new DateTime(1984, 10, 16, 21, 50, 55, 557, DateTimeKind.Unspecified).AddTicks(4724), "София Харитонова" },
                    { 95, new DateTime(2001, 5, 13, 22, 6, 55, 462, DateTimeKind.Unspecified).AddTicks(5056), "Алексей Блинов" },
                    { 96, new DateTime(1999, 2, 25, 7, 37, 58, 133, DateTimeKind.Unspecified).AddTicks(3679), "Денис Борисов" },
                    { 97, new DateTime(1983, 6, 10, 1, 53, 52, 86, DateTimeKind.Unspecified).AddTicks(1401), "Владимир Родионов" },
                    { 98, new DateTime(1965, 11, 10, 19, 3, 35, 838, DateTimeKind.Unspecified).AddTicks(2364), "Илья Константинов" },
                    { 99, new DateTime(1931, 2, 17, 9, 54, 0, 325, DateTimeKind.Unspecified).AddTicks(8728), "Матвей Исаев" },
                    { 100, new DateTime(1939, 3, 4, 17, 49, 28, 864, DateTimeKind.Unspecified).AddTicks(8092), "Таисия Самсонова" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "PublishedYear", "Title" },
                values: new object[,]
                {
                    { 1, 22, 2014, "Предпосылки плановых технологий всего важную." },
                    { 2, 71, 2019, "Обучения информационно-пропогандистское особенности." },
                    { 3, 3, 1989, "Соответствующих позиции." },
                    { 4, 99, 1984, "Обеспечение реализация важную намеченных не." },
                    { 5, 57, 1998, "Очевидна модернизации." },
                    { 6, 44, 2017, "Обуславливает сфера повышение следует." },
                    { 7, 48, 2006, "Поставленных обеспечение активности также модернизации." },
                    { 8, 39, 2023, "Развития отношении не информационно-пропогандистское." },
                    { 9, 27, 2000, "Инновационный понимание задания." },
                    { 10, 90, 2021, "Эксперимент разработке." },
                    { 11, 41, 2022, "Соответствующей равным степени проблем." },
                    { 12, 19, 1989, "Другой место а." },
                    { 13, 54, 2005, "Активом нами." },
                    { 14, 28, 1997, "Форм массового." },
                    { 15, 59, 1984, "Принципов что постоянный проверки зависит." },
                    { 16, 77, 1985, "Формированию экономической прогресса понимание." },
                    { 17, 88, 1977, "Общественной экономической." },
                    { 18, 17, 2006, "Очевидна повышение." },
                    { 19, 14, 1989, "Участниками работы опыт." },
                    { 20, 47, 1991, "Демократической повышению собой значимость." },
                    { 21, 36, 2015, "Гражданского нами реализация мира системы." },
                    { 22, 96, 1996, "Показывает представляет отметить." },
                    { 23, 60, 2019, "Профессионального значимость обучения." },
                    { 24, 100, 2018, "Задания информационно-пропогандистское дальнейших." },
                    { 25, 97, 2006, "Нашей повышение актуальность активности порядка." },
                    { 26, 19, 2007, "Стороны подготовке." },
                    { 27, 13, 1976, "Задач соответствующей административных национальный важные." },
                    { 28, 35, 2008, "Качественно опыт." },
                    { 29, 88, 1995, "Выбранный в." },
                    { 30, 82, 1978, "Поэтапного модели." },
                    { 31, 50, 1989, "Общественной повышению важные высшего практика." },
                    { 32, 42, 2008, "Степени интересный." },
                    { 33, 65, 1981, "Зависит сущности важные же." },
                    { 34, 48, 1991, "Влечёт развития." },
                    { 35, 77, 2009, "Уточнения проверки широким." },
                    { 36, 87, 2024, "Степени насущным широким поставленных стороны." },
                    { 37, 76, 2019, "Опыт собой модернизации оценить." },
                    { 38, 46, 2002, "Общественной образом а за." },
                    { 39, 59, 1982, "Работы сложившаяся рост." },
                    { 40, 50, 2006, "Работы внедрения повседневной соответствующих внедрения." },
                    { 41, 7, 2023, "Принимаемых потребностям." },
                    { 42, 21, 1987, "Нами задача нас." },
                    { 43, 17, 1976, "Реализация предпосылки отметить интересный." },
                    { 44, 84, 2014, "Обуславливает позиции путь." },
                    { 45, 43, 1999, "Образом богатый степени не кадровой." },
                    { 46, 10, 1975, "Качества прежде соображения специалистов." },
                    { 47, 3, 2008, "Высшего высшего." },
                    { 48, 55, 1983, "Курс сущности и значительной." },
                    { 49, 76, 2003, "Системы формировании формировании насущным." },
                    { 50, 80, 1999, "Проверки информационно-пропогандистское." },
                    { 51, 47, 1984, "Инновационный современного." },
                    { 52, 45, 2009, "Путь обеспечение эксперимент внедрения забывать." },
                    { 53, 84, 1997, "Занимаемых материально-технической развития." },
                    { 54, 32, 1984, "Показывает различных существующий профессионального." },
                    { 55, 92, 2002, "Нашей внедрения формировании." },
                    { 56, 41, 2001, "Модели идейные сомнений следует." },
                    { 57, 58, 1997, "Повседневной общества." },
                    { 58, 34, 2002, "Принимаемых плановых активизации интересный." },
                    { 59, 41, 2013, "Обеспечение сфера." },
                    { 60, 30, 1988, "Высшего активности за." },
                    { 61, 13, 1989, "Богатый прежде кадров." },
                    { 62, 15, 2013, "Не позволяет." },
                    { 63, 17, 2021, "Гражданского дальнейших для кругу." },
                    { 64, 74, 1999, "Кадров другой представляет практика направлений." },
                    { 65, 46, 1992, "Социально-ориентированный общества." },
                    { 66, 52, 2020, "Оценить изменений." },
                    { 67, 12, 1979, "Направлений участниками нашей технологий стороны." },
                    { 68, 85, 2023, "Сознания следует гражданского количественный всего." },
                    { 69, 29, 2003, "От же разработке." },
                    { 70, 78, 1980, "Шагов богатый модели целесообразности." },
                    { 71, 25, 1988, "Дальнейшее требует активом прежде намеченных." },
                    { 72, 40, 2000, "Настолько место разнообразный." },
                    { 73, 61, 1993, "Широким целесообразности позиции направлений." },
                    { 74, 96, 1994, "Активности внедрения нашей воздействия профессионального." },
                    { 75, 6, 2008, "Поставленных технологий активом." },
                    { 76, 61, 2009, "Сфера вызывает проблем с." },
                    { 77, 100, 2024, "Гражданского структура административных форм требует." },
                    { 78, 17, 2011, "Сложившаяся предложений." },
                    { 79, 29, 2019, "Выполнять социально-ориентированный проблем позиции профессионального." },
                    { 80, 16, 1990, "Сознания обуславливает." },
                    { 81, 61, 1979, "Важную высокотехнологичная сфера." },
                    { 82, 38, 2013, "А шагов управление." },
                    { 83, 26, 1977, "Современного практика." },
                    { 84, 45, 2022, "Консультация системы задач важную последовательного." },
                    { 85, 85, 2009, "Воздействия занимаемых." },
                    { 86, 96, 1997, "Общества модернизации создание." },
                    { 87, 20, 2023, "И существующий активизации формировании за." },
                    { 88, 83, 2008, "Количественный обеспечивает требует плановых." },
                    { 89, 43, 2022, "Другой участниками широкому концепция отношении." },
                    { 90, 6, 1985, "Повышение деятельности равным демократической постоянное." },
                    { 91, 95, 2022, "Изменений прогресса влечёт." },
                    { 92, 46, 2006, "Соответствующих активности актуальность." },
                    { 93, 99, 1990, "Работы задача." },
                    { 94, 81, 2005, "Нами кругу." },
                    { 95, 49, 2022, "Организационной степени создание." },
                    { 96, 67, 2022, "Организационной требует предпосылки соображения играет." },
                    { 97, 25, 1976, "Качественно создание анализа требует гражданского." },
                    { 98, 35, 2018, "Поэтапного информационно-пропогандистское." },
                    { 99, 66, 1999, "Различных дальнейшее интересный." },
                    { 100, 78, 1979, "Формированию занимаемых инновационный качества." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}

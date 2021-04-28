/********************************************************************
 *  класс построения дерева жанров
 *   
 * 
 * *****************************************************************/
namespace Bibliotecar.TagsTitle
{
    class ListTitle
    {
        public readonly string[] HeaderNode = new[] { "Фантастика", "Детектив", "Проза", "Любовные Романы", 
                                                      "Приключения", "Детские", "Древнее", "Наука", "Компьютер", 
                                                      "Справочники", "Документальное", "Религия", "Юмор", "Дом и Семья"};

        //Фантастика
        public readonly string[] Sf  = new[]{"Альтернативная история", "Боевая Фантастика",
                                             "Эпическая Фантастика", "Героическая фантастика",
                                             "Детективная Фантастика", "Киберпанк", 
                                             "Космическая Фантастика", "Социальная фантастика", 
                                             "Ужасы и Мистика", "Юмористическая фантастика", 
                                             "Фэнтези", "Научная Фантастика", "Детская Фантастика"};
        
        public readonly string[] SfFind = new[]{"sf_history", "sf_action", "sf_epic", "sf_heroic", 
                                               "sf_detective", "sf_cyberpunk", "sf_space", "sf_social",
                                               "sf_horror", "sf_humor", "sf_fantasy", "sf", "child_sf"};

        //Детектив
        public readonly string[] Det = new[] { "Классический Детектив", "Полицейский Детектив",  
                                               "Боевики", "Иронический Детектив", "Исторический Детектив", 
                                               "Шпионский Детектив", "Криминальный Детектив",  "Политический Детектив",
                                               "Маньяки", "Крутой Детектив", "Детектив" };

        public readonly string[] DetFind = new[]{"det_classic", "det_police", "det_action", "det_irony", 
                                               "det_history", "det_espionage", "det_crime", "det_political",
                                               "det_maniac", "det_hard", "detective"};

        //Проза
        public readonly string[] Prose = new[] { "Проза", "Классическая Проза", "Историческая Проза", "Современная Проза", 
                                                "Контркультура", "Русская Классика", "Советская Классика"};

        public readonly string[] ProseFind = new[]{"prose", "prose_classic", "prose_history", "prose_contemporary", 
                                                   "prose_counter", "prose_rus_classic", "prose_su_classics"};

        //Любовные романы
        public readonly string[] Love = new[] { "Любовные романы", "Остросюжетные Любовные Романы", "Современные Любовные Романы",  
                                               "Исторические Любовные Романы", "Короткие Любовные Романы", "Эротика"};

        public readonly string[] LoveFind = new[]{"love", "love_detective", "love_contemporary", 
                                                   "love_history", "love_short", "love_erotica"};

        //Приключения
        public readonly string[] Advent = new[] { "Вестерны", "Исторические Приключения", "Приключения: Индейцы",  
                                                  "Морские Приключенияы", "Путешествия и География", "Природа и Животные",
                                                  "Приключения: Прочее"};

        public readonly string[] AdventFind = new[]{"adv_western", "adv_historye", "adv_indian", 
                                                   "adv_maritime", "adv_geo", "adv_animal", "adventure"};
        
        //Детское
        public readonly string[] Child = new[] { "Детские Приключения", "Детское", "Сказки", "Детские Стихи",  
                                                  "Детская Проза", "Детская Фантастика", "Детские Остросюжетные",
                                                  "Детские Приключения", "Детская Образовательная литература", "Детское: Прочее"};

        public readonly string[] ChildFind = new[]{"child_adv", "children", "child_tale", "child_verse", 
                                                   "child_prose", "child_sf", "child_det", "child_adv",
                                                   "child_education", "children"};

        //Древнее
        public readonly string[] Antiq = new[] { "Античная Литература", "Европейская Старинная Литература", 
                                                 "Древнерусская Литература", "Древневосточная Литература", 
                                                 "Мифы. Легенды. Эпос", "Старинная Литература: Прочее"};

        public readonly string[] AntiqFind = new[]{"antique_ant", "antique_european", "antique_russian", 
                                                   "antique_east", "antique_myths", "antique"};

        //Наука
        public readonly string[] Sci = new[]{"История", "Психология", "Культурология", "Религиоведение",
                                             "Философия", "Политика", "Деловая литература", "Юриспруденция", 
                                             "Языкознание", "Медицина", "Физика", "Математика", "Химия", 
                                             "Биология", "Технические", "Научно-образовательная: Прочее"};


        public readonly string[] SciFind = new[]{"sci_history", "sci_psychology", "sci_culture", 
                                                 "sci_religion", "sci_philosophy", "sci_politics", "sci_business", 
                                                 "sci_juris", "sci_linguistic", "sci_medicine", "sci_phys", 
                                                 "sci_math", "sci_chem", "sci_biology", "sci_tech", "science"};

        //Компьютер
        public readonly string[] Comp = new[]{"Интернет", "Программирование", "Компьютерное Железо", 
                                              "Программы", "Базы Данных", "ОС и Сети", "Компьютеры: Прочее"};


        public readonly string[] CompFind = new[]{"comp_www", "comp_programming", "comp_hard", 
                                                  "comp_soft", "comp_db", "comp_osnet", "computers"};

        //Справочники
        public readonly string[] Referen = new[]{"Энциклопедии", "Словари", "Справочники", 
                                                 "Руководства", "Справочная Литература: Прочее"};

        public readonly string[] ReferenFind = new[] { "ref_encyc", "ref_dict", "ref_ref", "ref_guide", "reference" };

        //Документальное
        public readonly string[] Nonf = new[]{"Биографии и Мемуары", "Публицистика", 
                                              "Критика", "Документальное: Прочее"};

        public readonly string[] NonfFind = new[] { "nonf_biography", "nonf_publicism", "nonf_criticism", "nonfiction" };

        //Религия
        public readonly string[] Religion = new[]{"Религия", "Религия", "Эзотерика", 
                                                 "Самосовершенствование", "Религия и духовность: Прочее"};

        public readonly string[] ReligionFind = new[] { "religion", "religion_rel", "religion_esoterics", 
                                                        "religion_self", "religion" };

        //Юмор
        public readonly string[] Humor = new[]{"Анекдоты", "Юмористическая Проза", 
                                               "Юмористические Стихи", "Юмор: Прочее"};

        public readonly string[] HumorFind = new[] { "humor_anecdote", "humor_prose", "humor_verse", "humor" };

        //Дом и Семья
        public readonly string[] Home = new[]{"Кулинария", "Домашние Животные", "Хобби, Ремесла", "Развлечения", 
                                              "Здоровье", "Сад и Огород", "Сделай Сам", "Спорт", "Эротика, Секс", 
                                              "Дом и Семья: Прочее"};

        public readonly string[] HomeFind = new[] { "home_cooking", "home_pets", "home_crafts", "home_entertain", 
                                                    "home_health", "home_garden", "home_diy", "home_sport", "home_sex", 
                                                    "home" };

        public string[][] ListNodes = new string[14][];
        public string [][]ListTitleNodes = new string[14][];

        public ListTitle()
        {
            int countData;

            ListNodes[0] = new string[Sf.Length];
            ListTitleNodes[0] = new string[Sf.Length];
            for (countData = 0; countData < Sf.Length; countData++)
            {
                ListNodes[0][countData] = Sf[countData];
                ListTitleNodes[0][countData] = SfFind[countData];
            }

            ListNodes[1] = new string[Det.Length];
            ListTitleNodes[1] = new string[Det.Length];
            for (countData = 0; countData < Det.Length; countData++)
            {
                ListNodes[1][countData] = Det[countData];
                ListTitleNodes[1][countData] = DetFind[countData];
            }
 
            ListNodes[2] = new string[Prose.Length];
            ListTitleNodes[2] = new string[Prose.Length];
            for (countData = 0; countData < Prose.Length; countData++)
            {
                ListNodes[2][countData] = Prose[countData];
                ListTitleNodes[2][countData] = ProseFind[countData];
            }

            ListNodes[3] = new string[Love.Length];
            ListTitleNodes[3] = new string[Prose.Length];
            for (countData = 0; countData < Love.Length; countData++)
            {
                ListNodes[3][countData] = Love[countData];
                ListTitleNodes[3][countData] = LoveFind[countData];
            }               

            ListNodes[4] = new string[Advent.Length];
            ListTitleNodes[4] = new string[Prose.Length];
            for (countData = 0; countData < Advent.Length; countData++)
            {
                ListNodes[4][countData] = Advent[countData];
                ListTitleNodes[4][countData] = AdventFind[countData];
            }                

            ListNodes[5] = new string[Child.Length];
            ListTitleNodes[5] = new string[Child.Length];
            for (countData = 0; countData < Child.Length; countData++)
            {
                ListNodes[5][countData] = Child[countData];
                ListTitleNodes[5][countData] = ChildFind[countData];
            }                 

            ListNodes[6] = new string[Antiq.Length];
            ListTitleNodes[6] = new string[Antiq.Length];
            for (countData = 0; countData < Antiq.Length; countData++)
            {
                ListNodes[6][countData] = Antiq[countData];
                ListTitleNodes[6][countData] = AntiqFind[countData];
            }                

            ListNodes[7] = new string[Sci.Length];
            ListTitleNodes[7] = new string[Sci.Length];
            for (countData = 0; countData < Sci.Length; countData++)
            {
                ListNodes[7][countData] = Sci[countData];
                ListTitleNodes[7][countData] = SciFind[countData];
            }                

            ListNodes[8] = new string[Comp.Length];
            ListTitleNodes[8] = new string[Comp.Length];
            for (countData = 0; countData < Comp.Length; countData++)
            {
                ListNodes[8][countData] = Comp[countData];
                ListTitleNodes[8][countData] = CompFind[countData];
            }                

            ListNodes[9] = new string[Referen.Length];
            ListTitleNodes[9] = new string[Referen.Length];
            for (countData = 0; countData < Referen.Length; countData++)
            {
                ListNodes[9][countData] = Referen[countData];
                ListTitleNodes[9][countData] = ReferenFind[countData];
            }                

            ListNodes[10] = new string[Nonf.Length];
            ListTitleNodes[10] = new string[Nonf.Length];
            for (countData = 0; countData < Nonf.Length; countData++)
            {
                ListNodes[10][countData] = Nonf[countData];
                ListTitleNodes[10][countData] = NonfFind[countData];
            }                

            ListNodes[11] = new string[Religion.Length];
            ListTitleNodes[11] = new string[Religion.Length];
            for (countData = 0; countData < Religion.Length; countData++)
            {
                ListNodes[11][countData] = Religion[countData];
                ListTitleNodes[11][countData] = ReligionFind[countData];
            }                

            ListNodes[12] = new string[Humor.Length];
            ListTitleNodes[12] = new string[Humor.Length];
            for (countData = 0; countData < Humor.Length; countData++)
            {
                ListNodes[12][countData] = Humor[countData];
                ListTitleNodes[12][countData] = HumorFind[countData];
            }

            ListNodes[13] = new string[Home.Length];
            ListTitleNodes[13] = new string[Home.Length];
            for (countData = 0; countData < Home.Length; countData++)
            {
                ListNodes[13][countData] = Home[countData];
                ListTitleNodes[13][countData] = HomeFind[countData];
            }
        }    
    }
}

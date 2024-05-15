using Cinema.Models.DbContexts;

namespace Cinema.Models
{
    public class SeedData
    {
        public static void FillingMovies(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FilmDbContext>();

                if (context == null || (!context.FilmRatings.Any() && !context.Films.Any()))
                {
                    Film film1 = new Film
                    {
                        Name = "Аватар: Путь воды",
                        Director = "Джеймс Кэмерон",
                        Description = "После принятия образа аватара солдат Джейк Салли становится предводителем народа на'ви и берет на себя миссию по защите новых друзей от корыстных бизнесменов с Земли. Теперь ему есть за кого бороться — с Джейком его прекрасная возлюбленная Нейтири. Когда на Пандору возвращаются до зубов вооруженные земляне, Джейк готов дать им отпор."
                    };
                    Film film2 = new Film
                    {
                        Name = "Интерстеллар",
                        Director = "Кристофер Нолан",
                        Description = "Когда засуха, пыльные бури и вымирание растений приводят человечество к продовольственному кризису, коллектив исследователей и учёных отправляется сквозь червоточину (которая предположительно соединяет области пространства-времени через большое расстояние) в путешествие, чтобы превзойти прежние ограничения для космических путешествий человека и найти планету с подходящими для человечества условиями."
                    };
                    Film film3 = new Film
                    {
                        Name = "Твоё имя",
                        Director = "Макото Синкай",
                        Description = "Токийский парень Таки и провинциальная девушка Мицуха обнаруживают, что между ними существует странная связь. Во сне они меняются телами и проживают жизни друг друга. Но однажды эта способность исчезает так же внезапно, как появилась. Таки решает во что бы то ни стало отыскать Мицуху."
                    };

                    FilmRating rating1 = new FilmRating
                    {
                        Rating = 8,
                        Film = film1
                    };

                    FilmRating rating2 = new FilmRating
                    {
                        Rating = 9,
                        Film = film1
                    };

                    FilmRating rating3 = new FilmRating
                    {
                        Rating = 3,
                        Film = film2
                    };

                    FilmRating rating4 = new FilmRating
                    {
                        Rating = 3,
                        Film = film3
                    };

                    if (context != null)
                    {
                        context.Films.AddRange(film1, film2, film3);
                        context.FilmRatings.AddRange(rating1, rating2, rating3, rating4);
                        context.SaveChanges();
                    } else
                    {
                        throw new Exception("База данных пуста");
                    }
                    
                }
            }
        }

        public static void DeleteFilms(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<FilmDbContext>();

                foreach (var item in context.Films)
                {
                    context.Films.Remove(item);
                }

                foreach (var item in context.FilmRatings)
                {
                    context.FilmRatings.Remove(item);
                }

                context.SaveChanges();
            }
        }
    }
}

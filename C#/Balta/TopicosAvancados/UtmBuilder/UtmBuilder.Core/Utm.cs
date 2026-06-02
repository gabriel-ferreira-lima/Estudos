using UtmBuilder.Core.Extensions;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core {
    public class Utm {

        public Utm(Url url, Campaign campaign) {
            Url = url;
            Campaign = campaign;
        }

        /// <summary>
        /// URL (Website Link)
        /// </summary>
        public Url Url { get; }

        /// <summary>
        /// Campaign Details
        /// </summary>
        public Campaign Campaign { get; }

        public static implicit operator string(Utm utm) {
            return utm.ToString();
        }

        public static implicit operator Utm(string link) {
            InvalidUrlException.ThrowIfInvalid(link);

            var url = new Url(link);
            var segments = url.Address.Split("?");
            if (segments.Length == 1) {
                throw new InvalidUrlException("No segments were provided");
            }

            var pars = segments[1].Split("&");
            var source = pars.Where(x => x.StartsWith("utm_source=")).FirstOrDefault("").Split("=")[1];
            var medium = pars.Where(x => x.StartsWith("utm_medium=")).FirstOrDefault("").Split("=")[1];
            var name = pars.Where(x => x.StartsWith("utm_campaign=")).FirstOrDefault("").Split("=")[1];
            var id = pars.Where(x => x.StartsWith("utm_id=")).FirstOrDefault("").Split("=")[1];
            var term = pars.Where(x => x.StartsWith("utm_term=")).FirstOrDefault("").Split("=")[1];
            var content = pars.Where(x => x.StartsWith("utm_content=")).FirstOrDefault("").Split("=")[1];

            var utm = new Utm(new Url(segments[0]), new Campaign(source, medium, name, id, term, content));

            return utm;
        }

        public override string ToString() {
            var segments = new List<string>();
            segments.AddIfNotNull("utm_source", Campaign.Source);
            segments.AddIfNotNull("utm_medium", Campaign.Medium);
            segments.AddIfNotNull("utm_campaign", Campaign.Name);
            segments.AddIfNotNull("utm_id", Campaign.Id);
            segments.AddIfNotNull("utm_term", Campaign.Term);
            segments.AddIfNotNull("utm_content", Campaign.Content);

            return $"{Url.Address}?{string.Join("&", segments)}";
        }
    }

    public class Teste() {
        
        public void Teste2() {
            var url = "https://www.example.com?utm_source=google&utm_medium=cpc&utm_campaign=spring_sale&utm_id=123&utm_term=shoes&utm_content=ad1";
            string utm = (Utm)url;
        }
    }
}
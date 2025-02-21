namespace Progetto_S14_L5.Models
{
    public class Shoes
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public string? MainImage { get; set; }
        public List<string> Images { get; set; } = [];

        public static List<string> shoesImgs =
        [
            "https://img.freepik.com/vettori-gratuito/icona-dello-sport-di-scarpe-da-tennis-blu_18591-82518.jpg?t=st=1740129481~exp=1740133081~hmac=c3458c31705a1471f74595cee586933cb866759bddecc342d8cf11182ae96c23&w=1380",
            "https://img.freepik.com/vettori-gratuito/insieme-dell-illustrazione-del-disegno-della-mano-delle-icone-di-wanderlust_53876-28446.jpg?t=st=1740129548~exp=1740133148~hmac=0ba8bc15bfa83735e645ee0b3457789ba05757e22337109bea00febd91a07223&w=400",
            "https://img.freepik.com/vettori-gratuito/scarpe-donna-disegno_1268-344.jpg?t=st=1740129590~exp=1740133190~hmac=3f8c1d385c2f23ae358bb7dba73237db69c15fe6555596a98be388d2bae8d033&w=400",
            "https://img.freepik.com/vettori-gratuito/le-scarpe-da-tennis-moderne-di-sport-di-colore-blu-con-i-laccetti-bianchi-realizzano-la-singola-immagine-sull-illustrazione-isolata-fondo-bianco_1284-31208.jpg?t=st=1740129627~exp=1740133227~hmac=667a6febf15b3079011c7a13213e662160409b9981c63de82df14184f461f503&w=400",
            "https://assets.adidas.com/images/w_400,f_auto,q_auto/284a892018974be28d6be73d110e0d03_9366/Scarpe_Falcon_Rosa_IE8203.jpg",
            "https://www.bfgcdn.com/1500_1500_90/123-1195-0511/the-north-face-womens-vectiv-enduris-3-scarpe-per-trail-running.jpg",
            "https://www.misterrunning.com/media/products/2023-media-07/the-north-face-vectiv-enduris-3-scarpe-trail-donna-asphalt-grey-nf0a7w5pqn2_A-600x600.jpg",
            "https://image-raw.reversible.com/raw_images/717d5b072f1bd402ef008cad8c54169ea8c4b606d07b3bb08bd8b51eac376353",
        ];
    }
}

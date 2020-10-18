using System.Text.Json.Serialization;

namespace GScrape.Requests.BestBuy.Json
{
    public class ItemShopPayload
    {
        [JsonPropertyName("app")]
        public App App_ { get; set; }

        [JsonPropertyName("metaLayer")]
        public MetaLayer MetaLayer_ { get; set; }

        [JsonPropertyName("searchDerived")]
        public SearchDerived SearchDerived_ { get; set; }

        [JsonPropertyName("sku")]
        public Sku Sku_ { get; set; }

        public class App
        {
            [JsonPropertyName("skuId")]
            public string SkuId { get; set; }

            [JsonPropertyName("deviceClass")]
            public string DeviceClass { get; set; }

            [JsonPropertyName("instanceId")]
            public string InstanceId { get; set; }

            [JsonPropertyName("inViewport")]
            public bool InViewport { get; set; }

            [JsonPropertyName("isSponsored")]
            public bool IsSponsored { get; set; }

            [JsonPropertyName("highlightedVariationSkuId")]
            public string HighlightedVariationSkuId { get; set; }

            [JsonPropertyName("lazyLoadOffset")]
            public long LazyLoadOffset { get; set; }

            [JsonPropertyName("disableFulfillmentForVariation")]
            public bool DisableFulfillmentForVariation { get; set; }
        }

        public class MetaLayer
        {
            [JsonPropertyName("env_piscesUrl")]
            public string EnvPiscesUrl { get; set; }

            [JsonPropertyName("env_appServer")]
            public string EnvAppServer { get; set; }
        }

        public class SearchDerived
        {
            [JsonPropertyName("isOpenBoxFacetSelected")]
            public bool IsOpenBoxFacetSelected { get; set; }
        }

        public class Sku
        {
            [JsonPropertyName("image")]
            public Image Image { get; set; }

            [JsonPropertyName("link")]
            public string Link { get; set; }

            [JsonPropertyName("model")]
            public string Model { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("skuId")]
            public string SkuId { get; set; }

            [JsonPropertyName("releaseDate")]
            public ReleaseDate ReleaseDate { get; set; }

            [JsonPropertyName("isOpenBoxAvailable")]
            public bool IsOpenBoxAvailable { get; set; }

            [JsonPropertyName("isNew")]
            public bool IsNew { get; set; }

            [JsonPropertyName("isOpenBoxOnly")]
            public bool IsOpenBoxOnly { get; set; }
        }

        public class Image
        {
            [JsonPropertyName("alt")]
            public string Alt { get; set; }

            [JsonPropertyName("src")]
            public string Src { get; set; }
        }

        public class ReleaseDate
        {
            [JsonPropertyName("notYetAnnounced")]
            public bool NotYetAnnounced { get; set; }

            [JsonPropertyName("date")]
            public string Date { get; set; }
        }
    }
}
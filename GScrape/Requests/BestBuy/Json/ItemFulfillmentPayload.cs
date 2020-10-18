using System.Text.Json.Serialization;

namespace GScrape.Requests.BestBuy.Json
{
    public class ItemFulfillmentPayload
    {
        [JsonPropertyName("app")]
        public App App_ { get; set; }

        [JsonPropertyName("items")]
        public Item[] Items_ { get; set; }

        [JsonPropertyName("buttonState")]
        public ButtonState ButtonState_ { get; set; }

        [JsonPropertyName("metaLayer")]
        public MetaLayer MetaLayer_ { get; set; }

        public class App
        {
            [JsonPropertyName("attachModal")]
            public Modal AttachModal { get; set; }

            [JsonPropertyName("tests")]
            public Tests Tests { get; set; }

            [JsonPropertyName("context")]
            public string Context { get; set; }

            [JsonPropertyName("xboxAllAccess")]
            public bool XboxAllAccess { get; set; }

            [JsonPropertyName("instanceId")]
            public string InstanceId { get; set; }

            [JsonPropertyName("blockLevel")]
            public bool BlockLevel { get; set; }

            [JsonPropertyName("size")]
            public string Size { get; set; }

            [JsonPropertyName("disabled")]
            public bool Disabled { get; set; }

            [JsonPropertyName("chatForServiceUrl")]
            public string ChatForServiceUrl { get; set; }

            [JsonPropertyName("learnMoreUrl")]
            public string LearnMoreUrl { get; set; }

            [JsonPropertyName("attachModalEnabled")]
            public bool AttachModalEnabled { get; set; }

            [JsonPropertyName("buttonStateSourceRouteEnabled")]
            public bool ButtonStateSourceRouteEnabled { get; set; }

            [JsonPropertyName("inHomeConsultationUrl")]
            public string InHomeConsultationUrl { get; set; }

            [JsonPropertyName("maxComboSkusExceeded")]
            public bool MaxComboSkusExceeded { get; set; }

            [JsonPropertyName("soldOutDispatchDisabled")]
            public bool SoldOutDispatchDisabled { get; set; }

            [JsonPropertyName("reportingVariables")]
            public DisasterFallBackLists ReportingVariables { get; set; }

            [JsonPropertyName("pickupTodayStores")]
            public object[] PickupTodayStores { get; set; }

            [JsonPropertyName("disasterFallBackLists")]
            public DisasterFallBackLists DisasterFallBackLists { get; set; }

            [JsonPropertyName("xboxAllAccessModal")]
            public Modal XboxAllAccessModal { get; set; }

            [JsonPropertyName("skuPdpUrl")]
            public string SkuPdpUrl { get; set; }
        }

        public class Modal
        {
            [JsonPropertyName("isShowing")]
            public bool IsShowing { get; set; }

            [JsonPropertyName("instanceNumber")]
            public long InstanceNumber { get; set; }
        }

        public class DisasterFallBackLists
        {
        }

        public class Tests
        {
            [JsonPropertyName("sold-out-openbox")]
            public ComboAvailabilityPlp SoldOutOpenbox { get; set; }

            [JsonPropertyName("combo-availability-plp")]
            public ComboAvailabilityPlp ComboAvailabilityPlp { get; set; }
        }

        public class ComboAvailabilityPlp
        {
            [JsonPropertyName("scaled")]
            public bool Scaled { get; set; }

            [JsonPropertyName("ignore")]
            public bool Ignore { get; set; }
        }

        public class ButtonState
        {
            [JsonPropertyName("$__path")]
            public object[] Path { get; set; }

            [JsonPropertyName("buttonState")]
            public string BSState { get; set; }

            [JsonPropertyName("displayText")]
            public string DisplayText { get; set; }
        }

        public class Item
        {
            [JsonPropertyName("skuId")]
            public string SkuId { get; set; }

            [JsonPropertyName("condition")]
            public object Condition { get; set; }

            [JsonPropertyName("tags")]
            public string[] Tags { get; set; }
        }

        public class MetaLayer
        {
            [JsonPropertyName("env_assets")]
            public string EnvAssets { get; set; }

            [JsonPropertyName("env_piscesUrl")]
            public string EnvPiscesUrl { get; set; }

            [JsonPropertyName("env_appServer")]
            public string EnvAppServer { get; set; }
        }
    }
}
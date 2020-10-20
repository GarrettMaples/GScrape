using System;
using System.Text.Json.Serialization;

namespace GScrape.Requests.Walmart.Json
{
    public class ItemPayload
    {
        [JsonPropertyName("item")]
        public Item Item { get; set; }
    }

    public class Item
    {
        [JsonPropertyName("ads")]
        public Ads Ads { get; set; }

        [JsonPropertyName("uuid")]
        public object Uuid { get; set; }

        [JsonPropertyName("host")]
        public string Host { get; set; }

        [JsonPropertyName("isMobile")]
        public bool IsMobile { get; set; }

        [JsonPropertyName("isPacLoaded")]
        public bool IsPacLoaded { get; set; }

        [JsonPropertyName("pacRedirectUrl")]
        public string PacRedirectUrl { get; set; }

        [JsonPropertyName("isBot")]
        public bool IsBot { get; set; }

        [JsonPropertyName("isEsiEnabled")]
        public bool IsEsiEnabled { get; set; }

        [JsonPropertyName("isInitialStateDeferred")]
        public bool IsInitialStateDeferred { get; set; }

        [JsonPropertyName("isServiceWorkerEnabled")]
        public bool IsServiceWorkerEnabled { get; set; }

        [JsonPropertyName("isShellRequest")]
        public bool IsShellRequest { get; set; }

        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("fetchConfig")]
        public FetchConfig FetchConfig { get; set; }

        [JsonPropertyName("ccm")]
        public AddToList Ccm { get; set; }

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; }

        [JsonPropertyName("referer")]
        public object Referer { get; set; }

        [JsonPropertyName("verticalId")]
        public string VerticalId { get; set; }

        [JsonPropertyName("siteMode")]
        public int SiteMode { get; set; }

        [JsonPropertyName("product")]
        public ItemProduct Product { get; set; }

        [JsonPropertyName("showTrustModal")]
        public bool ShowTrustModal { get; set; }

        [JsonPropertyName("fulfillmentOptions")]
        public FulfillmentOptions FulfillmentOptions { get; set; }

        [JsonPropertyName("feedback")]
        public Feedback Feedback { get; set; }

        [JsonPropertyName("addToRegistry")]
        public AddToList AddToRegistry { get; set; }

        [JsonPropertyName("addToList")]
        public AddToList AddToList { get; set; }

        [JsonPropertyName("wpaMap")]
        public WpaMap WpaMap { get; set; }

        [JsonPropertyName("btvMap")]
        public BtvMap BtvMap { get; set; }

        [JsonPropertyName("postQuestion")]
        public AddToList PostQuestion { get; set; }

        [JsonPropertyName("lastAction")]
        public string[] LastAction { get; set; }

        [JsonPropertyName("nextDay")]
        public ItemNextDay NextDay { get; set; }

        [JsonPropertyName("easyReorder")]
        public EasyReorder EasyReorder { get; set; }

        [JsonPropertyName("location")]
        public ItemLocation Location { get; set; }

        [JsonPropertyName("isAjaxCall")]
        public bool IsAjaxCall { get; set; }

        [JsonPropertyName("accessModeEnabled")]
        public bool AccessModeEnabled { get; set; }

        [JsonPropertyName("productQuimbyData")]
        public ProductQuimbyData ProductQuimbyData { get; set; }

        [JsonPropertyName("cartData")]
        public AddToList CartData { get; set; }

        [JsonPropertyName("productComparison")]
        public ProductComparison ProductComparison { get; set; }

        [JsonPropertyName("isCachable")]
        public bool IsCachable { get; set; }

        [JsonPropertyName("relmData")]
        public RelmDatum[] RelmData { get; set; }

        [JsonPropertyName("reviews")]
        public ItemReviews Reviews { get; set; }

        [JsonPropertyName("productBuyBoxAppState")]
        public AddToList ProductBuyBoxAppState { get; set; }

        [JsonPropertyName("productBuyBoxLoader")]
        public ProductBuyBoxLoader ProductBuyBoxLoader { get; set; }

        [JsonPropertyName("heart")]
        public Heart Heart { get; set; }
    }

    public class AddToList
    {
    }

    public class Ads
    {
        [JsonPropertyName("config")]
        public Config Config { get; set; }

        [JsonPropertyName("display")]
        public AddToList Display { get; set; }

        [JsonPropertyName("networkCode")]
        public long NetworkCode { get; set; }

        [JsonPropertyName("wpa")]
        public AddToList Wpa { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("crawler")]
        public bool Crawler { get; set; }

        [JsonPropertyName("bot")]
        public bool Bot { get; set; }

        [JsonPropertyName("ivtScore")]

        public string IvtScore { get; set; }

        [JsonPropertyName("ivtTorbot")]
        public string IvtTorbot { get; set; }

        [JsonPropertyName("mapping")]
        public AddToList Mapping { get; set; }
    }

    public class Config
    {
        [JsonPropertyName("lazy-homepage-expose1")]

        public string LazyHomepageExpose1 { get; set; }

        [JsonPropertyName("lazy-search-expose1")]

        public string LazySearchExpose1 { get; set; }

        [JsonPropertyName("lazy-browse-expose1")]

        public string LazyBrowseExpose1 { get; set; }

        [JsonPropertyName("lazy-category-expose1")]

        public string LazyCategoryExpose1 { get; set; }

        [JsonPropertyName("no-category-marquee2")]
        public bool NoCategoryMarquee2 { get; set; }

        [JsonPropertyName("no-deals-skyline1")]
        public bool NoDealsSkyline1 { get; set; }

        [JsonPropertyName("no-homepage-twocolumnhp")]
        public bool NoHomepageTwocolumnhp { get; set; }

        [JsonPropertyName("lazy-item-expose1")]

        public string LazyItemExpose1 { get; set; }

        [JsonPropertyName("lazy-item-marquee2")]

        public string LazyItemMarquee2 { get; set; }

        [JsonPropertyName("lazy-item-rightrail2")]

        public string LazyItemRightrail2 { get; set; }

        [JsonPropertyName("displayAds")]
        public string DisplayAds { get; set; }

        [JsonPropertyName("adblockImgSource")]
        public string AdblockImgSource { get; set; }

        [JsonPropertyName("isTwoDayDeliveryTextEnabled")]
        public bool IsTwoDayDeliveryTextEnabled { get; set; }

        [JsonPropertyName("ads2s")]
        public bool Ads2S { get; set; }

        [JsonPropertyName("bypassproxy")]
        public bool Bypassproxy { get; set; }

        [JsonPropertyName("adblockDetectionEnabled")]
        public bool AdblockDetectionEnabled { get; set; }

        [JsonPropertyName("remoteAddress")]
        public string RemoteAddress { get; set; }

        [JsonPropertyName("cloud")]
        public string Cloud { get; set; }
    }

    public class BtvMap
    {
        [JsonPropertyName("btvPlacementBeaconAction")]
        public AddToList BtvPlacementBeaconAction { get; set; }

        [JsonPropertyName("terra")]
        public Terra Terra { get; set; }

        [JsonPropertyName("selection")]
        public object Selection { get; set; }

        [JsonPropertyName("ui")]
        public BtvMapUi Ui { get; set; }
    }

    public class Terra
    {
        [JsonPropertyName("variantCategoriesMap")]
        public AddToList VariantCategoriesMap { get; set; }

        [JsonPropertyName("products")]
        public AddToList Products { get; set; }

        [JsonPropertyName("offers")]
        public AddToList Offers { get; set; }

        [JsonPropertyName("images")]
        public AddToList Images { get; set; }

        [JsonPropertyName("sellers")]
        public AddToList Sellers { get; set; }

        [JsonPropertyName("buyTogetherValue")]
        public AddToList BuyTogetherValue { get; set; }
    }

    public class BtvMapUi
    {
        [JsonPropertyName("hidden")]
        public bool Hidden { get; set; }

        [JsonPropertyName("isChoice")]
        public bool IsChoice { get; set; }

        [JsonPropertyName("anchor")]
        public Anchor Anchor { get; set; }

        [JsonPropertyName("accessories")]
        public object[] Accessories { get; set; }

        [JsonPropertyName("offers")]
        public Offers Offers { get; set; }

        [JsonPropertyName("seller")]
        public Seller Seller { get; set; }
    }

    public class Anchor
    {
        [JsonPropertyName("selectedVariants")]
        public object[] SelectedVariants { get; set; }
    }

    public class Offers
    {
        [JsonPropertyName("badges")]
        public object[] Badges { get; set; }

        [JsonPropertyName("ageRestriction")]
        public object AgeRestriction { get; set; }

        [JsonPropertyName("legalRatingType")]
        public object LegalRatingType { get; set; }

        [JsonPropertyName("legalRatingValue")]
        public object LegalRatingValue { get; set; }

        [JsonPropertyName("totalPrice")]
        public int TotalPrice { get; set; }

        [JsonPropertyName("totalSavings")]
        public int TotalSavings { get; set; }

        [JsonPropertyName("selectedOffers")]
        public object[] SelectedOffers { get; set; }

        [JsonPropertyName("hasSavings")]
        public bool HasSavings { get; set; }

        [JsonPropertyName("shippingPassEligible")]
        public bool ShippingPassEligible { get; set; }

        [JsonPropertyName("twoDayShippingEligible")]
        public bool TwoDayShippingEligible { get; set; }
    }

    public class Seller
    {
        [JsonPropertyName("catalogSellerId")]
        public int CatalogSellerId { get; set; }

        [JsonPropertyName("sellerDisplayName")]
        public string SellerDisplayName { get; set; }

        [JsonPropertyName("sellerId")]
        public int SellerId { get; set; }

        [JsonPropertyName("sellerType")]
        public string SellerType { get; set; }
    }

    public class EasyReorder
    {
        [JsonPropertyName("quantitiesInCart")]
        public AddToList QuantitiesInCart { get; set; }
    }

    public class Feedback
    {
        [JsonPropertyName("showFeedbackContainer")]
        public bool ShowFeedbackContainer { get; set; }
    }

    public class FetchConfig
    {
        [JsonPropertyName("terraUsePOST")]
        public bool TerraUsePost { get; set; }

        [JsonPropertyName("terraFetchUrl")]
        public Uri TerraFetchUrl { get; set; }

        [JsonPropertyName("terraAjaxFetchUrl")]
        public string TerraAjaxFetchUrl { get; set; }

        [JsonPropertyName("useLocation")]
        public bool UseLocation { get; set; }

        [JsonPropertyName("terraConsumerId")]
        public Guid TerraConsumerId { get; set; }
    }

    public class FulfillmentOptions
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("showContainer")]
        public bool ShowContainer { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("didInvalidate")]
        public bool DidInvalidate { get; set; }

        [JsonPropertyName("locationErrorMessage")]
        public string LocationErrorMessage { get; set; }

        [JsonPropertyName("loaded")]
        public bool Loaded { get; set; }
    }

    public class Heart
    {
        [JsonPropertyName("hearts")]
        public AddToList Hearts { get; set; }
    }

    public class ItemLocation
    {
        [JsonPropertyName("location")]
        public LocationLocation Location { get; set; }
    }

    public class LocationLocation
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("postalCode")]

        public string PostalCode { get; set; }

        [JsonPropertyName("isZipLocated")]
        public bool IsZipLocated { get; set; }

        [JsonPropertyName("nextDay")]
        public LocationNextDay NextDay { get; set; }

        [JsonPropertyName("stores")]
        public Store[] Stores { get; set; }
    }

    public class LocationNextDay
    {
        [JsonPropertyName("cutoffTime")]
        public long? CutoffTime { get; set; }

        [JsonPropertyName("eligible")]
        public bool Eligible { get; set; }

        [JsonPropertyName("tempUnavailable")]
        public bool TempUnavailable { get; set; }

        [JsonPropertyName("targetDate")]
        public long? TargetDate { get; set; }

        [JsonPropertyName("cutoffTtl")]
        public object CutoffTtl { get; set; }
    }

    public class Store
    {
        [JsonPropertyName("storeId")]

        public string StoreId { get; set; }

        [JsonPropertyName("types")]
        public string[] Types { get; set; }

        [JsonPropertyName("distance")]
        public double Distance { get; set; }
    }

    public class ItemNextDay
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }

    public class ItemProduct
    {
        [JsonPropertyName("ads")]
        public Ads Ads { get; set; }

        [JsonPropertyName("addOnServices")]
        public AddToList AddOnServices { get; set; }

        [JsonPropertyName("carePlans")]
        public CarePlans CarePlans { get; set; }

        [JsonPropertyName("homeServices")]
        public AddToList HomeServices { get; set; }

        [JsonPropertyName("cellCoverageFinder")]
        public CellCoverageFinder CellCoverageFinder { get; set; }

        [JsonPropertyName("collectionId")]
        public string CollectionId { get; set; }

        [JsonPropertyName("completeTheLook")]
        public AddToList CompleteTheLook { get; set; }

        [JsonPropertyName("fashionCategoryNavBar")]
        public AddToList FashionCategoryNavBar { get; set; }

        [JsonPropertyName("idmlMap")]
        public IdmlMap IdmlMap { get; set; }

        [JsonPropertyName("idmlModal")]
        public IdmlModal IdmlModal { get; set; }

        [JsonPropertyName("itemBadge")]
        public AddToList ItemBadge { get; set; }

        [JsonPropertyName("itemPOVS")]
        public AddToList ItemPovs { get; set; }

        [JsonPropertyName("stringLeadTime")]
        public bool stringLeadTime { get; set; }

        [JsonPropertyName("midasContext")]
        public MidasContext MidasContext { get; set; }

        [JsonPropertyName("oosView")]
        public bool OosView { get; set; }

        [JsonPropertyName("preferredStoreId")]
        public string PreferredStoreId { get; set; }

        [JsonPropertyName("premiumBrandBanner")]
        public AddToList PremiumBrandBanner { get; set; }

        [JsonPropertyName("promotionalMessage")]
        public AddToList PromotionalMessage { get; set; }

        [JsonPropertyName("questionAnswers")]
        public QuestionAnswers QuestionAnswers { get; set; }

        [JsonPropertyName("reviews")]
        public ProductReviews Reviews { get; set; }

        [JsonPropertyName("buyBox")]
        public BuyBox BuyBox { get; set; }

        [JsonPropertyName("appState")]
        public State AppState { get; set; }

        [JsonPropertyName("addToCart")]
        public AddToCart AddToCart { get; set; }

        [JsonPropertyName("imagesState")]
        public int ImagesState { get; set; }

        [JsonPropertyName("selectedAddOnServices")]
        public object[] SelectedAddOnServices { get; set; }

        [JsonPropertyName("checkoutComments")]
        public CheckoutComments CheckoutComments { get; set; }
    }

    public class AddToCart
    {
        [JsonPropertyName("actionStatus")]
        public string ActionStatus { get; set; }

        [JsonPropertyName("addToCartError")]
        public AddToList AddToCartError { get; set; }
    }

    public class State
    {
        [JsonPropertyName("action")]
        public string Action { get; set; }

        [JsonPropertyName("product")]
        public int Product { get; set; }
    }

    public class BuyBox
    {
        [JsonPropertyName("primaryProductId")]
        public string PrimaryProductId { get; set; }

        [JsonPropertyName("primaryUsItemId")]

        public string PrimaryUsItemId { get; set; }

        [JsonPropertyName("prices")]
        public object[] Prices { get; set; }

        [JsonPropertyName("states")]
        public State[] States { get; set; }

        [JsonPropertyName("criteria")]
        public object[] Criteria { get; set; }

        [JsonPropertyName("images")]
        public object[] Images { get; set; }

        [JsonPropertyName("products")]
        public ProductElement[] Products { get; set; }

        [JsonPropertyName("verticalId")]
        public string VerticalId { get; set; }

        [JsonPropertyName("verticalTheme")]
        public string VerticalTheme { get; set; }

        [JsonPropertyName("walledGarden")]
        public bool WalledGarden { get; set; }

        [JsonPropertyName("athenaCategoryPathId")]
        public string AthenaCategoryPathId { get; set; }

        [JsonPropertyName("athenaPrimaryShelfId")]

        public string AthenaPrimaryShelfId { get; set; }

        [JsonPropertyName("athenaOfferType")]
        public string AthenaOfferType { get; set; }

        [JsonPropertyName("athenaAvailabilityStatus")]
        public string AthenaAvailabilityStatus { get; set; }

        [JsonPropertyName("lastSelectedItem")]
        public string LastSelectedItem { get; set; }

        [JsonPropertyName("select")]
        public string Select { get; set; }
    }

    public class ProductElement
    {
        [JsonPropertyName("isDigitalVariant")]
        public bool IsDigitalVariant { get; set; }

        [JsonPropertyName("isAudioBookVariant")]
        public bool IsAudioBookVariant { get; set; }

        [JsonPropertyName("showBuyNowButton")]
        public bool ShowBuyNowButton { get; set; }

        [JsonPropertyName("showFreeTrialButton")]
        public bool ShowFreeTrialButton { get; set; }

        [JsonPropertyName("isKeySpecFeatureEnabled")]
        public bool IsKeySpecFeatureEnabled { get; set; }

        [JsonPropertyName("isReduceOtherSellersEnabled")]
        public bool IsReduceOtherSellersEnabled { get; set; }

        [JsonPropertyName("brandName")]
        public string BrandName { get; set; }

        [JsonPropertyName("otherInfoLabel")]
        public string OtherInfoLabel { get; set; }

        [JsonPropertyName("otherInfoValue")]
        public string OtherInfoValue { get; set; }

        [JsonPropertyName("analyticsType")]
        public string AnalyticsType { get; set; }

        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("usItemId")]

        public string UsItemId { get; set; }

        [JsonPropertyName("upc")]
        public string Upc { get; set; }

        [JsonPropertyName("fetched")]
        public bool Fetched { get; set; }

        [JsonPropertyName("images")]
        public Image[] Images { get; set; }

        [JsonPropertyName("variants")]
        public object[] Variants { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; }

        [JsonPropertyName("bvShellProductName")]
        public string BvShellProductName { get; set; }

        [JsonPropertyName("categoryPathId")]
        public string CategoryPathId { get; set; }

        [JsonPropertyName("personalizationData")]
        public AddToList PersonalizationData { get; set; }

        [JsonPropertyName("inflexibleKitGroupComponents")]
        public object InflexibleKitGroupComponents { get; set; }

        [JsonPropertyName("groupType")]
        public string GroupType { get; set; }

        [JsonPropertyName("path")]
        public Path[] Path { get; set; }

        [JsonPropertyName("categoryPath")]
        public string CategoryPath { get; set; }

        [JsonPropertyName("rhPath")]
        public string RhPath { get; set; }

        [JsonPropertyName("primaryShelfId")]

        public string PrimaryShelfId { get; set; }

        [JsonPropertyName("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("detailedDescription")]
        public string DetailedDescription { get; set; }

        [JsonPropertyName("productHighlightedAttributes")]
        public object[] ProductHighlightedAttributes { get; set; }

        [JsonPropertyName("salesRank")]
        public AddToList SalesRank { get; set; }

        [JsonPropertyName("walmartItemNumber")]

        public string WalmartItemNumber { get; set; }

        [JsonPropertyName("classId")]

        public string ClassId { get; set; }

        [JsonPropertyName("ironbankCategory")]
        public string IronbankCategory { get; set; }

        [JsonPropertyName("offerId")]
        public string OfferId { get; set; }

        [JsonPropertyName("offerType")]
        public string OfferType { get; set; }

        [JsonPropertyName("offers")]
        public object[] Offers { get; set; }

        [JsonPropertyName("offerCount")]
        public int OfferCount { get; set; }

        [JsonPropertyName("isOnline")]
        public bool IsOnline { get; set; }

        [JsonPropertyName("sellerOfferId")]
        public string SellerOfferId { get; set; }

        [JsonPropertyName("shippingOptions")]
        public ShippingOption[] ShippingOptions { get; set; }

        [JsonPropertyName("highlightedShippingOption")]
        public HighlightedShippingOption HighlightedShippingOption { get; set; }

        [JsonPropertyName("shippingOptionIndex")]
        public int ShippingOptionIndex { get; set; }

        [JsonPropertyName("freeShippingThresholdPrice")]
        public AddToList FreeShippingThresholdPrice { get; set; }

        [JsonPropertyName("nextDayShippingOptionIndex")]
        public int NextDayShippingOptionIndex { get; set; }

        [JsonPropertyName("shippable")]
        public bool Shippable { get; set; }

        [JsonPropertyName("hasShippingRestrictions")]
        public bool HasShippingRestrictions { get; set; }

        [JsonPropertyName("locationSurcharge")]
        public bool LocationSurcharge { get; set; }

        [JsonPropertyName("upsellShippingOptionIndex")]
        public int UpsellShippingOptionIndex { get; set; }

        [JsonPropertyName("upsellFulfillmentOption")]
        public UpsellFulfillmentOption UpsellFulfillmentOption { get; set; }

        [JsonPropertyName("shippingOptionToDisplay")]
        public ShippingOption ShippingOptionToDisplay { get; set; }

        [JsonPropertyName("shippingTitleToDisplay")]
        public string ShippingTitleToDisplay { get; set; }

        [JsonPropertyName("isEDeliveryItem")]
        public bool IsEDeliveryItem { get; set; }

        [JsonPropertyName("nextDayShippingOptionToDisplay")]
        public string NextDayShippingOptionToDisplay { get; set; }

        [JsonPropertyName("nextDayShippingTitleToDisplay")]
        public string NextDayShippingTitleToDisplay { get; set; }

        [JsonPropertyName("nextDayFreeShippingThresholdPrice")]
        public AddToList NextDayFreeShippingThresholdPrice { get; set; }

        [JsonPropertyName("isBelowShippingThreshold")]
        public bool IsBelowShippingThreshold { get; set; }

        [JsonPropertyName("twoDayShippingEligible")]
        public bool TwoDayShippingEligible { get; set; }

        [JsonPropertyName("nextDayEligible")]
        public bool NextDayEligible { get; set; }

        [JsonPropertyName("hasFreightShipping")]
        public bool HasFreightShipping { get; set; }

        [JsonPropertyName("shippingPrice")]
        public int ShippingPrice { get; set; }

        [JsonPropertyName("surchargeType")]
        public string SurchargeType { get; set; }

        [JsonPropertyName("promotionsData")]
        public PromotionsData PromotionsData { get; set; }

        [JsonPropertyName("shipAsIs")]
        public bool ShipAsIs { get; set; }

        [JsonPropertyName("classType")]
        public string ClassType { get; set; }

        [JsonPropertyName("priceMap")]
        public PriceMap PriceMap { get; set; }

        [JsonPropertyName("priceFlagsList")]
        public object[] PriceFlagsList { get; set; }

        [JsonPropertyName("pickupable")]
        public bool Pickupable { get; set; }

        [JsonPropertyName("pickupOptions")]
        public object[] PickupOptions { get; set; }

        [JsonPropertyName("pickupDiscountEligible")]
        public bool PickupDiscountEligible { get; set; }

        [JsonPropertyName("pickupTodayEligible")]
        public bool PickupTodayEligible { get; set; }

        [JsonPropertyName("pickupMethod")]
        public string PickupMethod { get; set; }

        [JsonPropertyName("availabilityStatus")]
        public string AvailabilityStatus { get; set; }

        [JsonPropertyName("globalProductAvailability")]
        public string GlobalProductAvailability { get; set; }

        [JsonPropertyName("urgentQuantity")]
        public int UrgentQuantity { get; set; }

        [JsonPropertyName("orderPreselectedQuantity")]
        public int OrderPreselectedQuantity { get; set; }

        [JsonPropertyName("minQuantity")]
        public int MinQuantity { get; set; }

        [JsonPropertyName("maxQuantity")]
        public int MaxQuantity { get; set; }

        [JsonPropertyName("storeIds")]
        public object[] StoreIds { get; set; }

        [JsonPropertyName("sellerId")]
        public string SellerId { get; set; }

        [JsonPropertyName("catalogSellerId")]

        public string CatalogSellerId { get; set; }

        [JsonPropertyName("sellerDisplayName")]
        public string SellerDisplayName { get; set; }

        [JsonPropertyName("showSoldBy")]
        public bool ShowSoldBy { get; set; }

        [JsonPropertyName("isEGiftCard")]
        public bool IsEGiftCard { get; set; }

        [JsonPropertyName("isPhysicalGiftCard")]
        public bool IsPhysicalGiftCard { get; set; }

        [JsonPropertyName("isTiresItem")]
        public bool IsTiresItem { get; set; }

        [JsonPropertyName("isFsaEligible")]
        public bool IsFsaEligible { get; set; }

        [JsonPropertyName("flexibleSpendingAccountEligible")]
        public object FlexibleSpendingAccountEligible { get; set; }

        [JsonPropertyName("removeATC")]
        public bool RemoveAtc { get; set; }

        [JsonPropertyName("reviewsCount")]
        public int ReviewsCount { get; set; }

        [JsonPropertyName("averageRating")]
        public double AverageRating { get; set; }

        [JsonPropertyName("premiumDeliveryOptions")]
        public object[] PremiumDeliveryOptions { get; set; }

        [JsonPropertyName("brandUrl")]
        public string BrandUrl { get; set; }

        [JsonPropertyName("manufactureNumber")]
        public string ManufactureNumber { get; set; }

        [JsonPropertyName("productTypeId")]

        public string ProductTypeId { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("canonicalUrl")]
        public string CanonicalUrl { get; set; }

        [JsonPropertyName("skuId")]
        public string SkuId { get; set; }

        [JsonPropertyName("blitzDayStartTime")]
        public object BlitzDayStartTime { get; set; }

        [JsonPropertyName("blitzItem")]
        public bool BlitzItem { get; set; }

        [JsonPropertyName("blitzStoreMsg")]
        public object BlitzStoreMsg { get; set; }

        [JsonPropertyName("blitzDayStartMsg")]
        public object BlitzDayStartMsg { get; set; }

        [JsonPropertyName("isOzarkItem")]
        public bool IsOzarkItem { get; set; }

        [JsonPropertyName("ozarkMessage")]
        public string OzarkMessage { get; set; }

        [JsonPropertyName("productType")]
        public string ProductType { get; set; }

        [JsonPropertyName("productDietaryAttributes")]
        public object[] ProductDietaryAttributes { get; set; }

        [JsonPropertyName("specificationHighlights")]
        public object[] SpecificationHighlights { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("homeServiceType")]
        public string HomeServiceType { get; set; }

        [JsonPropertyName("isWirelessItem")]
        public bool IsWirelessItem { get; set; }

        [JsonPropertyName("isWirelessPrepaid")]
        public bool IsWirelessPrepaid { get; set; }

        [JsonPropertyName("subscription")]
        public AddToList Subscription { get; set; }

        [JsonPropertyName("subscriptionIntervalFrequency")]
        public string SubscriptionIntervalFrequency { get; set; }

        [JsonPropertyName("bundleGroupId")]
        public string BundleGroupId { get; set; }

        [JsonPropertyName("idmlSections")]
        public IdmlSections IdmlSections { get; set; }

        [JsonPropertyName("product360ImageContainer")]
        public object[] Product360ImageContainer { get; set; }

        [JsonPropertyName("sizeCharts")]
        public object[] SizeCharts { get; set; }

        [JsonPropertyName("videos")]
        public Video[] Videos { get; set; }

        [JsonPropertyName("sellPointsInteractiveImage")]
        public bool SellPointsInteractiveImage { get; set; }

        [JsonPropertyName("offerScoreBadge")]
        public bool OfferScoreBadge { get; set; }
    }

    public class HighlightedShippingOption
    {
        [JsonPropertyName("index")]
        public int Index { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class IdmlSections
    {
        [JsonPropertyName("marketingContent")]
        public string MarketingContent { get; set; }

        [JsonPropertyName("manualsAndGuides")]
        public AddToList ManualsAndGuides { get; set; }

        [JsonPropertyName("idmlShortDescription")]
        public string IdmlShortDescription { get; set; }

        [JsonPropertyName("idmlstringDescription")]
        public string IdmlstringDescription { get; set; }

        [JsonPropertyName("idmlWarnings")]
        public object[] IdmlWarnings { get; set; }

        [JsonPropertyName("ingredientsList")]
        public object[] IngredientsList { get; set; }

        [JsonPropertyName("instructions")]
        public object[] Instructions { get; set; }

        [JsonPropertyName("chokingHazards")]
        public object[] ChokingHazards { get; set; }

        [JsonPropertyName("directions")]
        public object[] Directions { get; set; }

        [JsonPropertyName("indications")]
        public object[] Indications { get; set; }

        [JsonPropertyName("productComparisonTable")]
        public AddToList ProductComparisonTable { get; set; }

        [JsonPropertyName("specifications")]
        public Specification[] Specifications { get; set; }

        [JsonPropertyName("trackListing")]
        public object[] TrackListing { get; set; }

        [JsonPropertyName("drugFacts")]
        public object[] DrugFacts { get; set; }

        [JsonPropertyName("displayabilityMatrix")]
        public DisplayabilityMatrix DisplayabilityMatrix { get; set; }

        [JsonPropertyName("supplementFacts")]
        public object[] SupplementFacts { get; set; }

        [JsonPropertyName("product360DegreeImage")]
        public string Product360DegreeImage { get; set; }

        [JsonPropertyName("productTour")]
        public string ProductTour { get; set; }

        [JsonPropertyName("warranty")]
        public Warranty Warranty { get; set; }

        [JsonPropertyName("interactiveImageUrl")]
        public Uri InteractiveImageUrl { get; set; }

        [JsonPropertyName("nutritionFacts")]
        public AddToList NutritionFacts { get; set; }

        [JsonPropertyName("legalBadges")]
        public object[] LegalBadges { get; set; }

        [JsonPropertyName("videoMatrix")]
        public VideoMatrix VideoMatrix { get; set; }
    }

    public class DisplayabilityMatrix
    {
        [JsonPropertyName("showVideoContent")]
        public bool ShowVideoContent { get; set; }

        [JsonPropertyName("showMarketingContent")]
        public bool ShowMarketingContent { get; set; }
    }

    public class Specification
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public class VideoMatrix
    {
        [JsonPropertyName("usItemId")]

        public string UsItemId { get; set; }

        [JsonPropertyName("videoModulesKey")]
        public string VideoModulesKey { get; set; }
    }

    public class Warranty
    {
        [JsonPropertyName("length")]
        public string Length { get; set; }

        [JsonPropertyName("information")]
        public string Information { get; set; }
    }

    public class Image
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("zoomable")]
        public bool? Zoomable { get; set; }
    }

    public class Path
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class PriceMap
    {
        [JsonPropertyName("currencyUnitSymbol")]
        public string CurrencyUnitSymbol { get; set; }

        [JsonPropertyName("unitPriceDisplayValue")]
        public object UnitPriceDisplayValue { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("submapType")]
        public string SubmapType { get; set; }

        [JsonPropertyName("unitPrice")]
        public string UnitPrice { get; set; }

        [JsonPropertyName("unitOfMeasure")]
        public string UnitOfMeasure { get; set; }
    }

    public class PromotionsData
    {
        [JsonPropertyName("isItemAccessEnabled")]
        public bool IsItemAccessEnabled { get; set; }

        [JsonPropertyName("isConsumable")]
        public bool IsConsumable { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("productSegment")]
        public string ProductSegment { get; set; }

        [JsonPropertyName("productType")]
        public string ProductType { get; set; }

        [JsonPropertyName("charPrimaryCategoryPath")]
        public string CharPrimaryCategoryPath { get; set; }

        [JsonPropertyName("priceDisplayCodes")]
        public AddToList PriceDisplayCodes { get; set; }

        [JsonPropertyName("productClassType")]
        public string ProductClassType { get; set; }

        [JsonPropertyName("rhPath")]
        public string RhPath { get; set; }

        [JsonPropertyName("itemClassId")]

        public string ItemClassId { get; set; }

        [JsonPropertyName("isAlcohol")]
        public bool IsAlcohol { get; set; }

        [JsonPropertyName("isWarp")]
        public bool IsWarp { get; set; }

        [JsonPropertyName("isPreorder")]
        public bool IsPreorder { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("subscriptionInterval")]
        public string SubscriptionInterval { get; set; }
    }

    public class ShippingOption
    {
        [JsonPropertyName("fulfillmentPrice")]
        public Price FulfillmentPrice { get; set; }

        [JsonPropertyName("fulfillmentDateRange")]
        public FulfillmentDateRange FulfillmentDateRange { get; set; }

        [JsonPropertyName("urgentQuantity")]
        public int UrgentQuantity { get; set; }

        [JsonPropertyName("fulfillmentPriceType")]
        public string FulfillmentPriceType { get; set; }

        [JsonPropertyName("shipMethod")]
        public string ShipMethod { get; set; }
    }

    public class FulfillmentDateRange
    {
        [JsonPropertyName("earliestDeliverDate")]
        public long EarliestDeliverDate { get; set; }

        [JsonPropertyName("latestDeliveryDate")]
        public long LatestDeliveryDate { get; set; }
    }

    public class Price
    {
        [JsonPropertyName("price")]
        public double PricePrice { get; set; }

        [JsonPropertyName("currencyUnit")]
        public string CurrencyUnit { get; set; }

        [JsonPropertyName("currencyUnitSymbol")]
        public string CurrencyUnitSymbol { get; set; }
    }

    public class UpsellFulfillmentOption
    {
        [JsonPropertyName("upsellable")]
        public bool Upsellable { get; set; }

        [JsonPropertyName("shippingPrice")]
        public Price ShippingPrice { get; set; }

        [JsonPropertyName("shipMethod")]
        public string ShipMethod { get; set; }

        [JsonPropertyName("arrivalDate")]
        public long ArrivalDate { get; set; }

        [JsonPropertyName("displayArrivalDate")]
        public string DisplayArrivalDate { get; set; }

        [JsonPropertyName("skyLineAdEnabled")]
        public bool SkyLineAdEnabled { get; set; }

        [JsonPropertyName("displayUpsellForAllCategoriesEnabled")]
        public bool DisplayUpsellForAllCategoriesEnabled { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }
    }

    public class Video
    {
        [JsonPropertyName("poster")]
        public Uri Poster { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("versions")]
        public Versions Versions { get; set; }
    }

    public class Versions
    {
        [JsonPropertyName("SMALL")]
        public Uri Small { get; set; }

        [JsonPropertyName("LARGE")]
        public Uri Large { get; set; }
    }

    public class CarePlans
    {
        [JsonPropertyName("FC543AC4236B4BF583FA30E1907B898D")]
        public Fc543Ac4236B4Bf583Fa30E1907B898D[] Fc543Ac4236B4Bf583Fa30E1907B898D { get; set; }
    }

    public class Fc543Ac4236B4Bf583Fa30E1907B898D
    {
        [JsonPropertyName("alternateTitle")]
        public string AlternateTitle { get; set; }

        [JsonPropertyName("altText")]
        public string AltText { get; set; }

        [JsonPropertyName("homeServiceType")]
        public string HomeServiceType { get; set; }

        [JsonPropertyName("planType")]
        public string PlanType { get; set; }

        [JsonPropertyName("assetUrl")]
        public Uri AssetUrl { get; set; }

        [JsonPropertyName("price")]
        public Price Price { get; set; }

        [JsonPropertyName("duration")]
        public string Duration { get; set; }

        [JsonPropertyName("offerId")]
        public string OfferId { get; set; }

        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("sellerId")]
        public string SellerId { get; set; }

        [JsonPropertyName("usSellerId")]

        public string UsSellerId { get; set; }

        [JsonPropertyName("sellerName")]
        public string SellerName { get; set; }

        [JsonPropertyName("anchorSellerId")]
        public string AnchorSellerId { get; set; }

        [JsonPropertyName("usItemId")]

        public string UsItemId { get; set; }

        [JsonPropertyName("warrantyAvail")]

        public string WarrantyAvail { get; set; }

        [JsonPropertyName("shortDescription")]
        public string ShortDescription { get; set; }
    }

    public class CellCoverageFinder
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }

        [JsonPropertyName("availability")]
        public string Availability { get; set; }

        [JsonPropertyName("heading")]
        public string Heading { get; set; }
    }

    public class CheckoutComments
    {
        [JsonPropertyName("productComments")]
        public AddToList ProductComments { get; set; }

        [JsonPropertyName("loading")]
        public bool Loading { get; set; }

        [JsonPropertyName("feedbackSubmitted")]
        public AddToList FeedbackSubmitted { get; set; }

        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("totalCommentsCount")]
        public int TotalCommentsCount { get; set; }

        [JsonPropertyName("cxoComments")]
        public CxoComment[] CxoComments { get; set; }
    }

    public class CxoComment
    {
        [JsonPropertyName("commentId")]

        public string CommentId { get; set; }

        [JsonPropertyName("userNickname")]
        public string UserNickname { get; set; }

        [JsonPropertyName("commentText")]
        public string CommentText { get; set; }

        [JsonPropertyName("commentSubmissionTime")]
        public string CommentSubmissionTime { get; set; }
    }

    public class IdmlMap
    {
        [JsonPropertyName("6Y2ZXJAUUTL3")]
        public The6Y2Zxjauutl3 The6Y2Zxjauutl3 { get; set; }
    }

    public class The6Y2Zxjauutl3
    {
        [JsonPropertyName("modules")]
        public AddToList Modules { get; set; }
    }

    public class IdmlModal
    {
        [JsonPropertyName("show")]
        public bool Show { get; set; }
    }

    public class MidasContext
    {
        [JsonPropertyName("pageType")]
        public string PageType { get; set; }

        [JsonPropertyName("subType")]
        public string SubType { get; set; }

        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("itemId")]

        public string ItemId { get; set; }

        [JsonPropertyName("price")]
        public double Price { get; set; }

        [JsonPropertyName("preorder")]
        public bool Preorder { get; set; }

        [JsonPropertyName("online")]
        public bool Online { get; set; }

        [JsonPropertyName("freeShipping")]
        public bool FreeShipping { get; set; }

        [JsonPropertyName("inStore")]
        public bool InStore { get; set; }

        [JsonPropertyName("query")]
        public string Query { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("categoryPathId")]
        public string CategoryPathId { get; set; }

        [JsonPropertyName("categoryPathName")]
        public string CategoryPathName { get; set; }

        [JsonPropertyName("manufacturer")]
        public string Manufacturer { get; set; }

        [JsonPropertyName("verticalId")]
        public string VerticalId { get; set; }

        [JsonPropertyName("verticalTheme")]
        public string VerticalTheme { get; set; }

        [JsonPropertyName("smode")]
        public int Smode { get; set; }

        [JsonPropertyName("isTwoDayDeliveryTextEnabled")]
        public bool IsTwoDayDeliveryTextEnabled { get; set; }

        [JsonPropertyName("zip")]

        public string Zip { get; set; }
    }

    public class QuestionAnswers
    {
        [JsonPropertyName("questionDetails")]
        public QuestionDetail[] QuestionDetails { get; set; }

        [JsonPropertyName("totalResults")]
        public int TotalResults { get; set; }

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("pages")]
        public Next[] Pages { get; set; }

        [JsonPropertyName("next")]
        public Next Next { get; set; }

        [JsonPropertyName("currentSpan")]
        public string CurrentSpan { get; set; }
    }

    public class Next
    {
        [JsonPropertyName("num")]
        public int Num { get; set; }

        [JsonPropertyName("gap")]
        public bool Gap { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class QuestionDetail
    {
        [JsonPropertyName("questionId")]

        public string QuestionId { get; set; }

        [JsonPropertyName("questionSummary")]
        public string QuestionSummary { get; set; }

        [JsonPropertyName("userNickname")]
        public string UserNickname { get; set; }

        [JsonPropertyName("positiveVoteCount")]
        public int PositiveVoteCount { get; set; }

        [JsonPropertyName("negativeVoteCount")]
        public int NegativeVoteCount { get; set; }

        [JsonPropertyName("totalAnswersCount")]
        public int TotalAnswersCount { get; set; }

        [JsonPropertyName("lastAnswerDate")]
        public string LastAnswerDate { get; set; }

        [JsonPropertyName("submissionDate")]
        public string SubmissionDate { get; set; }

        [JsonPropertyName("answers")]
        public Answer[] Answers { get; set; }
    }

    public class Answer
    {
        [JsonPropertyName("answerId")]

        public string AnswerId { get; set; }

        [JsonPropertyName("answerText")]
        public string AnswerText { get; set; }

        [JsonPropertyName("userNickname")]
        public string UserNickname { get; set; }

        [JsonPropertyName("positiveVoteCount")]
        public int PositiveVoteCount { get; set; }

        [JsonPropertyName("negativeVoteCount")]
        public int NegativeVoteCount { get; set; }

        [JsonPropertyName("submissionTime")]
        public string SubmissionTime { get; set; }
    }

    public class ProductReviews
    {
        [JsonPropertyName("activeAspect")]
        public object ActiveAspect { get; set; }

        [JsonPropertyName("frequentMentions")]
        public AddToList FrequentMentions { get; set; }

        [JsonPropertyName("averageOverallRating")]
        public double AverageOverallRating { get; set; }

        [JsonPropertyName("roundedAverageOverallRating")]
        public double RoundedAverageOverallRating { get; set; }

        [JsonPropertyName("overallRatingRange")]
        public int OverallRatingRange { get; set; }

        [JsonPropertyName("totalReviewCount")]
        public int TotalReviewCount { get; set; }

        [JsonPropertyName("recommendedPercentage")]
        public int RecommendedPercentage { get; set; }

        [JsonPropertyName("ratingValueOneCount")]
        public int RatingValueOneCount { get; set; }

        [JsonPropertyName("ratingValueTwoCount")]
        public int RatingValueTwoCount { get; set; }

        [JsonPropertyName("ratingValueThreeCount")]
        public int RatingValueThreeCount { get; set; }

        [JsonPropertyName("ratingValueFourCount")]
        public int RatingValueFourCount { get; set; }

        [JsonPropertyName("ratingValueFiveCount")]
        public int RatingValueFiveCount { get; set; }

        [JsonPropertyName("percentageOneCount")]
        public int PercentageOneCount { get; set; }

        [JsonPropertyName("percentageTwoCount")]
        public int PercentageTwoCount { get; set; }

        [JsonPropertyName("percentageThreeCount")]
        public int PercentageThreeCount { get; set; }

        [JsonPropertyName("percentageFourCount")]
        public int PercentageFourCount { get; set; }

        [JsonPropertyName("percentageFiveCount")]
        public int PercentageFiveCount { get; set; }

        [JsonPropertyName("activePage")]
        public int ActivePage { get; set; }

        [JsonPropertyName("activeSort")]
        public string ActiveSort { get; set; }

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }

        [JsonPropertyName("customerReviews")]
        public Review[] CustomerReviews { get; set; }

        [JsonPropertyName("topPositiveReview")]
        public Review TopPositiveReview { get; set; }

        [JsonPropertyName("topNegativeReview")]
        public Review TopNegativeReview { get; set; }

        [JsonPropertyName("lookupId")]
        public string LookupId { get; set; }

        [JsonPropertyName("aspects")]
        public Aspect[] Aspects { get; set; }

        [JsonPropertyName("totalImageReviewsCount")]
        public int TotalImageReviewsCount { get; set; }

        [JsonPropertyName("recommendedCount")]
        public int RecommendedCount { get; set; }

        [JsonPropertyName("recommendedPositiveCount")]
        public int RecommendedPositiveCount { get; set; }
    }

    public class Aspect
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("snippetCount")]
        public int SnippetCount { get; set; }
    }

    public class Review
    {
        [JsonPropertyName("reviewId")]
        public string ReviewId { get; set; }

        [JsonPropertyName("authorId")]
        public string AuthorId { get; set; }

        [JsonPropertyName("recommended")]
        public bool? Recommended { get; set; }

        [JsonPropertyName("showRecommended")]
        public bool? ShowRecommended { get; set; }

        [JsonPropertyName("negativeFeedback")]
        public int NegativeFeedback { get; set; }

        [JsonPropertyName("positiveFeedback")]
        public int PositiveFeedback { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("reviewTitle")]
        public string ReviewTitle { get; set; }

        [JsonPropertyName("reviewText")]
        public string ReviewText { get; set; }

        [JsonPropertyName("reviewSubmissionTime")]
        public string ReviewSubmissionTime { get; set; }

        [JsonPropertyName("userNickname")]
        public string UserNickname { get; set; }

        [JsonPropertyName("badges")]
        public Badge[] Badges { get; set; }

        [JsonPropertyName("userAttributes")]
        public AddToList UserAttributes { get; set; }

        [JsonPropertyName("photos")]
        public object[] Photos { get; set; }

        [JsonPropertyName("videos")]
        public object[] Videos { get; set; }

        [JsonPropertyName("externalSource")]
        public string ExternalSource { get; set; }

        [JsonPropertyName("pros")]
        public Pro[] Pros { get; set; }

        [JsonPropertyName("cons")]
        public object[] Cons { get; set; }

        [JsonPropertyName("clientResponses")]
        public ClientResponse[] ClientResponses { get; set; }
    }

    public class Badge
    {
        [JsonPropertyName("badgeType")]
        public string BadgeType { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("contentType")]
        public string ContentType { get; set; }
    }

    public class ClientResponse
    {
        [JsonPropertyName("response")]
        public string Response { get; set; }

        [JsonPropertyName("logoImage")]
        public Uri LogoImage { get; set; }
    }

    public class Pro
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class ProductBuyBoxLoader
    {
        [JsonPropertyName("isLoading")]
        public bool IsLoading { get; set; }
    }

    public class ProductComparison
    {
        [JsonPropertyName("ui")]
        public ProductComparisonUi Ui { get; set; }

        [JsonPropertyName("products")]
        public Products Products { get; set; }
    }

    public class Products
    {
        [JsonPropertyName("list")]
        public object[] List { get; set; }

        [JsonPropertyName("map")]
        public AddToList Map { get; set; }
    }

    public class ProductComparisonUi
    {
        [JsonPropertyName("tooltipMessage")]
        public object TooltipMessage { get; set; }
    }

    public class ProductQuimbyData
    {
        [JsonPropertyName("fetchBTV")]
        public bool FetchBtv { get; set; }
    }

    public class RelmDatum
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }

    public class ItemReviews
    {
        [JsonPropertyName("customerPhotos")]
        public CustomerPhotos CustomerPhotos { get; set; }
    }

    public class CustomerPhotos
    {
        [JsonPropertyName("activeReviewId")]
        public object ActiveReviewId { get; set; }

        [JsonPropertyName("activePhotoIndex")]
        public int ActivePhotoIndex { get; set; }

        [JsonPropertyName("customerReviews")]
        public CustomerReviews CustomerReviews { get; set; }

        [JsonPropertyName("currentPageCursor")]
        public int CurrentPageCursor { get; set; }

        [JsonPropertyName("modalTemplate")]
        public string ModalTemplate { get; set; }

        [JsonPropertyName("modalVisible")]
        public bool ModalVisible { get; set; }

        [JsonPropertyName("modalInReview")]
        public bool ModalInReview { get; set; }

        [JsonPropertyName("topReviewsWithImages")]
        public TopReviewsWithImage[] TopReviewsWithImages { get; set; }

        [JsonPropertyName("totalImageCount")]
        public int TotalImageCount { get; set; }

        [JsonPropertyName("usItemId")]
        public string UsItemId { get; set; }

        [JsonPropertyName("productId")]
        public string ProductId { get; set; }

        [JsonPropertyName("photoReviewPopup")]
        public PhotoReviewPopup PhotoReviewPopup { get; set; }

        [JsonPropertyName("totalImageReviewsPaginationCount")]
        public int TotalImageReviewsPaginationCount { get; set; }
    }

    public class CustomerReviews
    {
        [JsonPropertyName("ids")]
        public object[] Ids { get; set; }

        [JsonPropertyName("entities")]
        public AddToList Entities { get; set; }
    }

    public class PhotoReviewPopup
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("viewFullGalleryClicked")]
        public bool ViewFullGalleryClicked { get; set; }
    }

    public class TopReviewsWithImage
    {
        [JsonPropertyName("reviewId")]
        public string ReviewId { get; set; }

        [JsonPropertyName("imageUrls")]
        public Uri[] ImageUrls { get; set; }

        [JsonPropertyName("nickname")]
        public string Nickname { get; set; }
    }

    public class WpaMap
    {
        [JsonPropertyName("loading")]
        public bool Loading { get; set; }

        [JsonPropertyName("midasConfig")]
        public AddToList MidasConfig { get; set; }

        [JsonPropertyName("midasContext")]
        public AddToList MidasContext { get; set; }

        [JsonPropertyName("result")]
        public Result Result { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("adModules")]
        public AdModule[] AdModules { get; set; }

        [JsonPropertyName("details")]
        public string Details { get; set; }
    }

    public class AdModule
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("products")]
        public object[] Products { get; set; }

        [JsonPropertyName("midasModuleData")]
        public MidasModuleData MidasModuleData { get; set; }
    }

    public class MidasModuleData
    {
        [JsonPropertyName("adModule")]
        public string AdModule { get; set; }

        [JsonPropertyName("pageBeacon")]
        public string PageBeacon { get; set; }

        [JsonPropertyName("pageBeacons")]
        public AddToList PageBeacons { get; set; }

        [JsonPropertyName("pageId")]
        public string PageId { get; set; }

        [JsonPropertyName("pageType")]
        public string PageType { get; set; }

        [JsonPropertyName("bucketId")]
        public string BucketId { get; set; }

        [JsonPropertyName("details")]
        public string Details { get; set; }

        [JsonPropertyName("modulePosition")]
        public object ModulePosition { get; set; }

        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }

        [JsonPropertyName("featuredImage")]
        public object FeaturedImage { get; set; }

        [JsonPropertyName("featuredImageName")]
        public object FeaturedImageName { get; set; }

        [JsonPropertyName("featuredUrl")]
        public object FeaturedUrl { get; set; }

        [JsonPropertyName("featuredHeadline")]
        public object FeaturedHeadline { get; set; }

        [JsonPropertyName("logoClickTrackUrl")]
        public object LogoClickTrackUrl { get; set; }

        [JsonPropertyName("traceId")]
        public object TraceId { get; set; }

        [JsonPropertyName("unpublishedItems")]
        public object UnpublishedItems { get; set; }

        [JsonPropertyName("adExpId")]
        public object AdExpId { get; set; }

        [JsonPropertyName("moduleInfo")]
        public object ModuleInfo { get; set; }
    }
}
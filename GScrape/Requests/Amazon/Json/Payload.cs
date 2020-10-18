using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GScrape.Requests.Amazon.Json
{
    public class Resources    {
        [JsonPropertyName("AmazonStores/prime.png")]
        public string AmazonStoresPrimePng { get; set; } 

        [JsonPropertyName("AmazonStores/fresh.png")]
        public string AmazonStoresFreshPng { get; set; } 

        [JsonPropertyName("AmazonStores/pantry.png")]
        public string AmazonStoresPantryPng { get; set; } 

        [JsonPropertyName("AmazonStores/AmazonUISkinSky-sprite_sky_color.png")]
        public string AmazonStoresAmazonUISkinSkySpriteSkyColorPng { get; set; } 

        [JsonPropertyName("AmazonStores/cart.png")]
        public string AmazonStoresCartPng { get; set; } 

        [JsonPropertyName("AmazonStores/checkmark.png")]
        public string AmazonStoresCheckmarkPng { get; set; } 

        [JsonPropertyName("AmazonStores/close.png")]
        public string AmazonStoresClosePng { get; set; } 

        [JsonPropertyName("AmazonStores/warning.png")]
        public string AmazonStoresWarningPng { get; set; } 

        [JsonPropertyName("AmazonStores/spinner.png")]
        public string AmazonStoresSpinnerPng { get; set; } 

        [JsonPropertyName("AmazonStores/icon_close_dark_sm.png")]
        public string AmazonStoresIconCloseDarkSmPng { get; set; } 

        [JsonPropertyName("AmazonStores/info_icon_coupon_amazon.png")]
        public string AmazonStoresInfoIconCouponAmazonPng { get; set; } 

        [JsonPropertyName("AmazonStores/success.png")]
        public string AmazonStoresSuccessPng { get; set; } 

        [JsonPropertyName("AmazonStores/prime-2.png")]
        public string AmazonStoresPrime2Png { get; set; } 

        [JsonPropertyName("AmazonStores/checkmark-2.png")]
        public string AmazonStoresCheckmark2Png { get; set; } 

        [JsonPropertyName("AmazonStores/product.png")]
        public string AmazonStoresProductPng { get; set; } 

        [JsonPropertyName("AmazonStores/kindle_unlimited_program_badge.png")]
        public string AmazonStoresKindleUnlimitedProgramBadgePng { get; set; } 
    }

    public class Translations    {
        [JsonPropertyName("STORES_WIDGET_AddedToCart")]
        public string STORESWIDGETAddedToCart { get; set; } 

        [JsonPropertyName("STORES_WIDGET_AddToCart")]
        public string STORESWIDGETAddToCart { get; set; } 

        [JsonPropertyName("STORES_WIDGET_AddToCartError")]
        public string STORESWIDGETAddToCartError { get; set; } 

        [JsonPropertyName("STORES_WIDGET_PreOrderAddToCart")]
        public string STORESWIDGETPreOrderAddToCart { get; set; } 

        [JsonPropertyName("STORES_WIDGET_AllDepartments")]
        public string STORESWIDGETAllDepartments { get; set; } 

        [JsonPropertyName("STORES_WIDGET_AllStockAdded")]
        public string STORESWIDGETAllStockAdded { get; set; } 

        [JsonPropertyName("STORES_WIDGET_BlackFriday")]
        public string STORESWIDGETBlackFriday { get; set; } 

        [JsonPropertyName("STORES_WIDGET_BuenFin")]
        public string STORESWIDGETBuenFin { get; set; } 

        [JsonPropertyName("STORES_WIDGET_ByContributor")]
        public string STORESWIDGETByContributor { get; set; } 

        [JsonPropertyName("STORES_WIDGET_ByContributorEtAl")]
        public string STORESWIDGETByContributorEtAl { get; set; } 

        [JsonPropertyName("STORES_WIDGET_Cart")]
        public string STORESWIDGETCart { get; set; } 

        [JsonPropertyName("STORES_WIDGET_ClearAll")]
        public string STORESWIDGETClearAll { get; set; } 

        [JsonPropertyName("STORES_WIDGET_ContinueShopping")]
        public string STORESWIDGETContinueShopping { get; set; } 

        [JsonPropertyName("STORES_WIDGET_ContinueShoppingOr")]
        public string STORESWIDGETContinueShoppingOr { get; set; } 

        [JsonPropertyName("STORES_WIDGET_Coupon")]
        public string STORESWIDGETCoupon { get; set; } 

        [JsonPropertyName("STORES_WIDGET_Curated")]
        public string STORESWIDGETCurated { get; set; } 

        [JsonPropertyName("STORES_WIDGET_CurrencyCodePlaceholder")]
        public string STORESWIDGETCurrencyCodePlaceholder { get; set; } 

        [JsonPropertyName("STORES_WIDGET_CurrencySymbolTo")]
        public string STORESWIDGETCurrencySymbolTo { get; set; } 

        [JsonPropertyName("STORES_WIDGET_CyberMonday")]
        public string STORESWIDGETCyberMonday { get; set; } 

        [JsonPropertyName("STORES_WIDGET_Deal")]
        public string STORESWIDGETDeal { get; set; } 

        [JsonPropertyName("STORES_WIDGET_DealEnded")]
        public string STORESWIDGETDealEnded { get; set; } 

        [JsonPropertyName("STORES_WIDGET_DealOfTheDay")]
        public string STORESWIDGETDealOfTheDay { get; set; } 

        [JsonPropertyName("STORES_WIDGET_Department")]
        public string STORESWIDGETDepartment { get; set; } 

        [JsonPropertyName("STORES_WIDGET_DesktopCount")]
        public string STORESWIDGETDesktopCount { get; set; } 

        [JsonPropertyName("STORES_WIDGET_EndsIn")]
        public string STORESWIDGETEndsIn { get; set; } 

        [JsonPropertyName("STORES_WIDGET_FeaturedDeals")]
        public string STORESWIDGETFeaturedDeals { get; set; } 

        [JsonPropertyName("STORES_WIDGET_FilterButton")]
        public string STORESWIDGETFilterButton { get; set; } 

        [JsonPropertyName("STORES_WIDGET_FilterButtonWithCount")]
        public string STORESWIDGETFilterButtonWithCount { get; set; } 

        [JsonPropertyName("STORES_WIDGET_FilteredByPrice")]
        public string STORESWIDGETFilteredByPrice { get; set; } 

        [JsonPropertyName("STORES_WIDGET_FilteredCount")]
        public string STORESWIDGETFilteredCount { get; set; } 

        [JsonPropertyName("STORES_WIDGET_Showcase_DP_Variations_CTA")]
        public string STORESWIDGETShowcaseDPVariationsCTA { get; set; } 

        [JsonPropertyName("STORES_WIDGET_Loading_Error")]
        public string STORESWIDGETLoadingError { get; set; } 

        [JsonPropertyName("STORES_WIDGET_TryAgain")]
        public string STORESWIDGETTryAgain { get; set; } 

        [JsonPropertyName("STORES_WIDGET_SeeDetails")]
        public string STORESWIDGETSeeDetails { get; set; } 

        [JsonPropertyName("STORES_WIDGET_SeeMoreOptions")]
        public string STORESWIDGETSeeMoreOptions { get; set; } 

        [JsonPropertyName("STORES_WIDGET_NetworkErrorMessage")]
        public string STORESWIDGETNetworkErrorMessage { get; set; } 
    }

    public class Binding    {
        [JsonPropertyName("displayString")]
        public string DisplayString { get; set; } 

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } 
    }

    public class BindingInformation    {
        [JsonPropertyName("binding")]
        public Binding Binding { get; set; } 
    }

    public class AddToDashButtons    {
        [JsonPropertyName("url")]
        public object Url { get; set; } 
    }

    public class Data    {
        [JsonPropertyName("parameters")]
        public List<object> Parameters { get; set; } 
    }

    public class RequestNotification    {
        [JsonPropertyName("url")]
        public string Url { get; set; } 

        [JsonPropertyName("data")]
        public Data Data { get; set; } 
    }

    public class SeeDashButtons    {
        [JsonPropertyName("url")]
        public object Url { get; set; } 
    }

    public class CallToAction    {
        [JsonPropertyName("addToDashButtons")]
        public AddToDashButtons AddToDashButtons { get; set; } 

        [JsonPropertyName("requestNotification")]
        public RequestNotification RequestNotification { get; set; } 

        [JsonPropertyName("seeDashButtons")]
        public SeeDashButtons SeeDashButtons { get; set; } 
    }

    public class Availability    {
        [JsonPropertyName("primaryMessage")]
        public string PrimaryMessage { get; set; } 

        [JsonPropertyName("supplementaryMessage")]
        public string SupplementaryMessage { get; set; } 

        [JsonPropertyName("type")]
        public string Type { get; set; } 
    }

    public class BuyingOption    {
        [JsonPropertyName("callToAction")]
        public CallToAction CallToAction { get; set; } 

        [JsonPropertyName("availability")]
        public Availability Availability { get; set; } 

        [JsonPropertyName("type")]
        public string Type { get; set; } 
    }

    public class Role    {
        [JsonPropertyName("displayString")]
        public string DisplayString { get; set; } 

        [JsonPropertyName("type")]
        public string Type { get; set; } 
    }

    public class Link    {
        [JsonPropertyName("rel")]
        public string Rel { get; set; } 

        [JsonPropertyName("url")]
        public string Url { get; set; } 
    }

    public class BrandBrowseNode    {
        [JsonPropertyName("id")]
        public string Id { get; set; } 
    }

    public class Contributor    {
        [JsonPropertyName("roles")]
        public List<Role> Roles { get; set; } 

        [JsonPropertyName("links")]
        public List<Link> Links { get; set; } 

        [JsonPropertyName("brandStoreType")]
        public string BrandStoreType { get; set; } 

        [JsonPropertyName("brandBrowseNode")]
        public BrandBrowseNode BrandBrowseNode { get; set; } 

        [JsonPropertyName("bylineInfoType")]
        public string BylineInfoType { get; set; } 

        [JsonPropertyName("name")]
        public string Name { get; set; } 
    }

    public class ByLine    {
        [JsonPropertyName("contributors")]
        public List<Contributor> Contributors { get; set; } 
    }

    public class FiveStar    {
        [JsonPropertyName("percentage")]
        public int Percentage { get; set; } 

        [JsonPropertyName("labelDisplayString")]
        public string LabelDisplayString { get; set; } 

        [JsonPropertyName("percentageDisplayString")]
        public string PercentageDisplayString { get; set; } 
    }

    public class FourStar    {
        [JsonPropertyName("percentage")]
        public int Percentage { get; set; } 

        [JsonPropertyName("labelDisplayString")]
        public string LabelDisplayString { get; set; } 

        [JsonPropertyName("percentageDisplayString")]
        public string PercentageDisplayString { get; set; } 
    }

    public class OneStar    {
        [JsonPropertyName("percentage")]
        public int Percentage { get; set; } 

        [JsonPropertyName("labelDisplayString")]
        public string LabelDisplayString { get; set; } 

        [JsonPropertyName("percentageDisplayString")]
        public string PercentageDisplayString { get; set; } 
    }

    public class ThreeStar    {
        [JsonPropertyName("percentage")]
        public int Percentage { get; set; } 

        [JsonPropertyName("labelDisplayString")]
        public string LabelDisplayString { get; set; } 

        [JsonPropertyName("percentageDisplayString")]
        public string PercentageDisplayString { get; set; } 
    }

    public class TwoStar    {
        [JsonPropertyName("percentage")]
        public int Percentage { get; set; } 

        [JsonPropertyName("labelDisplayString")]
        public string LabelDisplayString { get; set; } 

        [JsonPropertyName("percentageDisplayString")]
        public string PercentageDisplayString { get; set; } 
    }

    public class Histogram    {
        [JsonPropertyName("fiveStar")]
        public FiveStar FiveStar { get; set; } 

        [JsonPropertyName("fourStar")]
        public FourStar FourStar { get; set; } 

        [JsonPropertyName("oneStar")]
        public OneStar OneStar { get; set; } 

        [JsonPropertyName("threeStar")]
        public ThreeStar ThreeStar { get; set; } 

        [JsonPropertyName("twoStar")]
        public TwoStar TwoStar { get; set; } 
    }

    public class Rating    {
        [JsonPropertyName("displayString")]
        public string DisplayString { get; set; } 

        [JsonPropertyName("shortDisplayString")]
        public string ShortDisplayString { get; set; } 

        [JsonPropertyName("fullStarCount")]
        public int FullStarCount { get; set; } 

        [JsonPropertyName("hasHalfStar")]
        public bool HasHalfStar { get; set; } 

        [JsonPropertyName("value")]
        public double Value { get; set; } 
    }

    public class Count    {
        [JsonPropertyName("displayString")]
        public string DisplayString { get; set; } 

        [JsonPropertyName("value")]
        public int Value { get; set; } 
    }

    public class CustomerReviewsSummary    {
        [JsonPropertyName("histogram")]
        public Histogram Histogram { get; set; } 

        [JsonPropertyName("rating")]
        public Rating Rating { get; set; } 

        [JsonPropertyName("count")]
        public Count Count { get; set; } 
    }

    public class FeatureBullets    {
        [JsonPropertyName("featureBullets")]
        public List<string> FeatureBulletsList { get; set; } 
    }

    public class ViewOnAmazon    {
        [JsonPropertyName("url")]
        public string Url { get; set; } 
    }

    public class Links    {
        [JsonPropertyName("viewOnAmazon")]
        public ViewOnAmazon ViewOnAmazon { get; set; } 
    }

    public class GlProductGroup    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } 
    }

    public class WebsiteDisplayGroup    {
        [JsonPropertyName("displayString")]
        public string DisplayString { get; set; } 

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } 
    }

    public class ProductCategory    {
        [JsonPropertyName("glProductGroup")]
        public GlProductGroup GlProductGroup { get; set; } 

        [JsonPropertyName("websiteDisplayGroup")]
        public WebsiteDisplayGroup WebsiteDisplayGroup { get; set; } 

        [JsonPropertyName("productType")]
        public string ProductType { get; set; } 

        [JsonPropertyName("categoryId")]
        public string CategoryId { get; set; } 

        [JsonPropertyName("subCategoryId")]
        public string SubCategoryId { get; set; } 
    }

    public class LowRes    {
        [JsonPropertyName("url")]
        public string Url { get; set; } 

        [JsonPropertyName("extension")]
        public string Extension { get; set; } 

        [JsonPropertyName("height")]
        public int Height { get; set; } 

        [JsonPropertyName("width")]
        public int Width { get; set; } 
    }

    public class HiRes    {
        [JsonPropertyName("url")]
        public string Url { get; set; } 

        [JsonPropertyName("extension")]
        public string Extension { get; set; } 

        [JsonPropertyName("height")]
        public int Height { get; set; } 

        [JsonPropertyName("width")]
        public int Width { get; set; } 
    }

    public class Image    {
        [JsonPropertyName("lowRes")]
        public LowRes LowRes { get; set; } 

        [JsonPropertyName("hiRes")]
        public HiRes HiRes { get; set; } 

        [JsonPropertyName("variant")]
        public string Variant { get; set; } 
    }

    public class ProductImages    {
        [JsonPropertyName("altText")]
        public string AltText { get; set; } 

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; } 
    }

    public class Title    {
        [JsonPropertyName("displayString")]
        public string DisplayString { get; set; } 
    }

    public class Product    {
        [JsonPropertyName("asin")]
        public string Asin { get; set; } 

        [JsonPropertyName("bindingInformation")]
        public BindingInformation BindingInformation { get; set; } 

        [JsonPropertyName("buyingOptions")]
        public List<BuyingOption> BuyingOptions { get; set; } 

        [JsonPropertyName("byLine")]
        public ByLine ByLine { get; set; } 

        [JsonPropertyName("customerReviewsSummary")]
        public CustomerReviewsSummary CustomerReviewsSummary { get; set; } 

        [JsonPropertyName("featureBullets")]
        public FeatureBullets FeatureBullets { get; set; } 

        [JsonPropertyName("links")]
        public Links Links { get; set; } 

        [JsonPropertyName("productCategory")]
        public ProductCategory ProductCategory { get; set; } 

        [JsonPropertyName("productImages")]
        public ProductImages ProductImages { get; set; } 

        [JsonPropertyName("title")]
        public Title Title { get; set; } 

        [JsonPropertyName("version")]
        public string Version { get; set; } 
    }

    public class Content    {
        [JsonPropertyName("ASINList")]
        public List<string> ASINList { get; set; } 

        [JsonPropertyName("includeOutOfStock")]
        public bool IncludeOutOfStock { get; set; } 

        [JsonPropertyName("description")]
        public string Description { get; set; } 

        [JsonPropertyName("id")]
        public string Id { get; set; } 

        [JsonPropertyName("type")]
        public string Type { get; set; } 

        [JsonPropertyName("title")]
        public string Title { get; set; } 

        [JsonPropertyName("keyword")]
        public string Keyword { get; set; } 

        [JsonPropertyName("bulk")]
        public bool Bulk { get; set; } 

        [JsonPropertyName("displayProductGridHeader")]
        public bool DisplayProductGridHeader { get; set; } 

        [JsonPropertyName("products")]
        public List<Product> Products { get; set; } 

        [JsonPropertyName("allProductsReturned")]
        public bool AllProductsReturned { get; set; } 

        [JsonPropertyName("ProductStrategy")]
        public string ProductStrategy { get; set; } 
    }

    public class IntroSplashVideo    {
        [JsonPropertyName("hideIntroSplashVideo")]
        public bool HideIntroSplashVideo { get; set; } 
    }

    public class BrandLogo    {
        [JsonPropertyName("imageWidth")]
        public string ImageWidth { get; set; } 

        [JsonPropertyName("imageOffsetTop")]
        public int ImageOffsetTop { get; set; } 

        [JsonPropertyName("shape")]
        public string Shape { get; set; } 

        [JsonPropertyName("imageKey")]
        public string ImageKey { get; set; } 

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; } 

        [JsonPropertyName("hideBrandLogo")]
        public bool HideBrandLogo { get; set; } 

        [JsonPropertyName("imageOffsetLeft")]
        public int ImageOffsetLeft { get; set; } 

        [JsonPropertyName("assetTags")]
        public string AssetTags { get; set; } 

        [JsonPropertyName("imageHeight")]
        public string ImageHeight { get; set; } 

        [JsonPropertyName("image")]
        public string Image { get; set; } 
    }

    public class PageContext    {
        [JsonPropertyName("template")]
        public string Template { get; set; } 

        [JsonPropertyName("pageUrlStatus")]
        public string PageUrlStatus { get; set; } 

        [JsonPropertyName("brandName")]
        public string BrandName { get; set; } 

        [JsonPropertyName("storeType")]
        public string StoreType { get; set; } 

        [JsonPropertyName("brandColor")]
        public string BrandColor { get; set; } 

        [JsonPropertyName("program")]
        public string Program { get; set; } 

        [JsonPropertyName("urlIdentifier")]
        public string UrlIdentifier { get; set; } 

        [JsonPropertyName("introSplashVideo")]
        public IntroSplashVideo IntroSplashVideo { get; set; } 

        [JsonPropertyName("rootPageId")]
        public string RootPageId { get; set; } 

        [JsonPropertyName("title")]
        public string Title { get; set; } 

        [JsonPropertyName("storeId")]
        public string StoreId { get; set; } 

        [JsonPropertyName("pagePath")]
        public string PagePath { get; set; } 

        [JsonPropertyName("version")]
        public string Version { get; set; } 

        [JsonPropertyName("pageDescription")]
        public string PageDescription { get; set; } 

        [JsonPropertyName("lastSubmittedTime")]
        public long LastSubmittedTime { get; set; } 

        [JsonPropertyName("pageImage")]
        public string PageImage { get; set; } 

        [JsonPropertyName("theme")]
        public string Theme { get; set; } 

        [JsonPropertyName("id")]
        public string Id { get; set; } 

        [JsonPropertyName("browseNode")]
        public long BrowseNode { get; set; } 

        [JsonPropertyName("brandLogo")]
        public BrandLogo BrandLogo { get; set; } 

        [JsonPropertyName("editionKey")]
        public string EditionKey { get; set; } 
    }

    public class QueryParameterMap    {
        [JsonPropertyName("ingress")]
        public List<string> Ingress { get; set; } 

        [JsonPropertyName("visitId")]
        public List<string> VisitId { get; set; } 

        [JsonPropertyName("slashargs")]
        public List<string> Slashargs { get; set; } 

        [JsonPropertyName("pageId")]
        public List<string> PageId { get; set; } 
    }

    public class WeblabMap    {
        [JsonPropertyName("STORES_290280")]
        public string STORES290280 { get; set; } 

        [JsonPropertyName("BOND_STORES_229337")]
        public string BONDSTORES229337 { get; set; } 

        [JsonPropertyName("BOND_MASTER_189895")]
        public string BONDMASTER189895 { get; set; } 

        [JsonPropertyName("STORES_182381")]
        public string STORES182381 { get; set; } 

        [JsonPropertyName("STORES_PPU_277122")]
        public string STORESPPU277122 { get; set; } 

        [JsonPropertyName("STORES_282155")]
        public string STORES282155 { get; set; } 

        [JsonPropertyName("STORES_244674")]
        public string STORES244674 { get; set; } 

        [JsonPropertyName("STORES_281049")]
        public string STORES281049 { get; set; } 

        [JsonPropertyName("BOND_STORES_APPNAV_URL_217885")]
        public string BONDSTORESAPPNAVURL217885 { get; set; } 

        [JsonPropertyName("STORES_215529")]
        public string STORES215529 { get; set; } 

        [JsonPropertyName("STORES_AAPI_254262")]
        public string STORESAAPI254262 { get; set; } 

        [JsonPropertyName("STORES_239063")]
        public string STORES239063 { get; set; } 
    }

    public class AppendedParameters    {
        [JsonPropertyName("ingress")]
        public string Ingress { get; set; } 

        [JsonPropertyName("visitId")]
        public string VisitId { get; set; } 
    }

    public class RequestContext    {
        [JsonPropertyName("obfuscatedMarketplaceId")]
        public string ObfuscatedMarketplaceId { get; set; } 

        [JsonPropertyName("obfuscatedMerchantId")]
        public string ObfuscatedMerchantId { get; set; } 

        [JsonPropertyName("language")]
        public string Language { get; set; } 

        [JsonPropertyName("sessionId")]
        public string SessionId { get; set; } 

        [JsonPropertyName("customerId")]
        public string CustomerId { get; set; } 

        [JsonPropertyName("customerIP")]
        public string CustomerIP { get; set; } 

        [JsonPropertyName("currency")]
        public string Currency { get; set; } 

        [JsonPropertyName("queryParameterMap")]
        public QueryParameterMap QueryParameterMap { get; set; } 

        [JsonPropertyName("weblabMap")]
        public WeblabMap WeblabMap { get; set; } 

        [JsonPropertyName("appendedParameters")]
        public AppendedParameters AppendedParameters { get; set; } 

        [JsonPropertyName("deviceType")]
        public string DeviceType { get; set; } 

        [JsonPropertyName("ubId")]
        public string UbId { get; set; } 

        [JsonPropertyName("slateToken")]
        public string SlateToken { get; set; } 

        [JsonPropertyName("debug")]
        public bool Debug { get; set; } 

        [JsonPropertyName("internal")]
        public bool Internal { get; set; } 

        [JsonPropertyName("profile")]
        public bool Profile { get; set; } 

        [JsonPropertyName("inBlacklist")]
        public bool InBlacklist { get; set; } 
    }

    public class Payload    {
        [JsonPropertyName("device")]
        public string Device { get; set; } 

        [JsonPropertyName("version")]
        public string Version { get; set; } 

        [JsonPropertyName("caller")]
        public string Caller { get; set; } 

        [JsonPropertyName("cssJsMode")]
        public string CssJsMode { get; set; } 

        [JsonPropertyName("debug")]
        public bool Debug { get; set; } 

        [JsonPropertyName("endpoint")]
        public string Endpoint { get; set; } 

        [JsonPropertyName("resources")]
        public Resources Resources { get; set; } 

        [JsonPropertyName("translations")]
        public Translations Translations { get; set; } 

        [JsonPropertyName("asset_dependencies")]
        public List<string> AssetDependencies { get; set; } 

        [JsonPropertyName("top_level")]
        public string TopLevel { get; set; } 

        [JsonPropertyName("componentType")]
        public string ComponentType { get; set; } 

        [JsonPropertyName("widgetId")]
        public string WidgetId { get; set; } 

        [JsonPropertyName("sectionType")]
        public string SectionType { get; set; } 

        [JsonPropertyName("widgetType")]
        public string WidgetType { get; set; } 

        [JsonPropertyName("content")]
        public Content Content { get; set; } 

        [JsonPropertyName("pageContext")]
        public PageContext PageContext { get; set; } 

        [JsonPropertyName("requestContext")]
        public RequestContext RequestContext { get; set; } 
    }
}
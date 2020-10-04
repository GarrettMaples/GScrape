using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GScrape.Requests.OfficeDepot
{
    public class ItemInfoJson
    {
        [JsonProperty("errorMessages")]
        public object[] ErrorMessages { get; set; }

        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("csrfAttack")]
        public bool CsrfAttack { get; set; }

        [JsonProperty("versionInfo")]
        public VersionInfo VersionInfo { get; set; }

        [JsonProperty("skuPriceList")]
        public Dictionary<string, SkuPriceList> SkuPriceList { get; set; }
    }

    public class SkuPriceList
    {
        [JsonProperty("skuId")]
        public string SkuId { get; set; }

        [JsonProperty("shortDescription")]
        public string ShortDescription { get; set; }

        [JsonProperty("skuUrl")]
        public string SkuUrl { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("smallImageUrl")]
        public string SmallImageUrl { get; set; }

        [JsonProperty("mediumImageUrl")]
        public string MediumImageUrl { get; set; }

        [JsonProperty("uom")]
        public string Uom { get; set; }

        [JsonProperty("rating")]
        public string Rating { get; set; }

        [JsonProperty("reviewCount")]
        public long ReviewCount { get; set; }

        [JsonProperty("retailPrice")]
        public string RetailPrice { get; set; }

        [JsonProperty("sellPrice")]
        public string SellPrice { get; set; }

        [JsonProperty("mapFlag")]
        public bool MapFlag { get; set; }

        [JsonProperty("smallBusinessSku")]
        public bool SmallBusinessSku { get; set; }

        [JsonProperty("availableQty")]
        public long AvailableQty { get; set; }

        [JsonProperty("backOrderable")]
        public bool BackOrderable { get; set; }

        [JsonProperty("clearanceSku")]
        public bool ClearanceSku { get; set; }

        [JsonProperty("globalPrice")]
        public GlobalPrice GlobalPrice { get; set; }

        [JsonProperty("restricted")]
        public bool Restricted { get; set; }

        [JsonProperty("showRestricted")]
        public bool ShowRestricted { get; set; }

        [JsonProperty("bulkPrices")]
        public BulkPrice[] BulkPrices { get; set; }

        [JsonProperty("privateBrandItem")]
        public bool PrivateBrandItem { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("categoryId")]
        public string CategoryId { get; set; }

        [JsonProperty("inkColorIcon")]
        public string InkColorIcon { get; set; }
    }

    public class BulkPrice
    {
        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("priceWithTax")]
        public long PriceWithTax { get; set; }

        [JsonProperty("range")]
        public string Range { get; set; }

        [JsonProperty("minQty")]
        public long MinQty { get; set; }
    }

    public class GlobalPrice
    {
        [JsonProperty("currencySymbol")]
        public string CurrencySymbol { get; set; }

        [JsonProperty("savingsFormat")]
        public string SavingsFormat { get; set; }

        [JsonProperty("sellPrice")]
        public double SellPrice { get; set; }

        [JsonProperty("sellPriceAmount")]
        public SellPriceAmount SellPriceAmount { get; set; }

        [JsonProperty("teaserPriceAmount")]
        public SellPriceAmount TeaserPriceAmount { get; set; }

        [JsonProperty("sellPriceAmountWithRebates")]
        public SellPriceAmount SellPriceAmountWithRebates { get; set; }

        [JsonProperty("priceAfterRebates")]
        public long PriceAfterRebates { get; set; }

        [JsonProperty("skuQuantityLimits")]
        public long SkuQuantityLimits { get; set; }

        [JsonProperty("uom")]
        public string Uom { get; set; }

        [JsonProperty("envFee")]
        public long EnvFee { get; set; }

        [JsonProperty("mapPriceApplicable")]
        public bool MapPriceApplicable { get; set; }

        [JsonProperty("mapPrice")]
        public long MapPrice { get; set; }

        [JsonProperty("showMapPrice")]
        public bool ShowMapPrice { get; set; }

        [JsonProperty("rebateData")]
        public RebateData RebateData { get; set; }

        [JsonProperty("mapPriceSaving")]
        public long MapPriceSaving { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("formattedTotalRebatesAmt")]
        public long FormattedTotalRebatesAmt { get; set; }

        [JsonProperty("formattedTotalRebatesAmtAsInt")]
        public long FormattedTotalRebatesAmtAsInt { get; set; }

        [JsonProperty("totalRebatesAmt")]
        public long TotalRebatesAmt { get; set; }

        [JsonProperty("totalRebatesPercent")]
        public string TotalRebatesPercent { get; set; }

        [JsonProperty("totalRebatesForSavingsType")]
        public string TotalRebatesForSavingsType { get; set; }

        [JsonProperty("regPrice")]
        public long RegPrice { get; set; }

        [JsonProperty("amtOfAllMailInRebates")]
        public long AmtOfAllMailInRebates { get; set; }

        [JsonProperty("amtOfAllInstantRebates")]
        public long AmtOfAllInstantRebates { get; set; }

        [JsonProperty("firstEndDate")]
        public object FirstEndDate { get; set; }

        [JsonProperty("formattedFirstEndDate")]
        public string FormattedFirstEndDate { get; set; }

        [JsonProperty("clearanceSku")]
        public bool ClearanceSku { get; set; }

        [JsonProperty("numOfRebates")]
        public long NumOfRebates { get; set; }

        [JsonProperty("rebates")]
        public object[] Rebates { get; set; }

        [JsonProperty("numOfMailInRebates")]
        public long NumOfMailInRebates { get; set; }

        [JsonProperty("amtOfAllInstantRebate")]
        public long AmtOfAllInstantRebate { get; set; }

        [JsonProperty("numOfInstantRebates")]
        public long NumOfInstantRebates { get; set; }

        [JsonProperty("jspText")]
        public string JspText { get; set; }

        [JsonProperty("retailPrice")]
        public double RetailPrice { get; set; }

        [JsonProperty("numOfClearanceRebates")]
        public long NumOfClearanceRebates { get; set; }

        [JsonProperty("amtOfAllClearanceRebates")]
        public long AmtOfAllClearanceRebates { get; set; }

        [JsonProperty("nestedPriceBadgesDetails")]
        public object[] NestedPriceBadgesDetails { get; set; }

        [JsonProperty("pricingIncentive")]
        public bool PricingIncentive { get; set; }

        [JsonProperty("teaserPrice")]
        public long TeaserPrice { get; set; }

        [JsonProperty("teaserPriceAfterRebates")]
        public long TeaserPriceAfterRebates { get; set; }

        [JsonProperty("rewardMemberSku")]
        public bool RewardMemberSku { get; set; }

        [JsonProperty("wlrIncentive")]
        public bool WlrIncentive { get; set; }

        [JsonProperty("incentivePercent")]
        public string IncentivePercent { get; set; }

        [JsonProperty("alwaysFreeDelivery")]
        public bool AlwaysFreeDelivery { get; set; }

        [JsonProperty("incentiveEndStrDate")]
        public string IncentiveEndStrDate { get; set; }

        [JsonProperty("wlrPercent")]
        public string WlrPercent { get; set; }

        [JsonProperty("restrictedItem")]
        public bool RestrictedItem { get; set; }

        [JsonProperty("subscriptionHasFreeDelivery")]
        public bool SubscriptionHasFreeDelivery { get; set; }

        [JsonProperty("subscribable")]
        public bool Subscribable { get; set; }

        [JsonProperty("alwaysFreeIncentive")]
        public bool AlwaysFreeIncentive { get; set; }

        [JsonProperty("incentivePrice")]
        public long IncentivePrice { get; set; }

        [JsonProperty("showTeaserPrice")]
        public bool ShowTeaserPrice { get; set; }

        [JsonProperty("showRetailPrice")]
        public bool ShowRetailPrice { get; set; }

        [JsonProperty("showNonLoyaltyPrice")]
        public bool ShowNonLoyaltyPrice { get; set; }

        [JsonProperty("nonLoyaltyPrice")]
        public long NonLoyaltyPrice { get; set; }

        [JsonProperty("nonLoyaltyPriceAfterRebates")]
        public long NonLoyaltyPriceAfterRebates { get; set; }

        [JsonProperty("sellPricePriceMethod")]
        public string SellPricePriceMethod { get; set; }

        [JsonProperty("formattedNonLoyaltySavingsAmount")]
        public long FormattedNonLoyaltySavingsAmount { get; set; }

        [JsonProperty("nonLoyaltySavingsAmount")]
        public long NonLoyaltySavingsAmount { get; set; }

        [JsonProperty("formattedTeaserSavingsAmount")]
        public long FormattedTeaserSavingsAmount { get; set; }

        [JsonProperty("formattedTeaserSavingsAmountForIncentivePrice")]
        public long FormattedTeaserSavingsAmountForIncentivePrice { get; set; }

        [JsonProperty("teaserSavingsAmount")]
        public long TeaserSavingsAmount { get; set; }

        [JsonProperty("formattedSellPriceSavingsAmount")]
        public long FormattedSellPriceSavingsAmount { get; set; }

        [JsonProperty("sellPriceSavingsAmount")]
        public long SellPriceSavingsAmount { get; set; }

        [JsonProperty("formattedSellPriceSavingsAmountAfterRebates")]
        public long FormattedSellPriceSavingsAmountAfterRebates { get; set; }

        [JsonProperty("sellPriceSavingsAmountAfterRebates")]
        public long SellPriceSavingsAmountAfterRebates { get; set; }

        [JsonProperty("freeDeliveryEndStrDate")]
        public string FreeDeliveryEndStrDate { get; set; }

        [JsonProperty("incentivePriceAfterRebates")]
        public long IncentivePriceAfterRebates { get; set; }

        [JsonProperty("hasAnyIncentive")]
        public bool HasAnyIncentive { get; set; }

        [JsonProperty("formattedIncentivePriceSavingsAmount")]
        public long FormattedIncentivePriceSavingsAmount { get; set; }

        [JsonProperty("incentivePriceSavingsAmount")]
        public long IncentivePriceSavingsAmount { get; set; }

        [JsonProperty("teaserSavingsAmountForIncentivePrice")]
        public long TeaserSavingsAmountForIncentivePrice { get; set; }

        [JsonProperty("incentiveRetailPrice")]
        public long IncentiveRetailPrice { get; set; }

        [JsonProperty("billingFrequency")]
        public object BillingFrequency { get; set; }

        [JsonProperty("serviceSku")]
        public bool ServiceSku { get; set; }

        [JsonProperty("smallBusinessSku")]
        public bool SmallBusinessSku { get; set; }

        [JsonProperty("items")]
        public Items Items { get; set; }

        [JsonProperty("priceMapPopulated")]
        public bool PriceMapPopulated { get; set; }
    }

    public class Items
    {
    }

    public class RebateData
    {
        [JsonProperty("skuId")]
        public string SkuId { get; set; }

        [JsonProperty("rebate")]
        public bool Rebate { get; set; }

        [JsonProperty("showMailInSavings")]
        public bool ShowMailInSavings { get; set; }

        [JsonProperty("rebates")]
        public object[] Rebates { get; set; }

        [JsonProperty("instantRebates")]
        public object[] InstantRebates { get; set; }

        [JsonProperty("regPrice")]
        public long RegPrice { get; set; }

        [JsonProperty("priceAfterRebates")]
        public long PriceAfterRebates { get; set; }

        [JsonProperty("priceAfterInstantRebate")]
        public long PriceAfterInstantRebate { get; set; }

        [JsonProperty("totalRebatesAmt")]
        public long TotalRebatesAmt { get; set; }

        [JsonProperty("numOfRebates")]
        public long NumOfRebates { get; set; }

        [JsonProperty("jspText")]
        public string JspText { get; set; }

        [JsonProperty("numOfInstantRebates")]
        public long NumOfInstantRebates { get; set; }

        [JsonProperty("numOfMailInRebates")]
        public long NumOfMailInRebates { get; set; }

        [JsonProperty("numOfClearanceRebates")]
        public long NumOfClearanceRebates { get; set; }

        [JsonProperty("amtOfAllInstantRebates")]
        public long AmtOfAllInstantRebates { get; set; }

        [JsonProperty("amtOfAllMailInRebates")]
        public long AmtOfAllMailInRebates { get; set; }

        [JsonProperty("amtOfAllClearanceRebates")]
        public long AmtOfAllClearanceRebates { get; set; }

        [JsonProperty("firstEndDate")]
        public object FirstEndDate { get; set; }

        [JsonProperty("bothRebates")]
        public bool BothRebates { get; set; }

        [JsonProperty("nonLoyaltyPriceAfterRebates")]
        public long NonLoyaltyPriceAfterRebates { get; set; }

        [JsonProperty("teaserPriceAfterRebates")]
        public long TeaserPriceAfterRebates { get; set; }

        [JsonProperty("formattedRegPrice")]
        public string FormattedRegPrice { get; set; }

        [JsonProperty("clearanceRebatePercent")]
        public long ClearanceRebatePercent { get; set; }

        [JsonProperty("instantRebatePercent")]
        public long InstantRebatePercent { get; set; }

        [JsonProperty("mailInRebatePercent")]
        public long MailInRebatePercent { get; set; }

        [JsonProperty("priceAfterRebatesIntegerPart")]
        public string PriceAfterRebatesIntegerPart { get; set; }

        [JsonProperty("priceAfterRebatesDecimalPart")]
        public string PriceAfterRebatesDecimalPart { get; set; }

        [JsonProperty("firstMailInRebate")]
        public object FirstMailInRebate { get; set; }

        [JsonProperty("mailInRebateAmount")]
        public bool MailInRebateAmount { get; set; }
    }

    public class SellPriceAmount
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("valid")]
        public bool Valid { get; set; }

        [JsonProperty("dollars")]
        public string Dollars { get; set; }

        [JsonProperty("cents")]
        public string Cents { get; set; }

        [JsonProperty("lessThanDollar")]
        public bool LessThanDollar { get; set; }

        [JsonProperty("validNonZero")]
        public bool ValidNonZero { get; set; }
    }

    public class VersionInfo
    {
        [JsonProperty("latestVersion")]
        public string LatestVersion { get; set; }

        [JsonProperty("lastSupportedVer")]
        public string LastSupportedVer { get; set; }

        [JsonProperty("versionWarn")]
        public string VersionWarn { get; set; }

        [JsonProperty("mustUpgrade")]
        public bool MustUpgrade { get; set; }

        [JsonProperty("appStoreUrl")]
        public string AppStoreUrl { get; set; }
    }
}
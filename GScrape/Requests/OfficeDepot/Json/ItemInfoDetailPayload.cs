using System;
using System.Text.Json.Serialization;

namespace GScrape.Requests.OfficeDepot.Json
{
    public class ItemInfoDetailPayload
    {
        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }

        [JsonPropertyName("page")]
        public Page Page { get; set; }

        [JsonPropertyName("product")]
        public Product Product { get; set; }

        [JsonPropertyName("cart")]
        public Cart Cart { get; set; }

        [JsonPropertyName("order")]
        public Order Order { get; set; }
    }

    public class Cart
    {
        [JsonPropertyName("products")]
        public object[] Products { get; set; }

        [JsonPropertyName("subtotal")]
        public string Subtotal { get; set; }

        [JsonPropertyName("total_quantity")]
        public string TotalQuantity { get; set; }

        [JsonPropertyName("products_pipe_delimited")]
        public ProductsPipeDelimited ProductsPipeDelimited { get; set; }
    }

    public class ProductsPipeDelimited
    {
        [JsonPropertyName("skus")]
        public string Skus { get; set; }

        [JsonPropertyName("names")]
        public string Names { get; set; }

        [JsonPropertyName("quantities")]
        public string Quantities { get; set; }

        [JsonPropertyName("is_subscription_eligible")]
        public object IsSubscriptionEligible { get; set; }

        [JsonPropertyName("is_subscription_selected")]
        public object IsSubscriptionSelected { get; set; }
    }

    public class Order
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("subtotal")]
        public string Subtotal { get; set; }

        [JsonPropertyName("total")]
        public string Total { get; set; }

        [JsonPropertyName("discount")]
        public string Discount { get; set; }

        [JsonPropertyName("shipping")]
        public string Shipping { get; set; }

        [JsonPropertyName("tax")]
        public string Tax { get; set; }

        [JsonPropertyName("transactions")]
        public object[] Transactions { get; set; }

        [JsonPropertyName("payment_cc_bin")]
        public string PaymentCcBin { get; set; }

        [JsonPropertyName("plcc_card")]
        public bool PlccCard { get; set; }
    }

    public class Page
    {
        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("category_id")]
        public string CategoryId { get; set; }

        [JsonPropertyName("sub_category")]
        public string SubCategory { get; set; }

        [JsonPropertyName("sub_sub_category")]
        public string SubSubCategory { get; set; }

        [JsonPropertyName("page_name")]
        public string PageName { get; set; }

        [JsonPropertyName("page_url")]
        public Uri PageUrl { get; set; }

        [JsonPropertyName("site_type")]
        public string SiteType { get; set; }

        [JsonPropertyName("onsite_search_term")]
        public string OnsiteSearchTerm { get; set; }

        [JsonPropertyName("promo_id")]
        public string PromoId { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("quantity")]
        public object Quantity { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("department")]
        public string Department { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("category_id")]
        public string CategoryId { get; set; }

        [JsonPropertyName("sub_category")]
        public string SubCategory { get; set; }

        [JsonPropertyName("sub_sub_category")]
        public string SubSubCategory { get; set; }

        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("available_qty")]
        public int AvailableQty { get; set; }

        [JsonPropertyName("is_out_of_stock")]
        public bool IsOutOfStock { get; set; }

        [JsonPropertyName("procurement")]
        public string Procurement { get; set; }

        [JsonPropertyName("is_replenished")]
        public bool IsReplenished { get; set; }

        [JsonPropertyName("location_id")]
        public string LocationId { get; set; }

        [JsonPropertyName("is_from_alt_src")]
        public bool IsFromAltSrc { get; set; }

        [JsonPropertyName("is_subscription_eligible")]
        public bool IsSubscriptionEligible { get; set; }

        [JsonPropertyName("is_subscription_selected")]
        public object IsSubscriptionSelected { get; set; }

        [JsonPropertyName("clearance_price")]
        public string ClearancePrice { get; set; }

        [JsonPropertyName("crossed_out_price")]
        public string CrossedOutPrice { get; set; }

        [JsonPropertyName("instant_savings_price")]
        public string InstantSavingsPrice { get; set; }

        [JsonPropertyName("unit_price")]
        public string UnitPrice { get; set; }

        [JsonPropertyName("is_business_select_price")]
        public bool IsBusinessSelectPrice { get; set; }

        [JsonPropertyName("is_marketplace_item")]
        public bool IsMarketplaceItem { get; set; }

        [JsonPropertyName("instore_pickup")]
        public object InstorePickup { get; set; }

        [JsonPropertyName("marketplace_seller_name")]
        public string MarketplaceSellerName { get; set; }

        [JsonPropertyName("is_warehouse")]
        public bool IsWarehouse { get; set; }

        [JsonPropertyName("is_virtual_warehouse")]
        public bool IsVirtualWarehouse { get; set; }

        [JsonPropertyName("fulfillment")]
        public string Fulfillment { get; set; }

        [JsonPropertyName("coupons")]
        public object Coupons { get; set; }

        [JsonPropertyName("discount")]
        public object Discount { get; set; }

        [JsonPropertyName("isImprint")]
        public bool IsImprint { get; set; }
    }

    public class User
    {
        [JsonPropertyName("session")]
        public Session Session { get; set; }

        [JsonPropertyName("account_store_pickup_enabled")]
        public object AccountStorePickupEnabled { get; set; }

        [JsonPropertyName("allow_alt_srcs")]
        public object AllowAltSrcs { get; set; }

        [JsonPropertyName("allow_banners")]
        public string AllowBanners { get; set; }

        [JsonPropertyName("customer_service_rep_id")]
        public string CustomerServiceRepId { get; set; }

        [JsonPropertyName("sales_rep_id")]
        public string SalesRepId { get; set; }

        [JsonPropertyName("parent")]
        public string Parent { get; set; }

        [JsonPropertyName("grand_parent")]
        public string GrandParent { get; set; }

        [JsonPropertyName("has_legal_agreement")]
        public string HasLegalAgreement { get; set; }

        [JsonPropertyName("third_party_customer_js_enabled")]
        public bool ThirdPartyCustomerJsEnabled { get; set; }

        [JsonPropertyName("billAddr")]
        public Addr BillAddr { get; set; }

        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("is_business_select_expired")]
        public bool IsBusinessSelectExpired { get; set; }

        [JsonPropertyName("has_business_select_payment")]
        public bool HasBusinessSelectPayment { get; set; }

        [JsonPropertyName("shipAddr")]
        public Addr ShipAddr { get; set; }

        [JsonPropertyName("segment")]
        public string Segment { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("email_md5")]
        public string EmailMd5 { get; set; }

        [JsonPropertyName("email_sha256")]
        public string EmailSha256 { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("promo_customer_type")]
        public string PromoCustomerType { get; set; }

        [JsonPropertyName("is_employee")]
        public bool IsEmployee { get; set; }

        [JsonPropertyName("contact_id")]
        public string ContactId { get; set; }

        [JsonPropertyName("loyalty")]
        public Loyalty Loyalty { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("user_id_md5")]
        public string UserIdMd5 { get; set; }

        [JsonPropertyName("user_id_sha256")]
        public string UserIdSha256 { get; set; }

        [JsonPropertyName("business_unit")]
        public string BusinessUnit { get; set; }

        [JsonPropertyName("browsing_zip")]
        public string BrowsingZip { get; set; }

        [JsonPropertyName("sic")]
        public string Sic { get; set; }

        [JsonPropertyName("store_id")]
        public string StoreId { get; set; }

        [JsonPropertyName("store_zip")]
        public string StoreZip { get; set; }

        [JsonPropertyName("store_address")]
        public string StoreAddress { get; set; }

        [JsonPropertyName("segment_code")]
        public string SegmentCode { get; set; }

        [JsonPropertyName("allow_coupons")]
        public bool AllowCoupons { get; set; }

        [JsonPropertyName("business_select_status")]
        public string BusinessSelectStatus { get; set; }
    }

    public class Addr
    {
        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("zip")]
        public string Zip { get; set; }
    }

    public class Loyalty
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("is_member")]
        public bool IsMember { get; set; }

        [JsonPropertyName("is_national_customer")]
        public bool IsNationalCustomer { get; set; }

        [JsonPropertyName("has_rewards_certificate")]
        public bool HasRewardsCertificate { get; set; }

        [JsonPropertyName("tier_type")]
        public string TierType { get; set; }

        [JsonPropertyName("tier_type_pricing_code")]
        public string TierTypePricingCode { get; set; }

        [JsonPropertyName("pricing_code")]
        public string PricingCode { get; set; }
    }

    public class Session
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
    }
}
using Newtonsoft.Json;
using System;

namespace Animations.DataModels
{
    public class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public decimal Price { get; set; }
        [JsonProperty("imageurl")]
        public string ImageUrl { get; set; }
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
        //[JsonProperty("category")]
        public long CustomerId { get; set; }
        //[JsonProperty("customer")]
        public long CategoryId { get; set; }
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
    }

}

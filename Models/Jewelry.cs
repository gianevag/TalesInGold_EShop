using System;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace TalesInGold_EShop.Models
{
    public class Jewelry
    {
        [BsonId]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();
        public string Title { get; set; }
        public float Price { get; set; }
        public string first_thumb_photo { get; set; }
        public string second_thumb_photo { get; set; }
        public string yellowPhoto { get; set; }
        public string whitePhoto { get; set; }
        public string rosePhoto { get; set; }
        public string etsyUrl { get; set; }
        public string amazonUrl { get; set; }
        public string amazonUKUrl { get; set; }
        public string dawandaUrl { get; set; }
        public int  isFirstPage { get; set; }
        public int orderInFirstPage { get; set; }
        public int isNecklace { get; set; }
        public string typeOfNecklace { get; set; }
        public int isRing { get; set; }
        public string typeOfRing { get; set; }
        public int isBracelet { get; set; }
        public string typeOfBracelet { get; set; }
        public int isEarring { get; set; }
        public string typeOfEarring { get; set; }
        public int isPersonalized { get; set; }
        public string typeOfPersonalized { get; set; }
        public int isBirthstone { get; set; }
        public string typeOfBirthstone { get; set; }
        public int isDiamond { get; set; } 
        public string typeOfDiamond { get; set; }
        public int orderInCatalog_lv1 { get; set; }
        public int orderInCatalog_lv2 { get; set; }
        public int orderInCatalog_lv3 { get; set; }
        public string quickReview { get; set; }
        public string moreInfo { get; set; }
        public DateTime dateCreated { get; set; } = DateTime.Now;
        public string JewelryId { get; set; }
    }
}


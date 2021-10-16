using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HackerspaceApp.Models.SpaceApi012
{
    /// <summary>
    /// SpaceAPI 0.12
    /// </summary>
    public partial class SpaceApi012Model
    {
        /// <summary>
        /// The postal address of your space (street, block, housenumber, zip code, city, whatever
        /// you usually need in your country, and the country itself)
        /// </summary>
        [JsonProperty("address", NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }

        /// <summary>
        /// The version of SpaceAPI your endpoint uses
        /// </summary>
        [JsonProperty("api")]
        public string Api { get; set; }

        /// <summary>
        /// URL(s) of webcams in your space
        /// </summary>
        [JsonProperty("cam", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Cam { get; set; }

        /// <summary>
        /// Contact information about your space
        /// </summary>
        [JsonProperty("contact", NullValueHandling = NullValueHandling.Ignore)]
        public Contact Contact { get; set; }

        /// <summary>
        /// Events which happened recently in your space and which could be interesting to the
        /// public, like 'User X has entered/triggered/did something at timestamp Z'
        /// </summary>
        [JsonProperty("events", NullValueHandling = NullValueHandling.Ignore)]
        public Event[] Events { get; set; }

        /// <summary>
        /// Feeds where users can get updates of your space
        /// </summary>
        [JsonProperty("feeds", NullValueHandling = NullValueHandling.Ignore)]
        public Feed[] Feeds { get; set; }

        /// <summary>
        /// Icons that show the status graphically
        /// </summary>
        [JsonProperty("icon")]
        public Icon Icon { get; set; }

        /// <summary>
        /// The Unix timestamp when the space status changed most recently
        /// </summary>
        [JsonProperty("lastchange", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lastchange { get; set; }

        /// <summary>
        /// Latitude of your space location, in degree with decimal places. Use positive values for
        /// locations north of the equator, negative values for locations south of equator.
        /// </summary>
        [JsonProperty("lat", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lat { get; set; }

        /// <summary>
        /// The space logo
        /// </summary>
        [JsonProperty("logo")]
        public string Logo { get; set; }

        /// <summary>
        /// Longitude of your space location, in degree with decimal places. Use positive values for
        /// locations west of Greenwich, and negative values for locations east of Greenwich.
        /// </summary>
        [JsonProperty("lon", NullValueHandling = NullValueHandling.Ignore)]
        public double? Lon { get; set; }

        /// <summary>
        /// A boolean which indicates if the space is currently open
        /// </summary>
        [JsonProperty("open")]
        public bool Open { get; set; }

        /// <summary>
        /// Data of various sensors in your space (e.g. temperature, humidity, amount of Club-Mate
        /// left, …). The only canonical property is the <em>temp</em> property, additional sensor
        /// types may be defined by you. In this case, you are requested to share your definition for
        /// inclusion in this specification.
        /// </summary>
        [JsonProperty("sensors", NullValueHandling = NullValueHandling.Ignore)]
        public Sensor[] Sensors { get; set; }

        /// <summary>
        /// The name of your space
        /// </summary>
        [JsonProperty("space")]
        public string Space { get; set; }

        /// <summary>
        /// An additional free-form string, could be something like <samp>'open for public'</samp>,
        /// <samp>'members only'</samp> or whatever you want it to be
        /// </summary>
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        /// <summary>
        /// A mapping of stream types to stream URLs. Example:
        /// <samp>{'mp4':'http//example.org/stream.mpg',
        /// 'mjpeg':'http://example.org/stream.mjpeg'}</samp>
        /// </summary>
        [JsonProperty("stream", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Stream { get; set; }

        /// <summary>
        /// The main website
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// Contact information about your space
    /// </summary>
    public partial class Contact
    {
        /// <summary>
        /// E-mail address for contacting your space
        /// </summary>
        [JsonProperty("email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        /// <summary>
        /// URL of the IRC channel, in the form <samp>irc://example.org/#channelname</samp>
        /// </summary>
        [JsonProperty("irc", NullValueHandling = NullValueHandling.Ignore)]
        public string Irc { get; set; }

        /// <summary>
        /// A public Jabber/XMPP multi-user chatroom in the form
        /// <samp>chatroom@conference.example.net</samp>
        /// </summary>
        [JsonProperty("jabber", NullValueHandling = NullValueHandling.Ignore)]
        public string Jabber { get; set; }

        /// <summary>
        /// Phone numbers of people who carry a key and are able to open the space upon request.
        /// Example: <samp>['+1 800 555 4567','+1 800 555 4544']</samp>
        /// </summary>
        [JsonProperty("keymaster", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Keymaster { get; set; }

        /// <summary>
        /// The e-mail address of your mailing list. If you use Google Groups then the e-mail looks
        /// like <samp>your-group@googlegroups.com</samp>.
        /// </summary>
        [JsonProperty("ml", NullValueHandling = NullValueHandling.Ignore)]
        public string Ml { get; set; }

        /// <summary>
        /// Phone number, including country code with a leading plus sign. Example: <samp>+1 800 555
        /// 4567</samp>
        /// </summary>
        [JsonProperty("phone", NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        /// <summary>
        /// URI for Voice-over-IP via SIP. Example: <samp>sip:yourspace@sip.example.org</samp>
        /// </summary>
        [JsonProperty("sip", NullValueHandling = NullValueHandling.Ignore)]
        public string Sip { get; set; }

        /// <summary>
        /// Twitter handle, with leading @
        /// </summary>
        [JsonProperty("twitter", NullValueHandling = NullValueHandling.Ignore)]
        public string Twitter { get; set; }
    }

    public partial class Event
    {
        /// <summary>
        /// A custom text field to give more information about the event
        /// </summary>
        [JsonProperty("extra", NullValueHandling = NullValueHandling.Ignore)]
        public string Extra { get; set; }

        /// <summary>
        /// Name or other identity of the subject (e.g. <samp>J. Random Hacker</samp>,
        /// <samp>fridge</samp>, <samp>3D printer</samp>, …)
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Unix timestamp when the event occurred
        /// </summary>
        [JsonProperty("t")]
        public double? T { get; set; }

        /// <summary>
        /// Action (e.g. <samp>check-in</samp>, <samp>check-out</samp>, <samp>finish-print</samp>,
        /// …). Define your own actions and use them consistently, canonical actions are not (yet)
        /// specified
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Feed
    {
        /// <summary>
        /// A mnemonic identifier, like <samp>wiki</samp>, <samp>blog</samp>, etc.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of the feed, for example <samp>rss</samp>, <samp>atom</atom>, <samp>ical</samp>
        /// </summary>
        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Feed URL
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }

    /// <summary>
    /// Icons that show the status graphically
    /// </summary>
    public partial class Icon
    {
        /// <summary>
        /// The URL to your customized space logo showing a closed space
        /// </summary>
        [JsonProperty("closed")]
        public string Closed { get; set; }

        /// <summary>
        /// The URL to your customized space logo showing an open space
        /// </summary>
        [JsonProperty("open")]
        public string Open { get; set; }
    }

    public partial class Sensor
    {
        /// <summary>
        /// A mapping of measuring locations to temperature values. The values should match the basic
        /// regular expression <code>^[+-]?[0-9]+(\.[0-9]+)?[FCK]$</code>. Example:
        /// <samp>{'kitchen':'48F', 'storage':'-273.1K'}</samp>
        /// </summary>
        [JsonProperty("temp", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, object> Temp { get; set; }
    }

    /// <summary>
    /// The version of SpaceAPI your endpoint uses
    /// </summary>
    public enum Api { The012 };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                ApiConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ApiConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Api) || t == typeof(Api?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "0.12")
            {
                return Api.The012;
            }
            throw new Exception("Cannot unmarshal type Api");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Api)untypedValue;
            if (value == Api.The012)
            {
                serializer.Serialize(writer, "0.12");
                return;
            }
            throw new Exception("Cannot marshal type Api");
        }

        public static readonly ApiConverter Singleton = new ApiConverter();
    }
}
